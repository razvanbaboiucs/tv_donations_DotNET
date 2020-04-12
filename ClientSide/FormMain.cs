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
        
        public MainController _controller;
        public FormMain(MainController controller)
        {
            _controller = controller;
            _controller.updateEvent += DonationUpdate;
            InitializeComponent();
            Init();
            
        }

        public void DonationUpdate(object sender, DonationEvent e)
        {
            IEnumerable<Case> cases = e.Cases;
            IEnumerable<Donor> donors = e.Donors;
            dataGridViewCases.BeginInvoke(new UpdateDataGridCase(this.UpdateCasesDonationAdded), cases);
            dataGridViewDonors.BeginInvoke(new UpdateDataGridDonor(this.UpdateDonorsDonationAdded), donors);
        }

        private void UpdateCasesDonationAdded(IEnumerable<Case> casesList)
        {
            dataGridViewCases.Rows.Clear();
            IEnumerable<Case> cases = casesList;
            foreach (var currentCase in cases)
            {
                var index = dataGridViewCases.Rows.Add();
                dataGridViewCases.Rows[index].Cells["CaseName"].Value = currentCase.Name;
                dataGridViewCases.Rows[index].Cells["CaseTotalSumDonated"].Value = currentCase.TotalSumDonated;
                dataGridViewCases.Rows[index].Cells["CaseId"].Value = currentCase.Id;
            }
        }

        private void UpdateDonorsDonationAdded(IEnumerable<Donor> donorsList)
        {
            dataGridViewDonors.Rows.Clear();
            IEnumerable<Donor> donors = donorsList;
            foreach (var donor in donors)
            {
                var index = dataGridViewDonors.Rows.Add();
                dataGridViewDonors.Rows[index].Cells["DonorName"].Value = donor.Name;
                dataGridViewDonors.Rows[index].Cells["DonorAddress"].Value = donor.Address;
                dataGridViewDonors.Rows[index].Cells["DonorPhoneNumber"].Value = donor.PhoneNumber;
                dataGridViewDonors.Rows[index].Cells["DonorId"].Value = donor.Id;
            }
        }

        public delegate void UpdateDataGridCase(IEnumerable<Case> cases);

        public delegate void UpdateDataGridDonor(IEnumerable<Donor> donors);

        private void Init()
        {
            dataGridViewDonors.Rows.Clear();
            IEnumerable<Donor> donors = _controller.FindAllDonors();
            foreach (var donor in donors)
            {
                var index = dataGridViewDonors.Rows.Add();
                dataGridViewDonors.Rows[index].Cells["DonorName"].Value = donor.Name;
                dataGridViewDonors.Rows[index].Cells["DonorAddress"].Value = donor.Address;
                dataGridViewDonors.Rows[index].Cells["DonorPhoneNumber"].Value = donor.PhoneNumber;
                dataGridViewDonors.Rows[index].Cells["DonorId"].Value = donor.Id;
            }
            
            dataGridViewCases.Rows.Clear();
            IEnumerable<Case> cases = _controller.FindAllCases();
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
            if (dataGridViewDonors.SelectedRows.Count == 0 || dataGridViewCases.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row from donors and one from cases!");
            }
            else
            {
                try
                {
                    int caseId = Int32.Parse(dataGridViewCases.SelectedRows[0].Cells["CaseId"].Value.ToString());
                    double sumToDonate = Double.Parse(textBoxSumToDonate.Text);
                    int donorId = 0;
                    if (dataGridViewDonors.SelectedRows[0].Cells["DonorName"].Value.ToString() == textBoxDonorName.Text)
                    {
                        donorId = Int32.Parse(dataGridViewDonors.SelectedRows[0].Cells["DonorId"].Value.ToString());
                    }
                    else
                    {
                        string name = textBoxDonorName.Text;
                        string address = textBoxDonorAddress.Text;
                        string phoneNumber = textBoxDonorPhoneNumber.Text;
                        donorId = _controller.AddDonor(name, address, phoneNumber);
                    }
                    _controller.AddDonation(donorId, caseId, sumToDonate);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data not inserted corectly!\n" + ex);
                }
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
            IEnumerable<Donor> donors = _controller.FindAllDonorsBySubstring(substring);
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
            _controller.Logout();
            Close();
        }
    }
}