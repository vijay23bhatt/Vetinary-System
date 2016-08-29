using AppointmentSystem.Modal.Bal;
using AppointmentSystem.Modal.Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppointmentSystem.Login
{
    public partial class StaffLogin : Form
    {
        public StaffLogin()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var email = txtemail.Text;
                var pass = EncryptDecrypt.Encrypt(txtpassword.Text);

                bool flag = DalStaffRegister.checkLogin(email, pass);
                if (flag == true)
                {
                    dashboard d = new dashboard("Staff");
                    d.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Incorrect Username or password");
                }
            }
            catch { }
        }

        private void txtemail_Enter(object sender, EventArgs e)
        {
            txtemail.BackColor = SystemColors.Info;
        }

        private void txtemail_Leave(object sender, EventArgs e)
        {
            txtemail.BackColor = SystemColors.Window;
        }

        private void txtpassword_Enter(object sender, EventArgs e)
        {
            txtpassword.BackColor = SystemColors.Info;

        }

        private void txtpassword_Leave(object sender, EventArgs e)
        {
            txtpassword.BackColor = SystemColors.Window;
        }
    }
}
