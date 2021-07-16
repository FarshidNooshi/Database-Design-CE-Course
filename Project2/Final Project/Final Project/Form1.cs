using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Final_Project
{
    public partial class Form1 : Form
    {
        private string _password = "";
        private int _richTextlent = 1;

        private const string MySqlDatasource = "127.0.0.1";
        private const string MySqlPort = "3306";
        private const string MySqlUsername = "root";
        private const string MySqlPassword = "";
        private const string MySqlDataBase = "proj1_db_aut";
        private string _mySqlConnectionString;
        private MySqlConnection _mySqlConnection;
        private Dictionary<string, Form> _dictionary;
        private string nextPage = "log_in";

        public Form1()
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

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void username_box_enter(object sender, EventArgs e)
        {
            username_box.Text = "";
        }

        private void password_box_enter(object sender, EventArgs e)
        {
            password_box.Text = "";
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            var query = @"log_in";
            var command = new MySqlCommand(query, _mySqlConnection) {CommandTimeout = 60};
            command.Parameters.Add(new MySqlParameter("@result", MySqlDbType.VarChar));
            command.Parameters.Add(new MySqlParameter("@username", username_box.Text));
            command.Parameters.Add(new MySqlParameter("@password", _password));
            command.Parameters["@result"].Direction = ParameterDirection.Output;
            command.CommandType = CommandType.StoredProcedure;
            try
            {
                command.ExecuteNonQuery();
                var result = command.Parameters["@result"].Value;
                if (result.Equals(username_box.Text))
                {
                    timer1.Start();
                }
                else
                {
                    MessageBox.Show(@"unsuccessful attempt!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void register_button_Click(object sender, EventArgs e)
        {
            nextPage = "register";
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
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