using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeagleBoys {
   /*
    * Beagle boys pizza ordering GUI application
    * Provides the functionality to order customizable pizzas
    * from BeagleBoys.
    * Author Eliot, Whalan, n9446800
    * Date: September 2016
    */
    public partial class Form1 : Form {
        double price = 10.00;
        int total = 0;
        string curst;
        public Form1() {
            InitializeComponent();

            comboBox1.Enabled = false;
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            radioButton3.Enabled = false;
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            checkBox3.Enabled = false;
            checkBox4.Enabled = false;
            checkBox5.Enabled = false;
            checkBox6.Enabled = false;
            checkBox7.Enabled = false;
            checkBox8.Enabled = false;
            checkBox9.Enabled = false;
            checkBox10.Enabled = false;
            checkBox11.Enabled = false;
            checkBox12.Enabled = false;
            checkBox13.Enabled = false;
            checkBox14.Enabled = false;
            checkBox15.Enabled = false;
            checkBox16.Enabled = false;
            button1.Hide();

        }

        private void checkBox_CheckedChanged(object sender, EventArgs e) {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox.Checked) {
                total += 1;
                if (total > 4) {
                    price += 1;
                }
            } else {
                if (total > 4) {
                    price -= 1;
                }
                total -= 1;
            }
            
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e) {
            RadioButton radioButton =  sender as RadioButton;
            if (radioButton.Checked) {
                comboBox1.Enabled = true;
                curst = radioButton.Text;
                if (radioButton1.Checked) {
                    price += 2;
                }
            }


        }
        private void Messages() {
            MessageBox.Show(string.Format("Thank you for your order {0},\n" +
                "of a {1} pizza base with {2} sauce and {3} toppings\n" +
                "The cost of your pizza is ${4}.",
                textBox1.Text, curst, comboBox1.SelectedItem.ToString(), total, price));
            MessageBox.Show("Thanks for your order from Beagle Boys Pizza,\n" +
                "your pizza will be delivered in 30 minutes or its free!");
        }

        private void button1_Click(object sender, EventArgs e) {
            if (total < 1) {
                MessageBox.Show("You require at least 1 topping to complete your order\n"+
                    "Remember up to 4 toppings are free!");
            } else {
                Messages();
                Application.Exit();
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e) {
            if (textBox1.Text != "") {
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                radioButton3.Enabled = true;
            }
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (comboBox1.SelectedItem.ToString() != "") {
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
                checkBox4.Enabled = true;
                checkBox5.Enabled = true;
                checkBox6.Enabled = true;
                checkBox7.Enabled = true;
                checkBox8.Enabled = true;
                checkBox9.Enabled = true;
                checkBox10.Enabled = true;
                checkBox11.Enabled = true;
                checkBox12.Enabled = true;
                checkBox13.Enabled = true;
                checkBox14.Enabled = true;
                checkBox15.Enabled = true;
                checkBox16.Enabled = true;
                button1.Show();
            }
            
        }
    }
}
