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
            try
            {

                decimal operand1 = Convert.ToDecimal(txtOperand1.Text);
                string operator1 = txtOperator.Text;
                decimal operand2 = Convert.ToDecimal(txtOperand2.Text);
                decimal result = Calculate(operand1, operator1, operand2);

                result = Math.Round(result, 4);
                txtResult.Text = result.ToString();

            }
            catch (FormatException)
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
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.GetType().ToString() + "\n" + ex.StackTrace, "Exception");
            }
            txtOperand1.Focus();
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

    }
}