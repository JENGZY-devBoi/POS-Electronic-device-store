using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_APP {
    public partial class formProductDetail : Form {
        private double totalPrice;
        private bool canBuy = false;
        public formProductDetail() {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e) {
            var formHome = new formHome();
            formHome.Show();
            this.Hide();
        }

        private void formProductDetail_Load(object sender, EventArgs e) {
            showProductDetail();
            showTotalDetail();
        }

        private void showProductDetail() {
            string product_name = "";
            string product_amount = "";
            string product_price = "";

            int i = 0;
            foreach (var itm in productData.proName) {
                product_name += itm;
                product_amount += productData.amount[i];
                product_price += productData.proPrice[i].ToString("#,#.00");

                product_name += ((i-1 < productData.proName.Count) ? "\n" : "");
                product_amount += ((i - 1 < productData.proName.Count) ? "\n" : "");
                product_price += ((i - 1 < productData.proName.Count) ? "\n" : "");
                i++;
            }
            lblProName.Text = product_name;
            lblProAmount.Text = product_amount;
            lblProPrice.Text = product_price;
        }

        private void showTotalDetail() {
            lblTotalAmount.Text = productData.proName.Count.ToString("#,#");
            
            totalPrice = 0;
            for (int i = 0; i < productData.proName.Count; i++) {
                totalPrice += productData.amount[i] * productData.proPrice[i];
            }
            
            lblTotalPrice.Text = totalPrice.ToString("#,#.00");
        }

        private void btnCalcTotal_Click(object sender, EventArgs e) {
            double amount = Convert.ToDouble(txtAmount.Text);

            double change = amount - totalPrice;
            
            // change cannot negative number
            if (change >= 0) {
                txtChange.Text = change.ToString("#,#.00");
                canBuy = true;
            } else {
                MessageBox.Show(
                    "Money not enough!",
                    "Warning"
                );
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e) {
            if (canBuy) {
                MessageBox.Show(
                    "Purchase success!",
                    "Notify"
                );

                // GO TO NEW FORM
            }
        }
    }
}
