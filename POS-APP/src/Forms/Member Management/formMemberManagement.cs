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
    public partial class formMemberManagement : Form {
        public formMemberManagement() {
            InitializeComponent();
        }

        private void btnProPOS_Click(object sender, EventArgs e) {
            memberData.clearData();

            var form = new formHome();
            form.Show();
            this.Hide();
        }

        private void btnRegister_Click(object sender, EventArgs e) {
            var form = new formRegister();
            form.Show();
            this.Hide();
        }

        private void btnAccount_Click(object sender, EventArgs e) {
            if (validFill()) fetchMemberData();
        }

        private void fetchMemberData() {
            dbConfig.connection.Open();
            var adapter = new SqlDataAdapter();
            var tb = new DataTable();
            string sql = "SELECT * FROM Members";

            adapter.SelectCommand = new SqlCommand(sql, dbConfig.connection);
            adapter.Fill(tb);

            sql = $"member_id='{txtPhone.Text}'";

            try {
                DataRow[] dr = tb.Select(sql);

                memberData.id = dr[0]["member_id"].ToString();
                memberData.fname = dr[0]["fname"].ToString();
                memberData.lname = dr[0]["lname"].ToString();
                memberData.address = dr[0]["address"].ToString();
                memberData.status = dr[0]["member_status"].ToString();
                memberData.email = dr[0]["email"].ToString();

                MessageBox.Show("Member account correctly", "Notification");

                // GO TO MEMBER DETAIL 
                var form = new formMemberDetail();
                form.Show();
                this.Hide();
            } catch (Exception ex) {
                MessageBox.Show("Member account doesn't exist", "Error");
            }

            dbConfig.connection.Close();
        }

        private bool validFill() {
            if (txtPhone.Text == "") {
                MessageBox.Show("Please complete information", "Error");
                return false;
            }
            return true;
        }
    }
}
