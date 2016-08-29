using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JEWELLERYSTOCKMGTSYSTEM.Model.Bal
{
   public static class ExportData
    {
        public static void Export(DataGridView dgvExport,String SheetName,int[] arr)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            app.Visible = true;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            worksheet.Name = SheetName;

            int count = dgvExport.Columns.Count;
            int colum = 1;
            for (int i = 1; i < count  + 1; i++)
            {
                int pos = Array.IndexOf(arr, i);
                if (pos > -1)
                {
                   
                }
                else
                {

                    worksheet.Cells[1,colum] = dgvExport.Columns[i - 1].HeaderText;
                    colum = colum + 1;
                }
                

            }



            for (int i = 0; i < dgvExport.Rows.Count; i++)
            {
                colum = 0;
                for (int j = 0; j < count; j++)
                {
                    int pos = Array.IndexOf(arr, j+1);
                     if (pos > -1)
                     {
                        
                     }
                     else
                     {
                         if (dgvExport.Rows[i].Cells[j].Value.ToString() != null)
                         {
                             worksheet.Cells[i + 2, colum + 1] = dgvExport.Rows[i].Cells[j].Value.ToString();
                         }
                         colum = colum + 1;
                     }
                }
            }
            
        }
    }
}
