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
    }
}
