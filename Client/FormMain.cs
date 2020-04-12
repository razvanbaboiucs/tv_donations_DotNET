using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model.Entities;
using Services;
using Services.Services;

namespace ClientServer_TvDonationsProject
{
    public partial class FormMain : Form
    {
        private IService _serverService;
        public FormMain(IService serverService)
        {
            _serverService = serverService;
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            dataGridViewDonors.Rows.Clear();
            IEnumerable<Donor> donors = _serverService.FindAllDonors();
            foreach (var donor in donors)
            {
                var index = dataGridViewDonors.Rows.Add();
                dataGridViewDonors.Rows[index].Cells["DonorName"].Value = donor.Name;
                dataGridViewDonors.Rows[index].Cells["DonorAddress"].Value = donor.Address;
                dataGridViewDonors.Rows[index].Cells["DonorPhoneNumber"].Value = donor.PhoneNumber;
                dataGridViewDonors.Rows[index].Cells["DonorId"].Value = donor.Id;
            }
            
            dataGridViewCases.Rows.Clear();
            IEnumerable<Case> cases = _serverService.FindAllCases();
            foreach (var currentCase in cases)
            {
                var index = dataGridViewCases.Rows.Add();
                dataGridViewCases.Rows[index].Cells["CaseName"].Value = currentCase.Name;
                dataGridViewCases.Rows[index].Cells["CaseTotalSumDonated"].Value = currentCase.TotalSumDonated;
                dataGridViewCases.Rows[index].Cells["CaseId"].Value = currentCase.Id;
            }
        }

        private void buttonDonate_Click(object sender, EventArgs e)
        {
            try
            {
                int caseId = Int32.Parse(dataGridViewCases.SelectedRows[0].Cells["CaseId"].Value.ToString());
                double sumToDonate = Double.Parse(textBoxSumToDonate.Text);
                int donorId = 0;
                if (dataGridViewDonors.SelectedRows.Count > 0)
                {
                    donorId = Int32.Parse(dataGridViewDonors.SelectedRows[0].Cells["DonorId"].Value.ToString());
                }
                else
                {
                    string name = textBoxDonorName.Text;
                    string address = textBoxDonorAddress.Text;
                    string phoneNumber = textBoxDonorPhoneNumber.Text;
                    donorId = _serverService.AddDonor(name, address, phoneNumber);
                }
                _serverService.AddDonation(donorId, caseId, sumToDonate);
                _serverService.UpdateCase(caseId, sumToDonate);
                Init();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data not inserted corectly!\n" + ex);
            }
        }

        private void buttonDeselect_Click(object sender, EventArgs e)
        {
            dataGridViewDonors.ClearSelection();
        }

        private void dataGridViewCases_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridViewDonors_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
          
            dataGridViewDonors.Rows.Clear();
            dataGridViewDonors.ClearSelection();
            string substring = textBoxDonorName.Text;
            IEnumerable<Donor> donors = _serverService.FindAllDonorsBySubstring(substring);
            foreach (var donor in donors)
            {
                var index = dataGridViewDonors.Rows.Add();
                dataGridViewDonors.Rows[index].Cells["DonorName"].Value = donor.Name;
                dataGridViewDonors.Rows[index].Cells["DonorAddress"].Value = donor.Address;
                dataGridViewDonors.Rows[index].Cells["DonorPhoneNumber"].Value = donor.PhoneNumber;
                dataGridViewDonors.Rows[index].Cells["DonorId"].Value = donor.Id;
            }
        }

        private void dataGridViewDonors_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewDonors.SelectedRows.Count > 0)
            {
                textBoxDonorName.Text = dataGridViewDonors.SelectedRows[0].Cells["DonorName"].Value.ToString();
                textBoxDonorAddress.Text = dataGridViewDonors.SelectedRows[0].Cells["DonorAddress"].Value.ToString();
                textBoxDonorPhoneNumber.Text =
                    dataGridViewDonors.SelectedRows[0].Cells["DonorPhoneNumber"].Value.ToString();
            }
        }

        private void dataGridViewCases_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridViewCases.SelectedRows.Count > 0)
                textBoxCaseName.Text = dataGridViewCases.SelectedRows[0].Cells["CaseName"].Value.ToString();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}