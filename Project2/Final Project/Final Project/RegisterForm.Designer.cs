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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            this.submit_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.userbox = new System.Windows.Forms.RichTextBox();
            this.BioBox = new System.Windows.Forms.RichTextBox();
            this.passwordBox = new System.Windows.Forms.RichTextBox();
            this.secondnameBox = new System.Windows.Forms.RichTextBox();
            this.firstnamebox = new System.Windows.Forms.RichTextBox();
            this.birthdatebox = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // submit_button
            // 
            this.submit_button.BackColor = System.Drawing.Color.YellowGreen;
            this.submit_button.Font = new System.Drawing.Font("Sylfaen", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.submit_button.ForeColor = System.Drawing.Color.Transparent;
            this.submit_button.Location = new System.Drawing.Point(839, 461);
            this.submit_button.Name = "submit_button";
            this.submit_button.Size = new System.Drawing.Size(304, 130);
            this.submit_button.TabIndex = 0;
            this.submit_button.Text = "submit";
            this.submit_button.UseVisualStyleBackColor = false;
            this.submit_button.Click += new System.EventHandler(this.submit_button_click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Teal;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Sylfaen", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(19, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 28);
            this.label1.TabIndex = 7;
            this.label1.Text = "first name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.Teal;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Font = new System.Drawing.Font("Sylfaen", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(19, 300);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 28);
            this.label2.TabIndex = 8;
            this.label2.Text = "Bio";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.Teal;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Font = new System.Drawing.Font("Sylfaen", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(654, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 28);
            this.label3.TabIndex = 9;
            this.label3.Text = "password";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BackColor = System.Drawing.Color.Teal;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Font = new System.Drawing.Font("Sylfaen", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(19, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 28);
            this.label4.TabIndex = 10;
            this.label4.Text = "birthdate";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.BackColor = System.Drawing.Color.Teal;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Font = new System.Drawing.Font("Sylfaen", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(19, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 28);
            this.label5.TabIndex = 11;
            this.label5.Text = "username";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.BackColor = System.Drawing.Color.Teal;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label6.Font = new System.Drawing.Font("Sylfaen", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(654, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(158, 28);
            this.label6.TabIndex = 12;
            this.label6.Text = "second name";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // userbox
            // 
            this.userbox.BackColor = System.Drawing.Color.SeaGreen;
            this.userbox.Font = new System.Drawing.Font("Sylfaen", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.userbox.ForeColor = System.Drawing.Color.White;
            this.userbox.Location = new System.Drawing.Point(207, 104);
            this.userbox.Multiline = false;
            this.userbox.Name = "userbox";
            this.userbox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.userbox.Size = new System.Drawing.Size(289, 58);
            this.userbox.TabIndex = 13;
            this.userbox.Text = "username";
            this.userbox.Enter += new System.EventHandler(this.username_box_enter);
            // 
            // BioBox
            // 
            this.BioBox.BackColor = System.Drawing.Color.SeaGreen;
            this.BioBox.Font = new System.Drawing.Font("Sylfaen", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.BioBox.ForeColor = System.Drawing.Color.White;
            this.BioBox.Location = new System.Drawing.Point(207, 295);
            this.BioBox.Multiline = false;
            this.BioBox.Name = "BioBox";
            this.BioBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.BioBox.Size = new System.Drawing.Size(583, 296);
            this.BioBox.TabIndex = 14;
            this.BioBox.Text = "...";
            this.BioBox.Enter += new System.EventHandler(this.bio_box_enter);
            // 
            // passwordBox
            // 
            this.passwordBox.BackColor = System.Drawing.Color.SeaGreen;
            this.passwordBox.Font = new System.Drawing.Font("Sylfaen", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.passwordBox.ForeColor = System.Drawing.Color.White;
            this.passwordBox.Location = new System.Drawing.Point(839, 109);
            this.passwordBox.Multiline = false;
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.passwordBox.Size = new System.Drawing.Size(289, 58);
            this.passwordBox.TabIndex = 15;
            this.passwordBox.Text = "password";
            this.passwordBox.TextChanged += new System.EventHandler(this.password_box_TextChanged);
            this.passwordBox.Enter += new System.EventHandler(this.password_box_enter);
            // 
            // secondnameBox
            // 
            this.secondnameBox.BackColor = System.Drawing.Color.SeaGreen;
            this.secondnameBox.Font = new System.Drawing.Font("Sylfaen", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.secondnameBox.ForeColor = System.Drawing.Color.White;
            this.secondnameBox.Location = new System.Drawing.Point(839, 12);
            this.secondnameBox.Multiline = false;
            this.secondnameBox.Name = "secondnameBox";
            this.secondnameBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.secondnameBox.Size = new System.Drawing.Size(289, 58);
            this.secondnameBox.TabIndex = 16;
            this.secondnameBox.Text = "second name";
            this.secondnameBox.Enter += new System.EventHandler(this.secondname_box_enter);
            // 
            // firstnamebox
            // 
            this.firstnamebox.BackColor = System.Drawing.Color.SeaGreen;
            this.firstnamebox.Font = new System.Drawing.Font("Sylfaen", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.firstnamebox.ForeColor = System.Drawing.Color.White;
            this.firstnamebox.Location = new System.Drawing.Point(207, 12);
            this.firstnamebox.Multiline = false;
            this.firstnamebox.Name = "firstnamebox";
            this.firstnamebox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.firstnamebox.Size = new System.Drawing.Size(289, 58);
            this.firstnamebox.TabIndex = 17;
            this.firstnamebox.Text = "first name";
            this.firstnamebox.Enter += new System.EventHandler(this.firstname_box_enter);
            // 
            // birthdatebox
            // 
            this.birthdatebox.BackColor = System.Drawing.Color.SeaGreen;
            this.birthdatebox.Font = new System.Drawing.Font("Sylfaen", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.birthdatebox.ForeColor = System.Drawing.Color.White;
            this.birthdatebox.Location = new System.Drawing.Point(207, 190);
            this.birthdatebox.Multiline = false;
            this.birthdatebox.Name = "birthdatebox";
            this.birthdatebox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.birthdatebox.Size = new System.Drawing.Size(289, 58);
            this.birthdatebox.TabIndex = 18;
            this.birthdatebox.Text = "yyyy-mm-dd hh:mm:ss";
            this.birthdatebox.Enter += new System.EventHandler(this.birthdate_box_enter);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1187, 692);
            this.Controls.Add(this.birthdatebox);
            this.Controls.Add(this.firstnamebox);
            this.Controls.Add(this.secondnameBox);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.BioBox);
            this.Controls.Add(this.userbox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.submit_button);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.Name = "RegisterForm";
            this.Text = "RegisterForm";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Timer timer1;

        private System.Windows.Forms.RichTextBox userbox;

        private System.Windows.Forms.RichTextBox BioBox;

        private System.Windows.Forms.RichTextBox secondnameBox;

        private System.Windows.Forms.RichTextBox firstnamebox;

        private System.Windows.Forms.RichTextBox passwordBox;

        private System.Windows.Forms.RichTextBox birthdatebox;
        private System.Windows.Forms.RichTextBox richTextBox3;

        private System.Windows.Forms.RichTextBox richTextBox7;

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;

        private System.Windows.Forms.RichTextBox richTextBox6;
        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox richTextBox4;
        private System.Windows.Forms.RichTextBox richTextBox5;

        private System.Windows.Forms.Button submit_button;

        private System.Windows.Forms.RichTextBox richTextBox1;

        #endregion
    }
}