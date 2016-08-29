using AppointmentSystem.Appointment;
using AppointmentSystem.ClientRegistration;
using AppointmentSystem.Modal.Bal;
using AppointmentSystem.ScheduleSlot;
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

namespace AppointmentSystem
{
    public partial class dashboard : Form
    {
        private int childFormNumber = 0;
        private static string User = "";
        public dashboard()
        {
            InitializeComponent();
        }
        public dashboard(string _user)
        {
            InitializeComponent();
            User = _user;
            if (User == "Staff")
            {
                Program.UserType = 1;
            }
            if (User == "Client")
            {
                Program.UserType = 0;
            }
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void addCleintRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  if (Permission.AddEditClientRegister(Program.UserType))
           // {
                AddEditClientRegistration cr = new AddEditClientRegistration();
                cr.ShowDialog();
            //}
            //else
            //{
            //    MessageBox.Show("You Don't have permission to access this.");
            //}
        }

        private void addStaffRegistraionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (Permission.AddEditStaffRegister(Program.UserType))
            //{
                AddEditStaffRegistration cr = new AddEditStaffRegistration();
                cr.ShowDialog();
            //}
            //else
            //{
            //    MessageBox.Show("You Don't have permission to access this.");
            //}
        }

        private void clientRegistrationListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Client Registration List")
                {
                    f.Focus();
                    isopen = false;
                    break;
                }
            }
            if (isopen == false)
            {
                ClientRegistrationList c1 = new ClientRegistrationList();
                c1.WindowState = FormWindowState.Maximized;
                c1.Text = "Client Registration List";
                c1.MdiParent = this;
                c1.Show();
            }
        }

        private void staffRegistrationListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Staff Registration List")
                {
                    f.Focus();
                    isopen = false;
                    break;
                }
            }
            if (isopen == false)
            {
                StaffRegistrationList c1 = new StaffRegistrationList();
                c1.WindowState = FormWindowState.Maximized;
                c1.Text = "Staff Registration List";
                c1.MdiParent = this;
                c1.Show();
            }
        }

        private void appointmentListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Appointment List")
                {
                    f.Focus();
                    isopen = false;
                    break;
                }
            }
            if (isopen == false)
            {
                AppointmentList c1 = new AppointmentList();
                c1.WindowState = FormWindowState.Maximized;
                c1.Text = "Appointment List";
                c1.MdiParent = this;
                c1.Show();
            }
        }

        private void scheduleSlotListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Schedule List")
                {
                    f.Focus();
                    isopen = false;
                    break;
                }
            }
            if (isopen == false)
            {
                ScheduleSlotList c1 = new ScheduleSlotList();
                c1.WindowState = FormWindowState.Maximized;
                c1.Text = "Schedule List";
                c1.MdiParent = this;
                c1.Show();
            }
        }

        private void addClientRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditClientRegistration cr = new AddEditClientRegistration();
            cr.ShowDialog();
        }

        private void clientRegistrationListToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Client Registration List")
                {
                    f.Focus();
                    isopen = false;
                    break;
                }
            }
            if (isopen == false)
            {
                ClientRegistrationList c1 = new ClientRegistrationList();
                c1.WindowState = FormWindowState.Maximized;
                c1.Text = "Client Registration List";
                c1.MdiParent = this;
                c1.Show();
            }
        }

        private void addStaffRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditStaffRegistration cr = new AddEditStaffRegistration();
            cr.ShowDialog();
        }

        private void staffRegistrationListToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Staff Registration List")
                {
                    f.Focus();
                    isopen = false;
                    break;
                }
            }
            if (isopen == false)
            {
                StaffRegistrationList c1 = new StaffRegistrationList();
                c1.WindowState = FormWindowState.Maximized;
                c1.Text = "Staff Registration List";
                c1.MdiParent = this;
                c1.Show();
            }
        }

        private void appointmentListToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Appointment List")
                {
                    f.Focus();
                    isopen = false;
                    break;
                }
            }
            if (isopen == false)
            {
                AppointmentList c1 = new AppointmentList();
                c1.WindowState = FormWindowState.Maximized;
                c1.Text = "Appointment List";
                c1.MdiParent = this;
                c1.Show();
            }
        }

        private void scheduleSlotListToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool isopen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Schedule List")
                {
                    f.Focus();
                    isopen = false;
                    break;
                }
            }
            if (isopen == false)
            {
                ScheduleSlotList c1 = new ScheduleSlotList();
                c1.WindowState = FormWindowState.Maximized;
                c1.Text = "Schedule List";
                c1.MdiParent = this;
                c1.Show();
            }
        }

        private void addScheduleSlotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditScheduleSlot cr = new AddEditScheduleSlot();
            cr.ShowDialog();
        }

        private void dashboard_Load(object sender, EventArgs e)
        {

        }

        private void dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are You Sure Want To Exit?", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Environment.Exit(0);
            }
            catch
            {
                Application.Exit();
            }
        } 
    }
}
