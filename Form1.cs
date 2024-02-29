using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tic_tac_toe
{
    public partial class Form1 : Form
    {
        bool turn = true; //  true = x; false = o;
        int turnCount = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By sheridan", "tic tac toe"); // this message appears when the user presses the about tab
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";
            }

            turn = !turn;
            b.Enabled = false;
            turnCount++;
            checkwinner(); 
        }

        private void checkwinner()
        {
            bool winner_winner = false;
            // checks horizontal
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled)) 
            {
                winner_winner = true;
            }
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
            {
                winner_winner = true;
            }
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
            {
                winner_winner = true;
            }

            // checks vertical
            if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
            {
                winner_winner = true;
            }
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
            {
                winner_winner = true;
            }
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
            {
                winner_winner = true;
            }

            // Checks diangele
            if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
            {
                winner_winner = true;
            }
            else if ((C1.Text == B2.Text) && (B2.Text == A3.Text) && (!C1.Enabled))
            {
                winner_winner = true;
            }

            if (winner_winner)
            {
                disablebutton();
                string winner = "";

                if (turn)
                {
                    winner = "O";
                }
                else
                {
                    winner = "X";
                }

                MessageBox.Show("WINNER WINNER CHICKEN DINNER " + winner);
            }

            else
            {
                if(turnCount == 9)
                {
                    MessageBox.Show("Draw, sucks");
                }
            }

        }

        private void disablebutton()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false; // when a button gets clicked it becomes disable
                } // end foreach
            }
            catch { }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true; // turn gets relex back to x is first
            turnCount = 0; // turn count gets reset back to 0
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = true; // buttons become enabled (you can press the buttons now
                    b.Text = " "; // x's o's gets erased from the borad
                } // end foreach
            }
            catch { }
        }
    }     
         
}
