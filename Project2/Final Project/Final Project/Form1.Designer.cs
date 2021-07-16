using MySql.Data.MySqlClient;

namespace Final_Project
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.username_box = new System.Windows.Forms.RichTextBox();
            this.password_box = new System.Windows.Forms.RichTextBox();
            this.login_button = new System.Windows.Forms.Button();
            this.register_button = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // username_box
            // 
            this.username_box.BackColor = System.Drawing.Color.Maroon;
            this.username_box.BulletIndent = 2;
            this.username_box.Font = new System.Drawing.Font("Sylfaen", 22F);
            this.username_box.ForeColor = System.Drawing.Color.White;
            this.username_box.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.username_box.Location = new System.Drawing.Point(366, 130);
            this.username_box.Name = "username_box";
            this.username_box.Size = new System.Drawing.Size(319, 77);
            this.username_box.TabIndex = 1;
            this.username_box.Text = "user name";
            this.username_box.Click += new System.EventHandler(this.username_box_enter);
            // 
            // password_box
            // 
            this.password_box.BackColor = System.Drawing.Color.Maroon;
            this.password_box.Font = new System.Drawing.Font("Sylfaen", 22F);
            this.password_box.ForeColor = System.Drawing.Color.White;
            this.password_box.Location = new System.Drawing.Point(366, 213);
            this.password_box.Name = "password_box";
            this.password_box.Size = new System.Drawing.Size(319, 77);
            this.password_box.TabIndex = 1;
            this.password_box.Text = "password";
            this.password_box.Click += new System.EventHandler(this.password_box_enter);
            this.password_box.TextChanged += new System.EventHandler(this.password_box_TextChanged);
            // 
            // login_button
            // 
            this.login_button.BackColor = System.Drawing.Color.DarkCyan;
            this.login_button.Font = new System.Drawing.Font("Sylfaen", 22F);
            this.login_button.ForeColor = System.Drawing.Color.White;
            this.login_button.Location = new System.Drawing.Point(366, 296);
            this.login_button.Name = "login_button";
            this.login_button.Size = new System.Drawing.Size(319, 81);
            this.login_button.TabIndex = 3;
            this.login_button.Text = "log in";
            this.login_button.UseVisualStyleBackColor = false;
            this.login_button.Click += new System.EventHandler(this.login_button_Click);
            // 
            // register_button
            // 
            this.register_button.BackColor = System.Drawing.Color.DarkCyan;
            this.register_button.Font = new System.Drawing.Font("Sylfaen", 22F);
            this.register_button.ForeColor = System.Drawing.Color.White;
            this.register_button.Location = new System.Drawing.Point(366, 383);
            this.register_button.Name = "register_button";
            this.register_button.Size = new System.Drawing.Size(319, 81);
            this.register_button.TabIndex = 4;
            this.register_button.Text = "register";
            this.register_button.UseVisualStyleBackColor = false;
            this.register_button.Click += new System.EventHandler(this.register_button_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1078, 643);
            this.Controls.Add(this.register_button);
            this.Controls.Add(this.login_button);
            this.Controls.Add(this.password_box);
            this.Controls.Add(this.username_box);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Timer timer1;

        private System.Windows.Forms.Button register_button;

        private System.Windows.Forms.RichTextBox password_box;

        private System.Windows.Forms.Button login_button;

        private System.Windows.Forms.RichTextBox username_box;

        private System.Windows.Forms.RichTextBox usernameTextBox;
        private System.Windows.Forms.RichTextBox passwordTextBox;

        #endregion
    }
}