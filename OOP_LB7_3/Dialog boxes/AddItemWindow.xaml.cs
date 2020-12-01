using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using OOP_LB7_3.Classes;

namespace OOP_LB7_3.Dialog_boxes
{
    /// <summary>
    /// Логика взаимодействия для AddItemWindow.xaml
    /// </summary>
    public partial class AddItemWindow : Window
    {
        public AddItemWindow(MainWindow main)

        {
            InitializeComponent();
            this.main = main;
        }

        private MainWindow main;

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            int index = main.mArticles.Count + 1;

            if (ProductPrice.Text == "" || ProductName.Text == "" || Shop.Text == "")
            {
                MessageBox.Show("Одно из полей не содержит значения");
            }
            else
            {
                char[] symbols = ProductPrice.Text.ToCharArray();
                bool isdouble = true;
                int symbolcount = 0;
                foreach (var i in symbols)
                {
                    if (i == ',')
                    {
                        symbolcount++;
                        continue;
                    }

                    if (i == '.')
                    {
                        isdouble = false;
                        break;
                    }
                    if (Char.IsSymbol(i)||Char.IsLetter(i))
                    {
                        isdouble = false;
                        break;
                    }
                }

                if (symbolcount > 1)
                    isdouble = false;

                if (isdouble == false)
                {
                    MessageBox.Show("Поле цены сожержит недопустимые символы");
                }
                else
                {
                    main.mArticles.Add(new Article(ProductName.Text, Convert.ToDouble(ProductPrice.Text).ToString("C",CultureInfo.CurrentCulture), Shop.Text,
                        index.ToString()));
                    Close();
                }
            }
        }
    }
}
