using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Games_Logic_Library;
using Low_Level_Objects_Library;


namespace Games {
    public partial class Crazy_Eights : Form {
        Crazy_Eights_Game game = new Crazy_Eights_Game();
        public Crazy_Eights() {
            InitializeComponent();
            game.SetUpGame();
            Card card = game.DrawTopCard(2);
            game.SetCurrentSuit(card.GetSuit());
        }

        private void button1_Click(object sender, EventArgs e) {
            game.SetUpGame();
            Card card = game.DrawTopCard(2);
            game.SetCurrentSuit(card.GetSuit());
            DisplayGuiHand(game.GetHand(0), tableLayoutPanel2, 0);
            DisplayGuiHand(game.GetHand(1), tableLayoutPanel1, 1);
            UpdatePictureBoxImage(game.GetTopCard(2));
            UpdatePictureBackBoxImage();

            button1.Enabled = false;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e) {
            game.SortHand(0);
            DisplayGuiHand(game.GetHand(0), tableLayoutPanel2, 0);

        }

        private void button3_Click(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show("Do you really want to quit?",
                 "Quit",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Question);
            if (result == DialogResult.Yes) {
                Form GameForm = new Which_Card_Game();
                this.Close();

                GameForm.Show();
            }
        }
        private void UpdatePictureBackBoxImage() {
            pictureBox1.Image = Images.GetBackOfCardImage();
        }
        private void UpdatePictureBoxImage(Card card) {
            pictureBox2.Image = Images.GetCardImage(card);
        }
        private void DisplayGuiHand(Hand hand, TableLayoutPanel tableLayoutPanel, int who) {

            tableLayoutPanel.Controls.Clear(); // Remove any cards already being shown.

            foreach (Card card in hand) {

                // Construct a PictureBox object.
                PictureBox pictureBox = new PictureBox();
                // Tell the PictureBox to use all the space inside its square.
                pictureBox.Dock = DockStyle.Fill;
                // Remove spacing around the PictureBox. (Default is 3 pixels.)
                pictureBox.Margin = new Padding(0);

                pictureBox.Image = Images.GetCardImage(card);
                if (who == 0) {
                    pictureBox.Click += new EventHandler(pictureBox_Click);
                    pictureBox.Tag = card;
                }

                // Add the PictureBox object to the tableLayoutPanel.
                tableLayoutPanel.Controls.Add(pictureBox);
            }
        }// End DisplayGuiHand

        private void pictureBox1_Click(object sender, EventArgs e) {
            game.DrawTopCard(0);
            DisplayGuiHand(game.GetHand(0), tableLayoutPanel2, 0);
            UpdatePictureBoxImage(game.GetTopCard(2));
            UpdatePictureBackBoxImage();
            if (game.GetHandSize(0) == 13) {
                label3.Text = "You lose";

                button1.Enabled = true;
                button2.Enabled = false;
            }


        }
        private void pictureBox_Click(object sender, EventArgs e) {

            PictureBox clickedPictureBox = (PictureBox)sender;
            Card clickedCard = (Card)clickedPictureBox.Tag;
            TryToPlayCard(clickedCard);
        }
        private void TryToPlayCard(Card clickedCard) {
            if (game.GetAvailableMoves(0) == false && game.GetAvailableMoves(2) == false) {
                label3.Text = "No available moves. Draw";
            } else {
                label3.Text = "Your turn. Ckick on one your cards to play";
            }

            if (clickedCard.GetFaceValue() == FaceValue.Eight) {
                var form = new SuitSelector();
                var result = form.ShowDialog();
                game.SetCurrentSuit(form.suit);
                game.NewTopCard(clickedCard, 0);
            } else if (clickedCard.GetSuit() == game.GetCurrentSuit()
                || clickedCard.GetFaceValue() == game.GetTopFaceValue(2)) {
                game.NewTopCard(clickedCard, 0);
            } else {
                label3.Text = "Can't do that Play that card right now.";
            }
            DisplayGuiHand(game.GetHand(0), tableLayoutPanel2, 0);
            UpdatePictureBoxImage(game.GetTopCard(2));
            UpdatePictureBackBoxImage();

            game.PlayForComputer();
            if (game.GetHandSize(1) == 13) {
                label3.Text = "You win";

                button1.Enabled = true;
                button2.Enabled = false;
            }
            DisplayGuiHand(game.GetHand(1), tableLayoutPanel1, 1);
            UpdatePictureBoxImage(game.GetTopCard(2));
            UpdatePictureBackBoxImage();
            RefreshTheformThenPause();
        }
        private static void RefreshTheformThenPause() {
            Application.DoEvents();
            const int HALF_SECOND = 500;
            Thread.Sleep(HALF_SECOND);
        }
    }
}
