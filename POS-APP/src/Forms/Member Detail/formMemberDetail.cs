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
    public partial class formMemberDetail : Form {
        public formMemberDetail() {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e) {
            memberData.clearData();

            var form = new formMemberManagement();
            form.Show();
            this.Hide();
        }

        private void formMemberDetail_Load(object sender, EventArgs e) {
            init();
            status();
        }

        private void init() {
            txtPhone.Text = memberData.id;
            txtFname.Text = memberData.fname;
            txtLname.Text = memberData.lname;
            txtAddr.Text = memberData.address;
            txtEmail.Text = memberData.email;
        }

        private void status() {
            // status
            if (memberData.status == "U") {
                btnStatus.Text = "Unlocked";
                unlockedColor();
            }
            if (memberData.status == "L") {
                btnStatus.Text = "Locked";
                lockedColor();
            }
        }

        private void unlockedColor() {
            btnStatus.BackColor = Color.FromArgb(192, 255, 192);
        }

        private void lockedColor() {
            btnStatus.BackColor = Color.FromArgb(255, 128, 128);
        }

        private void btnEdit_Click(object sender, EventArgs e) {
            if (btnEdit.Text == "Edit") {
                btnEdit.Text = "Cancel";
                enableText(true);
            } else {
                btnEdit.Text = "Edit";
                init();

                enableText(false);
            }
        }

        private void enableText(bool b) {
            txtFname.Enabled = b;
            txtLname.Enabled = b;
            txtAddr.Enabled = b;
            txtEmail.Enabled = b;
            btnSave.Visible = b;
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if (validChange() && validFill()) {
                btnEdit.Text = "Edit";
                enableText(false);

                // SQL update
                putMemberDB();
            }
        }

        private void putMemberDB() {
            dbConfig.connection.Open();

            var adapter = new SqlDataAdapter();
            string sql =
                $"UPDATE Members " +
                $"SET fname='{txtFname.Text}', lname='{txtLname.Text}'," +
                $"address='{txtAddr.Text}', email='{txtEmail.Text}' " +
                $"WHERE member_id='{txtPhone.Text}'";

            adapter.UpdateCommand = dbConfig.connection.CreateCommand();
            adapter.UpdateCommand.CommandText = sql;
            adapter.UpdateCommand.ExecuteNonQuery();

            MessageBox.Show("Save success", "Notification");
            dbConfig.connection.Close();
        }

        private bool validChange() {
            if (
                txtFname.Text == memberData.fname &&
                txtLname.Text == memberData.lname &&
                txtAddr.Text == memberData.address &&
                txtEmail.Text == memberData.email
                ) {
                MessageBox.Show("Cannot save because information not change", "Error");
                return false;
            }
            return true;
        }

        private bool validFill() {
            if (
                txtFname.Text == "" ||
                txtLname.Text == "" ||
                txtAddr.Text == "" ||
                txtEmail.Text == ""
                ) {
                MessageBox.Show("Please complete data", "Error");
                return false;
            }
            return true;
        }

        private void btnStatus_Click(object sender, EventArgs e) {
            if (btnStatus.Text == "Unlocked") {
                btnStatus.Text = "Locked";
                lockedColor();

                putStatusMem("L");
            } else {
                btnStatus.Text = "Unlocked";
                unlockedColor();

                putStatusMem("U");
            }
        }

        private void putStatusMem(string status) {
            dbConfig.connection.Open();

            var adapter = new SqlDataAdapter();
            string sql =
                $"UPDATE Members " +
                $"SET member_status='{status}' " +
                $"WHERE member_id='{txtPhone.Text}'";

            adapter.UpdateCommand = dbConfig.connection.CreateCommand();
            adapter.UpdateCommand.CommandText = sql;
            adapter.UpdateCommand.ExecuteNonQuery();

            dbConfig.connection.Close();
        }
    }
}
