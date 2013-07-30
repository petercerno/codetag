// 
// EditorForm.Designer.cs
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
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using CodeTag.Data;

namespace CodeTag
{
    partial class EditorForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorForm));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.moveDownButton = new System.Windows.Forms.Button();
            this.moveUpButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.addBlockButton = new System.Windows.Forms.Button();
            this.addCodeButton = new System.Windows.Forms.Button();
            this.treeView = new System.Windows.Forms.TreeView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addBlockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inheritanceSplitContainer = new System.Windows.Forms.SplitContainer();
            this.syntaxTextBox = new System.Windows.Forms.TextBox();
            this.tagsTextBox = new System.Windows.Forms.TextBox();
            this.prerequisitesTextBox = new System.Windows.Forms.TextBox();
            this.thisLabel = new System.Windows.Forms.Label();
            this.inheritedSyntaxTextBox = new System.Windows.Forms.TextBox();
            this.inheritedTagsTextBox = new System.Windows.Forms.TextBox();
            this.parentLabel = new System.Windows.Forms.Label();
            this.inheritedPrerequisitesTextBox = new System.Windows.Forms.TextBox();
            this.codeTextBox = new System.Windows.Forms.TextBox();
            this.codeLabel = new System.Windows.Forms.Label();
            this.prerequisitesLabel = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.tagsLabel = new System.Windows.Forms.Label();
            this.syntaxLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inheritanceSplitContainer)).BeginInit();
            this.inheritanceSplitContainer.Panel1.SuspendLayout();
            this.inheritanceSplitContainer.Panel2.SuspendLayout();
            this.inheritanceSplitContainer.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 24);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.moveDownButton);
            this.splitContainer.Panel1.Controls.Add(this.moveUpButton);
            this.splitContainer.Panel1.Controls.Add(this.removeButton);
            this.splitContainer.Panel1.Controls.Add(this.addBlockButton);
            this.splitContainer.Panel1.Controls.Add(this.addCodeButton);
            this.splitContainer.Panel1.Controls.Add(this.treeView);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.inheritanceSplitContainer);
            this.splitContainer.Panel2.Controls.Add(this.codeTextBox);
            this.splitContainer.Panel2.Controls.Add(this.codeLabel);
            this.splitContainer.Panel2.Controls.Add(this.prerequisitesLabel);
            this.splitContainer.Panel2.Controls.Add(this.descriptionTextBox);
            this.splitContainer.Panel2.Controls.Add(this.descriptionLabel);
            this.splitContainer.Panel2.Controls.Add(this.tagsLabel);
            this.splitContainer.Panel2.Controls.Add(this.syntaxLabel);
            this.splitContainer.Panel2.Controls.Add(this.nameTextBox);
            this.splitContainer.Panel2.Controls.Add(this.nameLabel);
            this.splitContainer.Size = new System.Drawing.Size(884, 538);
            this.splitContainer.SplitterDistance = 179;
            this.splitContainer.TabIndex = 0;
            // 
            // moveDownButton
            // 
            this.moveDownButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.moveDownButton.Location = new System.Drawing.Point(93, 474);
            this.moveDownButton.Name = "moveDownButton";
            this.moveDownButton.Size = new System.Drawing.Size(75, 23);
            this.moveDownButton.TabIndex = 5;
            this.moveDownButton.Text = "Down";
            this.moveDownButton.Click += new System.EventHandler(this.moveDownToolStripMenuItem_Click);
            // 
            // moveUpButton
            // 
            this.moveUpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.moveUpButton.Location = new System.Drawing.Point(93, 445);
            this.moveUpButton.Name = "moveUpButton";
            this.moveUpButton.Size = new System.Drawing.Size(75, 23);
            this.moveUpButton.TabIndex = 4;
            this.moveUpButton.Text = "Up";
            this.moveUpButton.Click += new System.EventHandler(this.moveUpToolStripMenuItem_Click);
            // 
            // removeButton
            // 
            this.removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removeButton.Location = new System.Drawing.Point(12, 503);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(75, 23);
            this.removeButton.TabIndex = 3;
            this.removeButton.Text = "Remove";
            this.removeButton.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // addBlockButton
            // 
            this.addBlockButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addBlockButton.Location = new System.Drawing.Point(12, 474);
            this.addBlockButton.Name = "addBlockButton";
            this.addBlockButton.Size = new System.Drawing.Size(75, 23);
            this.addBlockButton.TabIndex = 2;
            this.addBlockButton.Text = "+Block";
            this.addBlockButton.Click += new System.EventHandler(this.addBlockToolStripMenuItem_Click);
            // 
            // addCodeButton
            // 
            this.addCodeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addCodeButton.Location = new System.Drawing.Point(12, 445);
            this.addCodeButton.Name = "addCodeButton";
            this.addCodeButton.Size = new System.Drawing.Size(75, 23);
            this.addCodeButton.TabIndex = 1;
            this.addCodeButton.Text = "+Code";
            this.addCodeButton.Click += new System.EventHandler(this.addCodeToolStripMenuItem_Click);
            // 
            // treeView
            // 
            this.treeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView.ContextMenuStrip = this.contextMenuStrip;
            this.treeView.FullRowSelect = true;
            this.treeView.HideSelection = false;
            this.treeView.Location = new System.Drawing.Point(12, 3);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(164, 436);
            this.treeView.TabIndex = 0;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCodeToolStripMenuItem,
            this.addBlockToolStripMenuItem,
            this.removeToolStripMenuItem,
            this.moveUpToolStripMenuItem,
            this.moveDownToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(139, 114);
            // 
            // addCodeToolStripMenuItem
            // 
            this.addCodeToolStripMenuItem.Name = "addCodeToolStripMenuItem";
            this.addCodeToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.addCodeToolStripMenuItem.Text = "Add &Code";
            this.addCodeToolStripMenuItem.Click += new System.EventHandler(this.addCodeToolStripMenuItem_Click);
            // 
            // addBlockToolStripMenuItem
            // 
            this.addBlockToolStripMenuItem.Name = "addBlockToolStripMenuItem";
            this.addBlockToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.addBlockToolStripMenuItem.Text = "Add &Block";
            this.addBlockToolStripMenuItem.Click += new System.EventHandler(this.addBlockToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.removeToolStripMenuItem.Text = "&Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // moveUpToolStripMenuItem
            // 
            this.moveUpToolStripMenuItem.Name = "moveUpToolStripMenuItem";
            this.moveUpToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.moveUpToolStripMenuItem.Text = "Move &Up";
            this.moveUpToolStripMenuItem.Click += new System.EventHandler(this.moveUpToolStripMenuItem_Click);
            // 
            // moveDownToolStripMenuItem
            // 
            this.moveDownToolStripMenuItem.Name = "moveDownToolStripMenuItem";
            this.moveDownToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.moveDownToolStripMenuItem.Text = "Move &Down";
            this.moveDownToolStripMenuItem.Click += new System.EventHandler(this.moveDownToolStripMenuItem_Click);
            // 
            // inheritanceSplitContainer
            // 
            this.inheritanceSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inheritanceSplitContainer.Location = new System.Drawing.Point(101, 59);
            this.inheritanceSplitContainer.Name = "inheritanceSplitContainer";
            // 
            // inheritanceSplitContainer.Panel1
            // 
            this.inheritanceSplitContainer.Panel1.Controls.Add(this.syntaxTextBox);
            this.inheritanceSplitContainer.Panel1.Controls.Add(this.tagsTextBox);
            this.inheritanceSplitContainer.Panel1.Controls.Add(this.prerequisitesTextBox);
            this.inheritanceSplitContainer.Panel1.Controls.Add(this.thisLabel);
            // 
            // inheritanceSplitContainer.Panel2
            // 
            this.inheritanceSplitContainer.Panel2.Controls.Add(this.inheritedSyntaxTextBox);
            this.inheritanceSplitContainer.Panel2.Controls.Add(this.inheritedTagsTextBox);
            this.inheritanceSplitContainer.Panel2.Controls.Add(this.parentLabel);
            this.inheritanceSplitContainer.Panel2.Controls.Add(this.inheritedPrerequisitesTextBox);
            this.inheritanceSplitContainer.Size = new System.Drawing.Size(588, 200);
            this.inheritanceSplitContainer.SplitterDistance = 292;
            this.inheritanceSplitContainer.TabIndex = 7;
            // 
            // syntaxTextBox
            // 
            this.syntaxTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.syntaxTextBox.Location = new System.Drawing.Point(3, 18);
            this.syntaxTextBox.Name = "syntaxTextBox";
            this.syntaxTextBox.Size = new System.Drawing.Size(286, 22);
            this.syntaxTextBox.TabIndex = 1;
            this.syntaxTextBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // tagsTextBox
            // 
            this.tagsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tagsTextBox.Location = new System.Drawing.Point(3, 46);
            this.tagsTextBox.Name = "tagsTextBox";
            this.tagsTextBox.Size = new System.Drawing.Size(286, 22);
            this.tagsTextBox.TabIndex = 2;
            this.tagsTextBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // prerequisitesTextBox
            // 
            this.prerequisitesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prerequisitesTextBox.Location = new System.Drawing.Point(3, 74);
            this.prerequisitesTextBox.Multiline = true;
            this.prerequisitesTextBox.Name = "prerequisitesTextBox";
            this.prerequisitesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.prerequisitesTextBox.Size = new System.Drawing.Size(286, 123);
            this.prerequisitesTextBox.TabIndex = 3;
            this.prerequisitesTextBox.WordWrap = false;
            this.prerequisitesTextBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // thisLabel
            // 
            this.thisLabel.AutoSize = true;
            this.thisLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thisLabel.Location = new System.Drawing.Point(3, 0);
            this.thisLabel.Name = "thisLabel";
            this.thisLabel.Size = new System.Drawing.Size(30, 15);
            this.thisLabel.TabIndex = 0;
            this.thisLabel.Text = "This";
            // 
            // inheritedSyntaxTextBox
            // 
            this.inheritedSyntaxTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inheritedSyntaxTextBox.Location = new System.Drawing.Point(3, 18);
            this.inheritedSyntaxTextBox.Name = "inheritedSyntaxTextBox";
            this.inheritedSyntaxTextBox.ReadOnly = true;
            this.inheritedSyntaxTextBox.Size = new System.Drawing.Size(286, 22);
            this.inheritedSyntaxTextBox.TabIndex = 1;
            // 
            // inheritedTagsTextBox
            // 
            this.inheritedTagsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inheritedTagsTextBox.Location = new System.Drawing.Point(3, 46);
            this.inheritedTagsTextBox.Name = "inheritedTagsTextBox";
            this.inheritedTagsTextBox.ReadOnly = true;
            this.inheritedTagsTextBox.Size = new System.Drawing.Size(286, 22);
            this.inheritedTagsTextBox.TabIndex = 2;
            // 
            // parentLabel
            // 
            this.parentLabel.AutoSize = true;
            this.parentLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.parentLabel.Location = new System.Drawing.Point(3, 0);
            this.parentLabel.Name = "parentLabel";
            this.parentLabel.Size = new System.Drawing.Size(57, 15);
            this.parentLabel.TabIndex = 0;
            this.parentLabel.Text = "Inherited";
            // 
            // inheritedPrerequisitesTextBox
            // 
            this.inheritedPrerequisitesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inheritedPrerequisitesTextBox.Location = new System.Drawing.Point(3, 74);
            this.inheritedPrerequisitesTextBox.Multiline = true;
            this.inheritedPrerequisitesTextBox.Name = "inheritedPrerequisitesTextBox";
            this.inheritedPrerequisitesTextBox.ReadOnly = true;
            this.inheritedPrerequisitesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.inheritedPrerequisitesTextBox.Size = new System.Drawing.Size(286, 123);
            this.inheritedPrerequisitesTextBox.TabIndex = 3;
            this.inheritedPrerequisitesTextBox.WordWrap = false;
            // 
            // codeTextBox
            // 
            this.codeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.codeTextBox.Location = new System.Drawing.Point(104, 265);
            this.codeTextBox.Multiline = true;
            this.codeTextBox.Name = "codeTextBox";
            this.codeTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.codeTextBox.Size = new System.Drawing.Size(582, 261);
            this.codeTextBox.TabIndex = 9;
            this.codeTextBox.WordWrap = false;
            this.codeTextBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // codeLabel
            // 
            this.codeLabel.AutoSize = true;
            this.codeLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeLabel.Location = new System.Drawing.Point(61, 268);
            this.codeLabel.Name = "codeLabel";
            this.codeLabel.Size = new System.Drawing.Size(34, 15);
            this.codeLabel.TabIndex = 8;
            this.codeLabel.Text = "Code";
            // 
            // prerequisitesLabel
            // 
            this.prerequisitesLabel.AutoSize = true;
            this.prerequisitesLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prerequisitesLabel.Location = new System.Drawing.Point(15, 136);
            this.prerequisitesLabel.Name = "prerequisitesLabel";
            this.prerequisitesLabel.Size = new System.Drawing.Size(80, 15);
            this.prerequisitesLabel.TabIndex = 6;
            this.prerequisitesLabel.Text = "Prerequisites";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptionTextBox.Location = new System.Drawing.Point(104, 31);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(582, 22);
            this.descriptionTextBox.TabIndex = 3;
            this.descriptionTextBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLabel.Location = new System.Drawing.Point(25, 34);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(70, 15);
            this.descriptionLabel.TabIndex = 2;
            this.descriptionLabel.Text = "Description";
            // 
            // tagsLabel
            // 
            this.tagsLabel.AutoSize = true;
            this.tagsLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tagsLabel.Location = new System.Drawing.Point(64, 108);
            this.tagsLabel.Name = "tagsLabel";
            this.tagsLabel.Size = new System.Drawing.Size(31, 15);
            this.tagsLabel.TabIndex = 5;
            this.tagsLabel.Text = "Tags";
            // 
            // syntaxLabel
            // 
            this.syntaxLabel.AutoSize = true;
            this.syntaxLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.syntaxLabel.Location = new System.Drawing.Point(52, 80);
            this.syntaxLabel.Name = "syntaxLabel";
            this.syntaxLabel.Size = new System.Drawing.Size(43, 15);
            this.syntaxLabel.TabIndex = 4;
            this.syntaxLabel.Text = "Syntax";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTextBox.Location = new System.Drawing.Point(104, 3);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(582, 22);
            this.nameTextBox.TabIndex = 1;
            this.nameTextBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(54, 6);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(41, 15);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name ";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(884, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.openToolStripMenuItem.Text = "&Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.saveAsToolStripMenuItem.Text = "S&ave As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 562);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "EditorForm";
            this.Text = "Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditorForm_FormClosing);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.inheritanceSplitContainer.Panel1.ResumeLayout(false);
            this.inheritanceSplitContainer.Panel1.PerformLayout();
            this.inheritanceSplitContainer.Panel2.ResumeLayout(false);
            this.inheritanceSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inheritanceSplitContainer)).EndInit();
            this.inheritanceSplitContainer.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.TextBox inheritedSyntaxTextBox;
        private System.Windows.Forms.TextBox syntaxTextBox;
        private System.Windows.Forms.Label tagsLabel;
        private System.Windows.Forms.TextBox inheritedTagsTextBox;
        private System.Windows.Forms.TextBox tagsTextBox;
        private System.Windows.Forms.Label syntaxLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label codeLabel;
        private System.Windows.Forms.Label prerequisitesLabel;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label parentLabel;
        private System.Windows.Forms.Label thisLabel;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button moveDownButton;
        private System.Windows.Forms.Button moveUpButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button addBlockButton;
        private System.Windows.Forms.Button addCodeButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addCodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addBlockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveDownToolStripMenuItem;
        private System.Windows.Forms.TextBox codeTextBox;
        private System.Windows.Forms.TextBox inheritedPrerequisitesTextBox;
        private System.Windows.Forms.TextBox prerequisitesTextBox;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private SplitContainer inheritanceSplitContainer;
    }
}