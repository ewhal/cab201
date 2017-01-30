using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Low_Level_Objects_Library;

namespace Games {
    public partial class SuitSelector : Form {
        public Suit suit;
        public SuitSelector() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            if (radioButton1.Checked == true) {
                this.suit = Suit.Clubs;
                this.DialogResult = DialogResult.OK;
                this.Close();
            } else if (radioButton2.Checked == true) {
                this.suit = Suit.Diamonds;
                this.DialogResult = DialogResult.OK;
                this.Close();
            } else if (radioButton3.Checked == true) {
                this.suit = Suit.Hearts;
                this.DialogResult = DialogResult.OK;
                this.Close();
            } else if (radioButton4.Checked == true) {
                this.suit = Suit.Spades;
                this.DialogResult = DialogResult.OK;
                this.Close();
            } else {
                // do nothing
            }

        }
    }
}
