using Microsoft.VisualBasic;

namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {

            if (IsValidOperation())
            {
                try
                {

                    decimal operand1 = Convert.ToDecimal(txtOperand1.Text);
                    string operator1 = txtOperator.Text;
                    decimal operand2 = Convert.ToDecimal(txtOperand2.Text);
                    decimal result = Calculate(operand1, operator1, operand2);

                    result = Math.Round(result, 4);
                    txtResult.Text = result.ToString();

                }
                /*catch (FormatException)
                {
                    MessageBox.Show("The formatting of one of the values is incorrect. Please check each of your values and correct the formatting if it is incorrect.", "Formatting Error");
                }
                catch (OverflowException)
                {
                    MessageBox.Show("The number you have inserted is either too small or too large. Please correct its value.", "Overflow Error");
                }
                catch (DivideByZeroException)
                {
                    MessageBox.Show("The number you are dividing by is 0. Please change it to a non-zero value.", "Divide by Zero Error");
                }*/
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\n" + ex.GetType().ToString() + "\n" + ex.StackTrace, "Exception");
                }
                txtOperand1.Focus();
            }
        }

        private decimal Calculate(decimal operand1, string operator1, decimal operand2)
        {
            decimal result = 0;
            if (operator1 == "+")
                result = operand1 + operand2;
            else if (operator1 == "-")
                result = operand1 - operand2;
            else if (operator1 == "*")
                result = operand1 * operand2;
            else if (operator1 == "/")
                result = operand1 / operand2;
            return result;
        }

        private void ClearResult(object sender, EventArgs e)
        {
            txtResult.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool IsValidOperation()
        {

            bool success = true;
            string errorMsg = "";

            // Operand 1
            errorMsg += isPresent(txtOperand1.Text, "Operand 1");
            errorMsg += isDecimal(txtOperand1.Text, "Operand 1");
            errorMsg += isWithinRange(txtOperand1.Text, "Operand 1", 0, 1000000);

            // Operand 2
            errorMsg += isPresent(txtOperand2.Text, "Operand 2");
            errorMsg += isDecimal(txtOperand2.Text, "Operand 2");
            errorMsg += isWithinRange(txtOperand2.Text, "Operand 2", 0, 1000000);
            if (txtOperator.Text == "/")
            {
                errorMsg += isNotZero(txtOperand2.Text, "Operand 2");
            }

            // Operator
            errorMsg += isPresent(txtOperator.Text, "Operator");
            errorMsg += isOperator(txtOperator.Text, "Operator");

            if (errorMsg != "")
            {
                success = false;
                MessageBox.Show(errorMsg, "Entry Error");
            }

            return success;

        }

        private string isOperator(string value, string name)
        {

            string msg = "";

            if (value != "+" & value != "-" & value != "*" & value != "/")
            {
                msg = name + "must be a valid operator (+ - * / ).\n";
            }
            return msg;
        }

        private string isPresent(string value, string name)
        {

            string msg = "";

            if (value == "")
            {
                msg = name + "must have a value.\n";
            }

            return msg;

        }

        private string isDecimal(string value, string name)
        {

            string msg = "";

            if (!Decimal.TryParse(value, out _))
            {
                msg = name + " must be a valid decimal value.\n";
            }

            return msg;

        }

        private string isWithinRange(string value, string name, decimal min, decimal max)
        {

            string msg = "";

            if (Decimal.TryParse(value, out decimal number))
            {

                if (number < min || number > max)
                {
                    msg = name + " must be between " + min + " and " + max + ".\n";
                }
            }

            return msg;

        }

        private string isNotZero(string value, string name)
        {

            string msg = "";

            if (Convert.ToDecimal(value) == 0)
            {
                msg = name + " must be a non-zero value when dividing.\n";
            }

            return msg;

        }

    }
}