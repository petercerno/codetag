// 
// ConfigureForm.cs
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
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CodeTag
{
    public partial class ConfigureForm : Form
    {
        private const string FileNameFilter = "Xml files (*.xml)|*.xml|All files (*.*)|*.*";

        private bool LockLayout
        {
            set
            {
                if (value) SuspendLayout();
                else ResumeLayout();
            }
        }

        /// <summary>
        /// Indicator determining whether the configuration was updated.
        /// </summary>
        public bool IsConfigurationUpdated { get; protected set; }

        public ConfigureForm()
        {
            InitializeComponent();
            LoadConfiguration();
        }

        private void LoadConfiguration()
        {
            LockLayout = true;

            try
            {
                var tagPreprocessing = Configuration.TagPreprocessing;
                lowerCaseCheckBox.Checked =
                    (tagPreprocessing & Configuration.TagPreprocess.LowerCase) ==
                    Configuration.TagPreprocess.LowerCase;
                removeSpecialCharsCheckBox.Checked =
                    (tagPreprocessing & Configuration.TagPreprocess.RemoveSpecialChars) ==
                    Configuration.TagPreprocess.RemoveSpecialChars;

                var tagMatching = Configuration.TagMatching;
                switch (tagMatching)
                {
                    case Configuration.TagMatch.Exact:
                        exactMatchRadioButton.Checked = true;
                        break;
                    case Configuration.TagMatch.Prefix:
                        prefixMatchRadioButton.Checked = true;
                        break;
                    case Configuration.TagMatch.Substring:
                        substringMatchRadioButton.Checked = true;
                        break;
                }

                var codeSnippetSources = Configuration.CheckedCodeSnippetSources;
                sourceListView.Items.Clear();
                if (codeSnippetSources != null)
                    foreach (var codeSnippetSource in codeSnippetSources)
                    {
                        var item = sourceListView.Items.Add(Path.GetFileName(codeSnippetSource.Item1));
                        item.SubItems.Add(codeSnippetSource.Item1);
                        item.Checked = codeSnippetSource.Item2;
                    }

                startupCheckBox.Checked = Configuration.Startup;

                IsConfigurationUpdated = false;
            }
            catch (Exception exception)
            {
                ErrorReport.Report(exception);
                lowerCaseCheckBox.Checked = true;
                removeSpecialCharsCheckBox.Checked = true;
                prefixMatchRadioButton.Checked = true;
                sourceListView.Items.Clear();
                startupCheckBox.Checked = false;
            }

            LockLayout = false;
        }

        private void SaveConfiguration()
        {
            try
            {
                Configuration.TagPreprocess tagPreprocessing = 0;
                if (lowerCaseCheckBox.Checked)
                    tagPreprocessing = tagPreprocessing | Configuration.TagPreprocess.LowerCase;
                if (removeSpecialCharsCheckBox.Checked)
                    tagPreprocessing = tagPreprocessing | Configuration.TagPreprocess.RemoveSpecialChars;
                Configuration.TagPreprocessing = tagPreprocessing;

                if (exactMatchRadioButton.Checked)
                    Configuration.TagMatching = Configuration.TagMatch.Exact;
                else if (prefixMatchRadioButton.Checked)
                    Configuration.TagMatching = Configuration.TagMatch.Prefix;
                else if (substringMatchRadioButton.Checked)
                    Configuration.TagMatching = Configuration.TagMatch.Substring;

                Configuration.CheckedCodeSnippetSources =
                    (from ListViewItem item in sourceListView.Items
                     select Tuple.Create(item.SubItems[1].Text, item.Checked)).ToArray();

                Configuration.Startup = startupCheckBox.Checked;

                IsConfigurationUpdated = true;

                Configuration.Save();
            }
            catch (Exception exception)
            {
                ErrorReport.Report(exception);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                var openFileDialog = new OpenFileDialog { Filter = FileNameFilter, RestoreDirectory = true };
                if (openFileDialog.ShowDialog() != DialogResult.OK) return;
                LockLayout = true;
                var item = sourceListView.
                    Items.Add(Path.GetFileName(openFileDialog.FileName));
                item.SubItems.Add(openFileDialog.FileName);
                item.Checked = true;
                LockLayout = false;
            }
            catch (Exception exception)
            {
                ErrorReport.Report(exception);
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (sourceListView.SelectedItems.Count != 1) return;
                var selectedItem = sourceListView.SelectedItems[0];
                var selectedIndex = selectedItem.Index;
                LockLayout = true;
                sourceListView.Items.Remove(selectedItem);
                if (sourceListView.Items.Count > 0)
                    sourceListView.Items[Math.Min(selectedIndex, sourceListView.Items.Count - 1)].Selected = true;
                LockLayout = false;
            }
            catch (Exception exception)
            {
                ErrorReport.Report(exception);
            }
        }

        private void upButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (sourceListView.SelectedItems.Count != 1) return;
                var selectedItem = sourceListView.SelectedItems[0];
                var index = selectedItem.Index;
                if (index == 0) return;
                LockLayout = true;
                var newItem = (ListViewItem)selectedItem.Clone();
                sourceListView.Items.Remove(selectedItem);
                sourceListView.Items.Insert(index - 1, newItem).Selected = true;
                LockLayout = false;
            }
            catch (Exception exception)
            {
                ErrorReport.Report(exception);
            }
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (sourceListView.SelectedItems.Count != 1) return;
                var selectedItem = sourceListView.SelectedItems[0];
                var index = selectedItem.Index;
                if (index == sourceListView.Items.Count - 1) return;
                LockLayout = true;
                var newItem = (ListViewItem)selectedItem.Clone();
                sourceListView.Items.Remove(selectedItem);
                sourceListView.Items.Insert(index + 1, newItem).Selected = true;
                LockLayout = false;
            }
            catch (Exception exception)
            {
                ErrorReport.Report(exception);
            }
        }

        private void selectAllButton_Click(object sender, EventArgs e)
        {
            try
            {
                LockLayout = true;
                foreach (ListViewItem item in sourceListView.Items)
                    item.Checked = true;
                LockLayout = false;
            }
            catch (Exception exception)
            {
                ErrorReport.Report(exception);
            }
        }

        private void selectNoneButton_Click(object sender, EventArgs e)
        {
            try
            {
                LockLayout = true;
                foreach (ListViewItem item in sourceListView.Items)
                    item.Checked = false;
                LockLayout = false;
            }
            catch (Exception exception)
            {
                ErrorReport.Report(exception);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            SaveConfiguration();
            Close();
        }

        private void sourceListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LockLayout = true;
                if (sourceListView.SelectedItems.Count == 1)
                {
                    var selectedItem = sourceListView.SelectedItems[0];
                    upButton.Enabled = selectedItem.Index > 0;
                    downButton.Enabled = selectedItem.Index < sourceListView.Items.Count - 1;
                    removeButton.Enabled = true;
                }
                else
                {
                    upButton.Enabled = false;
                    downButton.Enabled = false;
                    removeButton.Enabled = false;
                }
                LockLayout = false;
            }
            catch (Exception exception)
            {
                ErrorReport.Report(exception);
            }
        }
    }
}
