using System.Windows.Forms;

namespace Final_Project
{
    public partial class FieldsForm : Form
    {
        public FieldsForm(LoginForm loginForm)
        {
            InitializeComponent();
            box1.Visible = false;
            box2.Visible = false;
            box3.Visible = false;
            box4.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            this.loginForm = loginForm;
        }

        private void submit_button_Click(object sender, System.EventArgs e)
        {
            Opacity = 0.0;
            if (LoginForm.type.Equals("send_ava"))
            {
                loginForm.send_ava(this);
            }
            if (LoginForm.type.Equals("followingSomeone"))
            {
                loginForm.followingSomeone(this);
            }
            if (LoginForm.type.Equals("unfollowingSomeone"))
            {
                loginForm.unfollowingSomeone(this);
            }
            if (LoginForm.type.Equals("blockSomeone"))
            {
                loginForm.blockSomeone(this);
            }
            if (LoginForm.type.Equals("unblockSomeone"))
            {
                loginForm.unblockSomeone(this);
            }
            if (LoginForm.type.Equals("showAvasFromSpecificUser"))
            {
                loginForm.showAvasFromSpecificUser(this);
            }
            if (LoginForm.type.Equals("AddOppinion"))
            {
                loginForm.AddOppinion(this);
            }
            if (LoginForm.type.Equals("GetOpinionsOfAAva"))
            {
                loginForm.GetOpinionsOfAAva(this);
            }
            if (LoginForm.type.Equals("add_hashtag_of_ava"))
            {
                loginForm.add_hashtag_of_ava(this);
            }
            if (LoginForm.type.Equals("GetAvasWithSpecialSign"))
            {
                loginForm.GetAvasWithSpecialSign(this);
            }
            if (LoginForm.type.Equals("likeAva"))
            {
                loginForm.likeAva(this);
            }
            if (LoginForm.type.Equals("ShowNumberOfLikes"))
            {
                loginForm.ShowNumberOfLikes(this);
            }
            if (LoginForm.type.Equals("showLikersOfAnAva"))
            {
                loginForm.showLikersOfAnAva(this);
            }
            if (LoginForm.type.Equals("send_message"))
            {
                loginForm.send_message(this);
            }
            if (LoginForm.type.Equals("GetMessagesFromSpecialUser"))
            {
                loginForm.GetMessagesFromSpecialUser(this);
            }
        }
    }
}