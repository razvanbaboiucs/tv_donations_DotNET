using System;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;
using Model.Entities;
using Services;
using Services.Services;

namespace ClientServer_TvDonationsProject
{
    public partial class FormLogin : Form
    {
        private IService _serverService;
        private FormMain _formMain;
        public FormLogin(IService serverService)
        {
            _serverService = serverService;
            _formMain = new FormMain(serverService);
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;
            try
            {
                Volunteer volunteer = _serverService.FindVolunteer(username, password);
                _formMain.Show();
            }
            catch (ValidationException exception)
            {
                MessageBox.Show("Login Failed!\n");
            }
        }
        
    }
}