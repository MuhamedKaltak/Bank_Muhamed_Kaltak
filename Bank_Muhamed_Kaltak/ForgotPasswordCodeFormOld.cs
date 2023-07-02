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

namespace Bank_Muhamed_Kaltak
{
    public partial class ForgotPasswordCodeFormOld : Form
    {

        public string userEmail { get; set; }

        public ForgotPasswordCodeFormOld()
        {
            InitializeComponent();
        }

        private void buttonCode_Click(object sender, EventArgs e)
        {
            LoginManager loginManager = new LoginManager();

            if (loginManager.CheckValidVerficationCode(userEmail, textBoxCode.Text))
            {
                ForgotPasswordRegisterFormOld forgotPasswordRegisterForm = new ForgotPasswordRegisterFormOld();
                forgotPasswordRegisterForm.userEmail = userEmail;
                forgotPasswordRegisterForm.enteredCode = textBoxCode.Text;

                FormChanger.ChangeForm(this, forgotPasswordRegisterForm);
            }
            else
            {
                UINotification.Popup(Color.Red, "ERROR", "INVALID CODE");
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            FormChanger.ChangeForm(this, new LoginForm());
        }
    }
}