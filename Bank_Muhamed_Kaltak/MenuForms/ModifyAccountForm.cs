﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business_Layer;

namespace Bank_Muhamed_Kaltak.MenuForms
{
    public partial class ModifyAccountForm : Form
    {
        public UserClient userClient { get; set; }

        public bool isAdd { get; set; }
        public bool isEdit { get; set; }
        public bool isDelete { get; set; }


        public ModifyAccountForm()
        {
            InitializeComponent();
        }

        private void ModifyAccountForm_Load(object sender, EventArgs e)
        {
            if (isAdd)
            {
                labelDetail.Text = "Add a new account";
                textBoxAccount.PlaceholderText = "Enter account name";
            }
            else
            {
                labelDetail.Text = "Edit selected account";
                textBoxAccount.PlaceholderText = "Change account name";
            }
        }

        private void buttonSaveChanges_Click(object sender, EventArgs e)
        {
            if (isAdd)
            {
                userClient.AddNewAccount(textBoxAccount.Text);

                ReturnToAccountForm();
               
            }
            else
            {

                ReturnToAccountForm();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            AccountForm accountForm = new AccountForm();
            accountForm.userClient = userClient;

            FormChanger.OpenForm(accountForm);
        }

        private void ReturnToAccountForm()
        {
            AccountForm accountForm = new AccountForm();
            accountForm.userClient = userClient;

            FormChanger.OpenForm(accountForm);
        }
    }
}