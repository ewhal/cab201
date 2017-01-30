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
    public partial class Snake_Eyes : Form {
        private bool another = false;
        private int counter = 0;
        public Snake_Eyes() {
            InitializeComponent();
            Snake_Eyes_Game.SetUpGame();
        }
        private void UpdatePictureBoxImage(PictureBox whichPB, int faceValue) {
            whichPB.Image = Images.GetDieImage(faceValue);
        }

        private void button1_Click(object sender, EventArgs e) {
            timer1.Start();

            if (another) {
                button2.Enabled = false;
                button1.Enabled = true;
                label2.Text = "You need to roll " + Snake_Eyes_Game.GetPossiblePoints() + " points";
            } else {
                label2.Text = "";
                button1.Enabled = false;
                button2.Enabled = true;
            }

            label1.Text = Snake_Eyes_Game.GetRollOutcome();
            label4.Text = Snake_Eyes_Game.GetPlayersPoints().ToString();
            label6.Text = Snake_Eyes_Game.GetHousePoints().ToString();
        }

        private void button2_Click(object sender, EventArgs e) {
            button2.Enabled = false;
            button1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show("Do you really want to quit with a score of "+ Snake_Eyes_Game.GetPlayersPoints() +"?",
                 "Quit",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Question);
            if (result == DialogResult.Yes) {
                Form GameForm = new Which_Dice_Game();
                this.Close();
                GameForm.Show();
            }
        }

        private void timer1_Tick(object sender, EventArgs e) {
            if (counter == 7) {
                counter = 0;
                timer1.Stop();
                if (another) {
                    another = Snake_Eyes_Game.AnotherRoll();
                } else {
                    another = Snake_Eyes_Game.FirstRoll();
                }
                UpdatePictureBoxImage(pictureBox1, Snake_Eyes_Game.GetDiceFacevalue(0));
                UpdatePictureBoxImage(pictureBox2, Snake_Eyes_Game.GetDiceFacevalue(1));
            } else {
                UpdatePictureBoxImage(pictureBox1, counter);
                UpdatePictureBoxImage(pictureBox2, counter);
                counter++;

            }

        }
    }
}
