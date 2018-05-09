using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Calculator
{
    public partial class Form1 : Form
    {
        decimal answer = 0m; 

        public Form1()
        {
            InitializeComponent();            
        }
        /* BEN WHEAT
         * CIS 123
         * MAY 9th 2018
         * EXTRA 7-1 */
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try // CREATING A TRY STATEMENT:
            {
                // DEFAULT CODE //
                decimal firstNumber = Decimal.Parse(txtFirstOperand.Text);
                decimal secondNumber = Decimal.Parse(txtSecondOperator.Text);

                string operatorEntered = txtOperator.Text;

                operandCalculations(firstNumber, secondNumber, operatorEntered);

                txtFirstOperand.Focus();
                // DEFAULT CODE //
            }
            catch (FormatException ex) // TO CATCH IF THEY ENTERED NUMBERS OR NOT
            {
                MessageBox.Show("You can only enter numbers for operands, silly!");
            }
            catch (OverflowException ex) // TO CATCH IF THEIR INPUT IS TOO LONG TO CALCULATE
            {
                MessageBox.Show("Your input is too long! Please enter a simplified number!");
            }
            catch (DivideByZeroException ex) // TO CATCH IF THEY DIVIDED BY ZERO
            {
                MessageBox.Show("You can't divide something by zero, silly!");
            }
            catch (Exception ex) // TO CATCH ANY OTHER EXCEPTION THAT MAY OCCUR
            {
                MessageBox.Show(ex.ToString(), "An Error Has Occured..."); // DISPLAYS DETAILS
            }
        }

        private void operandCalculations(decimal firstNumber, decimal secondNumber, string operatorEntered)
        {
            if (operatorEntered == "-")
            {
                answer = firstNumber - secondNumber;
                txtResult.Text = answer.ToString("f4");
            }

            else if (operatorEntered == "+")
            {
                answer = firstNumber + secondNumber;
                txtResult.Text = answer.ToString("f4");
            }

            else if (operatorEntered == "x" | operatorEntered == "*")
            {
                answer = firstNumber * secondNumber;
                txtResult.Text = answer.ToString("f4");
            }

            else if (operatorEntered == "/")
            {
                if (secondNumber != 0)
                {
                    answer = firstNumber / secondNumber;
                    txtResult.Text = answer.ToString("f4");
                }
                else
                {
                    MessageBox.Show("You can't divide something by zero, silly!"); // PRIMARY OPTION FOR IF THE USER DIVIDES BY ZERO
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearResults(object sender, EventArgs e)
        {
          txtResult.Text = "";
        }
    }
}
