namespace MatchCaseNameSpace {
    partial class MatchCase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MatchCase));
            this.MatchCaseGroup = new System.Windows.Forms.GroupBox();
            this.DefaultAndAdvancedTab = new System.Windows.Forms.TabControl();
            this.Default = new System.Windows.Forms.TabPage();
            this.NotAlphabet = new System.Windows.Forms.Button();
            this.NotDigit = new System.Windows.Forms.Button();
            this.Alphabets = new System.Windows.Forms.Button();
            this.StringCollection = new System.Windows.Forms.FlowLayoutPanel();
            this.Digit = new System.Windows.Forms.Button();
            this.String = new System.Windows.Forms.Button();
            this.UserInputString = new System.Windows.Forms.Button();
            this.Advanced = new System.Windows.Forms.TabPage();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.UserRegexBox = new System.Windows.Forms.TextBox();
            this.Regex_Label = new System.Windows.Forms.Label();
            this.DoneExit = new System.Windows.Forms.Button();
            this.MatchCaseGroup.SuspendLayout();
            this.DefaultAndAdvancedTab.SuspendLayout();
            this.Default.SuspendLayout();
            this.Advanced.SuspendLayout();
            this.SuspendLayout();
            // 
            // MatchCaseGroup
            // 
            this.MatchCaseGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MatchCaseGroup.Controls.Add(this.DefaultAndAdvancedTab);
            this.MatchCaseGroup.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MatchCaseGroup.Location = new System.Drawing.Point(9, 11);
            this.MatchCaseGroup.Margin = new System.Windows.Forms.Padding(2);
            this.MatchCaseGroup.Name = "MatchCaseGroup";
            this.MatchCaseGroup.Padding = new System.Windows.Forms.Padding(2);
            this.MatchCaseGroup.Size = new System.Drawing.Size(764, 310);
            this.MatchCaseGroup.TabIndex = 0;
            this.MatchCaseGroup.TabStop = false;
            this.MatchCaseGroup.Text = "Match Case";
            // 
            // DefaultAndAdvancedTab
            // 
            this.DefaultAndAdvancedTab.Controls.Add(this.Default);
            this.DefaultAndAdvancedTab.Controls.Add(this.Advanced);
            this.DefaultAndAdvancedTab.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DefaultAndAdvancedTab.Location = new System.Drawing.Point(4, 20);
            this.DefaultAndAdvancedTab.Margin = new System.Windows.Forms.Padding(2);
            this.DefaultAndAdvancedTab.Name = "DefaultAndAdvancedTab";
            this.DefaultAndAdvancedTab.SelectedIndex = 0;
            this.DefaultAndAdvancedTab.Size = new System.Drawing.Size(758, 286);
            this.DefaultAndAdvancedTab.TabIndex = 0;
            // 
            // Default
            // 
            this.Default.Controls.Add(this.NotAlphabet);
            this.Default.Controls.Add(this.NotDigit);
            this.Default.Controls.Add(this.Alphabets);
            this.Default.Controls.Add(this.StringCollection);
            this.Default.Controls.Add(this.Digit);
            this.Default.Controls.Add(this.String);
            this.Default.Controls.Add(this.UserInputString);
            this.Default.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Default.Location = new System.Drawing.Point(4, 24);
            this.Default.Margin = new System.Windows.Forms.Padding(2);
            this.Default.Name = "Default";
            this.Default.Padding = new System.Windows.Forms.Padding(2);
            this.Default.Size = new System.Drawing.Size(750, 258);
            this.Default.TabIndex = 0;
            this.Default.Text = "Default";
            this.Default.UseVisualStyleBackColor = true;
            // 
            // NotAlphabet
            // 
            this.NotAlphabet.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.NotAlphabet.Location = new System.Drawing.Point(500, 4);
            this.NotAlphabet.Margin = new System.Windows.Forms.Padding(2);
            this.NotAlphabet.Name = "NotAlphabet";
            this.NotAlphabet.Size = new System.Drawing.Size(120, 25);
            this.NotAlphabet.TabIndex = 6;
            this.NotAlphabet.Text = "Not Alphabet";
            this.NotAlphabet.UseVisualStyleBackColor = true;
            this.NotAlphabet.Click += new System.EventHandler(this.NotAlphabet_Click);
            // 
            // NotDigit
            // 
            this.NotDigit.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.NotDigit.Location = new System.Drawing.Point(624, 4);
            this.NotDigit.Margin = new System.Windows.Forms.Padding(2);
            this.NotDigit.Name = "NotDigit";
            this.NotDigit.Size = new System.Drawing.Size(120, 25);
            this.NotDigit.TabIndex = 5;
            this.NotDigit.Text = "Not Digit";
            this.NotDigit.UseVisualStyleBackColor = true;
            this.NotDigit.Click += new System.EventHandler(this.NotNumber_Click);
            // 
            // Alphabets
            // 
            this.Alphabets.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.Alphabets.Location = new System.Drawing.Point(128, 4);
            this.Alphabets.Margin = new System.Windows.Forms.Padding(2);
            this.Alphabets.Name = "Alphabets";
            this.Alphabets.Size = new System.Drawing.Size(120, 25);
            this.Alphabets.TabIndex = 4;
            this.Alphabets.Text = "Alphabet";
            this.Alphabets.UseVisualStyleBackColor = true;
            this.Alphabets.Click += new System.EventHandler(this.Alphabets_Click);
            // 
            // StringCollection
            // 
            this.StringCollection.BackColor = System.Drawing.Color.White;
            this.StringCollection.Location = new System.Drawing.Point(4, 33);
            this.StringCollection.Margin = new System.Windows.Forms.Padding(2);
            this.StringCollection.Name = "StringCollection";
            this.StringCollection.Size = new System.Drawing.Size(740, 221);
            this.StringCollection.TabIndex = 3;
            // 
            // Digit
            // 
            this.Digit.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Digit.Location = new System.Drawing.Point(252, 4);
            this.Digit.Margin = new System.Windows.Forms.Padding(2);
            this.Digit.Name = "Digit";
            this.Digit.Size = new System.Drawing.Size(120, 25);
            this.Digit.TabIndex = 2;
            this.Digit.Text = "Digit";
            this.Digit.UseVisualStyleBackColor = true;
            this.Digit.Click += new System.EventHandler(this.Number_Click);
            // 
            // String
            // 
            this.String.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.String.Location = new System.Drawing.Point(376, 4);
            this.String.Margin = new System.Windows.Forms.Padding(2);
            this.String.Name = "String";
            this.String.Size = new System.Drawing.Size(120, 25);
            this.String.TabIndex = 1;
            this.String.Text = "String";
            this.String.UseVisualStyleBackColor = true;
            this.String.Click += new System.EventHandler(this.VariableSting_Click);
            // 
            // UserInputString
            // 
            this.UserInputString.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserInputString.Location = new System.Drawing.Point(4, 4);
            this.UserInputString.Margin = new System.Windows.Forms.Padding(2);
            this.UserInputString.Name = "UserInputString";
            this.UserInputString.Size = new System.Drawing.Size(120, 25);
            this.UserInputString.TabIndex = 0;
            this.UserInputString.Text = "User Input String";
            this.UserInputString.UseVisualStyleBackColor = true;
            this.UserInputString.Click += new System.EventHandler(this.String_Click);
            // 
            // Advanced
            // 
            this.Advanced.Controls.Add(this.linkLabel1);
            this.Advanced.Controls.Add(this.UserRegexBox);
            this.Advanced.Controls.Add(this.Regex_Label);
            this.Advanced.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Advanced.Location = new System.Drawing.Point(4, 24);
            this.Advanced.Margin = new System.Windows.Forms.Padding(2);
            this.Advanced.Name = "Advanced";
            this.Advanced.Padding = new System.Windows.Forms.Padding(2);
            this.Advanced.Size = new System.Drawing.Size(750, 258);
            this.Advanced.TabIndex = 1;
            this.Advanced.Text = "Advanced";
            this.Advanced.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel1.Location = new System.Drawing.Point(568, 232);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(171, 19);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Regular Expression Syntax ";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // UserRegexBox
            // 
            this.UserRegexBox.Location = new System.Drawing.Point(54, 11);
            this.UserRegexBox.Margin = new System.Windows.Forms.Padding(2);
            this.UserRegexBox.Name = "UserRegexBox";
            this.UserRegexBox.Size = new System.Drawing.Size(683, 26);
            this.UserRegexBox.TabIndex = 1;
            this.UserRegexBox.Leave += new System.EventHandler(this.UserRegexBox_Leave);
            this.UserRegexBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.UserRegexBox_PreviewKeyDown);
            // 
            // Regex_Label
            // 
            this.Regex_Label.AutoSize = true;
            this.Regex_Label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Regex_Label.Location = new System.Drawing.Point(11, 15);
            this.Regex_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Regex_Label.Name = "Regex_Label";
            this.Regex_Label.Size = new System.Drawing.Size(47, 15);
            this.Regex_Label.TabIndex = 0;
            this.Regex_Label.Text = "Regex : ";
            // 
            // DoneExit
            // 
            this.DoneExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DoneExit.Location = new System.Drawing.Point(676, 325);
            this.DoneExit.Margin = new System.Windows.Forms.Padding(2);
            this.DoneExit.Name = "DoneExit";
            this.DoneExit.Size = new System.Drawing.Size(97, 25);
            this.DoneExit.TabIndex = 1;
            this.DoneExit.Text = "Done";
            this.DoneExit.UseVisualStyleBackColor = true;
            this.DoneExit.Click += new System.EventHandler(this.DoneExit_Click);
            // 
            // MatchCase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.DoneExit);
            this.Controls.Add(this.MatchCaseGroup);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MatchCase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Match Case";
            this.MatchCaseGroup.ResumeLayout(false);
            this.DefaultAndAdvancedTab.ResumeLayout(false);
            this.Default.ResumeLayout(false);
            this.Advanced.ResumeLayout(false);
            this.Advanced.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox MatchCaseGroup;
        private System.Windows.Forms.TabControl DefaultAndAdvancedTab;
        private System.Windows.Forms.TabPage Default;
        private System.Windows.Forms.FlowLayoutPanel StringCollection;
        private System.Windows.Forms.Button Digit;
        private System.Windows.Forms.Button String;
        private System.Windows.Forms.Button UserInputString;
        private System.Windows.Forms.TabPage Advanced;
        private System.Windows.Forms.Label Regex_Label;
        private System.Windows.Forms.Button DoneExit;
        private System.Windows.Forms.Button Alphabets;
        private System.Windows.Forms.Button NotAlphabet;
        private System.Windows.Forms.Button NotDigit;
        private System.Windows.Forms.TextBox UserRegexBox;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

