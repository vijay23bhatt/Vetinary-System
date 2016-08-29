using AppointmentSystem.Modal.Dal;
using JEWELLERYSTOCKMGTSYSTEM.Model.Bal;
using System;
using System.Collections;
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
    public partial class ScheduleSlotList : Form
    {
        StringFormat strFormat; //Used to format the grid rows.
        ArrayList arrColumnLefts = new ArrayList();//Used to save left coordinates of columns
        ArrayList arrColumnWidths = new ArrayList();//Used to save column widths
        int iCellHeight = 0; //Used to get/set the datagridview cell height
        int iTotalWidth = 0; //
        int iRow = 0;//Used as counter
        bool bFirstPage = false; //Used to check whether we are printing first page
        bool bNewPage = false;// Used to check whether we are printing a new page
        int iHeaderHeight = 0; //Used for the header height
        public ScheduleSlotList()
        {
            InitializeComponent();
        }
        private void fillDGV()
        {
            try
            {
                var data = DalScheduleSlot.ViewScheduleSlot();
                if (data.Count() > 0)
                {
                    dgvList.DataSource = data;
                    dgvList.Refresh();
                    dgvList.Columns["Id"].Visible = false;
                    btnEdit.Enabled = true;
                    btnSearch.Enabled = true;
                    btnView.Enabled = true;
                    btnDelete.Enabled = true;
                    btnPrint.Enabled = true;
                    btnSearch.Enabled = true;
                    btnExport.Enabled = true;
                }
                else
                {
                    dgvList.DataSource = null;
                    dgvList.Refresh();
                    btnEdit.Enabled = false;
                    btnSearch.Enabled = false;
                    btnView.Enabled = false;
                    btnDelete.Enabled = false;
                    btnPrint.Enabled = false;
                    btnSearch.Enabled = false;
                    btnExport.Enabled = false;
                }
            }

            catch { }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddEditScheduleSlot frmPAE = new AddEditScheduleSlot();
            frmPAE.Text = "Schedule Slot Add";
            frmPAE.StartPosition = FormStartPosition.CenterParent;
            frmPAE.ShowDialog();
            fillDGV();
        }

        private void ScheduleSlotList_Load(object sender, EventArgs e)
        {
            lblTitle.BackColor = Color.Transparent;
            lblTitle.ForeColor = Color.White;
            fillDGV();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvList.SelectedRows.Count > 0)
                {
                    int id = int.Parse(dgvList.Rows[dgvList.CurrentRow.Index].Cells["Id"].Value.ToString());
                    AddEditScheduleSlot f = new AddEditScheduleSlot(id, "View");
                    f.ShowDialog();
                    fillDGV();
                }
            }
            catch { }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvList.SelectedRows.Count > 0)
                {
                    int id = int.Parse(dgvList.Rows[dgvList.CurrentRow.Index].Cells["Id"].Value.ToString());
                    AddEditScheduleSlot f = new AddEditScheduleSlot(id);
                    f.ShowDialog();
                    fillDGV();
                }
            }
            catch { }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvList.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("Are you sure want to delete ?", "Confirm delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        int id = int.Parse(dgvList.Rows[dgvList.CurrentRow.Index].Cells["Id"].Value.ToString());
                        DalScheduleSlot.DeleteScheduleSlot(id);
                        fillDGV();
                    }
                }
            }
            catch { }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> lst = new List<int>();
                lst.Add(2);

                ExportData.Export(dgvList, "Schedule List", lst.ToArray<int>());
            }
            catch (Exception ex)
            {
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            fillDGV();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search(txtSearch.Text);
        }

        private void Search(string text)
        {
            var data = DalScheduleSlot.SearchScheduleSlot(text);
            dgvList.DataSource = data;
            dgvList.Refresh();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = pdschedule;
            printDialog.UseEXDialog = true;
            //Get the document
            if (DialogResult.OK == printDialog.ShowDialog())
            {
                pdschedule.DocumentName = "Schedule List";
                pdschedule.Print();
            }
            this.Cursor = Cursors.Default;
        }

        private void pdschedule_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Near;
                strFormat.LineAlignment = StringAlignment.Center;
                strFormat.Trimming = StringTrimming.EllipsisCharacter;

                arrColumnLefts.Clear();
                arrColumnWidths.Clear();
                iCellHeight = 0;
                iRow = 0;
                bFirstPage = true;
                bNewPage = true;

                // Calculating Total Widths
                iTotalWidth = 0;
                foreach (DataGridViewColumn dgvGridCol in dgvList.Columns)
                {
                    iTotalWidth += dgvGridCol.Width;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }

        private void pdschedule_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                //Set the left margin
                int iLeftMargin = e.MarginBounds.Left;
                //Set the top margin
                int iTopMargin = e.MarginBounds.Top;
                //Whether more pages have to print or not
                bool bMorePagesToPrint = false;
                int iTmpWidth = 0;

                //For the first page to print set the cell width and header height
                if (bFirstPage)
                {
                    foreach (DataGridViewColumn GridCol in dgvList.Columns)
                    {
                        iTmpWidth = (int)(Math.Floor((double)((double)GridCol.Width /
                                       (double)iTotalWidth * (double)iTotalWidth *
                                       ((double)e.MarginBounds.Width / (double)iTotalWidth))));

                        iHeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText,
                                    GridCol.InheritedStyle.Font, iTmpWidth).Height) + 11;

                        // Save width and height of headres
                        arrColumnLefts.Add(iLeftMargin);
                        arrColumnWidths.Add(iTmpWidth);
                        iLeftMargin += iTmpWidth;
                    }
                }
                //Loop till all the grid rows not get printed
                while (iRow <= dgvList.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = dgvList.Rows[iRow];
                    //Set the cell height
                    iCellHeight = GridRow.Height + 5;
                    int iCount = 0;
                    //Check whether the current page settings allo more rows to print
                    if (iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                    {
                        bNewPage = true;
                        bFirstPage = false;
                        bMorePagesToPrint = true;
                        break;
                    }
                    else
                    {
                        if (bNewPage)
                        {
                            //Draw Header
                            e.Graphics.DrawString("Schedule List", new Font(dgvList.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top -
                                    e.Graphics.MeasureString("Schedule List", new Font(dgvList.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            String strDate = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
                            //Draw Date
                            e.Graphics.DrawString(strDate, new Font(dgvList.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width -
                                    e.Graphics.MeasureString(strDate, new Font(dgvList.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Width), e.MarginBounds.Top -
                                    e.Graphics.MeasureString("Schedule List", new Font(new Font(dgvList.Font,
                                    FontStyle.Bold), FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            //Draw Columns                 
                            iTopMargin = e.MarginBounds.Top;
                            foreach (DataGridViewColumn GridCol in dgvList.Columns)
                            {
                                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawRectangle(Pens.Black,
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawString(GridCol.HeaderText, GridCol.InheritedStyle.Font,
                                    new SolidBrush(GridCol.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight), strFormat);
                                iCount++;
                            }
                            bNewPage = false;
                            iTopMargin += iHeaderHeight;
                        }
                        iCount = 0;
                        //Draw Columns Contents                
                        foreach (DataGridViewCell Cel in GridRow.Cells)
                        {
                            if (Cel.Value != null)
                            {
                                e.Graphics.DrawString(Cel.Value.ToString(), Cel.InheritedStyle.Font,
                                            new SolidBrush(Cel.InheritedStyle.ForeColor),
                                            new RectangleF((int)arrColumnLefts[iCount], (float)iTopMargin,
                                            (int)arrColumnWidths[iCount], (float)iCellHeight), strFormat);
                            }
                            //Drawing Cells Borders 
                            e.Graphics.DrawRectangle(Pens.Black, new Rectangle((int)arrColumnLefts[iCount],
                                    iTopMargin, (int)arrColumnWidths[iCount], iCellHeight));

                            iCount++;
                        }
                    }
                    iRow++;
                    iTopMargin += iCellHeight;
                }

                //If more lines exist, print another page.
                if (bMorePagesToPrint)
                    e.HasMorePages = true;
                else
                    e.HasMorePages = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }

        private void dgvList_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            e.Value = e.RowIndex + 1;
        }

        private void ScheduleSlotList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnClose.PerformClick();
            }
            if (e.KeyCode == Keys.Insert)
            {
                btnAdd.PerformClick();
            }
            if (e.KeyCode == Keys.Delete)
            {
                btnDelete.PerformClick();
            }
            if (e.KeyCode == Keys.F5)
            {
                btnRefresh.PerformClick();
            }
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit.PerformClick();
        }
    }
}
