using System.ComponentModel;

namespace Final_Project
{
    partial class FieldsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FieldsForm));
            this.box1 = new System.Windows.Forms.RichTextBox();
            this.box2 = new System.Windows.Forms.RichTextBox();
            this.box3 = new System.Windows.Forms.RichTextBox();
            this.box4 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.submit_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // box1
            // 
            this.box1.BackColor = System.Drawing.Color.SeaGreen;
            this.box1.Font = new System.Drawing.Font("Sylfaen", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.box1.ForeColor = System.Drawing.Color.White;
            this.box1.Location = new System.Drawing.Point(253, 63);
            this.box1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.box1.Multiline = false;
            this.box1.Name = "box1";
            this.box1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.box1.Size = new System.Drawing.Size(321, 72);
            this.box1.TabIndex = 25;
            this.box1.Text = "first name";
            // 
            // box2
            // 
            this.box2.BackColor = System.Drawing.Color.SeaGreen;
            this.box2.Font = new System.Drawing.Font("Sylfaen", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.box2.ForeColor = System.Drawing.Color.White;
            this.box2.Location = new System.Drawing.Point(955, 63);
            this.box2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.box2.Multiline = false;
            this.box2.Name = "box2";
            this.box2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.box2.Size = new System.Drawing.Size(321, 72);
            this.box2.TabIndex = 24;
            this.box2.Text = "second name";
            // 
            // box3
            // 
            this.box3.BackColor = System.Drawing.Color.SeaGreen;
            this.box3.Font = new System.Drawing.Font("Sylfaen", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.box3.ForeColor = System.Drawing.Color.White;
            this.box3.Location = new System.Drawing.Point(955, 184);
            this.box3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.box3.Multiline = false;
            this.box3.Name = "box3";
            this.box3.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.box3.Size = new System.Drawing.Size(321, 72);
            this.box3.TabIndex = 23;
            this.box3.Text = "password";
            // 
            // box4
            // 
            this.box4.BackColor = System.Drawing.Color.SeaGreen;
            this.box4.Font = new System.Drawing.Font("Sylfaen", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.box4.ForeColor = System.Drawing.Color.White;
            this.box4.Location = new System.Drawing.Point(253, 178);
            this.box4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.box4.Multiline = false;
            this.box4.Name = "box4";
            this.box4.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.box4.Size = new System.Drawing.Size(321, 72);
            this.box4.TabIndex = 22;
            this.box4.Text = "username";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.Teal;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Font = new System.Drawing.Font("Sylfaen", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(750, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 34);
            this.label2.TabIndex = 21;
            this.label2.Text = "second name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BackColor = System.Drawing.Color.Teal;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Font = new System.Drawing.Font("Sylfaen", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(44, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(175, 34);
            this.label4.TabIndex = 20;
            this.label4.Text = "username";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.Teal;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Font = new System.Drawing.Font("Sylfaen", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(750, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 34);
            this.label3.TabIndex = 19;
            this.label3.Text = "password";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Teal;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Sylfaen", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(44, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 34);
            this.label1.TabIndex = 18;
            this.label1.Text = "first name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // submit_button
            // 
            this.submit_button.BackColor = System.Drawing.Color.YellowGreen;
            this.submit_button.Font = new System.Drawing.Font("Sylfaen", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.submit_button.ForeColor = System.Drawing.Color.Transparent;
            this.submit_button.Location = new System.Drawing.Point(474, 476);
            this.submit_button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.submit_button.Name = "submit_button";
            this.submit_button.Size = new System.Drawing.Size(338, 112);
            this.submit_button.TabIndex = 26;
            this.submit_button.Text = "submit";
            this.submit_button.UseVisualStyleBackColor = false;
            this.submit_button.Click += new System.EventHandler(this.submit_button_Click);
            // 
            // FieldsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1317, 675);
            this.Controls.Add(this.submit_button);
            this.Controls.Add(this.box1);
            this.Controls.Add(this.box2);
            this.Controls.Add(this.box3);
            this.Controls.Add(this.box4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FieldsForm";
            this.Text = "FieldsForm";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RichTextBox box1 { get; set; }
        public System.Windows.Forms.RichTextBox box2 { get; set; }
        public System.Windows.Forms.RichTextBox box3 { get; set; }
        public System.Windows.Forms.RichTextBox box4 { get; set; }
        public System.Windows.Forms.Label label1 { get; set; }
        public System.Windows.Forms.Label label2 { get; set; }
        public System.Windows.Forms.Label label3 { get; set; }
        public System.Windows.Forms.Label label4 { get; set; }
        private System.Windows.Forms.Button submit_button;
        private LoginForm loginForm;

    }
}