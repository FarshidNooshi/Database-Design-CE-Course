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
        private Dictionary<string, Form> _dictionary;
        private string nextPage = "log_in";
        private string _password = "";
        private int _richTextlent = 1;

        public RegisterForm()
        {
            InitializeComponent();
            _dictionary = new Dictionary<string, Form>()
            {
                {"register", new RegisterForm()},
                {"log_in", new LoginForm()}
            };
            _mySqlConnectionString =
                $"datasource={MySqlDatasource};port={MySqlPort};username={MySqlUsername};password={MySqlPassword};database={MySqlDataBase}";
            try
            {
                _mySqlConnection = new MySqlConnection(_mySqlConnectionString);
                _mySqlConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error: " + ex);
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
            if (submit_button.Text.Length == _richTextlent)
            {
                _password += submit_button.Text[0].ToString();
                submit_button.Text = submit_button.Text.Remove(0, 1);
                submit_button.Text += "*";
            }
            else
            {
                _password = "";
                submit_button.Text = "";
            }

            _richTextlent = submit_button.Text.Length + 1;
        }

        private void submit_button_click(object sender, EventArgs e)
        {
            var query = @"log_in";
            var command = new MySqlCommand(query, _mySqlConnection) {CommandTimeout = 60};
            command.Parameters.Add(new MySqlParameter("@first_name", MySqlDbType.VarChar));
            command.Parameters.Add(new MySqlParameter("@second_name", MySqlDbType.VarChar));
            command.Parameters.Add(new MySqlParameter("@second_name", MySqlDbType.VarChar));
            command.Parameters.Add(new MySqlParameter("@birth_date", MySqlDbType.Timestamp));
            command.Parameters.Add(new MySqlParameter("@password", MySqlDbType.VarChar));
            command.Parameters.Add(new MySqlParameter("@Bio", MySqlDbType.VarChar));
            command.CommandType = CommandType.StoredProcedure;
            try
            {
                var result = command.ExecuteNonQuery();
                if (result != 0)
                {
                    MessageBox.Show(
                }

                timer1.Start();
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
                var newForm = _dictionary[nextPage];
                newForm.ShowDialog();
                Close();
            }
        }
    }
}