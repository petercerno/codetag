// 
// CodeTagForm.cs
//  
// Author:
//   Peter Cerno <petercerno@gmail.com>
// 
// Copyright (c) 2014 Peter Cerno
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
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CodeTag.Core;

namespace CodeTag
{
    public partial class CodeTagForm : Form
    {
        public CodeTagForm()
        {
            InitializeComponent();
        }

        internal CodeTagForm(
            Func<CodeSnippetSourceBase> codeSnippetSourceDelegate,
            Action<string, string, string> editCodeSnippetDelegate)
            : this()
        {
            _codeSnippetSourceDelegate = codeSnippetSourceDelegate;
            _editCodeSnippetDelegate = editCodeSnippetDelegate;
        }

        private readonly Func<CodeSnippetSourceBase> _codeSnippetSourceDelegate;
        private readonly Action<string, string, string> _editCodeSnippetDelegate;
        private static readonly char[] SplitChars = {',', ';', ' ', '\t', '\r', '\n'};

        private List<CodeSnippet> _filteredCodeSnippets;
        private int _filteredCodeSnippetIndex;
        private int _filteredCodeSnippetCount;
        private string _lastFilteredCodeSnippetPath;

        /// <summary>
        /// Updates code snippets.
        /// </summary>
        public void UpdateCodeSnippets()
        {
            try
            {
                _filteredCodeSnippets = null;
                _filteredCodeSnippetIndex = 0;
                _filteredCodeSnippetCount = 0;
                if (_codeSnippetSourceDelegate == null) return;
                var codeSnippetSource = _codeSnippetSourceDelegate();
                if (codeSnippetSource != null)
                {
                    var tags = filterTextBox.Text.Split(SplitChars, StringSplitOptions.RemoveEmptyEntries);
                    _filteredCodeSnippets = codeSnippetSource.Search(new SortedSet<string>(tags)).ToList();
                    _filteredCodeSnippetCount = _filteredCodeSnippets.Count;
                }
            }
            catch (Exception exception)
            {
                ErrorReport.Report(exception);
                _filteredCodeSnippets = null;
                _filteredCodeSnippetIndex = 0;
                _filteredCodeSnippetCount = 0;
                _lastFilteredCodeSnippetPath = null;
            }
            UpdateCodeSnippetView();
        }

        private void UpdateCodeSnippetView()
        {
            SuspendLayout();
            if (_filteredCodeSnippets != null && _filteredCodeSnippetIndex < _filteredCodeSnippetCount)
            {
                try
                {
                    var filteredCodeSnippet = _filteredCodeSnippets[_filteredCodeSnippetIndex];
                    _lastFilteredCodeSnippetPath = filteredCodeSnippet.Path;
                    var filteredCodeSnippetPath = !string.IsNullOrWhiteSpace(filteredCodeSnippet.Path)
                        ? "[" + Path.GetFileName(filteredCodeSnippet.Path) + "]"
                        : string.Empty;
                    var contextList = filteredCodeSnippet.GetContextList();
                    codeRichTextBox.Text =
                        (string.Join(Environment.NewLine,
                            contextList.Where(c => !string.IsNullOrWhiteSpace(c.Prerequisites))
                                .Select(c => c.Prerequisites)) +
                         Environment.NewLine + Environment.NewLine + filteredCodeSnippet.Code).Trim();
                    tagsTextBox.Text = string.Join(" ", filteredCodeSnippet.AllTags);
                    authorsTextBox.Text = filteredCodeSnippet.Authors;
                    sourceTextBox.Text = filteredCodeSnippet.Source;
                    statusTextBox.Text = string.Format(
                        CultureInfo.InvariantCulture,
                        "{0} / {1} {2} {3}", _filteredCodeSnippetIndex + 1, _filteredCodeSnippetCount,
                        filteredCodeSnippetPath, string.Join(" / ", contextList.Select(c => c.Name)));
                }
                catch (Exception exception)
                {
                    ErrorReport.Report(exception);
                    codeRichTextBox.Text = string.Empty;
                    tagsTextBox.Text = string.Empty;
                    authorsTextBox.Text = string.Empty;
                    sourceTextBox.Text = string.Empty;
                    // ReSharper disable LocalizableElement
                    statusTextBox.Text = "Error";
                    // ReSharper restore LocalizableElement
                }
            }
            else
            {
                codeRichTextBox.Text = string.Empty;
                tagsTextBox.Text = string.Empty;
                authorsTextBox.Text = string.Empty;
                sourceTextBox.Text = string.Empty;
                // ReSharper disable LocalizableElement
                statusTextBox.Text = "No code snippets found";
                // ReSharper restore LocalizableElement
            }
            ResumeLayout();
        }

        private void EditCodeSnippet()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_lastFilteredCodeSnippetPath)) return;
                var code = string.Empty;
                var tags = filterTextBox.Text;
                if (_filteredCodeSnippets != null && _filteredCodeSnippetIndex < _filteredCodeSnippetCount)
                {
                    var filteredCodeSnippet = _filteredCodeSnippets[_filteredCodeSnippetIndex];
                    code = filteredCodeSnippet.Code;
                    tags = string.Join(" ", filteredCodeSnippet.AllTags);
                }
                _editCodeSnippetDelegate(_lastFilteredCodeSnippetPath, code, tags);
            }
            catch (Exception exception)
            {
                ErrorReport.Report(exception);
            }
        }

        private void CodeTagForm_Load(object sender, EventArgs e)
        {
            Top = 0;
            Left = 0;
            Width = Screen.PrimaryScreen.WorkingArea.Width;
            UpdateCodeSnippets();
        }

        private void filterTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateCodeSnippets();
        }

        private void filterTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Down:
                        if (_filteredCodeSnippetIndex == _filteredCodeSnippetCount - 1) break;
                        e.Handled = true;
                        ++_filteredCodeSnippetIndex;
                        UpdateCodeSnippetView();
                        break;
                    case Keys.Up:
                        if (_filteredCodeSnippetIndex == 0) break;
                        e.Handled = true;
                        --_filteredCodeSnippetIndex;
                        UpdateCodeSnippetView();
                        break;
                }
            }
            catch (Exception exception)
            {
                ErrorReport.Report(exception);
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter && filterTextBox.Focused)
            {
                try
                {
                    var targetUri = "http://www.google.com/";
                    if (!string.IsNullOrWhiteSpace(sourceTextBox.Text) &&
                        Uri.IsWellFormedUriString(Uri.EscapeUriString(sourceTextBox.Text.Trim()), UriKind.Absolute))
                        targetUri = Uri.EscapeUriString(sourceTextBox.Text.Trim());
                    else if (!string.IsNullOrWhiteSpace(filterTextBox.Text))
                        targetUri = "http://www.google.com/search?q=" + Uri.EscapeDataString(filterTextBox.Text.Trim());
                    System.Diagnostics.Process.Start(targetUri);
                }
                catch (Exception exception)
                {
                    ErrorReport.Report(exception);
                }
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void CodeTagForm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.F4:
                        if (!e.Alt && !e.Control)
                            EditCodeSnippet();
                        break;
                    case Keys.Escape:
                        e.Handled = true;
                        Close();
                        break;
                }
            }
            catch (Exception exception)
            {
                ErrorReport.Report(exception);
            }
        }
    }
}
