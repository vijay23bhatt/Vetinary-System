using AppointmentSystem.Appointment;
using AppointmentSystem.ClientRegistration;
using AppointmentSystem.Modal.Bal;
using AppointmentSystem.Modal.Dal;
using AppointmentSystem.StaffRegistration;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var email = txtemail.Text;
                var pass = EncryptDecrypt.Encrypt(txtpassword.Text);

                bool flag = DalUser.checkLogin(email, pass);
                if (flag == true)
                {
                    var data = DalUser.ViewUser().Where(o => o.Email == txtemail.Text && o.Password == EncryptDecrypt.Encrypt(txtpassword.Text)).Single();
                    if (data.UserType == 1)
                    {
                        var clientdata = DalClientRegister.ViewRegistration().Where(o => o.Email == txtemail.Text && o.Password == EncryptDecrypt.Encrypt(txtpassword.Text)).Single();
                        this.Hide();
                        Appointment.AddEditAppointment appointment = new Appointment.AddEditAppointment(clientdata.Id);
                        appointment.ShowDialog();
                    }
                    if (data.UserType == 0)
                    {
                        this.Hide();
                        dashboard d = new dashboard();
                        d.ShowDialog();
                    }
                    if (data.UserType == 2)
                    {
                        this.Hide();
                        var staffdata = DalStaffRegister.ViewRegistration().Where(o => o.Email == txtemail.Text && o.Password == EncryptDecrypt.Encrypt(txtpassword.Text)).Single();
                        AppointmentList r1 = new AppointmentList(staffdata.Id,"Staff");
                        r1.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect Username or password");
                }
            }
            catch { }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            
            AddEditClientRegistration cr = new AddEditClientRegistration();
            cr.ShowDialog();
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
