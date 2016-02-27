namespace FileOrganizerMain {
    partial class Main {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.GroupsGroupBox = new System.Windows.Forms.GroupBox();
            this.GroupsFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.OptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.SortByComboBox = new System.Windows.Forms.ComboBox();
            this.SortByLabel = new System.Windows.Forms.Label();
            this.StartStopServiceButtion = new System.Windows.Forms.Button();
            this.AboutButton = new System.Windows.Forms.Button();
            this.CreateGroupButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.GroupsGroupBox.SuspendLayout();
            this.OptionsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupsGroupBox
            // 
            this.GroupsGroupBox.Controls.Add(this.GroupsFlowPanel);
            this.GroupsGroupBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupsGroupBox.Location = new System.Drawing.Point(12, 71);
            this.GroupsGroupBox.Name = "GroupsGroupBox";
            this.GroupsGroupBox.Size = new System.Drawing.Size(759, 478);
            this.GroupsGroupBox.TabIndex = 0;
            this.GroupsGroupBox.TabStop = false;
            this.GroupsGroupBox.Text = "Groups";
            // 
            // GroupsFlowPanel
            // 
            this.GroupsFlowPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupsFlowPanel.AutoScroll = true;
            this.GroupsFlowPanel.Location = new System.Drawing.Point(6, 22);
            this.GroupsFlowPanel.Name = "GroupsFlowPanel";
            this.GroupsFlowPanel.Size = new System.Drawing.Size(747, 449);
            this.GroupsFlowPanel.TabIndex = 0;
            // 
            // OptionsGroupBox
            // 
            this.OptionsGroupBox.Controls.Add(this.label1);
            this.OptionsGroupBox.Controls.Add(this.SortByComboBox);
            this.OptionsGroupBox.Controls.Add(this.SortByLabel);
            this.OptionsGroupBox.Controls.Add(this.StartStopServiceButtion);
            this.OptionsGroupBox.Controls.Add(this.AboutButton);
            this.OptionsGroupBox.Controls.Add(this.CreateGroupButton);
            this.OptionsGroupBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OptionsGroupBox.Location = new System.Drawing.Point(12, 12);
            this.OptionsGroupBox.Name = "OptionsGroupBox";
            this.OptionsGroupBox.Size = new System.Drawing.Size(759, 53);
            this.OptionsGroupBox.TabIndex = 1;
            this.OptionsGroupBox.TabStop = false;
            this.OptionsGroupBox.Text = "Options";
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
            "Time",
            "Day",
            "Interval"});
            this.SortByComboBox.Location = new System.Drawing.Point(528, 22);
            this.SortByComboBox.Name = "SortByComboBox";
            this.SortByComboBox.Size = new System.Drawing.Size(121, 23);
            this.SortByComboBox.TabIndex = 3;
            this.SortByComboBox.SelectedIndexChanged += new System.EventHandler(this.SortByComboBoxSelectedIndexChanged);
            // 
            // SortByLabel
            // 
            this.SortByLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SortByLabel.AutoSize = true;
            this.SortByLabel.Enabled = false;
            this.SortByLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SortByLabel.Location = new System.Drawing.Point(474, 25);
            this.SortByLabel.Name = "SortByLabel";
            this.SortByLabel.Size = new System.Drawing.Size(53, 15);
            this.SortByLabel.TabIndex = 2;
            this.SortByLabel.Text = "Sort By : ";
            // 
            // StartStopServiceButtion
            // 
            this.StartStopServiceButtion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartStopServiceButtion.Location = new System.Drawing.Point(110, 20);
            this.StartStopServiceButtion.Name = "StartStopServiceButtion";
            this.StartStopServiceButtion.Size = new System.Drawing.Size(97, 25);
            this.StartStopServiceButtion.TabIndex = 2;
            this.StartStopServiceButtion.Text = "Start Service";
            this.StartStopServiceButtion.UseVisualStyleBackColor = true;
            this.StartStopServiceButtion.Click += new System.EventHandler(this.StartStopServiceButtionClick);
            // 
            // AboutButton
            // 
            this.AboutButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AboutButton.Location = new System.Drawing.Point(655, 20);
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Size = new System.Drawing.Size(97, 25);
            this.AboutButton.TabIndex = 1;
            this.AboutButton.Text = "About";
            this.AboutButton.UseVisualStyleBackColor = true;
            this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // CreateGroupButton
            // 
            this.CreateGroupButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateGroupButton.Location = new System.Drawing.Point(7, 20);
            this.CreateGroupButton.Name = "CreateGroupButton";
            this.CreateGroupButton.Size = new System.Drawing.Size(97, 25);
            this.CreateGroupButton.TabIndex = 0;
            this.CreateGroupButton.Text = "Create Group";
            this.CreateGroupButton.UseVisualStyleBackColor = true;
            this.CreateGroupButton.Click += new System.EventHandler(this.CreateGroupButtonClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.Location = new System.Drawing.Point(234, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Right Click On The Group To Execute It";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.OptionsGroupBox);
            this.Controls.Add(this.GroupsGroupBox);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Organizer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormClosing);
            this.GroupsGroupBox.ResumeLayout(false);
            this.OptionsGroupBox.ResumeLayout(false);
            this.OptionsGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupsGroupBox;
        private System.Windows.Forms.FlowLayoutPanel GroupsFlowPanel;
        private System.Windows.Forms.GroupBox OptionsGroupBox;
        private System.Windows.Forms.Button CreateGroupButton;
        private System.Windows.Forms.Button AboutButton;
        private System.Windows.Forms.Button StartStopServiceButtion;
        private System.Windows.Forms.Label SortByLabel;
        private System.Windows.Forms.ComboBox SortByComboBox;
        private System.Windows.Forms.Label label1;
    }
}