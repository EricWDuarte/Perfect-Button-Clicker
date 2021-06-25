namespace HotkeyWin
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Button = new System.Windows.Forms.RadioButton();
            this.Fishing = new System.Windows.Forms.RadioButton();
            this.Whack = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(292, 273);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 241);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(85, 20);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "140";
            // 
            // Button
            // 
            this.Button.AutoSize = true;
            this.Button.Checked = true;
            this.Button.Location = new System.Drawing.Point(12, 105);
            this.Button.Name = "Button";
            this.Button.Size = new System.Drawing.Size(56, 17);
            this.Button.TabIndex = 2;
            this.Button.TabStop = true;
            this.Button.Text = "Button";
            this.Button.UseVisualStyleBackColor = true;
            this.Button.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // Fishing
            // 
            this.Fishing.AutoSize = true;
            this.Fishing.Location = new System.Drawing.Point(12, 128);
            this.Fishing.Name = "Fishing";
            this.Fishing.Size = new System.Drawing.Size(58, 17);
            this.Fishing.TabIndex = 3;
            this.Fishing.Text = "Fishing";
            this.Fishing.UseVisualStyleBackColor = true;
            this.Fishing.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // Whack
            // 
            this.Whack.AutoSize = true;
            this.Whack.Location = new System.Drawing.Point(12, 151);
            this.Whack.Name = "Whack";
            this.Whack.Size = new System.Drawing.Size(96, 17);
            this.Whack.TabIndex = 4;
            this.Whack.Text = "Whack A Greg";
            this.Whack.UseVisualStyleBackColor = true;
            this.Whack.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.Whack);
            this.Controls.Add(this.Fishing);
            this.Controls.Add(this.Button);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "C# Global Hotkeys";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.RadioButton Button;
        private System.Windows.Forms.RadioButton Fishing;
        private System.Windows.Forms.RadioButton Whack;
    }
}

