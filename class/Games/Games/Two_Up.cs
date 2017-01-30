using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Games_Logic_Library;

namespace Games {
    public partial class Two_Up : Form {
        int counter = 0;
        public Two_Up() {
            InitializeComponent();
            Two_Up_Game.SetUpGame();
            UpdatePictureBoxImage(pictureBox1, Two_Up_Game.IsHeads(1));
            UpdatePictureBoxImage(pictureBox2, Two_Up_Game.IsHeads(2));
        }
        private void UpdatePictureBoxImage(PictureBox whichPB, bool isHeads) {
            whichPB.Image = Images.GetCoinImage(isHeads);
        }

        private void button1_Click(object sender, EventArgs e) {
            button1.Enabled = false;
            timer1.Start();
            Two_Up_Game.TossCoins();

            UpdatePictureBoxImage(pictureBox1, Two_Up_Game.IsHeads(1));
            UpdatePictureBoxImage(pictureBox2, Two_Up_Game.IsHeads(2));
            label1.Text = Two_Up_Game.TossOutcome();
            label5.Text = Two_Up_Game.GetComputerScore().ToString();
            label3.Text = Two_Up_Game.GetPlayersScore().ToString();
            if (Two_Up_Game.TossOutcome() != "Odds") {
                button2.Enabled = true;
                button1.Enabled = false;
            }
            button1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e) {
            button2.Enabled = false;
            button1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e) {
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

        private void timer1_Tick(object sender, EventArgs e) {
            if (counter == 10) {
                counter = 0;
                timer1.Stop();

            } else if (counter % 2 == 0)  {
                counter++;
                button1.Enabled = false;

                UpdatePictureBoxImage(pictureBox1, true);
                UpdatePictureBoxImage(pictureBox2, true);
            } else {
                counter++;
                button1.Enabled = false;

                UpdatePictureBoxImage(pictureBox1, false);
                UpdatePictureBoxImage(pictureBox2, false);
            }

        }
    }

}
