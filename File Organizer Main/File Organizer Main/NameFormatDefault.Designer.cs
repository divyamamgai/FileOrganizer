namespace MatchCaseNameSpace {
    partial class NameFormatDefault
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NameFormatDefault));
            this.NameSelectPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.UserInputName = new System.Windows.Forms.Button();
            this.NameFinalPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.Done = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.OKButton = new System.Windows.Forms.Button();
            this.AttributeDropDown = new System.Windows.Forms.ComboBox();
            this.FileAttributesLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.NameSelectPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // NameSelectPanel
            // 
            this.NameSelectPanel.Controls.Add(this.UserInputName);
            this.NameSelectPanel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.NameSelectPanel.Location = new System.Drawing.Point(5, 21);
            this.NameSelectPanel.Margin = new System.Windows.Forms.Padding(2);
            this.NameSelectPanel.Name = "NameSelectPanel";
            this.NameSelectPanel.Size = new System.Drawing.Size(750, 74);
            this.NameSelectPanel.TabIndex = 2;
            // 
            // UserInputName
            // 
            this.UserInputName.Location = new System.Drawing.Point(2, 2);
            this.UserInputName.Margin = new System.Windows.Forms.Padding(2);
            this.UserInputName.Name = "UserInputName";
            this.UserInputName.Size = new System.Drawing.Size(120, 25);
            this.UserInputName.TabIndex = 0;
            this.UserInputName.Text = "User Input String";
            this.UserInputName.UseVisualStyleBackColor = true;
            this.UserInputName.Click += new System.EventHandler(this.UserInputName_Click);
            // 
            // NameFinalPanel
            // 
            this.NameFinalPanel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.NameFinalPanel.Location = new System.Drawing.Point(5, 21);
            this.NameFinalPanel.Margin = new System.Windows.Forms.Padding(2);
            this.NameFinalPanel.Name = "NameFinalPanel";
            this.NameFinalPanel.Size = new System.Drawing.Size(752, 147);
            this.NameFinalPanel.TabIndex = 3;
            // 
            // Done
            // 
            this.Done.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Done.Location = new System.Drawing.Point(676, 325);
            this.Done.Margin = new System.Windows.Forms.Padding(2);
            this.Done.Name = "Done";
            this.Done.Size = new System.Drawing.Size(97, 25);
            this.Done.TabIndex = 4;
            this.Done.Text = "Done";
            this.Done.UseVisualStyleBackColor = true;
            this.Done.Click += new System.EventHandler(this.Done_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.OKButton);
            this.groupBox1.Controls.Add(this.AttributeDropDown);
            this.groupBox1.Controls.Add(this.FileAttributesLabel);
            this.groupBox1.Controls.Add(this.NameSelectPanel);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 129);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Available Groups";
            // 
            // OKButton
            // 
            this.OKButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.OKButton.Location = new System.Drawing.Point(683, 98);
            this.OKButton.Margin = new System.Windows.Forms.Padding(2);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(72, 25);
            this.OKButton.TabIndex = 5;
            this.OKButton.Text = "Add";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // AttributeDropDown
            // 
            this.AttributeDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AttributeDropDown.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.AttributeDropDown.FormattingEnabled = true;
            this.AttributeDropDown.Location = new System.Drawing.Point(91, 99);
            this.AttributeDropDown.Name = "AttributeDropDown";
            this.AttributeDropDown.Size = new System.Drawing.Size(587, 23);
            this.AttributeDropDown.TabIndex = 3;
            // 
            // FileAttributesLabel
            // 
            this.FileAttributesLabel.AutoSize = true;
            this.FileAttributesLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FileAttributesLabel.Location = new System.Drawing.Point(6, 102);
            this.FileAttributesLabel.Name = "FileAttributesLabel";
            this.FileAttributesLabel.Size = new System.Drawing.Size(89, 15);
            this.FileAttributesLabel.TabIndex = 4;
            this.FileAttributesLabel.Text = "File Attributes : ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.NameFinalPanel);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 147);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(761, 173);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Name Format";
            // 
            // NameFormatDefault
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Done);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "NameFormatDefault";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Name Format";
            this.NameSelectPanel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel NameSelectPanel;
        private System.Windows.Forms.Button UserInputName;
        private System.Windows.Forms.FlowLayoutPanel NameFinalPanel;
        private System.Windows.Forms.Button Done;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox AttributeDropDown;
        private System.Windows.Forms.Label FileAttributesLabel;
        private System.Windows.Forms.Button OKButton;
    }
}