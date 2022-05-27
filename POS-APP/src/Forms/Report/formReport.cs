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

namespace POS_APP {
    public partial class formReport : Form {
        private BindingSource bindingreportNetSale = new BindingSource();
        private BindingSource bindingreportNetProfit = new BindingSource();

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
        }

        private void comboReport_SelectedIndexChanged(object sender, EventArgs e) {
            string report = comboReport.SelectedItem.ToString();
        }

        private void btnNetSale_Click(object sender, EventArgs e) {
            fetchNetSaleData();
        }

        private void btnNetProfit_Click(object sender, EventArgs e) {
            fetchNetProfitData();
        }

        private void fetchNetSaleData() {

            string conditon;

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
                $"{""}";

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
            string conditon;

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
                $"{""}";

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
    }
}
