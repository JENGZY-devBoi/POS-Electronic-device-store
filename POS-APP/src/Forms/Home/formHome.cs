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
    public partial class formHome : Form {
        #region Fields
        private List<string> lsProID = new List<string>();
        private List<string> lsProName = new List<string> ();
        private List<int> lsProAmount = new List<int> ();
        private List<string> lsProImageURL = new List<string>();
        private List<double> lsCostP = new List<double>();
        private List<double> lsSellP = new List<double>();
        private List<string> lsProStatus = new List<string>();
        private List<string> lsCategoryID = new List<string>();
        private List<string> lsBrandID = new List<string>();
        private List<string> lsBrandName = new List<string>();
        private List<string> lsCategoryName = new List<string>();
        private PictureBox[] arrIMG;
        private Label[] arrProName;
        private Label[] arrProBrand;
        private Label[] arrProCate;
        private Label[] arrProPrice;
        private Label[] arrProAmount;
        private int start = 0, end = 5;
        #endregion

        public formHome() {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, EventArgs e) {
            var formLogin = new formLogin();
            formLogin.Show();
            this.Hide();
        }

        private void formHome_Load(object sender, EventArgs e) {
            init();
            getEmpData();
            fetchProductData();
            fetchBrandData();
            fetchCategoryData();
            mapProductData();
        }

        private void getEmpData() {
            lblEmpID.Text = empData.emp_id;
            lblEmpName.Text = empData.emp_fname + " " + empData.emp_lname;
        }

        private void fetchProductData() {
            try {
                dbConfig.connection.Open();

                //Fields
                string sql;
                var adapter = new SqlDataAdapter();
                var productTB = new DataTable();

                sql = "SELECT * FROM Products";
                adapter.SelectCommand = new SqlCommand(sql, dbConfig.connection);
                adapter.Fill(productTB);

                try {
                    DataRow[] dr = productTB.Select();

                    foreach (var itm in dr) {
                        lsProID.Add(itm["product_id"].ToString());
                        lsProName.Add(itm["product_name"].ToString());
                        lsProAmount.Add(Convert.ToInt32(itm["amount"].ToString()));
                        lsProImageURL.Add(itm["image_url"].ToString());
                        lsCostP.Add(Convert.ToDouble(itm["cost_price"].ToString()));
                        lsSellP.Add(Convert.ToDouble(itm["selling_price"].ToString()));
                        lsProStatus.Add(itm["product_status"].ToString());
                        lsCategoryID.Add(itm["category_id"].ToString());
                        lsBrandID.Add(itm["brand_id"].ToString());
                    }

                } catch (Exception ex) {
                    MessageBox.Show(
                        ex.Message,
                        "Error"
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

        private void init() {
            // Init to arr
            arrIMG = new PictureBox[5]{
                proIMG1, proIMG2, proIMG3, proIMG4, proIMG5
            };
            arrProName = new Label[5] {
                proName1, proName2, proName3, proName4, proName5
            };
            arrProBrand = new Label[5] { 
                proBrand1, proBrand2, proBrand3, proBrand4, proBrand5
            };
            arrProAmount = new Label[5] {
                lblAmount1, lblAmount2, lblAmount3, lblAmount4, lblAmount5
            };
            arrProCate = new Label[5] {
                proCate1, proCate2, proCate3, proCate4, proCate5
            };
            arrProPrice = new Label[5] {
                proPrice1, proPrice2, proPrice3, proPrice4, proPrice5
            };
        }

        private void mapProductData() {
            for(int i = start; i < end; i++) {
                arrIMG[i].ImageLocation = lsProImageURL[i];
                arrProPrice[i].Text = lsSellP[i].ToString("#,#.00");
                arrProName[i].Text = lsProName[i];
                arrProBrand[i].Text = lsBrandName[i];
                arrProCate[i].Text = lsCategoryName[i];
            }
        }

        private void fetchBrandData() {
            try {
                dbConfig.connection.Open();

                //Fields
                string sql;
                var adapter = new SqlDataAdapter();
                var brandTB = new DataTable();

                sql = "SELECT * FROM Brands";
                adapter.SelectCommand = new SqlCommand(sql, dbConfig.connection);
                adapter.Fill(brandTB);

                foreach (var itm in lsBrandID) {
                    sql = $"brand_id='{itm}'";
                    try {
                        DataRow[] dr = brandTB.Select(sql);
                        foreach (var el in dr) lsBrandName.Add(el["brand_name"].ToString());
                    }
                    catch (Exception ex) {
                        MessageBox.Show(
                            ex.Message,
                            "Error"
                        );
                    }
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

        private void fetchCategoryData() {
            try {
                dbConfig.connection.Open();

                //Fields
                string sql;
                var adapter = new SqlDataAdapter();
                var cateTB = new DataTable();

                sql = "SELECT * FROM Categorys";
                adapter.SelectCommand = new SqlCommand(sql, dbConfig.connection);
                adapter.Fill(cateTB);

                foreach (var itm in lsCategoryID) {
                    sql = $"category_id='{itm}'";
                    try {
                        DataRow[] dr = cateTB.Select(sql);
                        foreach (var el in dr) lsCategoryName.Add(el["category_name"].ToString());
                    }
                    catch (Exception ex) {
                        MessageBox.Show(
                            ex.Message,
                            "Error"
                        );
                    }
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
