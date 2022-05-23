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
        public formProductDetail() {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e) {
            var formHome = new formHome();
            formHome.Show();
            this.Hide();
        }
    }
}
