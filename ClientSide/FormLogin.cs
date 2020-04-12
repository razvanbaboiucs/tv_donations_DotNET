using System;
using System.Windows.Forms;
using Model.Entities;
using Services;
using Services.Services;

namespace ClientServer_TvDonationsProject
{
    public partial class FormLogin : Form
    {
        private MainController _controller;
        private FormMain _formMain;
        public FormLogin(MainController controller)
        {
            _controller = controller;
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;
            try
            {
                Volunteer volunteer = _controller.FindVolunteer(username, password);
                _formMain = new FormMain(_controller);
                _formMain.Show();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Login Failed!\n");
            }
        }
        
    }
}