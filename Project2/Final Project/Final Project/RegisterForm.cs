using System;
using System.Windows.Forms;

namespace Final_Project
{
    public partial class RegisterForm : Form
    {
    
        private string _password = "";
        private int _richTextlent = 1;
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
        
        private void password_box_TextChanged(object sender, EventArgs e)
        {
            if (password_box.Text.Length == _richTextlent)
            {
                _password += password_box.Text[0].ToString();
                password_box.Text = password_box.Text.Remove(0, 1);
                password_box.Text += "*";
            }
            else
            {
                _password = "";
                password_box.Text = "";
            }

            _richTextlent = password_box.Text.Length + 1;
        }
    }
}