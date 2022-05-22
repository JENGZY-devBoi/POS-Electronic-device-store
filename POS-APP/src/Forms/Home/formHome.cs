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
        private Panel[] panelList;
        private PictureBox[] arrIMG;
        private Label[] arrProName;
        private Label[] arrProBrand;
        private Label[] arrProCate;
        private Label[] arrProPrice;
        private Label[] arrProAmount;
        private int start = 0, end = 5, st = 0;
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
            panelList = new Panel[5] {
                panelList1, panelList2, panelList3, panelList4, panelList5
            };
        }

        private void mapProductData() {
            st = start;
            if (st < lsProImageURL.Count) { 
                for(int i = 0; i < 5; i++) {
                    // Clear
                    panelList[i].Visible = false;
                    if (st < lsProImageURL.Count) {
                        panelList[i].Visible = true;
                        arrIMG[i].ImageLocation = lsProImageURL[st];
                        arrProPrice[i].Text = lsSellP[st].ToString("#,#.00");
                        arrProName[i].Text = lsProName[st];
                        arrProBrand[i].Text = lsBrandName[st];
                        arrProCate[i].Text = lsCategoryName[st];
                    }
                    st++;
                }
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

        private void proDel1_Click(object sender, EventArgs e) {
            int idx = convertIndex(proDel1);

        }

        private void proDel2_Click(object sender, EventArgs e) {
            
        }

        private void proDel3_Click(object sender, EventArgs e) {

        }

        private void proDel4_Click(object sender, EventArgs e) {

        }

        private void proDel5_Click(object sender, EventArgs e) {

        }

        private void delClicked(Label lbl) {
            
        }

        private int convertIndex(Label lbl) {
            int idx = Convert.ToInt32(lbl.Tag.ToString());
            return idx;
        }

        private void btnBack_Click(object sender, EventArgs e) {
            if (start != 0) {
                lblPage.Text = (Convert.ToInt32(lblPage.Text) - 1) + "";
                start -= 5;
                end -= 5;
                mapProductData();
            }
        }

        private void btnNext_Click(object sender, EventArgs e) {
            if (end <= lsProImageURL.Count) {
                lblPage.Text = (Convert.ToInt32(lblPage.Text) + 1) + "";
                start += 5;
                end += 5;
                mapProductData();
            }
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
