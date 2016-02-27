namespace MatchCaseNameSpace {
    partial class StringPopUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StringPopUp));
            this.UserInputTextBox = new System.Windows.Forms.TextBox();
            this.EnterInstruction = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UserInputTextBox
            // 
            this.UserInputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UserInputTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserInputTextBox.Location = new System.Drawing.Point(107, 12);
            this.UserInputTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.UserInputTextBox.MaxLength = 64;
            this.UserInputTextBox.Name = "UserInputTextBox";
            this.UserInputTextBox.Size = new System.Drawing.Size(304, 23);
            this.UserInputTextBox.TabIndex = 1;
            this.UserInputTextBox.TextChanged += new System.EventHandler(this.UserInputTextBox_TextChanged);
            this.UserInputTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UserInputTextBox_KeyPress);
            this.UserInputTextBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.UserInputTextBox_PreviewKeyDown);
            // 
            // EnterInstruction
            // 
            this.EnterInstruction.AutoSize = true;
            this.EnterInstruction.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.EnterInstruction.Location = new System.Drawing.Point(11, 15);
            this.EnterInstruction.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.EnterInstruction.Name = "EnterInstruction";
            this.EnterInstruction.Size = new System.Drawing.Size(100, 15);
            this.EnterInstruction.TabIndex = 2;
            this.EnterInstruction.Text = "Enter The String : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Note : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(51, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(359, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "This string is directly matched by the File Organizer when checking";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(350, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "for the file name matches in the Source folder through generated";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "regex.";
            // 
            // StringPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 111);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UserInputTextBox);
            this.Controls.Add(this.EnterInstruction);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "StringPopUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Regex Static String";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UserInputTextBox;
        private System.Windows.Forms.Label EnterInstruction;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}