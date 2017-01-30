using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Games {
    public partial class Which_Card_Game : Form {
        public Which_Card_Game() {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            if (comboBox1.Text == "Twenty-one") {
                Form GameForm = new Twenty_One();
                this.Close();
                GameForm.Show();
            } else if (comboBox1.Text == "Crazy Eights") {

                Form GameForm = new Crazy_Eights();
                this.Close();
                GameForm.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show("Do you really want to quit?",
                    "Quit",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
            if (result == DialogResult.Yes) {
                Form GameForm = new Game();
                this.Close();
                GameForm.Show();
            }
        }
    }
}
