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

namespace AppointmentSystem.ScheduleSlot
{
    public partial class AddEditScheduleSlot : Form
    {
        static string Mode = "";
        static int ID = 0;
        static DateTime oldDt = new DateTime();
        static DateTime NewDt = new DateTime();

        static string newRoom = "";
        static string oldRoom = "";
        public AddEditScheduleSlot()
        {
            InitializeComponent();
            Mode = "Add";
        }
        public AddEditScheduleSlot(int id)
        {
            InitializeComponent();
            Mode = "Edit";
            ID = id;
            show(id);
        }
        public AddEditScheduleSlot(int id,string view)
        {
            InitializeComponent();
            Mode = "View";
            ID = id;
            show(id);
            groupBox1.Enabled = false;
            btnSave.Enabled = false;
            btnClear.Enabled = false;
        }
        private void show(int id)
        {
            var data = DalScheduleSlot.ShowRecord(id);
            txtroom.Text = data.Room;
            dt.Value = data.Date;
            dateTimePicker1.Value = DateTime.Parse(data.StartTime);
            dateTimePicker2.Value = DateTime.Parse(data.EndTime);

            oldDt = data.Date;
            oldRoom = data.Room;
        }

        private void AddEditScheduleSlot_Load(object sender, EventArgs e)
        {
            lblTitle.BackColor = Color.Transparent;
            lblTitle.ForeColor = Color.White;
            if (Mode == "Add")
            {
                dateTimePicker2.Value = dateTimePicker1.Value.AddMinutes(30);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.Value = dateTimePicker1.Value.AddMinutes(30);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void clear()
        {
            txtroom.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateSave())
                {
                    PalScheduleSlot newScheduleSlot = new PalScheduleSlot();
                    newScheduleSlot.Date = dt.Value;
                    newScheduleSlot.EndTime = dateTimePicker2.Value.Hour + ":" + dateTimePicker2.Value.Minute;
                    newScheduleSlot.StartTime = dateTimePicker1.Value.Hour + ":" + dateTimePicker1.Value.Minute;
                    newScheduleSlot.Room = txtroom.Text;

                    if (Mode == "Add")
                    {
                        bool flag = DalScheduleSlot.insertScheduleSlot(newScheduleSlot);
                        if (flag == true)
                        {
                            clear();
                        }
                    }
                    else
                    {
                        newScheduleSlot.Id = ID;
                        bool flag = DalScheduleSlot.UpdateScheduleSlot(newScheduleSlot);
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
            try
            {
                bool flag = true;
                if (txtroom.Text == "")
                {
                    flag = false;
                    eproom.SetError(txtroom, "Please Enter Room");
                }
                if (Mode == "Add")
                {
                    var data = DalScheduleSlot.ViewScheduleSlot().Where(o => o.Date.ToShortDateString() == dt.Value.ToShortDateString() && o.Room == txtroom.Text);
                    if (data.Count() > 0)
                    {
                        var data1 = DalScheduleSlot.ViewScheduleSlot().Where(o => o.Date.ToShortDateString() == dt.Value.ToShortDateString() && o.Room == txtroom.Text).Single();
                        if (data1.StartTime == (dateTimePicker1.Value.Hour + ":" + dateTimePicker1.Value.Minute) && data1.EndTime == (dateTimePicker2.Value.Hour + ":" + dateTimePicker2.Value.Minute))
                        {

                            flag = false;
                            MessageBox.Show("Time already slotted");
                        }
                    }
                }
            
            //if (Mode == "Edit")
            //{
            //    NewDt = dt.Value;
            //    if (oldDt.ToShortDateString() != NewDt.ToShortDateString())
            //    {
            //        var data = DalScheduleSlot.ViewScheduleSlot().Where(o => o.Room == txtroom.Text);
            //        if(data.Count() > 0)
            //        {
            //            flag = false;
            //            MessageBox.Show("Room No Already inserted");
            //        }
            //    }
            //}

            return flag;
            }
            catch { return false; }
        }
    }
}
