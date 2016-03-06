namespace TaskNameSpace {
    partial class TaskForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskForm));
            this.CancelTaskbtn = new System.Windows.Forms.Button();
            this.FileTypeCB = new System.Windows.Forms.ComboBox();
            this.FileTypeLabel = new System.Windows.Forms.Label();
            this.DestinationFolderLabel = new System.Windows.Forms.Label();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.DestinationFolder = new System.Windows.Forms.TextBox();
            this.SourceFolder = new System.Windows.Forms.TextBox();
            this.SourceFolderLabel = new System.Windows.Forms.Label();
            this.TaskNameLabel = new System.Windows.Forms.Label();
            this.TaskName = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.SelectAllButton = new System.Windows.Forms.Button();
            this.SelectNoneButton = new System.Windows.Forms.Button();
            this.FileExtensionDisplayFLP = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.SelectNoneButtonAtt = new System.Windows.Forms.Button();
            this.SelectAllButtonAtt = new System.Windows.Forms.Button();
            this.FileAttributeFLP = new System.Windows.Forms.FlowLayoutPanel();
            this.TaskEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.MatchCaseButton = new System.Windows.Forms.Button();
            this.RegexTextBox = new System.Windows.Forms.TextBox();
            this.RegexLabel = new System.Windows.Forms.Label();
            this.CreateTaskbtn = new System.Windows.Forms.Button();
            this.BrowseButton2 = new System.Windows.Forms.Button();
            this.TaskIDLabel = new System.Windows.Forms.Label();
            this.FileNameTB = new System.Windows.Forms.TextBox();
            this.FileNameFormatLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PerformTypeComboBox = new System.Windows.Forms.ComboBox();
            this.SourceFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.DestinationFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.DeleteTaskButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // CancelTaskbtn
            // 
            this.CancelTaskbtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelTaskbtn.Location = new System.Drawing.Point(11, 525);
            this.CancelTaskbtn.Margin = new System.Windows.Forms.Padding(2);
            this.CancelTaskbtn.Name = "CancelTaskbtn";
            this.CancelTaskbtn.Size = new System.Drawing.Size(96, 25);
            this.CancelTaskbtn.TabIndex = 6;
            this.CancelTaskbtn.Text = "Close";
            this.CancelTaskbtn.UseVisualStyleBackColor = true;
            this.CancelTaskbtn.Click += new System.EventHandler(this.CancelTaskbtn_Click);
            // 
            // FileTypeCB
            // 
            this.FileTypeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FileTypeCB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileTypeCB.FormattingEnabled = true;
            this.FileTypeCB.Items.AddRange(new object[] {
            "Compressed",
            "Audio",
            "Document",
            "Image",
            "SourceCode",
            "Executable",
            "Video"});
            this.FileTypeCB.Location = new System.Drawing.Point(146, 111);
            this.FileTypeCB.Margin = new System.Windows.Forms.Padding(2);
            this.FileTypeCB.Name = "FileTypeCB";
            this.FileTypeCB.Size = new System.Drawing.Size(105, 23);
            this.FileTypeCB.TabIndex = 34;
            this.FileTypeCB.SelectedIndexChanged += new System.EventHandler(this.FileTypeCB_SelectedIndexChanged);
            // 
            // FileTypeLabel
            // 
            this.FileTypeLabel.AutoSize = true;
            this.FileTypeLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileTypeLabel.Location = new System.Drawing.Point(18, 115);
            this.FileTypeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.FileTypeLabel.Name = "FileTypeLabel";
            this.FileTypeLabel.Size = new System.Drawing.Size(62, 15);
            this.FileTypeLabel.TabIndex = 33;
            this.FileTypeLabel.Text = "File Type : ";
            // 
            // DestinationFolderLabel
            // 
            this.DestinationFolderLabel.AutoSize = true;
            this.DestinationFolderLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DestinationFolderLabel.Location = new System.Drawing.Point(18, 81);
            this.DestinationFolderLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.DestinationFolderLabel.Name = "DestinationFolderLabel";
            this.DestinationFolderLabel.Size = new System.Drawing.Size(112, 15);
            this.DestinationFolderLabel.TabIndex = 31;
            this.DestinationFolderLabel.Text = "Destination Folder : ";
            // 
            // BrowseButton
            // 
            this.BrowseButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrowseButton.Location = new System.Drawing.Point(677, 80);
            this.BrowseButton.Margin = new System.Windows.Forms.Padding(2);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(96, 25);
            this.BrowseButton.TabIndex = 32;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // DestinationFolder
            // 
            this.DestinationFolder.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DestinationFolder.Location = new System.Drawing.Point(146, 81);
            this.DestinationFolder.Margin = new System.Windows.Forms.Padding(2);
            this.DestinationFolder.Name = "DestinationFolder";
            this.DestinationFolder.ReadOnly = true;
            this.DestinationFolder.Size = new System.Drawing.Size(527, 23);
            this.DestinationFolder.TabIndex = 30;
            this.DestinationFolder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DestinationFolder_KeyDown);
            this.DestinationFolder.Leave += new System.EventHandler(this.DestinationFolder_Leave);
            // 
            // SourceFolder
            // 
            this.SourceFolder.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SourceFolder.Location = new System.Drawing.Point(146, 52);
            this.SourceFolder.Margin = new System.Windows.Forms.Padding(2);
            this.SourceFolder.Name = "SourceFolder";
            this.SourceFolder.ReadOnly = true;
            this.SourceFolder.Size = new System.Drawing.Size(527, 23);
            this.SourceFolder.TabIndex = 28;
            this.SourceFolder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SourceFolder_KeyDown);
            this.SourceFolder.Leave += new System.EventHandler(this.SourceFolder_Leave);
            // 
            // SourceFolderLabel
            // 
            this.SourceFolderLabel.AutoSize = true;
            this.SourceFolderLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SourceFolderLabel.Location = new System.Drawing.Point(18, 52);
            this.SourceFolderLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SourceFolderLabel.Name = "SourceFolderLabel";
            this.SourceFolderLabel.Size = new System.Drawing.Size(88, 15);
            this.SourceFolderLabel.TabIndex = 27;
            this.SourceFolderLabel.Text = "Source Folder : ";
            // 
            // TaskNameLabel
            // 
            this.TaskNameLabel.AutoSize = true;
            this.TaskNameLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaskNameLabel.Location = new System.Drawing.Point(18, 19);
            this.TaskNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TaskNameLabel.Name = "TaskNameLabel";
            this.TaskNameLabel.Size = new System.Drawing.Size(74, 15);
            this.TaskNameLabel.TabIndex = 25;
            this.TaskNameLabel.Text = "Task Name : ";
            // 
            // TaskName
            // 
            this.TaskName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaskName.Location = new System.Drawing.Point(146, 19);
            this.TaskName.Margin = new System.Windows.Forms.Padding(2);
            this.TaskName.Name = "TaskName";
            this.TaskName.Size = new System.Drawing.Size(216, 23);
            this.TaskName.TabIndex = 26;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ItemSize = new System.Drawing.Size(72, 20);
            this.tabControl1.Location = new System.Drawing.Point(11, 159);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(762, 363);
            this.tabControl1.TabIndex = 44;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.SelectAllButton);
            this.tabPage1.Controls.Add(this.SelectNoneButton);
            this.tabPage1.Controls.Add(this.FileExtensionDisplayFLP);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(754, 335);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "File Types";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // SelectAllButton
            // 
            this.SelectAllButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectAllButton.Location = new System.Drawing.Point(554, 306);
            this.SelectAllButton.Margin = new System.Windows.Forms.Padding(2);
            this.SelectAllButton.Name = "SelectAllButton";
            this.SelectAllButton.Size = new System.Drawing.Size(96, 25);
            this.SelectAllButton.TabIndex = 42;
            this.SelectAllButton.Text = "Select All";
            this.SelectAllButton.UseVisualStyleBackColor = true;
            this.SelectAllButton.Click += new System.EventHandler(this.SelectAllButton_Click);
            // 
            // SelectNoneButton
            // 
            this.SelectNoneButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectNoneButton.Location = new System.Drawing.Point(654, 306);
            this.SelectNoneButton.Margin = new System.Windows.Forms.Padding(2);
            this.SelectNoneButton.Name = "SelectNoneButton";
            this.SelectNoneButton.Size = new System.Drawing.Size(96, 25);
            this.SelectNoneButton.TabIndex = 43;
            this.SelectNoneButton.Text = "Select None";
            this.SelectNoneButton.UseVisualStyleBackColor = true;
            this.SelectNoneButton.Click += new System.EventHandler(this.SelectNoneButton_Click);
            // 
            // FileExtensionDisplayFLP
            // 
            this.FileExtensionDisplayFLP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileExtensionDisplayFLP.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileExtensionDisplayFLP.Location = new System.Drawing.Point(4, 4);
            this.FileExtensionDisplayFLP.Margin = new System.Windows.Forms.Padding(2);
            this.FileExtensionDisplayFLP.Name = "FileExtensionDisplayFLP";
            this.FileExtensionDisplayFLP.Size = new System.Drawing.Size(746, 298);
            this.FileExtensionDisplayFLP.TabIndex = 41;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.SelectNoneButtonAtt);
            this.tabPage2.Controls.Add(this.SelectAllButtonAtt);
            this.tabPage2.Controls.Add(this.FileAttributeFLP);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(754, 335);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "File Tags";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // SelectNoneButtonAtt
            // 
            this.SelectNoneButtonAtt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectNoneButtonAtt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectNoneButtonAtt.Location = new System.Drawing.Point(654, 306);
            this.SelectNoneButtonAtt.Margin = new System.Windows.Forms.Padding(2);
            this.SelectNoneButtonAtt.Name = "SelectNoneButtonAtt";
            this.SelectNoneButtonAtt.Size = new System.Drawing.Size(96, 25);
            this.SelectNoneButtonAtt.TabIndex = 46;
            this.SelectNoneButtonAtt.Text = "Select None";
            this.SelectNoneButtonAtt.UseVisualStyleBackColor = true;
            this.SelectNoneButtonAtt.Click += new System.EventHandler(this.SelectNoneButtonAtt_Click);
            // 
            // SelectAllButtonAtt
            // 
            this.SelectAllButtonAtt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectAllButtonAtt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectAllButtonAtt.Location = new System.Drawing.Point(554, 306);
            this.SelectAllButtonAtt.Margin = new System.Windows.Forms.Padding(2);
            this.SelectAllButtonAtt.Name = "SelectAllButtonAtt";
            this.SelectAllButtonAtt.Size = new System.Drawing.Size(96, 25);
            this.SelectAllButtonAtt.TabIndex = 45;
            this.SelectAllButtonAtt.Text = "Select All";
            this.SelectAllButtonAtt.UseVisualStyleBackColor = true;
            this.SelectAllButtonAtt.Click += new System.EventHandler(this.SelectAllButtonAtt_Click);
            // 
            // FileAttributeFLP
            // 
            this.FileAttributeFLP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileAttributeFLP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FileAttributeFLP.Location = new System.Drawing.Point(4, 4);
            this.FileAttributeFLP.Margin = new System.Windows.Forms.Padding(2);
            this.FileAttributeFLP.Name = "FileAttributeFLP";
            this.FileAttributeFLP.Size = new System.Drawing.Size(746, 298);
            this.FileAttributeFLP.TabIndex = 44;
            // 
            // TaskEnabledCheckBox
            // 
            this.TaskEnabledCheckBox.AutoSize = true;
            this.TaskEnabledCheckBox.Checked = true;
            this.TaskEnabledCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TaskEnabledCheckBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaskEnabledCheckBox.Location = new System.Drawing.Point(551, 22);
            this.TaskEnabledCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.TaskEnabledCheckBox.Name = "TaskEnabledCheckBox";
            this.TaskEnabledCheckBox.Size = new System.Drawing.Size(94, 19);
            this.TaskEnabledCheckBox.TabIndex = 45;
            this.TaskEnabledCheckBox.Text = "Task Enabled";
            this.TaskEnabledCheckBox.UseVisualStyleBackColor = true;
            // 
            // MatchCaseButton
            // 
            this.MatchCaseButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MatchCaseButton.Location = new System.Drawing.Point(677, 110);
            this.MatchCaseButton.Margin = new System.Windows.Forms.Padding(2);
            this.MatchCaseButton.Name = "MatchCaseButton";
            this.MatchCaseButton.Size = new System.Drawing.Size(96, 53);
            this.MatchCaseButton.TabIndex = 48;
            this.MatchCaseButton.Text = "Generate Match Case";
            this.MatchCaseButton.UseVisualStyleBackColor = true;
            this.MatchCaseButton.Click += new System.EventHandler(this.MatchCaseButton_Click);
            // 
            // RegexTextBox
            // 
            this.RegexTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegexTextBox.Location = new System.Drawing.Point(361, 112);
            this.RegexTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.RegexTextBox.Multiline = true;
            this.RegexTextBox.Name = "RegexTextBox";
            this.RegexTextBox.ReadOnly = true;
            this.RegexTextBox.Size = new System.Drawing.Size(312, 23);
            this.RegexTextBox.TabIndex = 47;
            // 
            // RegexLabel
            // 
            this.RegexLabel.AutoSize = true;
            this.RegexLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegexLabel.Location = new System.Drawing.Point(255, 115);
            this.RegexLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RegexLabel.Name = "RegexLabel";
            this.RegexLabel.Size = new System.Drawing.Size(100, 15);
            this.RegexLabel.TabIndex = 46;
            this.RegexLabel.Text = "File Name Regex :";
            // 
            // CreateTaskbtn
            // 
            this.CreateTaskbtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateTaskbtn.Location = new System.Drawing.Point(653, 526);
            this.CreateTaskbtn.Margin = new System.Windows.Forms.Padding(2);
            this.CreateTaskbtn.Name = "CreateTaskbtn";
            this.CreateTaskbtn.Size = new System.Drawing.Size(120, 25);
            this.CreateTaskbtn.TabIndex = 49;
            this.CreateTaskbtn.Text = "Create";
            this.CreateTaskbtn.UseVisualStyleBackColor = true;
            this.CreateTaskbtn.Click += new System.EventHandler(this.CreateTaskbtn_Click);
            // 
            // BrowseButton2
            // 
            this.BrowseButton2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrowseButton2.Location = new System.Drawing.Point(677, 51);
            this.BrowseButton2.Margin = new System.Windows.Forms.Padding(2);
            this.BrowseButton2.Name = "BrowseButton2";
            this.BrowseButton2.Size = new System.Drawing.Size(96, 25);
            this.BrowseButton2.TabIndex = 29;
            this.BrowseButton2.Text = "Browse";
            this.BrowseButton2.UseVisualStyleBackColor = true;
            this.BrowseButton2.Click += new System.EventHandler(this.BrowseButton2_Click);
            // 
            // TaskIDLabel
            // 
            this.TaskIDLabel.AutoSize = true;
            this.TaskIDLabel.Location = new System.Drawing.Point(674, 23);
            this.TaskIDLabel.Name = "TaskIDLabel";
            this.TaskIDLabel.Size = new System.Drawing.Size(27, 15);
            this.TaskIDLabel.TabIndex = 50;
            this.TaskIDLabel.Text = "ID : ";
            // 
            // FileNameTB
            // 
            this.FileNameTB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileNameTB.Location = new System.Drawing.Point(361, 139);
            this.FileNameTB.Margin = new System.Windows.Forms.Padding(2);
            this.FileNameTB.Multiline = true;
            this.FileNameTB.Name = "FileNameTB";
            this.FileNameTB.ReadOnly = true;
            this.FileNameTB.Size = new System.Drawing.Size(312, 23);
            this.FileNameTB.TabIndex = 52;
            // 
            // FileNameFormatLabel
            // 
            this.FileNameFormatLabel.AutoSize = true;
            this.FileNameFormatLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileNameFormatLabel.Location = new System.Drawing.Point(255, 142);
            this.FileNameFormatLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.FileNameFormatLabel.Name = "FileNameFormatLabel";
            this.FileNameFormatLabel.Size = new System.Drawing.Size(107, 15);
            this.FileNameFormatLabel.TabIndex = 51;
            this.FileNameFormatLabel.Text = "File Name Format :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(367, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 53;
            this.label1.Text = "Perform : ";
            // 
            // PerformTypeComboBox
            // 
            this.PerformTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PerformTypeComboBox.FormattingEnabled = true;
            this.PerformTypeComboBox.Items.AddRange(new object[] {
            "Copy",
            "Move",
            "Rename",
            "Delete"});
            this.PerformTypeComboBox.Location = new System.Drawing.Point(422, 19);
            this.PerformTypeComboBox.Name = "PerformTypeComboBox";
            this.PerformTypeComboBox.Size = new System.Drawing.Size(121, 23);
            this.PerformTypeComboBox.TabIndex = 54;
            // 
            // DeleteTaskButton
            // 
            this.DeleteTaskButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteTaskButton.Location = new System.Drawing.Point(529, 526);
            this.DeleteTaskButton.Margin = new System.Windows.Forms.Padding(2);
            this.DeleteTaskButton.Name = "DeleteTaskButton";
            this.DeleteTaskButton.Size = new System.Drawing.Size(120, 25);
            this.DeleteTaskButton.TabIndex = 55;
            this.DeleteTaskButton.Text = "Delete Task";
            this.DeleteTaskButton.UseVisualStyleBackColor = true;
            this.DeleteTaskButton.Click += new System.EventHandler(this.DeleteTaskButton_Click);
            // 
            // TaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.DeleteTaskButton);
            this.Controls.Add(this.PerformTypeComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FileNameTB);
            this.Controls.Add(this.FileNameFormatLabel);
            this.Controls.Add(this.TaskIDLabel);
            this.Controls.Add(this.CreateTaskbtn);
            this.Controls.Add(this.MatchCaseButton);
            this.Controls.Add(this.RegexTextBox);
            this.Controls.Add(this.RegexLabel);
            this.Controls.Add(this.TaskEnabledCheckBox);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.FileTypeCB);
            this.Controls.Add(this.FileTypeLabel);
            this.Controls.Add(this.DestinationFolderLabel);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.DestinationFolder);
            this.Controls.Add(this.BrowseButton2);
            this.Controls.Add(this.SourceFolder);
            this.Controls.Add(this.SourceFolderLabel);
            this.Controls.Add(this.TaskNameLabel);
            this.Controls.Add(this.TaskName);
            this.Controls.Add(this.CancelTaskbtn);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "TaskForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tasks";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button CancelTaskbtn;
        private System.Windows.Forms.ComboBox FileTypeCB;
        private System.Windows.Forms.Label FileTypeLabel;
        private System.Windows.Forms.Label DestinationFolderLabel;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.TextBox DestinationFolder;
        private System.Windows.Forms.TextBox SourceFolder;
        private System.Windows.Forms.Label SourceFolderLabel;
        private System.Windows.Forms.Label TaskNameLabel;
        private System.Windows.Forms.TextBox TaskName;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button SelectNoneButton;
        private System.Windows.Forms.Button SelectAllButton;
        private System.Windows.Forms.FlowLayoutPanel FileExtensionDisplayFLP;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button SelectNoneButtonAtt;
        private System.Windows.Forms.Button SelectAllButtonAtt;
        private System.Windows.Forms.FlowLayoutPanel FileAttributeFLP;
        private System.Windows.Forms.CheckBox TaskEnabledCheckBox;
        private System.Windows.Forms.Button MatchCaseButton;
        private System.Windows.Forms.TextBox RegexTextBox;
        private System.Windows.Forms.Label RegexLabel;
        private System.Windows.Forms.Button CreateTaskbtn;
        private System.Windows.Forms.Button BrowseButton2;
        private System.Windows.Forms.Label TaskIDLabel;
        private System.Windows.Forms.TextBox FileNameTB;
        private System.Windows.Forms.Label FileNameFormatLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox PerformTypeComboBox;
        private System.Windows.Forms.FolderBrowserDialog SourceFolderDialog;
        private System.Windows.Forms.FolderBrowserDialog DestinationFolderDialog;
        private System.Windows.Forms.Button DeleteTaskButton;
    }
}

