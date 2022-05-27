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
    public partial class formRegister : Form {
        public formRegister() {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e) {
            var form = new formMemberManagement();
            form.Show();
            this.Hide();
        }

        private void btnSubmit_Click(object sender, EventArgs e) {
            if (validFill()) {
                postMemberDB();

                MessageBox.Show("Register success", "Notification");

                var form = new formMemberManagement();
                form.Show();
                this.Hide();
            }
        }

        private void postMemberDB() {
            dbConfig.connection.Open();

            var adapter = new SqlDataAdapter();
            string sql = 
                "INSERT INTO Members " +
                $"VALUES(" +
                $"'{txtPhone.Text}'," +
                $"'{txtFname.Text}'," +
                $"'{txtLname.Text}'," +
                $"'{txtAddr.Text}'," +
                $"'U'," +
                $"'{txtEmail.Text}')";

            adapter.InsertCommand = dbConfig.connection.CreateCommand();
            adapter.InsertCommand.CommandText = sql;
            adapter.InsertCommand.ExecuteNonQuery();

            dbConfig.connection.Close();
        }

        private bool validFill() {
            if (txtPhone.Text == "" ||
                txtFname.Text == "" ||
                txtLname.Text == "" ||
                txtAddr.Text == "" ||
                txtEmail.Text == "") {
                MessageBox.Show("Please complete information", "Notification");
                return false;
            }
            return true;
        }
    }
}
