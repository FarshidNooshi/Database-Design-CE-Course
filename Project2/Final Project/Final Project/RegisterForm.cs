using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Final_Project
{
    public partial class RegisterForm : Form
    {
        private const string MySqlDatasource = "127.0.0.1";
        private const string MySqlPort = "3306";
        private const string MySqlUsername = "root";
        private const string MySqlPassword = "";
        private const string MySqlDataBase = "proj1_db_aut";
        private string _mySqlConnectionString;
        private MySqlConnection _mySqlConnection;
        private string nextPage = "log_in";
        private string _password = "";
        private int _richTextlent = 1;

        public RegisterForm()
        {
            InitializeComponent();
            _mySqlConnectionString =
                $"datasource={MySqlDatasource};port={MySqlPort};username={MySqlUsername};password={MySqlPassword};database={MySqlDataBase}";
            try
            {
                _mySqlConnection = new MySqlConnection(_mySqlConnectionString);
                _mySqlConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"error: " + ex);
            }
        }

        private void firstname_box_enter(object sender, EventArgs e)
        {
            firstnamebox.Text = "";
        }

        private void secondname_box_enter(object sender, EventArgs e)
        {
            secondnameBox.Text = "";
        }

        private void username_box_enter(object sender, EventArgs e)
        {
            userbox.Text = "";
        }

        private void birthdate_box_enter(object sender, EventArgs e)
        {
            birthdatebox.Text = "";
        }

        private void password_box_enter(object sender, EventArgs e)
        {
            passwordBox.Text = "";
        }

        private void bio_box_enter(object sender, EventArgs e)
        {
            BioBox.Text = "";
        }


        private void password_box_TextChanged(object sender, EventArgs e)
        {
            if (passwordBox.Text.Length == _richTextlent)
            {
                _password += passwordBox.Text[0].ToString();
                passwordBox.Text = passwordBox.Text.Remove(0, 1);
                passwordBox.Text += "*";
            }
            else
            {
                _password = "";
                passwordBox.Text = "";
            }

            _richTextlent = passwordBox.Text.Length + 1;
        }

        private void submit_button_click(object sender, EventArgs e)
        {
            var query = @"create_account";
            var command = new MySqlCommand(query, _mySqlConnection) {CommandTimeout = 60};
            command.Parameters.Add(new MySqlParameter("@first_name", firstnamebox.Text));
            command.Parameters.Add(new MySqlParameter("@second_name", secondnameBox.Text));
            command.Parameters.Add(new MySqlParameter("@user_name", userbox.Text));
            command.Parameters.Add(new MySqlParameter("@birth_date", birthdatebox.Text));
            command.Parameters.Add(new MySqlParameter("@password", passwordBox.Text));
            command.Parameters.Add(new MySqlParameter("@Bio", BioBox.Text));
            command.CommandType = CommandType.StoredProcedure;
            try
            {
                var result = command.ExecuteNonQuery();
                if (result != 2)
                {
                    MessageBox.Show(@"not successful!");
                }
                else
                {
                    timer1.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (Opacity > 0.00)
            {
                Opacity -= 0.07;
            }
            else
            {
                timer1.Stop();
                Hide();
                var newForm = new LoginForm();
                newForm.ShowDialog();
                Close();
            }
        }
    }
}