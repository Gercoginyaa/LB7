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
using OOP_LB7.Classes;

namespace OOP_LB7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private BuildArray array;

        private void ArrayLength_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (ArrayLength.Text.Length == 0)
            {
                ArrayLength.Text = "1";
            }

            int length=1;
            char[] elements = ArrayLength.Text.ToCharArray();
            bool IsNumber = true;

            foreach (char i in elements)
            {
                if (!Char.IsNumber(i))
                {
                    MessageBox.Show("Длина массива содержит недопустимые символы");
                    IsNumber = false;
                    break;
                }
            }

            if (IsNumber == true)
            {
                length = Convert.ToInt32(ArrayLength.Text);
            }

            array = new BuildArray(length);
            ShowArray();
        }

        private void ShowArray()
        {
            ArrayContent.Text = "";
            foreach (var i in array.MyMas)
            {
                ArrayContent.Text += i.ToString()+", ";
            }

            Max.Text = array.MaxElement.ToString();
            Min.Text = array.MinElement.ToString();
            Average.Text = array.AverageOfMas.ToString();
            Sum.Text = array.SumOfMas.ToString();
            Odd.Text = "";
            foreach (int i in array.OddMas)
            {
                Odd.Text += i.ToString()+", ";
            }
        }

        private void Refresh_OnClick(object sender, RoutedEventArgs e)
        {
            array.FillArray();
            ShowArray();
        }
    }
}
