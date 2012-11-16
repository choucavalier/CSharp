namespace MyCrypt
{
    partial class Form1
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
            this.textBox = new System.Windows.Forms.TextBox();
            this.hideButton = new System.Windows.Forms.Button();
            this.cryptButton = new System.Windows.Forms.Button();
            this.decryptButton = new System.Windows.Forms.Button();
            this.cryptBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(13, 14);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(270, 20);
            this.textBox.TabIndex = 0;
            // 
            // hideButton
            // 
            this.hideButton.Location = new System.Drawing.Point(13, 40);
            this.hideButton.Name = "hideButton";
            this.hideButton.Size = new System.Drawing.Size(75, 23);
            this.hideButton.TabIndex = 1;
            this.hideButton.Text = "Hide";
            this.hideButton.UseVisualStyleBackColor = true;
            this.hideButton.Click += new System.EventHandler(this.hideButton_Click);
            // 
            // cryptButton
            // 
            this.cryptButton.Location = new System.Drawing.Point(135, 41);
            this.cryptButton.Name = "cryptButton";
            this.cryptButton.Size = new System.Drawing.Size(67, 23);
            this.cryptButton.TabIndex = 3;
            this.cryptButton.Text = "Crypt";
            this.cryptButton.UseVisualStyleBackColor = true;
            this.cryptButton.Click += new System.EventHandler(this.cryptButton_Click);
            // 
            // decryptButton
            // 
            this.decryptButton.Location = new System.Drawing.Point(208, 40);
            this.decryptButton.Name = "decryptButton";
            this.decryptButton.Size = new System.Drawing.Size(75, 23);
            this.decryptButton.TabIndex = 4;
            this.decryptButton.Text = "Decrypt";
            this.decryptButton.UseVisualStyleBackColor = true;
            this.decryptButton.Click += new System.EventHandler(this.decryptButton_Click);
            // 
            // cryptBox
            // 
            this.cryptBox.Location = new System.Drawing.Point(94, 43);
            this.cryptBox.Name = "cryptBox";
            this.cryptBox.Size = new System.Drawing.Size(35, 20);
            this.cryptBox.TabIndex = 5;
            this.cryptBox.Text = "42";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 78);
            this.Controls.Add(this.cryptBox);
            this.Controls.Add(this.decryptButton);
            this.Controls.Add(this.cryptButton);
            this.Controls.Add(this.hideButton);
            this.Controls.Add(this.textBox);
            this.Name = "Form1";
            this.Text = "Crypt my ass !";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button hideButton;
        private System.Windows.Forms.Button cryptButton;
        private System.Windows.Forms.Button decryptButton;
        private System.Windows.Forms.TextBox cryptBox;
    }
}

