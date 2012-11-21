namespace Calculatrice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.calcBox = new System.Windows.Forms.RichTextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.subButton = new System.Windows.Forms.Button();
            this.mulButton = new System.Windows.Forms.Button();
            this.divButton = new System.Windows.Forms.Button();
            this.modButton = new System.Windows.Forms.Button();
            this.cosButton = new System.Windows.Forms.Button();
            this.sinButton = new System.Windows.Forms.Button();
            this.tanButton = new System.Windows.Forms.Button();
            this.sqrtButton = new System.Windows.Forms.Button();
            this.powButton = new System.Windows.Forms.Button();
            this.equalButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.resultBox = new System.Windows.Forms.RichTextBox();
            this.labelOp = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.radianButton = new System.Windows.Forms.RadioButton();
            this.degreeButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // calcBox
            // 
            this.calcBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.calcBox.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calcBox.Location = new System.Drawing.Point(13, 13);
            this.calcBox.Multiline = false;
            this.calcBox.Name = "calcBox";
            this.calcBox.Size = new System.Drawing.Size(149, 30);
            this.calcBox.TabIndex = 0;
            this.calcBox.Text = "";
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.Black;
            this.addButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addButton.FlatAppearance.BorderSize = 0;
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.addButton.Location = new System.Drawing.Point(13, 108);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(25, 26);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "+";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // subButton
            // 
            this.subButton.BackColor = System.Drawing.Color.Black;
            this.subButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.subButton.FlatAppearance.BorderSize = 0;
            this.subButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.subButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.subButton.Location = new System.Drawing.Point(44, 108);
            this.subButton.Name = "subButton";
            this.subButton.Size = new System.Drawing.Size(25, 26);
            this.subButton.TabIndex = 2;
            this.subButton.Text = "−";
            this.subButton.UseVisualStyleBackColor = false;
            this.subButton.Click += new System.EventHandler(this.subButton_Click);
            // 
            // mulButton
            // 
            this.mulButton.BackColor = System.Drawing.Color.Black;
            this.mulButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mulButton.FlatAppearance.BorderSize = 0;
            this.mulButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mulButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mulButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.mulButton.Location = new System.Drawing.Point(75, 108);
            this.mulButton.Name = "mulButton";
            this.mulButton.Size = new System.Drawing.Size(25, 26);
            this.mulButton.TabIndex = 3;
            this.mulButton.Text = "×";
            this.mulButton.UseVisualStyleBackColor = false;
            this.mulButton.Click += new System.EventHandler(this.mulButton_Click);
            // 
            // divButton
            // 
            this.divButton.BackColor = System.Drawing.Color.Black;
            this.divButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.divButton.FlatAppearance.BorderSize = 0;
            this.divButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.divButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.divButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.divButton.Location = new System.Drawing.Point(106, 108);
            this.divButton.Name = "divButton";
            this.divButton.Size = new System.Drawing.Size(25, 26);
            this.divButton.TabIndex = 4;
            this.divButton.Text = "÷";
            this.divButton.UseVisualStyleBackColor = false;
            this.divButton.Click += new System.EventHandler(this.divButton_Click);
            // 
            // modButton
            // 
            this.modButton.BackColor = System.Drawing.Color.Black;
            this.modButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.modButton.FlatAppearance.BorderSize = 0;
            this.modButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.modButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.modButton.Location = new System.Drawing.Point(137, 108);
            this.modButton.Name = "modButton";
            this.modButton.Size = new System.Drawing.Size(25, 26);
            this.modButton.TabIndex = 5;
            this.modButton.Text = "%";
            this.modButton.UseVisualStyleBackColor = false;
            this.modButton.Click += new System.EventHandler(this.modButton_Click);
            // 
            // cosButton
            // 
            this.cosButton.BackColor = System.Drawing.Color.Black;
            this.cosButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cosButton.FlatAppearance.BorderSize = 0;
            this.cosButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cosButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cosButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cosButton.Location = new System.Drawing.Point(13, 140);
            this.cosButton.Name = "cosButton";
            this.cosButton.Size = new System.Drawing.Size(66, 26);
            this.cosButton.TabIndex = 7;
            this.cosButton.Text = "cos";
            this.cosButton.UseVisualStyleBackColor = false;
            this.cosButton.Click += new System.EventHandler(this.cosButton_Click);
            // 
            // sinButton
            // 
            this.sinButton.BackColor = System.Drawing.Color.Black;
            this.sinButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sinButton.FlatAppearance.BorderSize = 0;
            this.sinButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sinButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sinButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.sinButton.Location = new System.Drawing.Point(85, 140);
            this.sinButton.Name = "sinButton";
            this.sinButton.Size = new System.Drawing.Size(66, 26);
            this.sinButton.TabIndex = 8;
            this.sinButton.Text = "sin";
            this.sinButton.UseVisualStyleBackColor = false;
            this.sinButton.Click += new System.EventHandler(this.sinButton_Click);
            // 
            // tanButton
            // 
            this.tanButton.BackColor = System.Drawing.Color.Black;
            this.tanButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tanButton.FlatAppearance.BorderSize = 0;
            this.tanButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tanButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tanButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.tanButton.Location = new System.Drawing.Point(157, 140);
            this.tanButton.Name = "tanButton";
            this.tanButton.Size = new System.Drawing.Size(66, 26);
            this.tanButton.TabIndex = 9;
            this.tanButton.Text = "tan";
            this.tanButton.UseVisualStyleBackColor = false;
            this.tanButton.Click += new System.EventHandler(this.tanButton_Click);
            // 
            // sqrtButton
            // 
            this.sqrtButton.BackColor = System.Drawing.Color.Black;
            this.sqrtButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sqrtButton.FlatAppearance.BorderSize = 0;
            this.sqrtButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sqrtButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sqrtButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.sqrtButton.Location = new System.Drawing.Point(167, 108);
            this.sqrtButton.Name = "sqrtButton";
            this.sqrtButton.Size = new System.Drawing.Size(25, 26);
            this.sqrtButton.TabIndex = 10;
            this.sqrtButton.Text = "√";
            this.sqrtButton.UseVisualStyleBackColor = false;
            this.sqrtButton.Click += new System.EventHandler(this.sqrtButton_Click);
            // 
            // powButton
            // 
            this.powButton.BackColor = System.Drawing.Color.Black;
            this.powButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.powButton.FlatAppearance.BorderSize = 0;
            this.powButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.powButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.powButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.powButton.Location = new System.Drawing.Point(198, 109);
            this.powButton.Name = "powButton";
            this.powButton.Size = new System.Drawing.Size(25, 26);
            this.powButton.TabIndex = 12;
            this.powButton.Text = "^";
            this.powButton.UseVisualStyleBackColor = false;
            this.powButton.Click += new System.EventHandler(this.powButton_Click);
            // 
            // equalButton
            // 
            this.equalButton.BackColor = System.Drawing.Color.Black;
            this.equalButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.equalButton.FlatAppearance.BorderSize = 0;
            this.equalButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.equalButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.equalButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.equalButton.Location = new System.Drawing.Point(168, 12);
            this.equalButton.Name = "equalButton";
            this.equalButton.Size = new System.Drawing.Size(55, 31);
            this.equalButton.TabIndex = 13;
            this.equalButton.Text = "=";
            this.equalButton.UseVisualStyleBackColor = false;
            this.equalButton.Click += new System.EventHandler(this.equalButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightGray;
            this.label1.Location = new System.Drawing.Point(13, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.label1.Size = new System.Drawing.Size(3, 19);
            this.label1.TabIndex = 14;
            // 
            // resultBox
            // 
            this.resultBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.resultBox.Enabled = false;
            this.resultBox.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.resultBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.resultBox.Location = new System.Drawing.Point(13, 71);
            this.resultBox.Multiline = false;
            this.resultBox.Name = "resultBox";
            this.resultBox.Size = new System.Drawing.Size(210, 30);
            this.resultBox.TabIndex = 6;
            this.resultBox.Text = "0";
            // 
            // labelOp
            // 
            this.labelOp.AutoSize = true;
            this.labelOp.BackColor = System.Drawing.Color.LightGray;
            this.labelOp.Location = new System.Drawing.Point(19, 43);
            this.labelOp.Margin = new System.Windows.Forms.Padding(0);
            this.labelOp.Name = "labelOp";
            this.labelOp.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.labelOp.Size = new System.Drawing.Size(0, 19);
            this.labelOp.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightGray;
            this.label2.Location = new System.Drawing.Point(25, 43);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.label2.Size = new System.Drawing.Size(3, 19);
            this.label2.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(9, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(220, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Pas de numpad, le clavier vous connaissez ?";
            // 
            // radianButton
            // 
            this.radianButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.radianButton.BackColor = System.Drawing.Color.Black;
            this.radianButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radianButton.Font = new System.Drawing.Font("Arial", 12F);
            this.radianButton.ForeColor = System.Drawing.SystemColors.Control;
            this.radianButton.Location = new System.Drawing.Point(13, 172);
            this.radianButton.Name = "radianButton";
            this.radianButton.Size = new System.Drawing.Size(100, 31);
            this.radianButton.TabIndex = 18;
            this.radianButton.Text = "radian";
            this.radianButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radianButton.UseVisualStyleBackColor = false;
            // 
            // degreeButton
            // 
            this.degreeButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.degreeButton.BackColor = System.Drawing.Color.Black;
            this.degreeButton.Checked = true;
            this.degreeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.degreeButton.Font = new System.Drawing.Font("Arial", 12F);
            this.degreeButton.ForeColor = System.Drawing.SystemColors.Control;
            this.degreeButton.Location = new System.Drawing.Point(123, 172);
            this.degreeButton.Name = "degreeButton";
            this.degreeButton.Size = new System.Drawing.Size(100, 31);
            this.degreeButton.TabIndex = 19;
            this.degreeButton.TabStop = true;
            this.degreeButton.Text = "degree";
            this.degreeButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.degreeButton.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(237, 238);
            this.Controls.Add(this.degreeButton);
            this.Controls.Add(this.radianButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelOp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.equalButton);
            this.Controls.Add(this.powButton);
            this.Controls.Add(this.sqrtButton);
            this.Controls.Add(this.tanButton);
            this.Controls.Add(this.sinButton);
            this.Controls.Add(this.cosButton);
            this.Controls.Add(this.resultBox);
            this.Controls.Add(this.modButton);
            this.Controls.Add(this.divButton);
            this.Controls.Add(this.mulButton);
            this.Controls.Add(this.subButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.calcBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Calculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox calcBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button subButton;
        private System.Windows.Forms.Button mulButton;
        private System.Windows.Forms.Button divButton;
        private System.Windows.Forms.Button modButton;
        private System.Windows.Forms.Button cosButton;
        private System.Windows.Forms.Button sinButton;
        private System.Windows.Forms.Button tanButton;
        private System.Windows.Forms.Button sqrtButton;
        private System.Windows.Forms.Button powButton;
        private System.Windows.Forms.Button equalButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox resultBox;
        private System.Windows.Forms.Label labelOp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radianButton;
        private System.Windows.Forms.RadioButton degreeButton;
    }
}

