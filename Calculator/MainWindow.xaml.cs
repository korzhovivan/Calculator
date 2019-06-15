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

        double currentNum = 0;
        double firstNum = 0;

        int action;

        string currentStr = "";

        bool first_ation = false;
        bool dot = false;
        bool NoDouble_Equall = false;
        bool NoDouble_Action = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = e.OriginalSource as Button;

            currentStr += btn.Content;

            txtBox_Value.Text = currentStr;
            currentNum = Convert.ToDouble(currentStr);
            NoDouble_Action = false;
        }

        private void Dot_Click(object sender, RoutedEventArgs e)
        {
            if (!dot)
            {
                currentStr += ",";
                txtBox_Value.Text += ",";
                dot = true;
            }
        }

        private void Equally_Click(object sender, RoutedEventArgs e)
        {
            if (NoDouble_Equall)
            {
                txtBox_Top.Text = "";

                switch (action)
                {
                    case 1: currentNum = firstNum / currentNum; break;
                    case 2: currentNum = firstNum * currentNum; break;
                    case 3: currentNum = firstNum - currentNum; break;
                    case 4: currentNum = firstNum + currentNum; break;
                }
                txtBox_Value.Text = currentNum.ToString();
                currentStr = currentNum.ToString();
                first_ation = false;
                NoDouble_Equall = false;
                NoDouble_Action = false;
                action = 0;
                firstNum = 0;
            }
        }

        private void Do_Action(object sender, RoutedEventArgs e)
        {
           
            if (!NoDouble_Action)
            {
                Button btn = e.OriginalSource as Button;
                txtBox_Top.Text += currentNum.ToString() + " " + btn.Content;
                if (!first_ation)
                {
                    firstNum = Convert.ToDouble(currentStr);

                }
                else
                {
                    switch (action)
                    {
                        case 1: currentNum = firstNum / currentNum; break;
                        case 2: currentNum = firstNum * currentNum; break;
                        case 3: currentNum = firstNum - currentNum; break;
                        case 4: currentNum = firstNum + currentNum; break;
                    }
                    firstNum = currentNum;
                }

                switch (btn.Content)
                {
                    case "/": action = 1; break;
                    case "*": action = 2; break;
                    case "-": action = 3; break;
                    case "+": action = 4; break;
                }

                currentStr = "";
                dot = false;
                first_ation = true;

                NoDouble_Equall = true;
                NoDouble_Action = true;

                txtBox_Value.Text = firstNum.ToString();
            }
            
        }

        private void Clear_СE(object sender, RoutedEventArgs e)
        {
            currentStr = "";
            currentNum = 0;
            txtBox_Value.Text = "";
            NoDouble_Action = true;
        }

        private void Clear_С(object sender, RoutedEventArgs e)
        {
            currentStr = "";
            currentNum = 0;
            txtBox_Top.Text = "";
            txtBox_Value.Text = "";
            first_ation = false;
            dot = false;
        }

        private void DelLast_Click(object sender, RoutedEventArgs e)
        {
            string str = txtBox_Value.Text;
            if (str.Length <=1)
            {
                currentNum = 0;
                txtBox_Value.Text = "";
            }
            else
            {
                str = str.Remove(str.Length - 1);
                currentNum = Convert.ToDouble(str);
                txtBox_Value.Text = str.ToString();
            }
            
        }
    }
}
