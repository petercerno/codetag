// 
// CustomApplicationContext.cs
//  
// Author:
//       Peter Cerno <petercerno@gmail.com>
// 
// Copyright (c) 2013 Peter Cerno
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CodeTag.Common;
using CodeTag.Core;
using CodeTag.Core.CodeSnippetSources;
using CodeTag.Core.TagPreprocessors;
using CodeTag.Data;

/*
 * Code adapted from "Creating Tray Applications in .NET: A Practical Guide", Michael Sorens, 
 * https://www.simple-talk.com/dotnet/.net-framework/creating-tray-applications-in-.net-a-practical-guide/
 */

namespace CodeTag
{
    /// <summary>
    /// Framework for running application as a tray app.
    /// </summary>
    /// <remarks>
    /// Tray app code adapted from "Creating Applications with NotifyIcon in Windows Forms", Jessica Fosler,
    /// http://windowsclient.net/articles/notifyiconapplications.aspx
    /// </remarks>
    class CustomApplicationContext : ApplicationContext
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private const int WmHotkey = 0x312;

        // ReSharper disable UnusedMember.Local
        enum KeyModifier
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            WinKey = 8
        }
        // ReSharper restore UnusedMember.Local

        /// <summary>
        /// A low-level encapsulation of a window handle and a window procedure based on:
        /// http://stackoverflow.com/questions/15434505/key-capture-using-global-hotkey-in-c-sharp
        /// </summary>
        public sealed class HotkeyManager : NativeWindow, IDisposable
        {
            /// <summary>
            /// Creates a hotkey manager and captures the application context.
            /// </summary>
            /// <param name="applicationContext">Application context.</param>
            public HotkeyManager(CustomApplicationContext applicationContext)
            {
                _applicationContext = applicationContext;
                CreateHandle(new CreateParams());
            }

            private readonly CustomApplicationContext _applicationContext;

            protected override void WndProc(ref Message m)
            {
                if (m.Msg == WmHotkey)
                {
                    // Handle hotkey message
                    _applicationContext.ShowCodeTagForm();
                }
                base.WndProc(ref m);
            }

            public void Dispose()
            {
                DestroyHandle();
            }
        }

        private readonly HotkeyManager _hotKeyManager;
        private const int HotKeyId = 0;

        // Icon graphic from http://fortawesome.github.io/Font-Awesome/
        private const string IconFileName = "Icons/icon_tags_16x16.ico";
        private const string DefaultTooltip = "CodeTag via context menu";

        /// <summary>
        /// This class should be created and passed into Application.Run( ... )
        /// </summary>
        public CustomApplicationContext()
        {
            try
            {
                InitializeContext();
                InitializeCodeSnippetSource();

                // Register Alt + A as global hotkey. 
                _hotKeyManager = new HotkeyManager(this);
                RegisterHotKey(_hotKeyManager.Handle, HotKeyId, (int) KeyModifier.Alt, Keys.A.GetHashCode());
            }
            catch (Exception exception)
            {
                ErrorReport.Report(exception);
                throw;
            }
        }

        private System.ComponentModel.IContainer components; // A list of components to dispose when the context is disposed
        private NotifyIcon _notifyIcon;				         // The icon that sits in the system tray
        private CompositeCodeSnippetSource _codeSnippetSource;

        private void InitializeContext()
        {
            try
            {
                components = new System.ComponentModel.Container();
                _notifyIcon = new NotifyIcon(components)
                {
                    ContextMenuStrip = new ContextMenuStrip(),
                    Icon = new Icon(IconFileName),
                    Text = DefaultTooltip,
                    Visible = true
                };
                _notifyIcon.ContextMenuStrip.Opening += ContextMenuStrip_Opening;
                _notifyIcon.DoubleClick += delegate { ShowCodeTagForm(); };
            }
            catch (Exception exception)
            {
                ErrorReport.Report(exception);
                throw;
            }
        }

        private void InitializeCodeSnippetSource()
        {
            try
            {
                var codeSnippetSourceList = new List<XmlCodeSnippetSource>();
                var codeSnippetSourceInvalidList = new List<string>();
                foreach (var checkedCodeSnippetSource in Configuration
                    .CheckedCodeSnippetSources
                    .Where(t => t.Item2)
                    .Select(t => t.Item1))
                    try
                    {
                        var xmlBlock = XmlHelper.DeserializeFromFile<XmlBlock>(checkedCodeSnippetSource);
                        codeSnippetSourceList.Add(new XmlCodeSnippetSource(xmlBlock));
                    }
                    catch
                    {
                        codeSnippetSourceInvalidList.Add(checkedCodeSnippetSource);
                    }

                if (codeSnippetSourceInvalidList.Count > 0)
                    ErrorReport.Report("The following files could not be deserialized: " + Environment.NewLine +
                                       string.Join(Environment.NewLine, codeSnippetSourceInvalidList));

                _codeSnippetSource = new CompositeCodeSnippetSource(codeSnippetSourceList);

                var tagPreprocessing = Configuration.TagPreprocessing;
                var tagPreprocessorList = new List<ITagPreprocessor>();
                if ((tagPreprocessing & Configuration.TagPreprocess.LowerCase) ==
                    Configuration.TagPreprocess.LowerCase)
                    tagPreprocessorList.Add(new LowerCaseTagPreprocessor());
                if ((tagPreprocessing & Configuration.TagPreprocess.RemoveSpecialChars) ==
                    Configuration.TagPreprocess.RemoveSpecialChars)
                    tagPreprocessorList.Add(new SpecialCharsTagPreprocessor());
                _codeSnippetSource.TagPreprocessor = new CompositeTagPreprocessor(tagPreprocessorList);

                var tagMatching = Configuration.TagMatching;
                switch (tagMatching)
                {
                    case Configuration.TagMatch.Exact:
                        _codeSnippetSource.TagMatcher = null;
                        break;
                    case Configuration.TagMatch.Prefix:
                        _codeSnippetSource.TagMatcher = (filterTag, tag) => tag.StartsWith(filterTag);
                        break;
                    case Configuration.TagMatch.Substring:
                        _codeSnippetSource.TagMatcher = (filterTag, tag) => tag.Contains(filterTag);
                        break;
                    default:
                        throw new InvalidProgramException();
                }
            }
            catch (Exception exception)
            {
                ErrorReport.Report(exception);
                _codeSnippetSource = null;
            }
        }

        private void ContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                e.Cancel = false;
                _notifyIcon.ContextMenuStrip.Items.Clear();
                var showCodeTagFormItem = new ToolStripMenuItem("&Show");
                showCodeTagFormItem.Click += delegate { ShowCodeTagForm(); };
                var showConfigureFormItem = new ToolStripMenuItem("&Configure");
                showConfigureFormItem.Click += delegate { ShowConfigureForm(); };
                var showEditorFormItem = new ToolStripMenuItem("&Editor");
                showEditorFormItem.Click += delegate { ShowEditorForm(); };
                var exitItem = new ToolStripMenuItem("E&xit");
                exitItem.Click += exitItem_Click;
                _notifyIcon.ContextMenuStrip.Items.Add(showCodeTagFormItem);
                _notifyIcon.ContextMenuStrip.Items.Add(showConfigureFormItem);
                _notifyIcon.ContextMenuStrip.Items.Add(showEditorFormItem);
                _notifyIcon.ContextMenuStrip.Items.Add(new ToolStripSeparator());
                _notifyIcon.ContextMenuStrip.Items.Add(exitItem);
            }
            catch (Exception exception)
            {
                ErrorReport.Report(exception);
                throw;
            }
        }

        private CodeTagForm _codeTagForm;
        private ConfigureForm _configureForm;
        private EditorForm _editorForm;

        /// <summary>
        /// Shows the main CodeTagForm.
        /// </summary>
        public void ShowCodeTagForm()
        {
            if (_codeTagForm == null)
            {
                _codeTagForm = new CodeTagForm(() => _codeSnippetSource);
                _codeTagForm.Closed += delegate { _codeTagForm = null; };
                _codeTagForm.Show();
                _codeTagForm.Activate();
            }
            else { _codeTagForm.Activate(); }
        }

        protected void ShowConfigureForm()
        {
            if (_configureForm == null)
            {
                _configureForm = new ConfigureForm();
                _configureForm.Closed += delegate
                    {
                        UpdateCodeTagForm(_configureForm.IsConfigurationUpdated);
                        if (_codeTagForm != null)
                            _codeTagForm.Activate();
                        _configureForm = null;
                    };
                _configureForm.Show();
                _configureForm.Activate();
            }
            else { _configureForm.Activate(); }
        }

        protected void ShowEditorForm()
        {
            if (_editorForm == null)
            {
                _editorForm = new EditorForm();
                _editorForm.SourceChanged += delegate { UpdateCodeTagForm(true); };
                _editorForm.Closed += delegate
                    {
                        UpdateCodeTagForm(true);
                        if (_codeTagForm != null)
                            _codeTagForm.Activate();
                        _editorForm = null;
                    };
                _editorForm.Show();
                _editorForm.Activate();
            }
            else { _editorForm.Activate(); }
        }

        private void UpdateCodeTagForm(bool rebuildCodeSnippetSource)
        {
            if (rebuildCodeSnippetSource)
                InitializeCodeSnippetSource();
            if (_codeTagForm != null)
                _codeTagForm.UpdateCodeSnippets();
        }

        /// <summary>
        /// When the application context is disposed, dispose things like the notify icon.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) { components.Dispose(); }
        }

        /// <summary>
        /// When the exit menu item is clicked, make a call to terminate the ApplicationContext.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitItem_Click(object sender, EventArgs e)
        {
            ExitThread();
        }

        /// <summary>
        /// If we are presently showing a form, clean it up.
        /// </summary>
        protected override void ExitThreadCore()
        {
            // Before we exit, let forms clean themselves up.
            if (_codeTagForm != null) { _codeTagForm.Close(); }
            if (_configureForm != null) { _configureForm.Close(); }
            if (_editorForm != null) { _editorForm.Close(); }

            // Unregister hotkey
            if (_hotKeyManager != null) { UnregisterHotKey(_hotKeyManager.Handle, HotKeyId); }

            // Should remove lingering tray icon
            if (_notifyIcon != null) { _notifyIcon.Visible = false; } 

            base.ExitThreadCore();
        }
    }
}
