// 
// CodeTagForm.Designer.cs
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
    partial class CodeTagForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CodeTagForm));
            this.filterTextBox = new System.Windows.Forms.TextBox();
            this.panel = new System.Windows.Forms.Panel();
            this.codeRichTextBox = new System.Windows.Forms.RichTextBox();
            this.tagsTextBox = new System.Windows.Forms.TextBox();
            this.hintLabel = new System.Windows.Forms.Label();
            this.authorsTextBox = new System.Windows.Forms.TextBox();
            this.sourceTextBox = new System.Windows.Forms.TextBox();
            this.tagsLabel = new System.Windows.Forms.Label();
            this.authorsLabel = new System.Windows.Forms.Label();
            this.sourceLabel = new System.Windows.Forms.Label();
            this.statusTextBox = new System.Windows.Forms.TextBox();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // filterTextBox
            // 
            this.filterTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filterTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filterTextBox.Location = new System.Drawing.Point(12, 12);
            this.filterTextBox.Name = "filterTextBox";
            this.filterTextBox.Size = new System.Drawing.Size(760, 22);
            this.filterTextBox.TabIndex = 0;
            this.filterTextBox.TextChanged += new System.EventHandler(this.filterTextBox_TextChanged);
            this.filterTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.filterTextBox_KeyDown);
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel.Controls.Add(this.codeRichTextBox);
            this.panel.Location = new System.Drawing.Point(12, 56);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(760, 286);
            this.panel.TabIndex = 2;
            // 
            // codeRichTextBox
            // 
            this.codeRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.codeRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeRichTextBox.Location = new System.Drawing.Point(0, 0);
            this.codeRichTextBox.Name = "codeRichTextBox";
            this.codeRichTextBox.ReadOnly = true;
            this.codeRichTextBox.Size = new System.Drawing.Size(758, 284);
            this.codeRichTextBox.TabIndex = 0;
            this.codeRichTextBox.Text = "";
            // 
            // tagsTextBox
            // 
            this.tagsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tagsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tagsTextBox.Location = new System.Drawing.Point(90, 376);
            this.tagsTextBox.Name = "tagsTextBox";
            this.tagsTextBox.ReadOnly = true;
            this.tagsTextBox.Size = new System.Drawing.Size(682, 22);
            this.tagsTextBox.TabIndex = 5;
            // 
            // hintLabel
            // 
            this.hintLabel.AutoSize = true;
            this.hintLabel.Location = new System.Drawing.Point(12, 37);
            this.hintLabel.Name = "hintLabel";
            this.hintLabel.Size = new System.Drawing.Size(688, 16);
            this.hintLabel.TabIndex = 1;
            this.hintLabel.Text = "Press Up / Down to navigate, F4 to edit, Esc to hide, Enter to google / go to sou" +
    "rce.";
            // 
            // authorsTextBox
            // 
            this.authorsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.authorsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.authorsTextBox.Location = new System.Drawing.Point(90, 404);
            this.authorsTextBox.Name = "authorsTextBox";
            this.authorsTextBox.ReadOnly = true;
            this.authorsTextBox.Size = new System.Drawing.Size(682, 22);
            this.authorsTextBox.TabIndex = 7;
            // 
            // sourceTextBox
            // 
            this.sourceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sourceTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sourceTextBox.Location = new System.Drawing.Point(90, 432);
            this.sourceTextBox.Name = "sourceTextBox";
            this.sourceTextBox.ReadOnly = true;
            this.sourceTextBox.Size = new System.Drawing.Size(682, 22);
            this.sourceTextBox.TabIndex = 9;
            // 
            // tagsLabel
            // 
            this.tagsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tagsLabel.AutoSize = true;
            this.tagsLabel.Location = new System.Drawing.Point(12, 378);
            this.tagsLabel.Name = "tagsLabel";
            this.tagsLabel.Size = new System.Drawing.Size(48, 16);
            this.tagsLabel.TabIndex = 4;
            this.tagsLabel.Text = "Tags:";
            // 
            // authorsLabel
            // 
            this.authorsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.authorsLabel.AutoSize = true;
            this.authorsLabel.Location = new System.Drawing.Point(12, 406);
            this.authorsLabel.Name = "authorsLabel";
            this.authorsLabel.Size = new System.Drawing.Size(72, 16);
            this.authorsLabel.TabIndex = 6;
            this.authorsLabel.Text = "Authors:";
            // 
            // sourceLabel
            // 
            this.sourceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sourceLabel.AutoSize = true;
            this.sourceLabel.Location = new System.Drawing.Point(12, 434);
            this.sourceLabel.Name = "sourceLabel";
            this.sourceLabel.Size = new System.Drawing.Size(64, 16);
            this.sourceLabel.TabIndex = 8;
            this.sourceLabel.Text = "Source:";
            // 
            // statusTextBox
            // 
            this.statusTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statusTextBox.Location = new System.Drawing.Point(12, 348);
            this.statusTextBox.Name = "statusTextBox";
            this.statusTextBox.ReadOnly = true;
            this.statusTextBox.Size = new System.Drawing.Size(760, 22);
            this.statusTextBox.TabIndex = 3;
            this.statusTextBox.Text = "No code snippets configured.";
            // 
            // CodeTagForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 466);
            this.ControlBox = false;
            this.Controls.Add(this.statusTextBox);
            this.Controls.Add(this.sourceLabel);
            this.Controls.Add(this.authorsLabel);
            this.Controls.Add(this.tagsLabel);
            this.Controls.Add(this.sourceTextBox);
            this.Controls.Add(this.authorsTextBox);
            this.Controls.Add(this.hintLabel);
            this.Controls.Add(this.tagsTextBox);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.filterTextBox);
            this.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 450);
            this.Name = "CodeTagForm";
            this.Text = "Search by Tags";
            this.Load += new System.EventHandler(this.CodeTagForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CodeTagForm_KeyDown);
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox filterTextBox;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.RichTextBox codeRichTextBox;
        private System.Windows.Forms.TextBox tagsTextBox;
        private System.Windows.Forms.Label hintLabel;
        private System.Windows.Forms.TextBox authorsTextBox;
        private System.Windows.Forms.TextBox sourceTextBox;
        private System.Windows.Forms.Label tagsLabel;
        private System.Windows.Forms.Label authorsLabel;
        private System.Windows.Forms.Label sourceLabel;
        private System.Windows.Forms.TextBox statusTextBox;
    }
}

