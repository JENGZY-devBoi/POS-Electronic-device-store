using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace POS_APP {
    public partial class formReport : Form {
        private BindingSource bindingreportNetSale = new BindingSource();
        private BindingSource bindingreportNetProfit = new BindingSource();
        private string reportType = "Day";

        public formReport() {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, EventArgs e) {
            var form = new formLogin();
            form.Show();
            this.Hide();
        }

        private void formReport_Load(object sender, EventArgs e) {
            init();
        }

        private void init() {
            dtPick.Format = DateTimePickerFormat.Custom;
            dtPick.CustomFormat = "MM / dd / yyyy";

            comboReportDur.SelectedIndex = 0;
            comboReportType.SelectedIndex = 0;

            fetchNetSaleData();
        }

        private void comboReport_SelectedIndexChanged(object sender, EventArgs e) {
            string report = comboReportDur.SelectedItem.ToString();

            if (report == "Daily") {
                dtPick.CustomFormat = "MM / dd / yyyy";
                lbldate.Text = "Month/Day/Year";
                reportType = "Day";
            } else if (report == "Weekly") {
                dtPick.CustomFormat = "MM / dd / yyyy";
                lbldate.Text = "Month/Day/Year";
                reportType = "Week";
            }
            else if (report == "Monthly") {
                dtPick.CustomFormat = "MM / yyyy";
                lbldate.Text = "Month/Year";
                reportType = "Month";
            }
            else if (report == "Yearly") {
                dtPick.CustomFormat = "yyyy";
                lbldate.Text = "Year";
                reportType = "Year";
            }
            else {
                //
            }
        }

        private string whereClauseSQL() {
            Console.WriteLine(dtPick.Value.ToString().Split()[0].Split('/')[2]);
            string sql = "WHERE ";
            string r = "";
            if (comboReportType.SelectedItem.ToString() == "Net Profit") {
                r = "r.";
            }

            if (reportType == "Day") {
                sql += $"{r}req_date='{dtPick.Value.ToString().Split()[0]}'";
            }
            else if (reportType == "Week") {
                sql += 
                    $"{r}req_date BETWEEN '{dtPick.Value.ToString().Split()[0]}' " +
                    $"AND DATEADD(DAY, 6,'{dtPick.Value.ToString().Split()[0]}')";
            }
            else if (reportType == "Month") {
                sql +=
                    $"MONTH({r}req_date)='{dtPick.Value.ToString().Split('/')[0]}' " +
                    $"AND YEAR({r}req_date)='{dtPick.Value.ToString().Split()[0].Split('/')[2]}'"; 
            }
            else if (reportType == "Year") {
                sql +=
                    $"YEAR({r}req_date)='{dtPick.Value.ToString().Split()[0].Split('/')[2]}'";
            }
            else {
                sql = "";
            }
            return sql;
        }

        private void fetchNetSaleData() {

            string conditon = whereClauseSQL();

            dbConfig.connection.Open();
            var adapter = new SqlDataAdapter();
            var tb = new DataTable();

            string sql =
                "Select req_id," +
                "product_id," +
                "req_amount AS \"amount\"," +
                "req_price AS \"total price\"," +
                "req_date AS \"date\" " +
                "From RequestProduct " +
                $"{conditon}";

            try {
                adapter.SelectCommand = new SqlCommand(sql, dbConfig.connection);
                adapter.Fill(tb);

                bindingreportNetSale.DataSource = tb;
                dataGridReport.DataSource = bindingreportNetSale;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }


            dbConfig.connection.Close();
        }

        private void fetchNetProfitData() {
            string conditon = whereClauseSQL();

            dbConfig.connection.Open();
            var adapter = new SqlDataAdapter();
            var tb = new DataTable();

            string sql =
                "Select r.req_id," +
                "r.product_id," +
                "r.req_amount AS \"amount\"," +
                "r.req_price AS \"total price\"," +
                "r.req_date AS \"date\"," +
                "((p.selling_price - p.cost_price) * r.req_amount) AS \"net profit\" " +
                "From RequestProduct r " +
                "INNER JOIN Products p " +
                "ON p.product_id = r.product_id " +
                $"{conditon}";

            try {
                adapter.SelectCommand = new SqlCommand(sql, dbConfig.connection);
                adapter.Fill(tb);

                bindingreportNetProfit.DataSource = tb;
                dataGridReport.DataSource = bindingreportNetProfit;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }


            dbConfig.connection.Close();
        }

        private void btnGenReport_Click(object sender, EventArgs e) {
            string report = comboReportType.SelectedItem.ToString();
            if (report == "Net Sale") fetchNetSaleData();
            else fetchNetProfitData();
        }

        private void btnExport_Click(object sender, EventArgs e) {
            excelExport();
        }

        private void excelExport() {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "Inventory_Adjustment_Export.xls";
            if (sfd.ShowDialog() == DialogResult.OK) {
                // Copy DataGridView results to clipboard
                copyAlltoClipboard();

                object misValue = System.Reflection.Missing.Value;
                Excel.Application xlexcel = new Excel.Application();

                xlexcel.DisplayAlerts = false; // Without this you will get two confirm overwrite prompts
                Excel.Workbook xlWorkBook = xlexcel.Workbooks.Add(misValue);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                // Format column D as text before pasting results, this was required for my data
                Excel.Range rng = xlWorkSheet.get_Range("D:D").Cells;
                rng.NumberFormat = "@";

                // Paste clipboard results to worksheet range
                Excel.Range CR = (Excel.Range)xlWorkSheet.Cells[1, 1];
                CR.Select();
                xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

                // For some reason column A is always blank in the worksheet. ¯\_(ツ)_/¯
                // Delete blank column A and select cell A1
                Excel.Range delRng = xlWorkSheet.get_Range("A:A").Cells;
                delRng.Delete(Type.Missing);
                xlWorkSheet.get_Range("A1").Select();

                // Save the excel file under the captured location from the SaveFileDialog
                xlWorkBook.SaveAs(sfd.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlexcel.DisplayAlerts = true;
                xlWorkBook.Close(true, misValue, misValue);
                xlexcel.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlexcel);

                // Clear Clipboard and DataGridView selection
                Clipboard.Clear();
                dataGridReport.ClearSelection();

                // Open the newly saved excel file
                if (File.Exists(sfd.FileName))
                    System.Diagnostics.Process.Start(sfd.FileName);
            }
        }

        private void copyAlltoClipboard() {
            dataGridReport.SelectAll();
            DataObject dataObj = dataGridReport.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void releaseObject(object obj) {
            try {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex) {
                obj = null;
                MessageBox.Show("Exception Occurred while releasing object " + ex.ToString());
            }
            finally {
                GC.Collect();
            }
        }
    }
}
