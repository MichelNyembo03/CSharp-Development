using Antlr4.Runtime.Atn;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class CalculatorForm : Form
    {
        public CalculatorForm()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (ExpressionScreen.Text == "0") ExpressionScreen.Text = ""; ResultScreen.Text = "";
            ExpressionScreen.Text += btn.Text;

        }

        private void Operators(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (char.IsDigit(ExpressionScreen.Text.Last()))
            {
                ExpressionScreen.Text += btn.Text;
            }
        }

        private void BtnDot_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (!(ExpressionScreen.Text.Contains("."))) ExpressionScreen.Text += btn.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ExpressionScreen.Text.Length > 0)
            {
                ExpressionScreen.Text = ExpressionScreen.Text.Remove(ExpressionScreen.Text.Length - 1, 1);
            }
            if (ExpressionScreen.Text.Length == 0)
            {
                ExpressionScreen.Text = "0";
            }
        }

        private void ExpressionScreen_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ExpressionScreen_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {
            decimal result = Convert.ToDecimal(new DataTable().Compute(ExpressionScreen.Text, ""));
            ResultScreen.Text = result.ToString();
            ExpressionScreen.Text = "0";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExpressionScreen.Text = "0";
            ResultScreen.Text = "";
        }

        private void ceBtn_Click(object sender, EventArgs e)
        {
            ExpressionScreen.Text = "0";
            ResultScreen.Text = "";
        }

        private void sqrt_Click(object sender, EventArgs e)
        {

            if(ExpressionScreen.Text.Length > 0 && char.IsDigit(ExpressionScreen.Text.Last()))
                {
                decimal result = Convert.ToDecimal(new DataTable().Compute(ExpressionScreen.Text, ""));
                decimal sqrt = (decimal)Math.Sqrt((double)result);
                ResultScreen.Text = sqrt.ToString();
            }

            
        }

        private void square_Click(object sender, EventArgs e)
        {
            if (ExpressionScreen.Text.Length > 0 && char.IsDigit(ExpressionScreen.Text.Last()))
            {
                decimal result = Convert.ToDecimal(new DataTable().Compute(ExpressionScreen.Text, ""));
                decimal sqrt = (decimal)Math.Pow((double)result, 2);
                ResultScreen.Text = sqrt.ToString();
            }
        }

        private void onedivide_x_Click(object sender, EventArgs e)
        {
            if (ExpressionScreen.Text.Length > 0 && char.IsDigit(ExpressionScreen.Text.Last()))
            {
                decimal result = Convert.ToDecimal(new DataTable().Compute(ExpressionScreen.Text, ""));
                if(result > 0)
                {
                    double sqrt = (double)(1 / (result));
                    ResultScreen.Text = sqrt.ToString();
                }
                else
                {
                    ResultScreen.Text = "Can't divid by Zero";
                }
                
            }
        }
    }
}
