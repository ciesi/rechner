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

namespace rechner1._0
{/// <summary>
 /// Interaktionslogik für MainWindow.xaml
 /// </summary>
    public partial class MainWindow : Window
    {

        List<CalcElement> calcElements = new List<CalcElement>();
        List<int> inputNumbers = new List<int>();
        CalcElement calcElement = new CalcElement();

        public MainWindow()
        {
            InitializeComponent();

        }

        private void calcAndPushResult(string op = "")
        {
            // 1
            if (calcElement.number2 == null)
            {
                calcElement.number2 = createNumberFromDigits(inputNumbers);
                inputNumbers = new List<int>();
            }
            
            calcElements.Add(calcElement);

            // calc
            int returVal = 0;
            foreach (CalcElement tmpCalcElement in calcElements)
            {
                returVal = tmpCalcElement.chooseCalcMethod();
            }

            calcElements = new List<CalcElement>();

            // 2 
            calcElement = new CalcElement();
            calcElement.number1 = returVal;
            if (!String.IsNullOrEmpty(op))
                calcElement.op = op;
        }

        private int createNumberFromDigits(List<int> digits)
        {
            int returnVal = 0;

            foreach (int digit in digits)
            {
                returnVal = returnVal * 10 + digit;
                textBlock.Text = Convert.ToString(returnVal);
            }
            return returnVal;

        }


        private void btn_1_Click(object sender, RoutedEventArgs e)
        {
            inputNumbers.Add(1);

        }

        private void btn_2_Click(object sender, RoutedEventArgs e)
        {
            inputNumbers.Add(2);
        }

        private void btn_3_Click(object sender, RoutedEventArgs e)
        {
            inputNumbers.Add(3);
        }

        private void btn_gleich_Click(object sender, RoutedEventArgs e)
        {
            calcAndPushResult();

        }

        private void btn_plus_Click(object sender, RoutedEventArgs e)
        {

            calcElement.op = "+";

            if (calcElement.number1 == null)
            {
                calcElement.number1 = createNumberFromDigits(inputNumbers);
                inputNumbers = new List<int>();
            }
            else if (calcElement.number2 == null)
            {
                calcAndPushResult("+");
            }
            else
            {
                calcElements.Add(calcElement);
                calcElement = new CalcElement();
                
            }
        }

        private void btn_minus_Click(object sender, RoutedEventArgs e)
        {

            calcElement.op = "-";

            if (calcElement.number1 == null)
            {
                calcElement.number1 = createNumberFromDigits(inputNumbers);
                inputNumbers = new List<int>();
            }
            else if (calcElement.number2 == null)
            {
                calcAndPushResult("-");
            }
            else
            {
                calcElements.Add(calcElement);
                calcElement = new CalcElement();

            }

        }
    }
}
