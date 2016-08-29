using AppointmentSystem.Modal.Dal;
using AppointmentSystem.Modal.Pal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using AppointmentSystem.Modal.Bal;
namespace AppointmentSystem.StaffRegistration
{
    public partial class AddEditStaffRegistration : Form
    {
        static string Mode = "";
        static int ID = 0;
        public AddEditStaffRegistration()
        {
            InitializeComponent();
            Mode = "Add";
        }

        public AddEditStaffRegistration(int id)
        {
            InitializeComponent();
            Mode = "Edit";
            ID = id;
            show(id);
        }
        public AddEditStaffRegistration(int id,string view)
        {
            InitializeComponent();
            Mode = "View";
            show(id);
            groupBox1.Enabled = false;
            btnSave.Enabled = false;
            btnClear.Enabled = false;

        }
        private void show(int id)
        {
            var data = DalStaffRegister.ShowRecord(id);
            txtspecialitiyname.Text = data.SpecialityName;
            txtemail.Text = data.Email;
            txtfirstname.Text = data.FirstName;
            txtlastname.Text = data.LastName;
            txtpassword.Text = EncryptDecrypt.Decrypt(data.Password);
            txtphone.Text = data.Phone;
            txtspicialitydescription.Text = data.SpeciallityDescription;

        }

        private void AddEditRegistraion_Load(object sender, EventArgs e)
        {
            lblTitle.BackColor = Color.Transparent;
            lblTitle.ForeColor = Color.White;
            
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateSave())
                {
                    PalStaffRegistration newRegistration = new PalStaffRegistration();
                    newRegistration.SpecialityName = txtspecialitiyname.Text;
                    newRegistration.Email = txtemail.Text;
                    newRegistration.FirstName = txtfirstname.Text;
                    newRegistration.LastName = txtlastname.Text;
                    newRegistration.Password = txtpassword.Text;
                    newRegistration.Phone = txtphone.Text;
                    newRegistration.SpeciallityDescription = txtspicialitydescription.Text;

                    if (Mode == "Add")
                    {
                        var flag = DalStaffRegister.insertRegistration(newRegistration);
                        if (flag == true)
                        {
                            clear();
                        }
                    }
                    if (Mode == "Edit")
                    {
                        newRegistration.Id = ID;
                        var flag = DalStaffRegister.UpdateRegistration(newRegistration);
                        if (flag == true)
                        {
                            clear();
                            this.Close();
                        }
                    }

                }
            }
            catch { }
        }
        private bool ValidateSave()
        {
            bool flag = true;
            if (txtfirstname.Text == "" || txtfirstname.Text == string.Empty)
            {
                flag = false;
                epname.SetError(txtfirstname,"Please Enter Name");
                return flag;
            }
            if (txtpassword.Text == "" || txtpassword.Text == string.Empty)
            {
                flag = false;
                eppassword.SetError(txtpassword,"Please Enter Password");
            }
            try
            {
                
                Regex reg=new Regex(@"^[A-z0-9._%+-]+@[A-z0-9.-]+\.[A-z]{2,6}$");
                if (!reg.IsMatch(txtemail.Text))
                {
                    MessageBox.Show("Not valid email");
                    flag = false;
                    return flag;
                }
            }
            catch { }
            if (txtemail.Text == "" || txtemail.Text == string.Empty)
            {
                flag = false;
                epemail.SetError(txtemail, "Please Enter Email");
            }
            try
            {
                var data = DalUser.ViewUser().Where(o => o.Email.ToLower() == txtemail.Text.ToLower());
                if (data.Count() > 0)
                {
                    flag = false;
                    MessageBox.Show("Email Is Registered");
                }
            }
            catch { }
            
            return flag;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void clear()
        {
            epname.Clear();
            eppassword.Clear();
            epemail.Clear();
            txtspecialitiyname.Text = "";
            txtemail.Text = "";
            txtfirstname.Text = "";
            txtpassword.Text = "";
            txtphone.Text = "";
            txtspicialitydescription.Text = "";
            txtlastname.Text = "";
        }

        private void txtname_Enter(object sender, EventArgs e)
        {
            txtfirstname.BackColor = SystemColors.Info;
        }

        private void txtname_Leave(object sender, EventArgs e)
        {
            txtfirstname.BackColor = SystemColors.Window;
        }

        private void txtphone_Enter(object sender, EventArgs e)
        {
            txtphone.BackColor = SystemColors.Info;
        }

        private void txtphone_Leave(object sender, EventArgs e)
        {
            txtphone.BackColor = SystemColors.Window;
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

        private void txtlastname_Enter(object sender, EventArgs e)
        {
            txtlastname.BackColor = SystemColors.Info;
        }

        private void txtlastname_Leave(object sender, EventArgs e)
        {
            txtlastname.BackColor = SystemColors.Window;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtphone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtfirstname_TextChanged(object sender, EventArgs e)
        {
            epname.Clear();
        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {
            eppassword.Clear();
        }

        private void txtspecialitiyname_Enter(object sender, EventArgs e)
        {
            txtspecialitiyname.BackColor = SystemColors.Info;
        }

        private void txtspecialitiyname_Leave(object sender, EventArgs e)
        {
            txtspecialitiyname.BackColor = SystemColors.Window;
        }

        private void txtspicialitydescription_Enter(object sender, EventArgs e)
        {
            txtspicialitydescription.BackColor = SystemColors.Info;
        }

        private void txtspicialitydescription_Leave(object sender, EventArgs e)
        {
            txtspicialitydescription.BackColor = SystemColors.Window;
        }
    }
}
