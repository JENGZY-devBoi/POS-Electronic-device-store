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

        private void putProductDB() {
            dbConfig.connection.Open();
            try {
                for (int i = 0; i < productData.proName.Count; i++) {
                    var adapter = new SqlDataAdapter();

                    string sql =
                        $"UPDATE Products " +
                        $"SET amount = '{productData.proAmount[i]}' " +
                        $"WHERE product_id = '{productData.proID[i]}'";
                    adapter.UpdateCommand = dbConfig.connection.CreateCommand();
                    adapter.UpdateCommand.CommandText = sql;
                    adapter.UpdateCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            dbConfig.connection.Close();
        }

        private void postPayment() {
            dbConfig.connection.Open();

            try {
                for (int i = 0; i < productData.proName.Count; i++) {
                    var adapter = new SqlDataAdapter();

                    string sql =
                        $"INSERT INTO Payments " +
                        $"(payment_method, payment_status) " +
                        $"VALUES" +
                        $"(" +
                        $"'Pay by cash'," +
                        $"'YES'" +
                        $")";

                    adapter.InsertCommand = dbConfig.connection.CreateCommand();
                    adapter.InsertCommand.CommandText = sql;
                    adapter.InsertCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            dbConfig.connection.Close();
        }

        private void postReq() {
            dbConfig.connection.Open();

            try {
                for (int i = 0; i < productData.proName.Count; i++) {
                    var adapter = new SqlDataAdapter();

                    string sql =
                        $"INSERT INTO RequestProduct " +
                        $"(product_id, req_amount, member_id, payment_id, req_price, req_date, req_status) " +
                        $"VALUES" +
                        $"(" +
                        $"'{"product id"}'," +
                        $"'{productData.amount[i]}'," +
                        $"'{"member id"}', '{"payment id"}'," +
                        $"'{productData.proPrice[i] * productData.amount[i]}'," +
                        $"'{"Date"}', 'YES'" +
                        $")";

                    adapter.InsertCommand = dbConfig.connection.CreateCommand();
                    adapter.InsertCommand.CommandText = sql;
                    adapter.InsertCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            dbConfig.connection.Close();
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
            } catch (Exception ex) {
                MessageBox.Show(
                    "Dosen't exist", "Error"
                );
            }
            dbConfig.connection.Close();
        }
    }
}
