﻿using System;
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
    public partial class ForgotPasswordEmailForm : Form
    {
        public ForgotPasswordEmailForm()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            FormChanger.ChangeForm(this, new LoginForm());
        }
    }
}
