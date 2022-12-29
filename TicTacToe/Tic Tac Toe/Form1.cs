using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {
        //Player switcher
        bool isPlayer;

        //Player's point
        int score = 0;
        public Form1()
        {
            InitializeComponent();
        }

        //This method is responsible for disabling all buttons
        void Enable_Disable()
        {
            btn1.Enabled = false;
            btn2.Enabled = false;
            btn3.Enabled = false;
            btn4.Enabled = false;
            btn5.Enabled = false;
            btn6.Enabled = false;
            btn7.Enabled = false;
            btn8.Enabled = false;
            btn9.Enabled = false;
        }

        //This method is responsible for defining the wining confition and checking which player win the game
        void Score()
        {

            if (btn1.Text == "X" && btn2.Text == "X" && btn3.Text == "X")
            {
                //Changing the button's colors
                btn1.BackColor= Color.Blue;
                btn2.BackColor= Color.Blue;
                btn3.BackColor= Color.Blue;

                //displaying the player who won the game
                MessageBox.Show("Player 1 has won");

                //incrementing the player's point and displaying them
                ScoreP1.Text = (score +1).ToString();
                Enable_Disable();

            }
            if (btn4.Text == "X" && btn5.Text == "X" && btn6.Text == "X")
            {
                btn4.BackColor = Color.Blue;
                btn5.BackColor = Color.Blue;
                btn6.BackColor = Color.Blue;

                MessageBox.Show("Player 1 has won");
                ScoreP1.Text = (score + 1).ToString();
                Enable_Disable();
            }
            if (btn7.Text == "X" && btn8.Text == "X" && btn9.Text == "X")
            {
                btn7.BackColor = Color.Blue;
                btn8.BackColor = Color.Blue;
                btn9.BackColor = Color.Blue;

                MessageBox.Show("Player 1 has won");
                ScoreP1.Text = (score + 1).ToString();
                Enable_Disable();
            }
            if (btn1.Text == "X" && btn4.Text == "X" && btn7.Text == "X")
            {
                btn1.BackColor = Color.Blue;
                btn4.BackColor = Color.Blue;
                btn7.BackColor = Color.Blue;

                MessageBox.Show("Player 1 has won");
                ScoreP1.Text = (score + 1).ToString();
                Enable_Disable();
            }
            if (btn2.Text == "X" && btn5.Text == "X" && btn8.Text == "X")
            {
                btn2.BackColor = Color.Blue;
                btn5.BackColor = Color.Blue;
                btn8.BackColor = Color.Blue;

                MessageBox.Show("Player 1 has won");
                ScoreP1.Text = (score + 1).ToString();
                Enable_Disable();
            }
            if (btn3.Text == "X" && btn6.Text == "X" && btn9.Text == "X")
            {
                btn3.BackColor = Color.Blue;
                btn6.BackColor = Color.Blue;
                btn9.BackColor = Color.Blue;

                MessageBox.Show("Player 1 has won");
                ScoreP1.Text = (score + 1).ToString();
                Enable_Disable();
            }
            if (btn1.Text == "X" && btn5.Text == "X" && btn9.Text == "X")
            {
                btn1.BackColor = Color.Blue;
                btn5.BackColor = Color.Blue;
                btn9.BackColor = Color.Blue;

                MessageBox.Show("Player 1 has won");
                ScoreP1.Text = (score + 1).ToString();
                Enable_Disable();
            }
            if (btn3.Text == "X" && btn5.Text == "X" && btn7.Text == "X")
            {

                btn3.BackColor = Color.Blue;
                btn5.BackColor = Color.Blue;
                btn7.BackColor = Color.Blue;

                MessageBox.Show("Player 1 has won");
                ScoreP1.Text = (score + 1).ToString();
                Enable_Disable();
            }


            //Player 2 (O)

            if (btn1.Text == "O" && btn2.Text == "O" && btn3.Text == "O")
            {
                btn1.BackColor = Color.Blue;
                btn2.BackColor = Color.Blue;
                btn3.BackColor = Color.Blue;

                MessageBox.Show("Player 2 has won");
                ScoreP2.Text = (score + 1).ToString();
                Enable_Disable();

            }
            if (btn4.Text == "0" && btn5.Text == "O" && btn6.Text == "O")
            {
                btn4.BackColor = Color.Blue;
                btn5.BackColor = Color.Blue;
                btn6.BackColor = Color.Blue;

                MessageBox.Show("Player 2 has won");
                ScoreP2.Text = (score + 1).ToString();
                Enable_Disable();
            }
            if (btn7.Text == "O" && btn8.Text == "O" && btn9.Text == "O")
            {
                btn7.BackColor = Color.Blue;
                btn8.BackColor = Color.Blue;
                btn9.BackColor = Color.Blue;

                MessageBox.Show("Player 2 has won");
                ScoreP2.Text = (score + 1).ToString();
                Enable_Disable();
            }
            if (btn1.Text == "O" && btn4.Text == "O" && btn7.Text == "O")
            {
                btn1.BackColor = Color.BlueViolet;
                btn4.BackColor = Color.BlueViolet;
                btn7.BackColor = Color.BlueViolet;

                MessageBox.Show("Player 2 has won");
                ScoreP2.Text = (score + 1).ToString();
                Enable_Disable();
            }
            if (btn2.Text == "O" && btn5.Text == "O" && btn8.Text == "O")
            {
                btn2.BackColor = Color.BlueViolet;
                btn5.BackColor = Color.BlueViolet;
                btn8.BackColor = Color.BlueViolet;

                MessageBox.Show("Player 2 has won");
                ScoreP2.Text = (score + 1).ToString();
                Enable_Disable();
            }
            if (btn3.Text == "O" && btn6.Text == "O" && btn9.Text == "O")
            {
                btn3.BackColor = Color.BlueViolet;
                btn6.BackColor = Color.BlueViolet;
                btn9.BackColor = Color.BlueViolet;

                MessageBox.Show("Player 2 has won");
                ScoreP2.Text = (score + 1).ToString();
                Enable_Disable();
            }
            if (btn1.Text == "O" && btn5.Text == "O" && btn9.Text == "O")
            {
                btn1.BackColor = Color.BlueViolet;
                btn5.BackColor = Color.BlueViolet;
                btn9.BackColor = Color.BlueViolet;

                MessageBox.Show("Player 2 has won");
                ScoreP2.Text = (score + 1).ToString();
                Enable_Disable();
            }
            if (btn3.Text == "O" && btn5.Text == "O" && btn7.Text == "O")
            {
                btn3.BackColor = Color.BlueViolet;
                btn5.BackColor = Color.BlueViolet;
                btn7.BackColor = Color.BlueViolet;

                MessageBox.Show("Player 2 has won");
                ScoreP2.Text = (score + 1).ToString();
                Enable_Disable();
            }

            //This if statement define the condition in which there is a draw game
             if(btn1.Text != "" && btn2.Text != "" && btn3.Text != "" &&
                btn4.Text != "" && btn5.Text != "" && btn6.Text != "" &&
                btn7.Text != "" && btn8.Text != "" && btn9.Text != "")
            {
                
                btn1.BackColor = Color.IndianRed;
                btn2.BackColor = Color.IndianRed;
                btn3.BackColor = Color.IndianRed;
                btn4.BackColor = Color.IndianRed;
                btn5.BackColor = Color.IndianRed;
                btn6.BackColor = Color.IndianRed;
                btn7.BackColor = Color.IndianRed;
                btn8.BackColor = Color.IndianRed;
                btn9.BackColor = Color.IndianRed;

                MessageBox.Show("Draw Score");
                Enable_Disable();
            }

        }
        private void button_Click(object sender, EventArgs e)
        {
            //creating the button and casting them as the sender object
            Button btn = (Button)sender;

            //Switching the boolean's value true or false
            isPlayer ^= true;

            if (btn.Text == "")
                btn.Text = isPlayer ? "X" : "O";
   
            //Calling the Score method;
            Score();
        
        }


        //This method Restart the game
        private void New_Game(object sender, EventArgs e)
        {
            btn1.Enabled = true;
            btn1.BackColor = Color.Transparent;

            btn2.Enabled = true;
            btn2.BackColor = Color.Transparent;

            btn3.Enabled = true;
            btn3.BackColor = Color.Transparent;

            btn4.Enabled = true;
            btn4.BackColor = Color.Transparent;

            btn5.Enabled = true;
            btn5.BackColor = Color.Transparent;

            btn6.Enabled = true;
            btn6.BackColor = Color.Transparent;

            btn7.Enabled = true;
            btn7.BackColor = Color.Transparent;

            btn8.Enabled = true;
            btn8.BackColor = Color.Transparent;

            btn9.Enabled = true;
            btn9.BackColor = Color.Transparent;

            btn1.Text = "";
            btn2.Text = "";
            btn3.Text = "";
            btn4.Text = "";
            btn5.Text = "";
            btn6.Text = "";
            btn7.Text = "";
            btn8.Text = "";
            btn9.Text = "";

            ScoreP1.Text = "0";
            ScoreP2.Text = "0";
        }

        //This method reset the board
        private void Reset_Game(object sender, EventArgs e)
        {
            btn1.Enabled = true;
            btn1.BackColor= Color.Transparent;
            
            btn2.Enabled = true;
            btn2.BackColor = Color.Transparent;

            btn3.Enabled = true;
            btn3.BackColor = Color.Transparent;

            btn4.Enabled = true;
            btn4.BackColor = Color.Transparent;

            btn5.Enabled = true;
            btn5.BackColor = Color.Transparent;

            btn6.Enabled = true;
            btn6.BackColor = Color.Transparent;

            btn7.Enabled = true;
            btn7.BackColor = Color.Transparent;

            btn8.Enabled = true;
            btn8.BackColor = Color.Transparent;

            btn9.Enabled = true;
            btn9.BackColor = Color.Transparent;


            btn1.Text = "";
            btn2.Text = "";
            btn3.Text = "";
            btn4.Text = "";
            btn5.Text = "";
            btn6.Text = "";
            btn7.Text = "";
            btn8.Text = "";
            btn9.Text = "";
        }
    }
}


//Michael Nyembo//