using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        bool moreThanOneNumber = false;
        bool opEntered = false;
        double firstNumber;
        double secondNumber;
        string op;
        double result;

        public MainWindow()
        {
            InitializeComponent();
        }

        //Operator buttons. When pressed they set the 'op' value to the particular operator symbol clicked
        //They clear the displsy text box of the first value and start displaying the value of the second number.
        //They set the 'opEntered' value to true
        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            op = "+";
            tbDisplay.Text = Convert.ToString(secondNumber);
            opEntered = true;
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            op = "-";
            tbDisplay.Text = Convert.ToString(secondNumber);
            opEntered = true;
        }

        private void btnTimes_Click(object sender, RoutedEventArgs e)
        {
            op = "x";
            tbDisplay.Text = Convert.ToString(secondNumber);
            opEntered = true;
        }

        private void btnDivide_Click(object sender, RoutedEventArgs e)
        {
            op = "/";
            tbDisplay.Text = Convert.ToString(secondNumber);
            opEntered = true;
        }

        //Number buttons. They all call the 'NumberButtonPush' method and each one passes the relevant number through
        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            NumberButtonPush(9);
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            NumberButtonPush(8);
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            NumberButtonPush(7);
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            NumberButtonPush(6);
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            NumberButtonPush(5);
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            NumberButtonPush(4);
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            NumberButtonPush(3);
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            NumberButtonPush(2);
        }

        private void One_Click(object sender, RoutedEventArgs e)
        {
            NumberButtonPush(1);
        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            NumberButtonPush(0);
        }

        // When Equals button is clicked, depending on what 'op' variable is set to perform the relevant
        // calculation on firstNumber and secondNumber & display the result to the display text box
        private void btnEquals_Click(object sender, RoutedEventArgs e)
        {
            if (op == "+")
            {
                result = firstNumber + secondNumber;
                tbDisplay.Text = Convert.ToString(result);
            }
            else if (op == "-")
            {
                result = firstNumber - secondNumber;
                tbDisplay.Text = Convert.ToString(result);
            }
            else if (op == "x")
            {
                result = firstNumber * secondNumber;
                tbDisplay.Text = Convert.ToString(result);
            }
            else if (op == "/")
            {
                result = firstNumber / secondNumber;
                tbDisplay.Text = Convert.ToString(result);
            }
        }

        private void btnPoint_Click(object sender, RoutedEventArgs e)
        {
            if (opEntered && moreThanOneNumber == false)
            {
                secondNumber = Convert.ToDouble(",");
                moreThanOneNumber = true;
                tbDisplay.Text = Convert.ToString(secondNumber);
            }
            else if (opEntered && moreThanOneNumber == true)
            {
                secondNumber = Convert.ToDouble(string.Format("{0}{1}", secondNumber, ","));
                tbDisplay.Text = Convert.ToString(secondNumber);
            }
            if (opEntered == false && moreThanOneNumber == false)
            {
                firstNumber = Convert.ToDouble(",");
                moreThanOneNumber = true;
                tbDisplay.Text = Convert.ToString(firstNumber);
            }
            else if (opEntered == false && moreThanOneNumber == true)
            {
                firstNumber = Convert.ToDouble(string.Format("{0}{1}", firstNumber, ","));
                tbDisplay.Text = Convert.ToString(firstNumber);
            }
        }

        //Clear button resets all values and clears text box display
        private void btnCE_Click(object sender, RoutedEventArgs e)
        {
            moreThanOneNumber = false;
            opEntered = false;
            firstNumber = 0;
            secondNumber = 0;
            tbDisplay.Text = Convert.ToString(firstNumber);
        }

        //Method used to work the number buttons. It uses the if statement to find out a number of things:
        //If opEntered(operator has been entered) == true then it means we are using the secondNumber
        //If moreThanOneNumber == false then this is the first number button pressed (in either firstNumber or secondNumber
        //If moreThanOneNumber == true than it means we are concatonating another number to the existing number - i.e.
        //4 + 6 + 5 = 456 instead of 15   ***** I'M NOT SURE THIS IS NECESSARY, TEST REMOVING(moreThanOneNumber == false)
        public void NumberButtonPush(double number)
        {
            if (opEntered && moreThanOneNumber == false)
            {
                secondNumber = Convert.ToDouble(number);
                moreThanOneNumber = true;
                tbDisplay.Text = Convert.ToString(secondNumber);
            }
            else if (opEntered && moreThanOneNumber == true)
            {
                secondNumber = Convert.ToDouble(string.Format("{0}{1}", secondNumber, number));
                tbDisplay.Text = Convert.ToString(secondNumber);
            }
            if (opEntered == false && moreThanOneNumber == false)
            {
                firstNumber = Convert.ToDouble(number);
                moreThanOneNumber = true;
                tbDisplay.Text = Convert.ToString(firstNumber);
            }
            else if (opEntered == false && moreThanOneNumber == true)
            {
                firstNumber = Convert.ToDouble(string.Format("{0}{1}", firstNumber, number));
                tbDisplay.Text = Convert.ToString(firstNumber);
            }
        }
    }
}
