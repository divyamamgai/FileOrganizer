namespace MatchCaseNameSpace {
    partial class NameFormatAdvanced {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NameFormatAdvanced));
            this.SyntaxBox = new System.Windows.Forms.GroupBox();
            this.OKButton = new System.Windows.Forms.Button();
            this.AttributeDropDown = new System.Windows.Forms.ComboBox();
            this.AttributeOptions = new System.Windows.Forms.Label();
            this.AttributeSyntaxLabel = new System.Windows.Forms.Label();
            this.GroupSyntaxLabel = new System.Windows.Forms.Label();
            this.NameSpecifier = new System.Windows.Forms.GroupBox();
            this.UserEnteredFormat = new System.Windows.Forms.TextBox();
            this.NameFormatBox = new System.Windows.Forms.Label();
            this.Done = new System.Windows.Forms.Button();
            this.SyntaxBox.SuspendLayout();
            this.NameSpecifier.SuspendLayout();
            this.SuspendLayout();
            // 
            // SyntaxBox
            // 
            this.SyntaxBox.Controls.Add(this.OKButton);
            this.SyntaxBox.Controls.Add(this.AttributeDropDown);
            this.SyntaxBox.Controls.Add(this.AttributeOptions);
            this.SyntaxBox.Controls.Add(this.AttributeSyntaxLabel);
            this.SyntaxBox.Controls.Add(this.GroupSyntaxLabel);
            this.SyntaxBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SyntaxBox.Location = new System.Drawing.Point(9, 8);
            this.SyntaxBox.Margin = new System.Windows.Forms.Padding(2);
            this.SyntaxBox.Name = "SyntaxBox";
            this.SyntaxBox.Padding = new System.Windows.Forms.Padding(2);
            this.SyntaxBox.Size = new System.Drawing.Size(668, 166);
            this.SyntaxBox.TabIndex = 0;
            this.SyntaxBox.TabStop = false;
            this.SyntaxBox.Text = "Syntax";
            // 
            // OKButton
            // 
            this.OKButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.OKButton.Location = new System.Drawing.Point(581, 126);
            this.OKButton.Margin = new System.Windows.Forms.Padding(2);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(72, 25);
            this.OKButton.TabIndex = 4;
            this.OKButton.Text = "Add";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // AttributeDropDown
            // 
            this.AttributeDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AttributeDropDown.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.AttributeDropDown.FormattingEnabled = true;
            this.AttributeDropDown.Location = new System.Drawing.Point(119, 127);
            this.AttributeDropDown.Margin = new System.Windows.Forms.Padding(2);
            this.AttributeDropDown.Name = "AttributeDropDown";
            this.AttributeDropDown.Size = new System.Drawing.Size(458, 23);
            this.AttributeDropDown.TabIndex = 3;
            // 
            // AttributeOptions
            // 
            this.AttributeOptions.BackColor = System.Drawing.Color.White;
            this.AttributeOptions.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.AttributeOptions.Location = new System.Drawing.Point(9, 124);
            this.AttributeOptions.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AttributeOptions.Name = "AttributeOptions";
            this.AttributeOptions.Size = new System.Drawing.Size(118, 27);
            this.AttributeOptions.TabIndex = 2;
            this.AttributeOptions.Text = "Possible Attributes :";
            this.AttributeOptions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AttributeSyntaxLabel
            // 
            this.AttributeSyntaxLabel.BackColor = System.Drawing.Color.White;
            this.AttributeSyntaxLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.AttributeSyntaxLabel.Location = new System.Drawing.Point(9, 73);
            this.AttributeSyntaxLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AttributeSyntaxLabel.Name = "AttributeSyntaxLabel";
            this.AttributeSyntaxLabel.Size = new System.Drawing.Size(644, 35);
            this.AttributeSyntaxLabel.TabIndex = 1;
            this.AttributeSyntaxLabel.Text = "Attribute : |Attribute| \r\nExample: If you want to get the Title of a mp3 file, us" +
    "e the following : |Title| or choose from the dropdown";
            // 
            // GroupSyntaxLabel
            // 
            this.GroupSyntaxLabel.BackColor = System.Drawing.Color.White;
            this.GroupSyntaxLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GroupSyntaxLabel.Location = new System.Drawing.Point(9, 29);
            this.GroupSyntaxLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.GroupSyntaxLabel.Name = "GroupSyntaxLabel";
            this.GroupSyntaxLabel.Size = new System.Drawing.Size(658, 35);
            this.GroupSyntaxLabel.TabIndex = 0;
            this.GroupSyntaxLabel.Text = "Groups : {Group Number} \r\nExample: If you want to match Group number 2 from the e" +
    "ntered regex, use the following : {2}";
            // 
            // NameSpecifier
            // 
            this.NameSpecifier.Controls.Add(this.UserEnteredFormat);
            this.NameSpecifier.Controls.Add(this.NameFormatBox);
            this.NameSpecifier.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameSpecifier.Location = new System.Drawing.Point(11, 203);
            this.NameSpecifier.Margin = new System.Windows.Forms.Padding(2);
            this.NameSpecifier.Name = "NameSpecifier";
            this.NameSpecifier.Padding = new System.Windows.Forms.Padding(2);
            this.NameSpecifier.Size = new System.Drawing.Size(662, 64);
            this.NameSpecifier.TabIndex = 1;
            this.NameSpecifier.TabStop = false;
            this.NameSpecifier.Text = "Name Specifier";
            // 
            // UserEnteredFormat
            // 
            this.UserEnteredFormat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.UserEnteredFormat.Location = new System.Drawing.Point(127, 25);
            this.UserEnteredFormat.Margin = new System.Windows.Forms.Padding(2);
            this.UserEnteredFormat.Name = "UserEnteredFormat";
            this.UserEnteredFormat.Size = new System.Drawing.Size(519, 23);
            this.UserEnteredFormat.TabIndex = 0;
            this.UserEnteredFormat.Leave += new System.EventHandler(this.UserEnteredFormat_Leave);
            this.UserEnteredFormat.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.UserEnteredFormat_PreviewKeyDown);
            // 
            // NameFormatBox
            // 
            this.NameFormatBox.AutoSize = true;
            this.NameFormatBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.NameFormatBox.Location = new System.Drawing.Point(12, 28);
            this.NameFormatBox.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NameFormatBox.Name = "NameFormatBox";
            this.NameFormatBox.Size = new System.Drawing.Size(116, 15);
            this.NameFormatBox.TabIndex = 1;
            this.NameFormatBox.Text = "Enter Name Format :";
            // 
            // Done
            // 
            this.Done.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Done.Location = new System.Drawing.Point(553, 271);
            this.Done.Margin = new System.Windows.Forms.Padding(2);
            this.Done.Name = "Done";
            this.Done.Size = new System.Drawing.Size(120, 25);
            this.Done.TabIndex = 2;
            this.Done.Text = "Done";
            this.Done.UseVisualStyleBackColor = true;
            this.Done.Click += new System.EventHandler(this.Done_Click);
            // 
            // NameFormatAdvanced
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(684, 307);
            this.Controls.Add(this.Done);
            this.Controls.Add(this.NameSpecifier);
            this.Controls.Add(this.SyntaxBox);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "NameFormatAdvanced";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Name Format Advanced";
            this.SyntaxBox.ResumeLayout(false);
            this.NameSpecifier.ResumeLayout(false);
            this.NameSpecifier.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox SyntaxBox;
        private System.Windows.Forms.GroupBox NameSpecifier;
        private System.Windows.Forms.Label NameFormatBox;
        private System.Windows.Forms.TextBox UserEnteredFormat;
        private System.Windows.Forms.Button Done;
        private System.Windows.Forms.Label AttributeSyntaxLabel;
        private System.Windows.Forms.Label GroupSyntaxLabel;
        private System.Windows.Forms.Label AttributeOptions;
        private System.Windows.Forms.ComboBox AttributeDropDown;
        private System.Windows.Forms.Button OKButton;
    }
}