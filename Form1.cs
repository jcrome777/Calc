using System.Globalization;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private double value = 0;
        private List<double> nums = new List<double>();
        private List<string> symbols = new List<string>();

        private double Calculate(double num1, double num2, string symbol)
        {
            double result = 0;
            switch (symbol)
            {
                case "+": result = num1 + num2; break;
                case "-": result = num1 - num2; break;
                case "*": result = num1 * num2; break;
                case "/": result = num1 / num2; break;
            }
            return result;
        }

        private void num0_Click(object sender, EventArgs e)
        {
            boxResult.Text += "0";
        }

        private void num1_Click(object sender, EventArgs e)
        {
            boxResult.Text += "1";
        }

        private void num2_Click(object sender, EventArgs e)
        {
            boxResult.Text += "2";
        }

        private void num3_Click(object sender, EventArgs e)
        {
            boxResult.Text += "3";
        }

        private void num4_Click(object sender, EventArgs e)
        {
            boxResult.Text += "4";
        }

        private void num5_Click(object sender, EventArgs e)
        {
            boxResult.Text += "5";
        }

        private void num6_Click(object sender, EventArgs e)
        {
            boxResult.Text += "6";
        }

        private void num7_Click(object sender, EventArgs e)
        {
            boxResult.Text += "7";
        }

        private void num8_Click(object sender, EventArgs e)
        {
            boxResult.Text += "8";
        }

        private void num9_Click(object sender, EventArgs e)
        {
            boxResult.Text += "9";
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (!boxResult.Text.Contains("."))
            {
                boxResult.Text += ".";
            }
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            boxResult.Text = "";
            value = 0;
            nums.Clear();
            symbols.Clear();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (boxResult.Text.Length > 0)
            {
                boxResult.Text = boxResult.Text.Substring(0, boxResult.Text.Length - 1);
            }
        }

        private void btnNeg_Click(object sender, EventArgs e)
        {
            if (boxResult.Text.StartsWith("-"))
            {
                boxResult.Text = boxResult.Text.Substring(1);
            }
            else
            {
                boxResult.Text = "-" + boxResult.Text;
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(boxResult.Text, out double inputNum))
            {
                return;
            }

            nums.Add(inputNum);
            symbols.Add("+");

            boxResult.Text = "";
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(boxResult.Text, out double inputNum))
            {
                return;
            }

            nums.Add(inputNum);
            symbols.Add("-");

            boxResult.Text = "";
        }

        private void btnMult_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(boxResult.Text, out double inputNum))
            {
                return;
            }

            nums.Add(inputNum);
            symbols.Add("*");

            boxResult.Text = "";
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(boxResult.Text, out double inputNum))
            {
                return;
            }

            nums.Add(inputNum);
            symbols.Add("/");

            boxResult.Text = "";
        }

        private void btnEqls_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(boxResult.Text, out double inputNum))
            {
                return;
            }

            nums.Add(inputNum);

            for (int i = 0; i < symbols.Count; i++)
            {
                if (symbols[i] == "*" || symbols[i] == "/")
                {
                    double result = Calculate(nums[i], nums[i + 1], symbols[i]);
                    nums[i] = result;
                    nums.RemoveAt(i + 1);
                    symbols.RemoveAt(i);
                    i--;
                }
            }

            value = nums[0];

            for (int i = 0; i < symbols.Count; i++)
            {
                value = Calculate(value, nums[i + 1], symbols[i]);
            }

            boxResult.Text = value.ToString();
            nums.Clear();
            symbols.Clear();
        }
    }
}
