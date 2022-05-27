using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Data;
using System.Windows.Forms;

namespace POS_APP {
    public class reportExcel {
        public void Print(System.Data.DataTable data) {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel|*.xlsx" }) {

                /*  string path = @"test.pdf";*/
                if (sfd.ShowDialog() == DialogResult.OK) {
                    ExportToExcel(data, sfd.FileName);
                    System.Diagnostics.Process.Start(sfd.FileName);
                }

            }
        }

        public static void ExportToExcel(System.Data.DataTable tbl, string excelFilePath = null) {
            try {
                if (tbl == null || tbl.Columns.Count == 0)
                    throw new Exception("ExportToExcel: Null or empty input table!\n");

                // load excel, and create a new workbook
                var excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Workbooks.Add();

                // single worksheet
                Microsoft.Office.Interop.Excel._Worksheet workSheet = excelApp.ActiveSheet;

                // column headings
                for (var i = 0; i < tbl.Columns.Count; i++) {
                    workSheet.Cells[1, i + 1] = tbl.Columns[i].ColumnName;
                }

                // rows
                for (var i = 0; i < tbl.Rows.Count; i++) {
                    // to do: format datetime values before printing
                    for (var j = 0; j < tbl.Columns.Count; j++) {
                        workSheet.Cells[i + 2, j + 1] = tbl.Rows[i][j];
                    }
                }

                // check file path
                if (!string.IsNullOrEmpty(excelFilePath)) {
                    try {
                        workSheet.SaveAs(excelFilePath);
                        excelApp.Quit();

                    }
                    catch (Exception ex) {
                        throw new Exception("ExportToExcel: Excel file could not be saved! Check filepath.\n"
                                            + ex.Message);
                    }
                }
                else { // no file path is given
                    excelApp.Visible = true;
                }
            }
            catch (Exception ex) {
                throw new Exception("ExportToExcel: \n" + ex.Message);
            }
        }
    }
}