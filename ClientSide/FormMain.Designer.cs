﻿using System.ComponentModel;

namespace ClientServer_TvDonationsProject
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.dataGridViewCases = new System.Windows.Forms.DataGridView();
            this.CaseId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CaseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CaseTotalSumDonated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewDonors = new System.Windows.Forms.DataGridView();
            this.DonorId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonorAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonorPhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.labelCases = new System.Windows.Forms.Label();
            this.labelDonors = new System.Windows.Forms.Label();
            this.textBoxCaseName = new System.Windows.Forms.TextBox();
            this.labelCaseName = new System.Windows.Forms.Label();
            this.labelSumToDonate = new System.Windows.Forms.Label();
            this.textBoxSumToDonate = new System.Windows.Forms.TextBox();
            this.labelDonorName = new System.Windows.Forms.Label();
            this.textBoxDonorName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDonorAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDonorPhoneNumber = new System.Windows.Forms.TextBox();
            this.buttonDonate = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridViewCases)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridViewDonors)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewCases
            // 
            this.dataGridViewCases.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCases.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
                {this.CaseId, this.CaseName, this.CaseTotalSumDonated});
            this.dataGridViewCases.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridViewCases.Location = new System.Drawing.Point(31, 108);
            this.dataGridViewCases.MultiSelect = false;
            this.dataGridViewCases.Name = "dataGridViewCases";
            this.dataGridViewCases.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCases.Size = new System.Drawing.Size(286, 507);
            this.dataGridViewCases.TabIndex = 0;
            this.dataGridViewCases.CellContentClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCases_CellContentClick);
            this.dataGridViewCases.SelectionChanged += new System.EventHandler(this.dataGridViewCases_SelectionChanged);
            // 
            // CaseId
            // 
            this.CaseId.HeaderText = "Id";
            this.CaseId.Name = "CaseId";
            this.CaseId.Visible = false;
            // 
            // CaseName
            // 
            this.CaseName.HeaderText = "Name";
            this.CaseName.Name = "CaseName";
            // 
            // CaseTotalSumDonated
            // 
            this.CaseTotalSumDonated.HeaderText = "Total sum donated";
            this.CaseTotalSumDonated.Name = "CaseTotalSumDonated";
            // 
            // dataGridViewDonors
            // 
            this.dataGridViewDonors.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDonors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
                {this.DonorId, this.DonorName, this.DonorAddress, this.DonorPhoneNumber});
            this.dataGridViewDonors.Location = new System.Drawing.Point(759, 108);
            this.dataGridViewDonors.MultiSelect = false;
            this.dataGridViewDonors.Name = "dataGridViewDonors";
            this.dataGridViewDonors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDonors.Size = new System.Drawing.Size(360, 507);
            this.dataGridViewDonors.TabIndex = 1;
            this.dataGridViewDonors.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDonors_CellContentClick);
            this.dataGridViewDonors.SelectionChanged +=
                new System.EventHandler(this.dataGridViewDonors_SelectionChanged);
            // 
            // DonorId
            // 
            this.DonorId.HeaderText = "Id";
            this.DonorId.Name = "DonorId";
            this.DonorId.Visible = false;
            // 
            // DonorName
            // 
            this.DonorName.HeaderText = "Name";
            this.DonorName.Name = "DonorName";
            // 
            // DonorAddress
            // 
            this.DonorAddress.HeaderText = "Address";
            this.DonorAddress.Name = "DonorAddress";
            // 
            // DonorPhoneNumber
            // 
            this.DonorPhoneNumber.HeaderText = "Phone number";
            this.DonorPhoneNumber.Name = "DonorPhoneNumber";
            // 
            // buttonLogout
            // 
            this.buttonLogout.Location = new System.Drawing.Point(1046, 30);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(75, 31);
            this.buttonLogout.TabIndex = 2;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // labelCases
            // 
            this.labelCases.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.labelCases.Location = new System.Drawing.Point(31, 76);
            this.labelCases.Name = "labelCases";
            this.labelCases.Size = new System.Drawing.Size(96, 30);
            this.labelCases.TabIndex = 3;
            this.labelCases.Text = "Cases :";
            // 
            // labelDonors
            // 
            this.labelDonors.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.labelDonors.Location = new System.Drawing.Point(759, 76);
            this.labelDonors.Name = "labelDonors";
            this.labelDonors.Size = new System.Drawing.Size(100, 23);
            this.labelDonors.TabIndex = 4;
            this.labelDonors.Text = "Donors :";
            // 
            // textBoxCaseName
            // 
            this.textBoxCaseName.Location = new System.Drawing.Point(479, 224);
            this.textBoxCaseName.Name = "textBoxCaseName";
            this.textBoxCaseName.ReadOnly = true;
            this.textBoxCaseName.Size = new System.Drawing.Size(228, 23);
            this.textBoxCaseName.TabIndex = 5;
            // 
            // labelCaseName
            // 
            this.labelCaseName.Location = new System.Drawing.Point(388, 227);
            this.labelCaseName.Name = "labelCaseName";
            this.labelCaseName.Size = new System.Drawing.Size(75, 23);
            this.labelCaseName.TabIndex = 6;
            this.labelCaseName.Text = "Case name:";
            // 
            // labelSumToDonate
            // 
            this.labelSumToDonate.Location = new System.Drawing.Point(363, 280);
            this.labelSumToDonate.Name = "labelSumToDonate";
            this.labelSumToDonate.Size = new System.Drawing.Size(100, 23);
            this.labelSumToDonate.TabIndex = 7;
            this.labelSumToDonate.Text = "Sum to donate:";
            // 
            // textBoxSumToDonate
            // 
            this.textBoxSumToDonate.Location = new System.Drawing.Point(479, 277);
            this.textBoxSumToDonate.Name = "textBoxSumToDonate";
            this.textBoxSumToDonate.Size = new System.Drawing.Size(228, 23);
            this.textBoxSumToDonate.TabIndex = 8;
            // 
            // labelDonorName
            // 
            this.labelDonorName.Location = new System.Drawing.Point(378, 327);
            this.labelDonorName.Name = "labelDonorName";
            this.labelDonorName.Size = new System.Drawing.Size(85, 23);
            this.labelDonorName.TabIndex = 9;
            this.labelDonorName.Text = "Donor name:";
            // 
            // textBoxDonorName
            // 
            this.textBoxDonorName.Location = new System.Drawing.Point(479, 324);
            this.textBoxDonorName.Name = "textBoxDonorName";
            this.textBoxDonorName.Size = new System.Drawing.Size(228, 23);
            this.textBoxDonorName.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(367, 372);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 23);
            this.label1.TabIndex = 11;
            this.label1.Text = "Donor address:";
            // 
            // textBoxDonorAddress
            // 
            this.textBoxDonorAddress.Location = new System.Drawing.Point(479, 368);
            this.textBoxDonorAddress.Name = "textBoxDonorAddress";
            this.textBoxDonorAddress.Size = new System.Drawing.Size(228, 23);
            this.textBoxDonorAddress.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(329, 418);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 23);
            this.label2.TabIndex = 13;
            this.label2.Text = "Donor phone number:";
            // 
            // textBoxDonorPhoneNumber
            // 
            this.textBoxDonorPhoneNumber.Location = new System.Drawing.Point(479, 415);
            this.textBoxDonorPhoneNumber.Name = "textBoxDonorPhoneNumber";
            this.textBoxDonorPhoneNumber.Size = new System.Drawing.Size(228, 23);
            this.textBoxDonorPhoneNumber.TabIndex = 14;
            // 
            // buttonDonate
            // 
            this.buttonDonate.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.buttonDonate.Location = new System.Drawing.Point(503, 503);
            this.buttonDonate.Name = "buttonDonate";
            this.buttonDonate.Size = new System.Drawing.Size(97, 36);
            this.buttonDonate.TabIndex = 15;
            this.buttonDonate.Text = "Donate";
            this.buttonDonate.UseVisualStyleBackColor = true;
            this.buttonDonate.Click += new System.EventHandler(this.buttonDonate_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Image = ((System.Drawing.Image) (resources.GetObject("buttonSearch.Image")));
            this.buttonSearch.Location = new System.Drawing.Point(713, 316);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(40, 36);
            this.buttonSearch.TabIndex = 16;
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1184, 762);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.buttonDonate);
            this.Controls.Add(this.textBoxDonorPhoneNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxDonorAddress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxDonorName);
            this.Controls.Add(this.labelDonorName);
            this.Controls.Add(this.textBoxSumToDonate);
            this.Controls.Add(this.labelSumToDonate);
            this.Controls.Add(this.labelCaseName);
            this.Controls.Add(this.textBoxCaseName);
            this.Controls.Add(this.labelDonors);
            this.Controls.Add(this.labelCases);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.dataGridViewDonors);
            this.Controls.Add(this.dataGridViewCases);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Name = "FormMain";
            this.Text = "Main";
            ((System.ComponentModel.ISupportInitialize) (this.dataGridViewCases)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridViewDonors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn CaseTotalSumDonated;
        private System.Windows.Forms.DataGridViewTextBoxColumn CaseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonorPhoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonorAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonorName;
        private System.Windows.Forms.Label labelCases;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.DataGridView dataGridViewDonors;
        private System.Windows.Forms.DataGridView dataGridViewCases;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCaseName;
        private System.Windows.Forms.Label labelDonors;
        private System.Windows.Forms.Button buttonDonate;
        private System.Windows.Forms.TextBox textBoxDonorPhoneNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxDonorAddress;
        private System.Windows.Forms.TextBox textBoxDonorName;
        private System.Windows.Forms.Label labelDonorName;
        private System.Windows.Forms.Label labelCaseName;
        private System.Windows.Forms.TextBox textBoxSumToDonate;
        private System.Windows.Forms.Label labelSumToDonate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CaseId;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonorId;
        private System.Windows.Forms.Button buttonSearch;
    }
}