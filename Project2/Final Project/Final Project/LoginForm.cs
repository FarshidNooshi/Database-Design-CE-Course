using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
        public static string type { get; set; }
        private Dictionary<string, Func<int>> methods;

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

        private void button1_Click(object sender, System.EventArgs e) // show_logs
        {
            var query = @"show_logs";
            using var command = new MySqlCommand(query, _mySqlConnection) {CommandTimeout = 60};
            command.CommandType = CommandType.StoredProcedure;
            using var result = command.ExecuteReader();
            var resultPage = new result_page();
            resultPage.listView1.Columns.Add("user name", 300);
            resultPage.listView1.Columns.Add("log time", 500);
            resultPage.listView1.Columns.Add("type", 300);
            initListView(resultPage);
            while (result.Read())
            {
                var arr = new List<string>();
                arr.Add(result.GetString(0));
                arr.Add(result.GetString(1));
                arr.Add(result.GetString(2));
                resultPage.listView1.Items.Add(new ListViewItem(arr.ToArray()));
            }

            resultPage.ShowDialog();
        }

        private void initListView(result_page resultPage)
        {
            resultPage.listView1.View = View.Details;
            resultPage.listView1.GridLines = true;
            resultPage.listView1.FullRowSelect = true;
        }

        private void button21_Click(object sender, EventArgs e) // send_ava
        {
            var form = new FieldsForm(this);
            type = "send_ava";
            form.box1.Visible = true;
            form.label1.Visible = true;
            form.box1.Text = "";
            form.label1.Text = "attributes";
            form.ShowDialog();
        }

        public void send_ava(FieldsForm form)
        {
            var query = @"send_ava";
            using var command = new MySqlCommand(query, _mySqlConnection) {CommandTimeout = 60};
            command.Parameters.Add(new MySqlParameter("@attributes", form.box1.Text));
            command.CommandType = CommandType.StoredProcedure;
            var result = command.ExecuteNonQuery();
            if (result == 2)
            {
                MessageBox.Show("success");
            }

            form.Close();
        }

        private void button23_Click(object sender, EventArgs e) //get_avas_of_someone
        {
            var query = @"get_avas_of_someone";
            using var command = new MySqlCommand(query, _mySqlConnection) {CommandTimeout = 60};
            command.CommandType = CommandType.StoredProcedure;
            using var result = command.ExecuteReader();
            var resultPage = new result_page();
            resultPage.listView1.Columns.Add("sender_user", 300);
            resultPage.listView1.Columns.Add("time", 500);
            resultPage.listView1.Columns.Add("Attributes", 400);
            initListView(resultPage);
            while (result.Read())
            {
                var arr = new List<string>();
                arr.Add(result.GetString(0));
                arr.Add(result.GetString(1));
                arr.Add(result.GetString(2));
                resultPage.listView1.Items.Add(new ListViewItem(arr.ToArray()));
            }

            resultPage.ShowDialog();
        }

        private void button24_Click(object sender, EventArgs e) //followingSomeone
        {
            var form = new FieldsForm(this);
            type = "followingSomeone";
            form.box1.Visible = true;
            form.label1.Visible = true;
            form.box1.Text = "";
            form.label1.Text = "following_user";
            form.ShowDialog();
        }

        public void followingSomeone(FieldsForm form)
        {
            var query = @"followingSomeone";
            using var command = new MySqlCommand(query, _mySqlConnection) {CommandTimeout = 60};
            command.Parameters.Add(new MySqlParameter("@following_user", form.box1.Text));
            command.CommandType = CommandType.StoredProcedure;
            var result = command.ExecuteNonQuery();
            if (result == 1)
            {
                MessageBox.Show("success");
                form.Close();
            }
        }

        private void button25_Click(object sender, EventArgs e) //unfollowingSomeone
        {
            var form = new FieldsForm(this);
            type = "unfollowingSomeone";
            form.box1.Visible = true;
            form.label1.Visible = true;
            form.box1.Text = "";
            form.label1.Text = "following_user";
            form.ShowDialog();
        }

        public void unfollowingSomeone(FieldsForm form)
        {
            var query = @"unfollowingSomeone";
            using var command = new MySqlCommand(query, _mySqlConnection) {CommandTimeout = 60};
            command.Parameters.Add(new MySqlParameter("@following_user", form.box1.Text));
            command.CommandType = CommandType.StoredProcedure;
            var result = command.ExecuteNonQuery();
            if (result == 1)
            {
                MessageBox.Show("success");
                form.Close();
            }
        }

        private void button26_Click(object sender, EventArgs e) //blockSomeone
        {
            var form = new FieldsForm(this);
            type = "blockSomeone";
            form.box1.Visible = true;
            form.label1.Visible = true;
            form.box1.Text = "";
            form.label1.Text = "blocked_user";
            form.ShowDialog();
        }

        public void blockSomeone(FieldsForm form)
        {
            var query = @"blockSomeone";
            using var command = new MySqlCommand(query, _mySqlConnection) {CommandTimeout = 60};
            command.Parameters.Add(new MySqlParameter("@blocked_user", form.box1.Text));
            command.CommandType = CommandType.StoredProcedure;
            var result = command.ExecuteNonQuery();
            if (result == 1)
            {
                MessageBox.Show("success");
                form.Close();
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            var form = new FieldsForm(this);
            type = "unblockSomeone";
            form.box1.Visible = true;
            form.label1.Visible = true;
            form.box1.Text = "";
            form.label1.Text = "blocked_user";
            form.ShowDialog();
        }

        public void unblockSomeone(FieldsForm form)
        {
            var query = @"unblockSomeone";
            using var command = new MySqlCommand(query, _mySqlConnection) {CommandTimeout = 60};
            command.Parameters.Add(new MySqlParameter("@blocked_user", form.box1.Text));
            command.CommandType = CommandType.StoredProcedure;
            var result = command.ExecuteNonQuery();
            if (result == 1)
            {
                MessageBox.Show("success");
                form.Close();
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            var query = @"showAvasFromFollowings";
            using var command = new MySqlCommand(query, _mySqlConnection) {CommandTimeout = 60};
            command.CommandType = CommandType.StoredProcedure;
            using var result = command.ExecuteReader();
            var resultPage = new result_page();
            resultPage.listView1.Columns.Add("Attributes", 300);
            resultPage.listView1.Columns.Add("time", 500);
            resultPage.listView1.Columns.Add("sender_user", 400);
            initListView(resultPage);
            while (result.Read())
            {
                var arr = new List<string>();
                arr.Add(result.GetString(0));
                arr.Add(result.GetString(1));
                arr.Add(result.GetString(2));
                resultPage.listView1.Items.Add(new ListViewItem(arr.ToArray()));
            }

            resultPage.ShowDialog();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            var form = new FieldsForm(this);
            type = "showAvasFromSpecificUser";
            form.box1.Visible = true;
            form.label1.Visible = true;
            form.box1.Text = "";
            form.label1.Text = "specific_user";
            form.ShowDialog();
        }

        public void showAvasFromSpecificUser(FieldsForm form)
        {
            var query = @"showAvasFromSpecificUser";
            using var command = new MySqlCommand(query, _mySqlConnection) {CommandTimeout = 60};
            command.Parameters.Add(new MySqlParameter("@specific_user", form.box1.Text));
            command.CommandType = CommandType.StoredProcedure;
            using var result = command.ExecuteReader();
            var resultPage = new result_page();
            resultPage.listView1.Columns.Add("Attributes", 300);
            resultPage.listView1.Columns.Add("time", 500);
            resultPage.listView1.Columns.Add("sender_user", 400);
            initListView(resultPage);
            while (result.Read())
            {
                var arr = new List<string>();
                arr.Add(result.GetString(0));
                arr.Add(result.GetString(1));
                arr.Add(result.GetString(2));
                resultPage.listView1.Items.Add(new ListViewItem(arr.ToArray()));
            }

            resultPage.ShowDialog();
            form.Close();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            var form = new FieldsForm(this);
            type = "AddOppinion";
            form.box1.Visible = true;
            form.label1.Visible = true;
            form.box1.Text = "";
            form.label1.Text = "attributes";

            form.box2.Visible = true;
            form.label2.Visible = true;
            form.box2.Text = "";
            form.label2.Text = "ava_id";
            form.ShowDialog();
        }

        public void AddOppinion(FieldsForm form)
        {
            var query = @"AddOppinion";
            using var command = new MySqlCommand(query, _mySqlConnection) {CommandTimeout = 60};
            command.Parameters.Add(new MySqlParameter("@attributes", form.box1.Text));
            command.Parameters.Add(new MySqlParameter("@ava_id", form.box2.Text));
            command.CommandType = CommandType.StoredProcedure;
            var result = command.ExecuteNonQuery();
            if (result == 3)
            {
                MessageBox.Show("success");
                form.Close();
            }
        }

        private void button31_Click(object sender, EventArgs e)
        {
            var form = new FieldsForm(this);
            type = "GetOpinionsOfAAva";
            form.box1.Visible = true;
            form.label1.Visible = true;
            form.box1.Text = "";
            form.label1.Text = "ava_id";
            form.ShowDialog();
        }

        public void GetOpinionsOfAAva(FieldsForm form)
        {
            var query = @"GetOpinionsOfAAva";
            using var command = new MySqlCommand(query, _mySqlConnection) {CommandTimeout = 60};
            command.Parameters.Add(new MySqlParameter("@ava_id", form.box1.Text));
            command.CommandType = CommandType.StoredProcedure;
            using var result = command.ExecuteReader();
            var resultPage = new result_page();
            resultPage.listView1.Columns.Add("sender_user", 300);
            resultPage.listView1.Columns.Add("time", 500);
            resultPage.listView1.Columns.Add("Attributes", 400);
            resultPage.listView1.Columns.Add("Ava_id", 400);
            initListView(resultPage);
            while (result.Read())
            {
                var arr = new List<string>();
                arr.Add(result.GetString(0));
                arr.Add(result.GetString(1));
                arr.Add(result.GetString(2));
                arr.Add(result.GetString(3));
                resultPage.listView1.Items.Add(new ListViewItem(arr.ToArray()));
            }

            resultPage.ShowDialog();
            form.Close();
        }

        private void button32_Click(object sender, EventArgs e) //add_hashtag_of_ava
        {
            var form = new FieldsForm(this);
            type = "add_hashtag_of_ava";
            form.box1.Visible = true;
            form.label1.Visible = true;
            form.box1.Text = "";
            form.label1.Text = "sign";

            form.box2.Visible = true;
            form.label2.Visible = true;
            form.box2.Text = "";
            form.label2.Text = "avaID";

            form.box3.Visible = true;
            form.label3.Visible = true;
            form.box3.Text = "";
            form.label3.Text = "time";
            form.ShowDialog();
        }

        public void add_hashtag_of_ava(FieldsForm form)
        {
            var query = @"add_hashtag_of_ava";
            using var command = new MySqlCommand(query, _mySqlConnection) {CommandTimeout = 60};
            command.Parameters.Add(new MySqlParameter("@sign", form.box1.Text));
            command.Parameters.Add(new MySqlParameter("@avaID", form.box2.Text));
            command.Parameters.Add(new MySqlParameter("@time", form.box3.Text));
            command.CommandType = CommandType.StoredProcedure;
            var result = command.ExecuteNonQuery();
            if (result == 2)
            {
                MessageBox.Show("success");
                form.Close();
            }

            form.Close();
        }

        private void button33_Click(object sender, EventArgs e) //GetAvasWithSpecialSign
        {
            var form = new FieldsForm(this);
            type = "GetAvasWithSpecialSign";
            form.box1.Visible = true;
            form.label1.Visible = true;
            form.box1.Text = "";
            form.label1.Text = "special_sign_id";
            form.ShowDialog();
        }

        public void GetAvasWithSpecialSign(FieldsForm form)
        {
            var query = @"GetAvasWithSpecialSign";
            using var command = new MySqlCommand(query, _mySqlConnection) {CommandTimeout = 60};
            command.Parameters.Add(new MySqlParameter("@special_sign_id", form.box1.Text));
            command.CommandType = CommandType.StoredProcedure;
            using var result = command.ExecuteReader();
            var resultPage = new result_page();
            resultPage.listView1.Columns.Add("Ava_id", 400);
            resultPage.listView1.Columns.Add("Attributes", 400);
            resultPage.listView1.Columns.Add("sender_user", 300);
            resultPage.listView1.Columns.Add("time", 500);
            initListView(resultPage);
            while (result.Read())
            {
                var arr = new List<string>
                {
                    result.GetString(0),
                    result.GetString(1),
                    result.GetString(2),
                    result.GetString(3)
                };
                resultPage.listView1.Items.Add(new ListViewItem(arr.ToArray()));
            }

            resultPage.ShowDialog();
            form.Close();
        }

        private void button34_Click(object sender, EventArgs e) //likeAva
        {
            var form = new FieldsForm(this);
            type = "likeAva";
            form.box1.Visible = true;
            form.label1.Visible = true;
            form.box1.Text = "";
            form.label1.Text = "ava_id";

            form.ShowDialog();
        }

        public void likeAva(FieldsForm form)
        {
            var query = @"likeAva";
            using var command = new MySqlCommand(query, _mySqlConnection) {CommandTimeout = 60};
            command.Parameters.Add(new MySqlParameter("@ava_id", form.box1.Text));
            command.CommandType = CommandType.StoredProcedure;
            var result = command.ExecuteNonQuery();
            if (result == 1)
            {
                MessageBox.Show("success");
                form.Close();
            }
        }

        private void button35_Click(object sender, EventArgs e) //ShowNumberOfLikes
        {
            var form = new FieldsForm(this);
            type = "ShowNumberOfLikes";
            form.box1.Visible = true;
            form.label1.Visible = true;
            form.box1.Text = "";
            form.label1.Text = "ava_id";

            form.ShowDialog();
        }

        public void ShowNumberOfLikes(FieldsForm form)
        {
            var query = @"ShowNumberOfLikes";
            using var command = new MySqlCommand(query, _mySqlConnection) {CommandTimeout = 60};
            command.Parameters.Add(new MySqlParameter("@ava_id", form.box1.Text));
            command.CommandType = CommandType.StoredProcedure;
            using var result = command.ExecuteReader();
            var resultPage = new result_page();
            resultPage.listView1.Columns.Add("number of likes", 400);
            initListView(resultPage);
            while (result.Read())
            {
                var arr = new List<string>
                {
                    result.GetString(0),
                };
                resultPage.listView1.Items.Add(new ListViewItem(arr.ToArray()));
            }

            resultPage.ShowDialog();
            form.Close();
        }

        private void button36_Click(object sender, EventArgs e)
        {
            var form = new FieldsForm(this);
            type = "showLikersOfAnAva";
            form.box1.Visible = true;
            form.label1.Visible = true;
            form.box1.Text = "";
            form.label1.Text = "ava_id";

            form.ShowDialog();
        }

        public void showLikersOfAnAva(FieldsForm form)
        {
            var query = @"showLikersOfAnAva";
            using var command = new MySqlCommand(query, _mySqlConnection) {CommandTimeout = 60};
            command.Parameters.Add(new MySqlParameter("@ava_id", form.box1.Text));
            command.CommandType = CommandType.StoredProcedure;
            using var result = command.ExecuteReader();
            var resultPage = new result_page();
            resultPage.listView1.Columns.Add("like_time", 400);
            resultPage.listView1.Columns.Add("liker_user_name", 400);
            initListView(resultPage);
            while (result.Read())
            {
                var arr = new List<string>
                {
                    result.GetString(0),
                    result.GetString(1)
                };
                resultPage.listView1.Items.Add(new ListViewItem(arr.ToArray()));
            }

            resultPage.ShowDialog();
            form.Close();
        }

        private void button37_Click(object sender, EventArgs e)
        {
            var query = @"showPopularAvas";
            using var command = new MySqlCommand(query, _mySqlConnection) {CommandTimeout = 60};
            command.CommandType = CommandType.StoredProcedure;
            using var result = command.ExecuteReader();
            var resultPage = new result_page();
            resultPage.listView1.Columns.Add("count_of_likes", 400);
            resultPage.listView1.Columns.Add("Ava_id", 400);
            resultPage.listView1.Columns.Add("sender_user", 300);
            resultPage.listView1.Columns.Add("time", 500);
            resultPage.listView1.Columns.Add("Attributes", 400);
            initListView(resultPage);
            while (result.Read())
            {
                var arr = new List<string>
                {
                    result.GetString(0),
                    result.GetString(1),
                    result.GetString(2),
                    result.GetString(3),
                    result.GetString(4)
                };
                resultPage.listView1.Items.Add(new ListViewItem(arr.ToArray()));
            }

            resultPage.ShowDialog();
        }

        private void button38_Click(object sender, EventArgs e)
        {
            var form = new FieldsForm(this);
            type = "send_message";
            form.box1.Visible = true;
            form.label1.Visible = true;
            form.box1.Text = "";
            form.label1.Text = "attributes";

            form.box2.Visible = true;
            form.label2.Visible = true;
            form.box2.Text = "";
            form.label2.Text = "to_id";

            form.box3.Visible = true;
            form.label3.Visible = true;
            form.box3.Text = "";
            form.label3.Text = "text";
            form.ShowDialog();
        }

        public void send_message(FieldsForm form)
        {
            var query = @"send_message";
            using var command = new MySqlCommand(query, _mySqlConnection) {CommandTimeout = 60};
            command.Parameters.Add(new MySqlParameter("@attributes", form.box1.Text));
            command.Parameters.Add(new MySqlParameter("@to_id", form.box2.Text));
            command.Parameters.Add(new MySqlParameter("@text", form.box3.Text));
            command.CommandType = CommandType.StoredProcedure;
            var result = command.ExecuteNonQuery();
            if (result == 3 || result == 1)
            {
                MessageBox.Show("success");
                form.Close();
            }

            form.Close();
        }

        private void button39_Click(object sender, EventArgs e)
        {
            var form = new FieldsForm(this);
            type = "GetMessagesFromSpecialUser";
            form.box1.Visible = true;
            form.label1.Visible = true;
            form.box1.Text = "";
            form.label1.Text = "from_id";

            form.ShowDialog();
        }

        public void GetMessagesFromSpecialUser(FieldsForm form)
        {
            var query = @"GetMessagesFromSpecialUser";
            using var command = new MySqlCommand(query, _mySqlConnection) {CommandTimeout = 60};
            command.Parameters.Add(new MySqlParameter("@from_id", form.box1.Text));
            command.CommandType = CommandType.StoredProcedure;
            using var result = command.ExecuteReader();
            var resultPage = new result_page();
            resultPage.listView1.Columns.Add("from_id", 200);
            resultPage.listView1.Columns.Add("text", 300);
            resultPage.listView1.Columns.Add("ava_id", 200);
            resultPage.listView1.Columns.Add("Attributes", 400);
            resultPage.listView1.Columns.Add("time", 200);
            initListView(resultPage);
            while (result.Read())
            {
                object[] objects = new object[5];
                var items = result.GetValues(objects);
                var arr = new List<string>();
                for (int i = 0; i < 5; i++)
                {
                    if (objects[i] == null)
                    {
                        arr.Add("");
                    }
                    else
                    {
                        arr.Add(objects[i].ToString());
                    }
                }

                resultPage.listView1.Items.Add(new ListViewItem(arr.ToArray()));
            }

            resultPage.ShowDialog();
            form.Close();
        }

        private void button40_Click(object sender, EventArgs e)
        {
            var query = @"Get_List_Of_Senders";
            using var command = new MySqlCommand(query, _mySqlConnection) {CommandTimeout = 60};
            command.CommandType = CommandType.StoredProcedure;
            using var result = command.ExecuteReader();
            var resultPage = new result_page();
            resultPage.listView1.Columns.Add("from", 300);
            resultPage.listView1.Columns.Add("time", 500);
            initListView(resultPage);
            while (result.Read())
            {
                var arr = new List<string>();
                arr.Add(result.GetString(0));
                arr.Add(result.GetString(1));
                resultPage.listView1.Items.Add(new ListViewItem(arr.ToArray()));
            }

            resultPage.ShowDialog();
        }
    }
}