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
    public partial class formLogin : Form {
        public formLogin() {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, EventArgs e) {
            try {
                dbConfig.connection.Open();

                // Fields
                string sql;
                var adapter = new SqlDataAdapter();
                var empTB = new DataTable();

                sql = "SELECT * FROM Employees";
                adapter.SelectCommand = new SqlCommand(sql, dbConfig.connection);
                adapter.Fill(empTB);

                sql =
                    $"username='{txtUsrename.Text}' AND " +
                    $"password='{txtPassword.Text}'";

                try {
                    DataRow[] dr = empTB.Select(sql);

                    // Keep data to var
                    empData.emp_id = dr[0]["emp_id"].ToString();
                    empData.emp_fname = dr[0]["fname"].ToString();
                    empData.emp_lname = dr[0]["lname"].ToString();

                    dbConfig.connection.Close();

                    // GO TO NEW FORM
                    var formHome = new formHome();
                    formHome.Show();
                    this.Hide();
                }
                catch (Exception ex) {
                    // Login failed
                    MessageBox.Show(
                        "Login failed, please try again.",
                        "Warning"
                    );
                }

            }
            catch (Exception ex) {
                MessageBox.Show(
                    ex.Message,
                    "Error"
                );
            }
            dbConfig.connection.Close();
        }
    }
}
