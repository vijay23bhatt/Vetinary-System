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

namespace AppointmentSystem.Appointment
{
    public partial class AddEditAppointment : Form
    {
        static string Mode = "";
        static int ID = 0;
        static int clientID = 0;

        static int oldClientId = 0;
        static int newClientId = 0;
        static int oldStaffId = 0;
        static int newStaffId = 0;
        static DateTime newDt = new DateTime();
        static DateTime oldDt = new DateTime();
        public AddEditAppointment()
        {
            InitializeComponent();
        }
        public AddEditAppointment(int id)
        {
            InitializeComponent();
            Mode = "Add";
            clientID = id;
            var data = DalClientRegister.ShowRecord(id);
            label4.Text = data.FirstName;
            fillStaff();
        }

        public AddEditAppointment(int id,string View)
        {
            InitializeComponent();
            Mode = View;
            ID = id;
            
            show(id);
            if (View == "Edit")
            {
                groupBox1.Enabled = true;
                btnRegister.Enabled = true;
            }
            else
            {
                groupBox1.Enabled = false;
                btnRegister.Enabled = false;
            }
        }
        private void show(int id)
        {
            fillStaff();
            var data = DalAppointment.ShowRecord(id);
            label4.Text = DalClientRegister.ShowRecord(data.ClientId).FirstName;
            clientID = data.ClientId;
            cmbStaff.SelectedValue = data.StaffId;
            dt.Value = data.Date;
            oldDt = data.Date;
            oldStaffId = data.StaffId;
            //var str = data.TimeSlot.Split('-');
            dateTimePicker1.Value = Convert.ToDateTime(data.StartTime);
            dateTimePicker2.Value = Convert.ToDateTime(data.EndTime);
            
        }
        private void fillStaff()
        {
            try
            {
                var data = DalStaffRegister.ViewRegistration();

                cmbStaff.DataSource = data;
                cmbStaff.Refresh();
                cmbStaff.DisplayMember = "FirstName";
                cmbStaff.ValueMember = "Id";
                cmbStaff.AutoCompleteCustomSource.AddRange(data.Select(o => o.FirstName).ToArray<string>());
                cmbStaff.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbStaff.AutoCompleteSource = AutoCompleteSource.ListItems;

            }
            catch { }
        }

        private void AddEditAppointment_Load(object sender, EventArgs e)
        {
            lblTitle.BackColor = Color.Transparent;
            lblTitle.ForeColor = Color.White;
            if (Mode == "Add")
            {
                dateTimePicker2.Value = dateTimePicker1.Value.AddMinutes(30);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateSave())
                {
                    PalAppointment newAppointment = new PalAppointment();
                    newAppointment.ClientId = clientID;
                    newAppointment.Date = dt.Value;
                    newAppointment.StaffId = int.Parse(cmbStaff.SelectedValue.ToString());
                   // newAppointment.TimeSlot = (dateTimePicker1.Value.Hour+":"+dateTimePicker1.Value.Minute) + "-" + dateTimePicker2.Value.Hour+":"+dateTimePicker2.Value.Minute;
                    newAppointment.StartTime = dateTimePicker1.Value.Hour + ":" + dateTimePicker1.Value.Minute;
                    newAppointment.EndTime = dateTimePicker2.Value.Hour + ":" + dateTimePicker2.Value.Minute;
                    if (Mode == "Add")
                    {
                        bool flag = DalAppointment.insertAppointment(newAppointment);
                        if (flag == true)
                        {
                            MessageBox.Show("Insert Successfully");
                        }
                    }
                    else
                    {
                        newAppointment.Id = ID;
                        bool flag = DalAppointment.UpdateAppointment(newAppointment);
                        if (flag == true)
                        {
                            MessageBox.Show("Update Successfully");
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
            if (Mode == "Add")
            {
                var data = DalAppointment.ViewAppointment().Where(o => o.ClientId == clientID && o.StaffId == int.Parse(cmbStaff.SelectedValue.ToString()) && o.Date.ToShortDateString() == dt.Value.ToShortDateString());
                if (data.Count() > 0)
                {

                    var getData = DalAppointment.ViewAppointment().Where(o => o.ClientId == clientID && o.StaffId == int.Parse(cmbStaff.SelectedValue.ToString()) && o.Date.ToShortDateString() == dt.Value.ToShortDateString()).Single();
                    if (getData.StartTime == (dateTimePicker1.Value.Hour + ":" + dateTimePicker1.Value.Minute) && getData.EndTime == (dateTimePicker2.Value.Hour + ":" + dateTimePicker2.Value.Minute))
                    {
                        flag = false;
                        MessageBox.Show("You already take appointment.");
                    }
                }
            }
            
            if (Mode == "Edit")
            {
                newDt = dt.Value;
                newStaffId = int.Parse(cmbStaff.SelectedValue.ToString());
                if (oldDt.ToShortDateString() != newDt.ToShortDateString() || oldStaffId != newStaffId)
                {
                    var data = DalAppointment.ViewAppointment().Where(o => o.ClientId == clientID && o.StaffId == int.Parse(cmbStaff.SelectedValue.ToString()) && o.Date.ToShortDateString() == dt.Value.ToShortDateString());
                    if (data.Count() > 0)
                    {
                        var getData = DalAppointment.ViewAppointment().Where(o => o.ClientId == clientID && o.StaffId == int.Parse(cmbStaff.SelectedValue.ToString()) && o.Date.ToShortDateString() == dt.Value.ToShortDateString()).Single();

                        if (getData.StartTime == (dateTimePicker1.Value.Hour + ":" + dateTimePicker1.Value.Minute) && getData.EndTime == (dateTimePicker2.Value.Hour + ":" + dateTimePicker2.Value.Minute))
                        {
                            flag = false;
                            MessageBox.Show("You already take appointment.");
                        }
                    }
                }
            }
            return flag;
        }

        private void AddEditAppointment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.Value = dateTimePicker1.Value.AddMinutes(30);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
