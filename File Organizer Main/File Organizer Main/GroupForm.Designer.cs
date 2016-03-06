namespace FileOrganizerMain {
    partial class GroupForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GroupForm));
            this.NameLabel = new System.Windows.Forms.Label();
            this.GroupDetailsGroupBox = new System.Windows.Forms.GroupBox();
            this.GroupIDLabel = new System.Windows.Forms.Label();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.ScheduleGroupBox = new System.Windows.Forms.GroupBox();
            this.MinutesLabel = new System.Windows.Forms.Label();
            this.TimeSeparatorLabel = new System.Windows.Forms.Label();
            this.MinuteTextBox = new System.Windows.Forms.TextBox();
            this.HourTextBox = new System.Windows.Forms.TextBox();
            this.IntervalTextBox = new System.Windows.Forms.TextBox();
            this.IntervalComboBox = new System.Windows.Forms.ComboBox();
            this.IntervalLabel = new System.Windows.Forms.Label();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.DayComboBox = new System.Windows.Forms.ComboBox();
            this.OccurrenceComboBox = new System.Windows.Forms.ComboBox();
            this.DayLabel = new System.Windows.Forms.Label();
            this.OccurrenceLabel = new System.Windows.Forms.Label();
            this.EnabledComboBox = new System.Windows.Forms.ComboBox();
            this.EnabledLabel = new System.Windows.Forms.Label();
            this.PathTextBox = new System.Windows.Forms.TextBox();
            this.PathLabel = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.TasksGroupBox = new System.Windows.Forms.GroupBox();
            this.SortByComboBox = new System.Windows.Forms.ComboBox();
            this.SortByLabel = new System.Windows.Forms.Label();
            this.TaskTemplatesButton = new System.Windows.Forms.Button();
            this.TotalTasksLabel = new System.Windows.Forms.Label();
            this.AddTaskButton = new System.Windows.Forms.Button();
            this.TasksFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.CreateSaveGroupButton = new System.Windows.Forms.Button();
            this.CancelCloseButton = new System.Windows.Forms.Button();
            this.GroupFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.DeleteGroup = new System.Windows.Forms.Button();
            this.GroupDetailsGroupBox.SuspendLayout();
            this.ScheduleGroupBox.SuspendLayout();
            this.TasksGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLabel.Location = new System.Drawing.Point(6, 25);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(48, 15);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Name : ";
            // 
            // GroupDetailsGroupBox
            // 
            this.GroupDetailsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupDetailsGroupBox.Controls.Add(this.GroupIDLabel);
            this.GroupDetailsGroupBox.Controls.Add(this.BrowseButton);
            this.GroupDetailsGroupBox.Controls.Add(this.ScheduleGroupBox);
            this.GroupDetailsGroupBox.Controls.Add(this.EnabledComboBox);
            this.GroupDetailsGroupBox.Controls.Add(this.EnabledLabel);
            this.GroupDetailsGroupBox.Controls.Add(this.PathTextBox);
            this.GroupDetailsGroupBox.Controls.Add(this.PathLabel);
            this.GroupDetailsGroupBox.Controls.Add(this.NameTextBox);
            this.GroupDetailsGroupBox.Controls.Add(this.NameLabel);
            this.GroupDetailsGroupBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupDetailsGroupBox.Location = new System.Drawing.Point(12, 12);
            this.GroupDetailsGroupBox.Name = "GroupDetailsGroupBox";
            this.GroupDetailsGroupBox.Size = new System.Drawing.Size(760, 133);
            this.GroupDetailsGroupBox.TabIndex = 0;
            this.GroupDetailsGroupBox.TabStop = false;
            this.GroupDetailsGroupBox.Text = "Group Details";
            // 
            // GroupIDLabel
            // 
            this.GroupIDLabel.AutoSize = true;
            this.GroupIDLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupIDLabel.Location = new System.Drawing.Point(339, 25);
            this.GroupIDLabel.Name = "GroupIDLabel";
            this.GroupIDLabel.Size = new System.Drawing.Size(27, 15);
            this.GroupIDLabel.TabIndex = 8;
            this.GroupIDLabel.Text = "ID : ";
            // 
            // BrowseButton
            // 
            this.BrowseButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrowseButton.Location = new System.Drawing.Point(372, 80);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(75, 25);
            this.BrowseButton.TabIndex = 7;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButtonClick);
            // 
            // ScheduleGroupBox
            // 
            this.ScheduleGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScheduleGroupBox.Controls.Add(this.MinutesLabel);
            this.ScheduleGroupBox.Controls.Add(this.TimeSeparatorLabel);
            this.ScheduleGroupBox.Controls.Add(this.MinuteTextBox);
            this.ScheduleGroupBox.Controls.Add(this.HourTextBox);
            this.ScheduleGroupBox.Controls.Add(this.IntervalTextBox);
            this.ScheduleGroupBox.Controls.Add(this.IntervalComboBox);
            this.ScheduleGroupBox.Controls.Add(this.IntervalLabel);
            this.ScheduleGroupBox.Controls.Add(this.TimeLabel);
            this.ScheduleGroupBox.Controls.Add(this.DayComboBox);
            this.ScheduleGroupBox.Controls.Add(this.OccurrenceComboBox);
            this.ScheduleGroupBox.Controls.Add(this.DayLabel);
            this.ScheduleGroupBox.Controls.Add(this.OccurrenceLabel);
            this.ScheduleGroupBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScheduleGroupBox.Location = new System.Drawing.Point(453, 16);
            this.ScheduleGroupBox.Name = "ScheduleGroupBox";
            this.ScheduleGroupBox.Size = new System.Drawing.Size(301, 111);
            this.ScheduleGroupBox.TabIndex = 6;
            this.ScheduleGroupBox.TabStop = false;
            this.ScheduleGroupBox.Text = "Schedule";
            // 
            // MinutesLabel
            // 
            this.MinutesLabel.AutoSize = true;
            this.MinutesLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinutesLabel.Location = new System.Drawing.Point(135, 84);
            this.MinutesLabel.Name = "MinutesLabel";
            this.MinutesLabel.Size = new System.Drawing.Size(58, 15);
            this.MinutesLabel.TabIndex = 17;
            this.MinutesLabel.Text = "Minute(s)";
            // 
            // TimeSeparatorLabel
            // 
            this.TimeSeparatorLabel.AutoSize = true;
            this.TimeSeparatorLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeSeparatorLabel.Location = new System.Drawing.Point(221, 54);
            this.TimeSeparatorLabel.Name = "TimeSeparatorLabel";
            this.TimeSeparatorLabel.Size = new System.Drawing.Size(10, 15);
            this.TimeSeparatorLabel.TabIndex = 16;
            this.TimeSeparatorLabel.Text = ":";
            // 
            // MinuteTextBox
            // 
            this.MinuteTextBox.Enabled = false;
            this.MinuteTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinuteTextBox.Location = new System.Drawing.Point(231, 51);
            this.MinuteTextBox.MaxLength = 2;
            this.MinuteTextBox.Name = "MinuteTextBox";
            this.MinuteTextBox.Size = new System.Drawing.Size(26, 23);
            this.MinuteTextBox.TabIndex = 15;
            this.MinuteTextBox.TextChanged += new System.EventHandler(this.MinuteTextBoxTextChanged);
            this.MinuteTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MinuteTextBoxKeyDown);
            // 
            // HourTextBox
            // 
            this.HourTextBox.Enabled = false;
            this.HourTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HourTextBox.Location = new System.Drawing.Point(193, 51);
            this.HourTextBox.MaxLength = 2;
            this.HourTextBox.Name = "HourTextBox";
            this.HourTextBox.Size = new System.Drawing.Size(26, 23);
            this.HourTextBox.TabIndex = 14;
            this.HourTextBox.TextChanged += new System.EventHandler(this.HourTextBoxTextChanged);
            this.HourTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HourTextBoxKeyDown);
            // 
            // IntervalTextBox
            // 
            this.IntervalTextBox.Enabled = false;
            this.IntervalTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.IntervalTextBox.Location = new System.Drawing.Point(58, 80);
            this.IntervalTextBox.Name = "IntervalTextBox";
            this.IntervalTextBox.Size = new System.Drawing.Size(74, 23);
            this.IntervalTextBox.TabIndex = 7;
            // 
            // IntervalComboBox
            // 
            this.IntervalComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.IntervalComboBox.Enabled = false;
            this.IntervalComboBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IntervalComboBox.FormattingEnabled = true;
            this.IntervalComboBox.Items.AddRange(new object[] {
            "Minute(s)",
            "Hour(s)",
            "Day(s)",
            "Week(s)"});
            this.IntervalComboBox.Location = new System.Drawing.Point(138, 80);
            this.IntervalComboBox.Name = "IntervalComboBox";
            this.IntervalComboBox.Size = new System.Drawing.Size(81, 23);
            this.IntervalComboBox.TabIndex = 13;
            this.IntervalComboBox.Visible = false;
            // 
            // IntervalLabel
            // 
            this.IntervalLabel.AutoSize = true;
            this.IntervalLabel.Enabled = false;
            this.IntervalLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IntervalLabel.Location = new System.Drawing.Point(7, 83);
            this.IntervalLabel.Name = "IntervalLabel";
            this.IntervalLabel.Size = new System.Drawing.Size(55, 15);
            this.IntervalLabel.TabIndex = 11;
            this.IntervalLabel.Text = "Interval : ";
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Enabled = false;
            this.TimeLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeLabel.Location = new System.Drawing.Point(154, 54);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(43, 15);
            this.TimeLabel.TabIndex = 9;
            this.TimeLabel.Text = "Time : ";
            // 
            // DayComboBox
            // 
            this.DayComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DayComboBox.Enabled = false;
            this.DayComboBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DayComboBox.FormattingEnabled = true;
            this.DayComboBox.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
            this.DayComboBox.Location = new System.Drawing.Point(38, 51);
            this.DayComboBox.Name = "DayComboBox";
            this.DayComboBox.Size = new System.Drawing.Size(100, 23);
            this.DayComboBox.TabIndex = 8;
            this.DayComboBox.SelectedIndexChanged += new System.EventHandler(this.DayComboBoxSelectedIndexChanged);
            // 
            // OccurrenceComboBox
            // 
            this.OccurrenceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OccurrenceComboBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OccurrenceComboBox.FormattingEnabled = true;
            this.OccurrenceComboBox.Items.AddRange(new object[] {
            "Weekly",
            "Daily",
            "Interval"});
            this.OccurrenceComboBox.Location = new System.Drawing.Point(79, 22);
            this.OccurrenceComboBox.Name = "OccurrenceComboBox";
            this.OccurrenceComboBox.Size = new System.Drawing.Size(100, 23);
            this.OccurrenceComboBox.TabIndex = 7;
            this.OccurrenceComboBox.SelectedIndexChanged += new System.EventHandler(this.OccurrenceComboBoxSelectedIndexChanged);
            // 
            // DayLabel
            // 
            this.DayLabel.AutoSize = true;
            this.DayLabel.Enabled = false;
            this.DayLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DayLabel.Location = new System.Drawing.Point(6, 54);
            this.DayLabel.Name = "DayLabel";
            this.DayLabel.Size = new System.Drawing.Size(36, 15);
            this.DayLabel.TabIndex = 2;
            this.DayLabel.Text = "Day : ";
            // 
            // OccurrenceLabel
            // 
            this.OccurrenceLabel.AutoSize = true;
            this.OccurrenceLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OccurrenceLabel.Location = new System.Drawing.Point(6, 25);
            this.OccurrenceLabel.Name = "OccurrenceLabel";
            this.OccurrenceLabel.Size = new System.Drawing.Size(77, 15);
            this.OccurrenceLabel.TabIndex = 0;
            this.OccurrenceLabel.Text = "Occurrence : ";
            // 
            // EnabledComboBox
            // 
            this.EnabledComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EnabledComboBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnabledComboBox.FormattingEnabled = true;
            this.EnabledComboBox.Items.AddRange(new object[] {
            "True",
            "False"});
            this.EnabledComboBox.Location = new System.Drawing.Point(60, 103);
            this.EnabledComboBox.Name = "EnabledComboBox";
            this.EnabledComboBox.Size = new System.Drawing.Size(100, 23);
            this.EnabledComboBox.TabIndex = 5;
            // 
            // EnabledLabel
            // 
            this.EnabledLabel.AutoSize = true;
            this.EnabledLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnabledLabel.Location = new System.Drawing.Point(6, 106);
            this.EnabledLabel.Name = "EnabledLabel";
            this.EnabledLabel.Size = new System.Drawing.Size(58, 15);
            this.EnabledLabel.TabIndex = 4;
            this.EnabledLabel.Text = "Enabled : ";
            // 
            // PathTextBox
            // 
            this.PathTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.PathTextBox.Location = new System.Drawing.Point(69, 51);
            this.PathTextBox.Name = "PathTextBox";
            this.PathTextBox.Size = new System.Drawing.Size(378, 23);
            this.PathTextBox.TabIndex = 3;
            this.PathTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PathTextBoxKeyDown);
            this.PathTextBox.Leave += new System.EventHandler(this.PathTextBoxLeave);
            // 
            // PathLabel
            // 
            this.PathLabel.AutoSize = true;
            this.PathLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PathLabel.Location = new System.Drawing.Point(6, 54);
            this.PathLabel.Name = "PathLabel";
            this.PathLabel.Size = new System.Drawing.Size(64, 15);
            this.PathLabel.TabIndex = 2;
            this.PathLabel.Text = "XML Path :";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameTextBox.Location = new System.Drawing.Point(51, 22);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(282, 23);
            this.NameTextBox.TabIndex = 1;
            this.NameTextBox.TextChanged += new System.EventHandler(this.NameTextBoxTextChanged);
            this.NameTextBox.Leave += new System.EventHandler(this.NameTextBoxLeave);
            // 
            // TasksGroupBox
            // 
            this.TasksGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TasksGroupBox.Controls.Add(this.SortByComboBox);
            this.TasksGroupBox.Controls.Add(this.SortByLabel);
            this.TasksGroupBox.Controls.Add(this.TaskTemplatesButton);
            this.TasksGroupBox.Controls.Add(this.TotalTasksLabel);
            this.TasksGroupBox.Controls.Add(this.AddTaskButton);
            this.TasksGroupBox.Controls.Add(this.TasksFlowPanel);
            this.TasksGroupBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TasksGroupBox.Location = new System.Drawing.Point(12, 151);
            this.TasksGroupBox.Name = "TasksGroupBox";
            this.TasksGroupBox.Size = new System.Drawing.Size(760, 365);
            this.TasksGroupBox.TabIndex = 8;
            this.TasksGroupBox.TabStop = false;
            this.TasksGroupBox.Text = "Tasks";
            // 
            // SortByComboBox
            // 
            this.SortByComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SortByComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SortByComboBox.Enabled = false;
            this.SortByComboBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SortByComboBox.FormattingEnabled = true;
            this.SortByComboBox.Items.AddRange(new object[] {
            "ID",
            "Name",
            "Perform"});
            this.SortByComboBox.Location = new System.Drawing.Point(510, 19);
            this.SortByComboBox.Name = "SortByComboBox";
            this.SortByComboBox.Size = new System.Drawing.Size(121, 23);
            this.SortByComboBox.TabIndex = 9;
            this.SortByComboBox.SelectedIndexChanged += new System.EventHandler(this.SortByComboBoxSelectedIndexChanged);
            // 
            // SortByLabel
            // 
            this.SortByLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SortByLabel.AutoSize = true;
            this.SortByLabel.Enabled = false;
            this.SortByLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SortByLabel.Location = new System.Drawing.Point(456, 22);
            this.SortByLabel.Name = "SortByLabel";
            this.SortByLabel.Size = new System.Drawing.Size(53, 15);
            this.SortByLabel.TabIndex = 8;
            this.SortByLabel.Text = "Sort By : ";
            // 
            // TaskTemplatesButton
            // 
            this.TaskTemplatesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TaskTemplatesButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaskTemplatesButton.Location = new System.Drawing.Point(309, 18);
            this.TaskTemplatesButton.Name = "TaskTemplatesButton";
            this.TaskTemplatesButton.Size = new System.Drawing.Size(141, 25);
            this.TaskTemplatesButton.TabIndex = 9;
            this.TaskTemplatesButton.Text = "Use Task Templates";
            this.TaskTemplatesButton.UseVisualStyleBackColor = true;
            this.TaskTemplatesButton.Visible = false;
            // 
            // TotalTasksLabel
            // 
            this.TotalTasksLabel.AutoSize = true;
            this.TotalTasksLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalTasksLabel.Location = new System.Drawing.Point(6, 28);
            this.TotalTasksLabel.Name = "TotalTasksLabel";
            this.TotalTasksLabel.Size = new System.Drawing.Size(73, 15);
            this.TotalTasksLabel.TabIndex = 8;
            this.TotalTasksLabel.Text = "Total Tasks : ";
            // 
            // AddTaskButton
            // 
            this.AddTaskButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddTaskButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddTaskButton.Location = new System.Drawing.Point(637, 18);
            this.AddTaskButton.Name = "AddTaskButton";
            this.AddTaskButton.Size = new System.Drawing.Size(91, 25);
            this.AddTaskButton.TabIndex = 8;
            this.AddTaskButton.Text = "Add Task";
            this.AddTaskButton.UseVisualStyleBackColor = true;
            this.AddTaskButton.Click += new System.EventHandler(this.AddTaskButtonClick);
            // 
            // TasksFlowPanel
            // 
            this.TasksFlowPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TasksFlowPanel.Location = new System.Drawing.Point(6, 49);
            this.TasksFlowPanel.Name = "TasksFlowPanel";
            this.TasksFlowPanel.Size = new System.Drawing.Size(748, 310);
            this.TasksFlowPanel.TabIndex = 0;
            // 
            // CreateSaveGroupButton
            // 
            this.CreateSaveGroupButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateSaveGroupButton.Enabled = false;
            this.CreateSaveGroupButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateSaveGroupButton.Location = new System.Drawing.Point(658, 522);
            this.CreateSaveGroupButton.Name = "CreateSaveGroupButton";
            this.CreateSaveGroupButton.Size = new System.Drawing.Size(114, 27);
            this.CreateSaveGroupButton.TabIndex = 9;
            this.CreateSaveGroupButton.Text = "Create Group";
            this.CreateSaveGroupButton.UseVisualStyleBackColor = true;
            this.CreateSaveGroupButton.Click += new System.EventHandler(this.CreateSaveGroupButtonClick);
            // 
            // CancelCloseButton
            // 
            this.CancelCloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelCloseButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelCloseButton.Location = new System.Drawing.Point(12, 522);
            this.CancelCloseButton.Name = "CancelCloseButton";
            this.CancelCloseButton.Size = new System.Drawing.Size(114, 27);
            this.CancelCloseButton.TabIndex = 10;
            this.CancelCloseButton.Text = "Cancel";
            this.CancelCloseButton.UseVisualStyleBackColor = true;
            this.CancelCloseButton.Click += new System.EventHandler(this.CancelCloseButtonClick);
            // 
            // DeleteGroup
            // 
            this.DeleteGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteGroup.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteGroup.Location = new System.Drawing.Point(538, 522);
            this.DeleteGroup.Name = "DeleteGroup";
            this.DeleteGroup.Size = new System.Drawing.Size(114, 27);
            this.DeleteGroup.TabIndex = 11;
            this.DeleteGroup.Text = "Delete Group";
            this.DeleteGroup.UseVisualStyleBackColor = true;
            this.DeleteGroup.Click += new System.EventHandler(this.DeleteGroupClick);
            // 
            // GroupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.DeleteGroup);
            this.Controls.Add(this.CancelCloseButton);
            this.Controls.Add(this.CreateSaveGroupButton);
            this.Controls.Add(this.TasksGroupBox);
            this.Controls.Add(this.GroupDetailsGroupBox);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GroupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Group";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GroupFormFormClosing);
            this.GroupDetailsGroupBox.ResumeLayout(false);
            this.GroupDetailsGroupBox.PerformLayout();
            this.ScheduleGroupBox.ResumeLayout(false);
            this.ScheduleGroupBox.PerformLayout();
            this.TasksGroupBox.ResumeLayout(false);
            this.TasksGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.GroupBox GroupDetailsGroupBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label EnabledLabel;
        private System.Windows.Forms.TextBox PathTextBox;
        private System.Windows.Forms.Label PathLabel;
        private System.Windows.Forms.ComboBox EnabledComboBox;
        private System.Windows.Forms.GroupBox ScheduleGroupBox;
        private System.Windows.Forms.Label DayLabel;
        private System.Windows.Forms.Label OccurrenceLabel;
        private System.Windows.Forms.ComboBox OccurrenceComboBox;
        private System.Windows.Forms.ComboBox DayComboBox;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.Label IntervalLabel;
        private System.Windows.Forms.ComboBox IntervalComboBox;
        private System.Windows.Forms.TextBox IntervalTextBox;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.TextBox MinuteTextBox;
        private System.Windows.Forms.TextBox HourTextBox;
        private System.Windows.Forms.Label TimeSeparatorLabel;
        private System.Windows.Forms.GroupBox TasksGroupBox;
        private System.Windows.Forms.FlowLayoutPanel TasksFlowPanel;
        private System.Windows.Forms.Button AddTaskButton;
        private System.Windows.Forms.Label TotalTasksLabel;
        private System.Windows.Forms.Button CreateSaveGroupButton;
        private System.Windows.Forms.Button CancelCloseButton;
        private System.Windows.Forms.Button TaskTemplatesButton;
        private System.Windows.Forms.ComboBox SortByComboBox;
        private System.Windows.Forms.Label SortByLabel;
        private System.Windows.Forms.Label GroupIDLabel;
        private System.Windows.Forms.SaveFileDialog GroupFileDialog;
        private System.Windows.Forms.Label MinutesLabel;
        private System.Windows.Forms.Button DeleteGroup;
    }
}