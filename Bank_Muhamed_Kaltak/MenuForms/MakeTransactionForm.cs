﻿using Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_Muhamed_Kaltak.MenuForms
{
    public partial class MakeTransactionForm : Form
    {
        public UserClient userClient;


        public MakeTransactionForm()
        {
            InitializeComponent();
        }

        private void panelSelectFromAccount_Click(object sender, EventArgs e)
        {
            AccountForm accountForm = SendDataToAccountForm();

            accountForm.isTransactionAccountFrom = true;

            FormChanger.OpenForm(accountForm);
        }

        private void panelSelectToAccount_Click(object sender, EventArgs e)
        {
            AccountForm accountForm = SendDataToAccountForm();

            accountForm.isTransactionAccountTo = true;

            FormChanger.OpenForm(accountForm);
        }

        private void MakeTransactionForm_Load(object sender, EventArgs e)
        {
            RetrieveAccountDetails();
        }

        private AccountForm SendDataToAccountForm()
        {
            AccountForm accountForm = new AccountForm();

            accountForm.userClient = userClient;
            accountForm.isTransactionAccountSelection = true;

            return accountForm;
        }

        private void RetrieveAccountDetails()
        {
            if (userClient.transactionManager.senderAccount != null)
            {
                labelAccountFromName.Text = userClient.transactionManager.senderAccount.AccountName;
                labelAccountFromCode.Text = userClient.transactionManager.senderAccount.AccountCode;
                labelAccountFromMoney.Text = userClient.transactionManager.senderAccount.Money.ToString();
            }

            if (userClient.transactionManager.receiverAccount != null)
            {
                labelAccountToName.Text = userClient.transactionManager.receiverAccount.AccountName;
                labelAccountToCode.Text = userClient.transactionManager.receiverAccount.AccountCode;
                labelAccountToMoney.Text = userClient.transactionManager.receiverAccount.Money.ToString();
            }
        }

    }
}
