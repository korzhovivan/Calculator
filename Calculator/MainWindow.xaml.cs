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

        bool dot = false;
        string currentStr = "";
        

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

        private void Devide_Click(object sender, RoutedEventArgs e)
        {
            txtBox_Top.Text = currentStr + " /";
            currentStr = "";
            dot = false;
            firstNum = currentNum;
            action = 1;
        }

        private void Multyply_Click(object sender, RoutedEventArgs e)
        {
            txtBox_Top.Text = currentStr + " *";
            currentStr = "";
            dot = false;
            firstNum = currentNum;
            action = 2;
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            txtBox_Top.Text = currentStr + " -";
            currentStr = "";
            dot = false;
            firstNum = currentNum;
            action = 3;
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            txtBox_Top.Text = currentStr + " -";
            currentStr = "";
            dot = false;
            firstNum = currentNum;
            action = 3;
        }

        private void Equally_Click(object sender, RoutedEventArgs e)
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
        }
    }
}
