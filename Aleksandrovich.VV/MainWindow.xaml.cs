using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace Aleksandrovich.VV 
{
    public partial class MainWindow : Window
    {
        private string expression = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            expression += btn.Content.ToString();
            txtDisplay.Text = expression;
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            expression += btn.Content.ToString();
            txtDisplay.Text = expression;
        }

        private void Dot_Click(object sender, RoutedEventArgs e)
        {
            expression += ".";
            txtDisplay.Text = expression;
        }

        private void Bracket_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            expression += btn.Content.ToString();
            txtDisplay.Text = expression;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            expression = "";
            txtDisplay.Text = "0";
        }

        private string ProcessPower(string expr)
        {
            while (expr.Contains("^"))
            {
                int index = expr.IndexOf('^');

                int leftStart = index - 1;
                while (leftStart >= 0 && (char.IsDigit(expr[leftStart]) || expr[leftStart] == '.'))
                    leftStart--;
                leftStart++;
                string leftNum = expr.Substring(leftStart, index - leftStart);

                int rightEnd = index + 1;
                while (rightEnd < expr.Length && (char.IsDigit(expr[rightEnd]) || expr[rightEnd] == '.'))
                    rightEnd++;
                string rightNum = expr.Substring(index + 1, rightEnd - index - 1);

                double a = double.Parse(leftNum);
                double b = double.Parse(rightNum);
                double result = Math.Pow(a, b);

                expr = expr.Substring(0, leftStart) + result.ToString() + expr.Substring(rightEnd);
            }
            return expr;
        }

        private string ProcessBrackets(string expr)
        {
            while (expr.Contains("("))
            {
                int start = expr.LastIndexOf('(');
                int end = expr.IndexOf(')', start);
                if (end == -1) break;

                string subExpr = expr.Substring(start + 1, end - start - 1);
                string subResult = ProcessPower(subExpr);

                DataTable table = new DataTable();
                object result = table.Compute(subResult, "");

                expr = expr.Substring(0, start) + result.ToString() + expr.Substring(end + 1);
            }
            return expr;
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(expression))
                {
                    txtDisplay.Text = "0";
                    return;
                }
                if (Regex.IsMatch(expression, @"/0(?!\.)"))
                {
                    txtDisplay.Text = expression + "=Ошибка (деление на 0)";
                    expression = "";
                    return;
                }

                string computeExpr = ProcessBrackets(expression);
                computeExpr = ProcessPower(computeExpr);

                DataTable table = new DataTable();
                object result = table.Compute(computeExpr, "");

                txtDisplay.Text = expression + "=" + result.ToString();
                expression = result.ToString();
            }
            catch (DivideByZeroException)
            {
                txtDisplay.Text = expression + "=Ошибка (деление на 0)";
                expression = "";
            }
            catch
            {
                txtDisplay.Text = expression;
            }
        }
    }
}