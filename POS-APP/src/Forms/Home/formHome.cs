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
        private int[] arrAmount;
        private int start = 0, end = 5, st = 0, amount_start = 0, amount_end = 5;
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
            getEmpData();
            fetchProductData();
            init();
            fetchBrandData();
            fetchCategoryData();
            mapProductData();
            lblProduct.Text = "Product( " + lsProID.Count + " )";
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

                    arrAmount = new int[lsProID.Count];

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

            if (productData.proName != null) {
                int i = 0;
                foreach (var itm in productData.amountBack) {
                    arrAmount[i] = itm;
                    i++;
                }
            }
        }

        private void mapProductData() {
            st = start;
            int num = 5;
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
                        num--;
                    }
                    st++;
                }

                int j = 0;
                for (int i = amount_start; i < amount_end - num; i++) {
                    arrProAmount[j].Text = arrAmount[i].ToString();
                    j++;
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
            delLbl(proDel1);
        }

        private void proDel2_Click(object sender, EventArgs e) {
            delLbl(proDel2);
        }

        private void proDel3_Click(object sender, EventArgs e) {
            delLbl(proDel3);
        }

        private void proDel4_Click(object sender, EventArgs e) {
            delLbl(proDel4);
        }

        private void proDel5_Click(object sender, EventArgs e) {
            delLbl(proDel5);
        }

        private void delAmount(int idx) {
            if (Convert.ToInt32(arrProAmount[idx].Text) > 0) {
                int i = amount_start + idx;
                arrProAmount[idx].Text = (Convert.ToInt32(arrProAmount[idx].Text) - 1) + "";
                arrAmount[i] = (Convert.ToInt32(arrProAmount[idx].Text));
            }
        }

        private void addAmount(int idx) {
            if (Convert.ToInt32(arrProAmount[idx].Text) < lsProAmount[idx]) {
                int i = amount_start + idx;
                arrProAmount[idx].Text = (Convert.ToInt32(arrProAmount[idx].Text) + 1) + "";
                arrAmount[i] = (Convert.ToInt32(arrProAmount[idx].Text));
            }
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
                amount_start -= 5;
                amount_end -= 5;
                mapProductData();
            }
        }

        private void delLbl(Label lbl) {
            int idx = convertIndex(lbl);
            delAmount(idx);
        }

        private void addLbl(Label lbl) {
            int idx = convertIndex(lbl);
            addAmount(idx);
        }

        private void proAdd1_Click(object sender, EventArgs e) {
            addLbl(proAdd1);
        }

        private void proAdd2_Click(object sender, EventArgs e) {
            addLbl(proAdd2);
        }

        private void proAdd3_Click(object sender, EventArgs e) {
            addLbl(proAdd3);
        }


        private void proAdd4_Click(object sender, EventArgs e) {
            addLbl(proAdd4);
        }


        private void proAdd5_Click(object sender, EventArgs e) {
            addLbl(proAdd5);
        }


        private void btnNext_Click(object sender, EventArgs e) {
            if (end <= lsProImageURL.Count) {
                lblPage.Text = (Convert.ToInt32(lblPage.Text) + 1) + "";
                start += 5;
                end += 5;
                amount_start += 5;
                amount_end += 5;
                mapProductData();
            }
        }

        private void btnMemManage_Click(object sender, EventArgs e) {
            var form = new formMemberManagement();
            form.Show();
            this.Hide();
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

        private void btnSelectAll_Click(object sender, EventArgs e) {
            for (int i = 0; i < arrAmount.Length; i++) {
                if (arrAmount[i] == 0) arrAmount[i] = 1;
            }
            mapProductData();
        }
        private void btnClear_Click(object sender, EventArgs e) {
            for (int i = 0; i < arrAmount.Length; i++) {
                if (arrAmount[i] != 0) arrAmount[i] = 0;
            }
            mapProductData();
        }
        private void btnConfirm_Click(object sender, EventArgs e) {
            productData.clearData();

            int i = 0;
            bool unselected = true;
            foreach (var itm in arrAmount) {
                if (itm > 0) {
                    unselected = false;

                    // Update to DB
                    productData.proID.Add(lsProID[i]);
                    productData.proAmount.Add(lsProAmount[i] - itm);

                    // Backup for rollback
                    productData.amountBack.Add(itm);

                    // Next form
                    productData.proName.Add(lsProName[i]);
                    productData.amount.Add(itm);
                    productData.proPrice.Add(lsSellP[i]);
                }
                i++;
            }

            if (unselected) {
                MessageBox.Show(
                    "Please select item!",
                    "Warning"
                );
            } else {
                // GO TO NEW FORM
                var formProductDetail = new formProductDetail();
                formProductDetail.Show();
                this.Hide();
            }
        }
    }
}
