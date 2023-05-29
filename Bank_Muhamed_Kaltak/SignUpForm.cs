﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business_Layer;
using Tulpep.NotificationWindow;

namespace Bank_Muhamed_Kaltak
{
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
        }


        private void buttonRegister_Click(object sender, EventArgs e)
        {
            RegistrationManager registrationManager = new RegistrationManager();



            if (registrationManager.Register(textBoxUsername.Text, textBoxPassword.Text, textBoxName.Text, textBoxLastName.Text, textBoxEmail.Text))
            {
                Popup(Color.Green,"Registered", "Successfully registered to the database!");

                this.Hide();
                LoginForm loginForm = new LoginForm();
                loginForm.ShowDialog();
                this.Close();
            }
            else
            {
                Popup(Color.Red,"Invalid Fields", "Make sure that the fields are not empty");
            }
        }

        private void Popup(Color color,string title,string body) //Möljigtvist att jag gör det till en klass och har denna metoden med, om det ska användas i andra pos
        {
            PopupNotifier popupNotifier = new PopupNotifier();

            popupNotifier.BodyColor = color;
            popupNotifier.TitleText = title;
            popupNotifier.TitleColor = Color.White;
            popupNotifier.TitleFont = new Font("Century Gothic", 15, FontStyle.Bold);

            popupNotifier.ContentText = body;
            popupNotifier.ContentColor = Color.White;
            popupNotifier.ContentFont = new Font("Century Gothic", 15);
            popupNotifier.Popup();
        }
    }
}