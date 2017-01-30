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
    public partial class Game : Form {
        public Game() {
            InitializeComponent();
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e) {
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e) {
            if (radioButton1.Checked) {
                Form GameForm = new Two_Up();
                GameForm.Show();
            } else if (radioButton2.Checked) {
                Form GameForm = new Which_Dice_Game();
                GameForm.Show();
            } else if (radioButton3.Checked) {
                Form GameForm = new Which_Card_Game();
                GameForm.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show("Do you really want to quit?", 
                "Quit",
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes) {
                System.Windows.Forms.Application.Exit();
            }
        }
    }
}
