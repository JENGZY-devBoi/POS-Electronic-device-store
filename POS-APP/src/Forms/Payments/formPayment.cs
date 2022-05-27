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
    public partial class formPayment : Form {
        double totalPrice;
        public formPayment() {
            InitializeComponent();
        }

        private void formPayment_Load(object sender, EventArgs e) {
            showTotalDetail();
        }

        private void showTotalDetail() {
            lblTotalAmount.Text = productData.proName.Count.ToString("#,#");

            totalPrice = 0;
            for (int i = 0; i < productData.proName.Count; i++) {
                totalPrice += productData.amount[i] * productData.proPrice[i];
            }
            productData.totalPrice = totalPrice;
            lblTotalPrice.Text = totalPrice.ToString("#,#.00");
        }
       

        private void btnBack_Click(object sender, EventArgs e) {

            var form = new formProductDetail();
            form.Show();
            this.Hide();
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e) {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnOK_Click(object sender, EventArgs e) {
            if (txtPhone.Text.Length != 10) MessageBox.Show("Please phone number 10 digits", "Error");
            else {
                fetchMemberData();
            }

            // Status member account is locked
            if (memberData.status == "L") {
                MessageBox.Show("This member account has locked!", "Error");
                memberData.clearData();
                lblName.Text = "Not member";
                txtPhone.Text = "";
            }

            // Status member account is unlocked
            if (memberData.status == "U") {
                MessageBox.Show("Access into member account success", "Notification");         
            }
        }

        private void fetchMemberData() {
            dbConfig.connection.Open();
            var adapter = new SqlDataAdapter();
            var tb = new DataTable();
            string sql = "SELECT * FROM Members";

            adapter.SelectCommand = new SqlCommand(sql, dbConfig.connection);
            adapter.Fill(tb);

            sql = $"member_id={txtPhone.Text}";
            try {
                DataRow[] dr = tb.Select(sql);
                lblName.Text = dr[0]["fname"].ToString() + " " + dr[0]["lname"].ToString();
                memberData.id_pur = dr[0]["member_id"].ToString();
                memberData.status = dr[0]["member_status"].ToString();
            } catch (Exception ex) {
                MessageBox.Show(
                    "Member account doesn't exist", "Error"
                );
            }
            dbConfig.connection.Close();
        }

        private void btnCash_Click(object sender, EventArgs e) {
            var form = new formCash();
            form.Show();
            this.Hide();
        }

        private void btnMastercard_Click(object sender, EventArgs e) {
            var form = new formDebit();
            form.Show();
            this.Hide();
        }

        private void btnTransfer_Click(object sender, EventArgs e) {
            var form = new formBankTransfer();
            form.Show();
            this.Hide();
        }
    }
}
