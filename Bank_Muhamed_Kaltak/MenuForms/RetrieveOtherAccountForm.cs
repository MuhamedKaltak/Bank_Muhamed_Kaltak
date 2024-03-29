﻿using Business_Layer;
using Microsoft.IdentityModel.Tokens;
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
    public partial class RetrieveOtherAccountForm : Form
    {
        public UserClient userClient;

        public SavedOtherAccountForm savedOtherAccountForm;

        public RetrieveOtherAccountForm()
        {
            InitializeComponent();

            buttonRetrieve.Select(); //Fix för att undvika att denna popup formen väljer automatiskt en textbox. Sker pga form.ShowDialog();
        }

        private void RetrieveOtherAccountForm_Load(object sender, EventArgs e)
        {
            textBoxEmail_Click(sender, e);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            FormChanger.CloseForm(this);
        }

        private void textBoxEmail_Click(object sender, EventArgs e)
        {
            UINotification.Mark(textBoxEmail, panelEmail);
        }

        private void textBoxAccountCode_Click(object sender, EventArgs e)
        {
            UINotification.Mark(textBoxAccountCode, panelAccountCode);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            FormChanger.CloseForm(this);
        }

        private void buttonRetrieve_Click(object sender, EventArgs e)
        {
            RetrieveOtherAccount();
        }

        private bool CheckValidInputs()
        {
            if (textBoxEmail.Text.IsNullOrEmpty())
            {
                UINotification.Popup(Color.Red, "ERROR", "The email text field cannot be empty");
                return false;
            }
            else if (textBoxAccountCode.Text.IsNullOrEmpty())
            {
                UINotification.Popup(Color.Red, "ERROR", "The account code text field cannot be empty");
                return false;
            }

            return true;
        }

        private void textBoxEmail_KeyDown(object sender, KeyEventArgs e)
        {
            RetrieveOtherAccountIfEnterPressed(sender, e);
        }

        private void textBoxAccountCode_KeyDown(object sender, KeyEventArgs e)
        {
            RetrieveOtherAccountIfEnterPressed(sender, e);
        }

        private void RetrieveOtherAccountIfEnterPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RetrieveOtherAccount();
            }
        }

        private void RetrieveOtherAccount()
        {
            if (CheckValidInputs())
            {
                var otherAccount = userClient.accountManager.GetAccountByEmailAndAccountCode(textBoxEmail.Text, textBoxAccountCode.Text);

                if (otherAccount != null)
                {
                    if (userClient.accountManager.AddAccountToOtherUserAccount(otherAccount))
                    {
                        UINotification.Popup(Color.Green, "Succesfully saved account", "The account has been sucesfully retrieved and saved.");

                        savedOtherAccountForm.AddAccountsToDatagridviewFromClient();

                        FormChanger.CloseForm(this);
                    }
                    else
                    {
                        UINotification.Popup(Color.Red, "ERROR", "The account could not be saved, It's possible that the account has already been saved before.");
                    }

                }
                else
                {
                    UINotification.Popup(Color.Red, "ERROR", "The account was not found in the system, double check that you have written the correct email and account code");
                }
            }
        }


    }
}
