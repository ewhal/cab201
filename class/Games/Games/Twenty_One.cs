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

using Low_Level_Objects_Library;



namespace Games {
    public partial class Twenty_One : Form {

        Twenty_One_Game game = new Twenty_One_Game();
        public Twenty_One() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            game.SetUpGame();
            DisplayGuiHand(game.GetHand(1), tableLayoutPanel1);
            DisplayGuiHand(game.GetHand(0), tableLayoutPanel2);
            label2.Text = "Dealer    " + game.CalculateHandTotal(1).ToString();
            label7.Text = "Player     " + game.CalculateHandTotal(0).ToString();
            label5.Text = game.GetNumberOfGamesWon(1).ToString();
            label10.Text = game.GetNumberOfGamesWon(0).ToString();
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
            label1.Visible = false;

            label6.Visible = false;

        }

        private void button2_Click(object sender, EventArgs e) {
            Card card = game.DealOneCardTo(0);
            if (card.GetFaceValue() == FaceValue.Ace) {
                DialogResult result = MessageBox.Show("Count Ace as 1?",
                    "You got an Ace!",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (result == DialogResult.Yes) {
                    game.IncrementNumOfUserAcesWithValueOne();
                }
            }
            DisplayGuiHand(game.GetHand(0), tableLayoutPanel2);
            label7.Text = "Player     " + game.CalculateHandTotal(0).ToString();
            if (game.CalculateHandTotal(0) == 21) {
                game.numOfGamesWon[0]++;
                button1.Enabled = true;
                button2.Enabled = false;
                button3.Enabled = false;
            }

            if (game.CalculateHandTotal(0) > 21) {
                game.numOfGamesWon[1]++;
                label6.Visible = true;
                button1.Enabled = true;
                button2.Enabled = false;
                button3.Enabled = false;
            }
            label5.Text = game.GetNumberOfGamesWon(1).ToString();
            label10.Text = game.GetNumberOfGamesWon(0).ToString();
        }

        private void button3_Click(object sender, EventArgs e) {
            if (game.CalculateHandTotal(1) < 17) {
                game.PlayForDealer();
            }


            if (game.CalculateHandTotal(1) == 21) {
                game.numOfGamesWon[1]++;
                button1.Enabled = true;
                button2.Enabled = false;
                button3.Enabled = false;
            }

            if (game.CalculateHandTotal(1) > 21) {
                game.numOfGamesWon[0]++;
                label1.Visible = true;
                button1.Enabled = true;
                button2.Enabled = false;
                button3.Enabled = false;
            }
            DisplayGuiHand(game.GetHand(1), tableLayoutPanel1);
            label2.Text = "Dealer    " + game.CalculateHandTotal(1).ToString();
            label5.Text = game.GetNumberOfGamesWon(1).ToString();
            label10.Text = game.GetNumberOfGamesWon(0).ToString();
        }

        private void button4_Click(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show("Do you really want to quit with a score of " 
                + game.GetNumberOfGamesWon(0).ToString() + "?",
                "Quit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes) {
                Form GameForm = new Which_Card_Game();
                this.Close();
                GameForm.Show();
            }
        }

        private void DisplayGuiHand(Hand hand, TableLayoutPanel tableLayoutPanel) {

            tableLayoutPanel.Controls.Clear(); // Remove any cards already being shown.

            foreach (Card card in hand) {

                // Construct a PictureBox object.
                PictureBox pictureBox = new PictureBox();
                // Tell the PictureBox to use all the space inside its square.
                pictureBox.Dock = DockStyle.Fill;
                // Remove spacing around the PictureBox. (Default is 3 pixels.)
                pictureBox.Margin = new Padding(0);

                pictureBox.Image = Images.GetCardImage(card);

                // Add the PictureBox object to the tableLayoutPanel.
                tableLayoutPanel.Controls.Add(pictureBox);
            }
        }// End DisplayGuiHand
    }
}
