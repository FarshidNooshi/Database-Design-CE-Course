using System.ComponentModel;

namespace Final_Project
{
    partial class RegisterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.password_box = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // password_box
            // 
            this.password_box.Location = new System.Drawing.Point(196, 121);
            this.password_box.Name = "password_box";
            this.password_box.Size = new System.Drawing.Size(304, 130);
            this.password_box.TabIndex = 0;
            this.password_box.Text = "password";
            this.password_box.UseVisualStyleBackColor = true;
            this.password_box.Click += new System.EventHandler(this.password_box_TextChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(15, 25);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(232, 58);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.password_box);
            this.Name = "RegisterForm";
            this.Text = "RegisterForm";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button password_box;

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;

        #endregion
    }
}