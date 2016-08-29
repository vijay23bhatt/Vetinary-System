using AppointmentSystem.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppointmentSystem
{
    public partial class LoginHome : Form
    {
        public LoginHome()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
          //  Login c = new Login();
          //  c.ShowDialog();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            StaffLogin c = new StaffLogin();
            c.ShowDialog();
        }

        private void LoginHome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
