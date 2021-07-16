using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Final_Project
{
    public partial class LoginForm : Form
    {
        private const string MySqlDatasource = "127.0.0.1";
        private const string MySqlPort = "3306";
        private const string MySqlUsername = "root";
        private const string MySqlPassword = "";
        private const string MySqlDataBase = "proj1_db_aut";
        private string _mySqlConnectionString;
        private MySqlConnection _mySqlConnection;
        private string nextPage = "log_in";
        public LoginForm()
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
                MessageBox.Show("error: " + ex);
            }
        }

        private void button1_Click(object sender, System.EventArgs e)// show_logs
        {
            var query = @"show_logs";
            var command = new MySqlCommand(query, _mySqlConnection) { CommandTimeout = 60 };
            command.CommandType = CommandType.StoredProcedure;
            var result = command.ExecuteReader();

        }
    }
}