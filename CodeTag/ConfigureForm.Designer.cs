// 
// ConfigureForm.Designer.cs
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

namespace CodeTag
{
    partial class ConfigureForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigureForm));
            this.tagGroupBox = new System.Windows.Forms.GroupBox();
            this.removeSpecialCharsCheckBox = new System.Windows.Forms.CheckBox();
            this.lowerCaseCheckBox = new System.Windows.Forms.CheckBox();
            this.sourceGroupBox = new System.Windows.Forms.GroupBox();
            this.selectNoneButton = new System.Windows.Forms.Button();
            this.selectAllButton = new System.Windows.Forms.Button();
            this.downButton = new System.Windows.Forms.Button();
            this.upButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.sourceListView = new System.Windows.Forms.ListView();
            this.sourceNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sourcePathColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.matchGroupBox = new System.Windows.Forms.GroupBox();
            this.substringMatchRadioButton = new System.Windows.Forms.RadioButton();
            this.prefixMatchRadioButton = new System.Windows.Forms.RadioButton();
            this.exactMatchRadioButton = new System.Windows.Forms.RadioButton();
            this.tagGroupBox.SuspendLayout();
            this.sourceGroupBox.SuspendLayout();
            this.matchGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // tagGroupBox
            // 
            this.tagGroupBox.Controls.Add(this.removeSpecialCharsCheckBox);
            this.tagGroupBox.Controls.Add(this.lowerCaseCheckBox);
            this.tagGroupBox.Location = new System.Drawing.Point(12, 12);
            this.tagGroupBox.Name = "tagGroupBox";
            this.tagGroupBox.Size = new System.Drawing.Size(377, 130);
            this.tagGroupBox.TabIndex = 0;
            this.tagGroupBox.TabStop = false;
            this.tagGroupBox.Text = "Tag Preprocessing";
            // 
            // removeSpecialCharsCheckBox
            // 
            this.removeSpecialCharsCheckBox.AutoSize = true;
            this.removeSpecialCharsCheckBox.Checked = true;
            this.removeSpecialCharsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.removeSpecialCharsCheckBox.Location = new System.Drawing.Point(20, 56);
            this.removeSpecialCharsCheckBox.Name = "removeSpecialCharsCheckBox";
            this.removeSpecialCharsCheckBox.Size = new System.Drawing.Size(187, 20);
            this.removeSpecialCharsCheckBox.TabIndex = 1;
            this.removeSpecialCharsCheckBox.Text = "Remove Special Chars";
            // 
            // lowerCaseCheckBox
            // 
            this.lowerCaseCheckBox.AutoSize = true;
            this.lowerCaseCheckBox.Checked = true;
            this.lowerCaseCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.lowerCaseCheckBox.Location = new System.Drawing.Point(20, 30);
            this.lowerCaseCheckBox.Name = "lowerCaseCheckBox";
            this.lowerCaseCheckBox.Size = new System.Drawing.Size(107, 20);
            this.lowerCaseCheckBox.TabIndex = 0;
            this.lowerCaseCheckBox.Text = "Lower Case";
            // 
            // sourceGroupBox
            // 
            this.sourceGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sourceGroupBox.Controls.Add(this.selectNoneButton);
            this.sourceGroupBox.Controls.Add(this.selectAllButton);
            this.sourceGroupBox.Controls.Add(this.downButton);
            this.sourceGroupBox.Controls.Add(this.upButton);
            this.sourceGroupBox.Controls.Add(this.removeButton);
            this.sourceGroupBox.Controls.Add(this.addButton);
            this.sourceGroupBox.Controls.Add(this.sourceListView);
            this.sourceGroupBox.Location = new System.Drawing.Point(12, 148);
            this.sourceGroupBox.Name = "sourceGroupBox";
            this.sourceGroupBox.Size = new System.Drawing.Size(760, 277);
            this.sourceGroupBox.TabIndex = 2;
            this.sourceGroupBox.TabStop = false;
            this.sourceGroupBox.Text = "Code Snippet Sources";
            // 
            // selectNoneButton
            // 
            this.selectNoneButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.selectNoneButton.Location = new System.Drawing.Point(665, 235);
            this.selectNoneButton.Name = "selectNoneButton";
            this.selectNoneButton.Size = new System.Drawing.Size(75, 23);
            this.selectNoneButton.TabIndex = 6;
            this.selectNoneButton.Text = "None";
            this.selectNoneButton.Click += new System.EventHandler(this.selectNoneButton_Click);
            // 
            // selectAllButton
            // 
            this.selectAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.selectAllButton.Location = new System.Drawing.Point(584, 235);
            this.selectAllButton.Name = "selectAllButton";
            this.selectAllButton.Size = new System.Drawing.Size(75, 23);
            this.selectAllButton.TabIndex = 5;
            this.selectAllButton.Text = "All";
            this.selectAllButton.Click += new System.EventHandler(this.selectAllButton_Click);
            // 
            // downButton
            // 
            this.downButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.downButton.Enabled = false;
            this.downButton.Location = new System.Drawing.Point(263, 235);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(75, 23);
            this.downButton.TabIndex = 4;
            this.downButton.Text = "Down";
            this.downButton.Click += new System.EventHandler(this.downButton_Click);
            // 
            // upButton
            // 
            this.upButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.upButton.Enabled = false;
            this.upButton.Location = new System.Drawing.Point(182, 235);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(75, 23);
            this.upButton.TabIndex = 3;
            this.upButton.Text = "Up";
            this.upButton.Click += new System.EventHandler(this.upButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removeButton.Enabled = false;
            this.removeButton.Location = new System.Drawing.Point(101, 235);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(75, 23);
            this.removeButton.TabIndex = 2;
            this.removeButton.Text = "Remove";
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addButton.Location = new System.Drawing.Point(20, 235);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Add";
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // sourceListView
            // 
            this.sourceListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sourceListView.CheckBoxes = true;
            this.sourceListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.sourceNameColumnHeader,
            this.sourcePathColumnHeader});
            this.sourceListView.FullRowSelect = true;
            this.sourceListView.GridLines = true;
            this.sourceListView.HideSelection = false;
            this.sourceListView.Location = new System.Drawing.Point(20, 30);
            this.sourceListView.Name = "sourceListView";
            this.sourceListView.Size = new System.Drawing.Size(720, 199);
            this.sourceListView.TabIndex = 0;
            this.sourceListView.UseCompatibleStateImageBehavior = false;
            this.sourceListView.View = System.Windows.Forms.View.Details;
            this.sourceListView.SelectedIndexChanged += new System.EventHandler(this.sourceListView_SelectedIndexChanged);
            // 
            // sourceNameColumnHeader
            // 
            this.sourceNameColumnHeader.Text = "Name";
            this.sourceNameColumnHeader.Width = 200;
            // 
            // sourcePathColumnHeader
            // 
            this.sourcePathColumnHeader.Text = "Path";
            this.sourcePathColumnHeader.Width = 400;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(616, 431);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(697, 431);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "Ok";
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // matchGroupBox
            // 
            this.matchGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.matchGroupBox.Controls.Add(this.substringMatchRadioButton);
            this.matchGroupBox.Controls.Add(this.prefixMatchRadioButton);
            this.matchGroupBox.Controls.Add(this.exactMatchRadioButton);
            this.matchGroupBox.Location = new System.Drawing.Point(395, 12);
            this.matchGroupBox.Name = "matchGroupBox";
            this.matchGroupBox.Size = new System.Drawing.Size(377, 130);
            this.matchGroupBox.TabIndex = 1;
            this.matchGroupBox.TabStop = false;
            this.matchGroupBox.Text = "Tag Matching";
            // 
            // substringMatchRadioButton
            // 
            this.substringMatchRadioButton.AutoSize = true;
            this.substringMatchRadioButton.Location = new System.Drawing.Point(20, 82);
            this.substringMatchRadioButton.Name = "substringMatchRadioButton";
            this.substringMatchRadioButton.Size = new System.Drawing.Size(98, 20);
            this.substringMatchRadioButton.TabIndex = 2;
            this.substringMatchRadioButton.Text = "Substring";
            // 
            // prefixMatchRadioButton
            // 
            this.prefixMatchRadioButton.AutoSize = true;
            this.prefixMatchRadioButton.Checked = true;
            this.prefixMatchRadioButton.Location = new System.Drawing.Point(20, 56);
            this.prefixMatchRadioButton.Name = "prefixMatchRadioButton";
            this.prefixMatchRadioButton.Size = new System.Drawing.Size(74, 20);
            this.prefixMatchRadioButton.TabIndex = 1;
            this.prefixMatchRadioButton.TabStop = true;
            this.prefixMatchRadioButton.Text = "Prefix";
            // 
            // exactMatchRadioButton
            // 
            this.exactMatchRadioButton.AutoSize = true;
            this.exactMatchRadioButton.Location = new System.Drawing.Point(20, 30);
            this.exactMatchRadioButton.Name = "exactMatchRadioButton";
            this.exactMatchRadioButton.Size = new System.Drawing.Size(66, 20);
            this.exactMatchRadioButton.TabIndex = 0;
            this.exactMatchRadioButton.Text = "Exact";
            // 
            // ConfigureForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(784, 466);
            this.ControlBox = false;
            this.Controls.Add(this.matchGroupBox);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.sourceGroupBox);
            this.Controls.Add(this.tagGroupBox);
            this.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 450);
            this.Name = "ConfigureForm";
            this.Text = "Configure";
            this.tagGroupBox.ResumeLayout(false);
            this.tagGroupBox.PerformLayout();
            this.sourceGroupBox.ResumeLayout(false);
            this.matchGroupBox.ResumeLayout(false);
            this.matchGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox tagGroupBox;
        private System.Windows.Forms.CheckBox removeSpecialCharsCheckBox;
        private System.Windows.Forms.CheckBox lowerCaseCheckBox;
        private System.Windows.Forms.GroupBox sourceGroupBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.ListView sourceListView;
        private System.Windows.Forms.ColumnHeader sourceNameColumnHeader;
        private System.Windows.Forms.ColumnHeader sourcePathColumnHeader;
        private System.Windows.Forms.GroupBox matchGroupBox;
        private System.Windows.Forms.RadioButton substringMatchRadioButton;
        private System.Windows.Forms.RadioButton prefixMatchRadioButton;
        private System.Windows.Forms.RadioButton exactMatchRadioButton;
        private System.Windows.Forms.Button selectNoneButton;
        private System.Windows.Forms.Button selectAllButton;
    }
}