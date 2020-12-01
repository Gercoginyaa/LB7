using System;
using System.Collections;
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
using System.Linq;
using OOP_LB7_3.Classes;

namespace OOP_LB7_3.Dialog_boxes
{
    /// <summary>
    /// Логика взаимодействия для FindItemWindow.xaml
    /// </summary>
    public partial class FindItemWindow : Window
    {
        public FindItemWindow(MainWindow main)
        {
            InitializeComponent();
            this.main = main;
        }

        private MainWindow main;

        private void ButtonBaseFind_OnClick(object sender, RoutedEventArgs e)
        {
            string resultMessage = "";
            
            //Проверка суммы товара, для конфертации в гривну
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
                if (Char.IsSymbol(i) || Char.IsLetter(i))
                {
                    isdouble = false;
                    break;
                }
            }

            if (symbolcount > 1)
                isdouble = false;
            if (ProductPrice.Text == "")
                isdouble = false;

            if (isdouble == true)
            {
                ProductPrice.Text = Convert.ToDouble(ProductPrice.Text).ToString("C",CultureInfo.CurrentCulture);
            }

            //Список списков типа Article
            var myList = new List<IEnumerable<Article>>();

            //Список для вывода
            IEnumerable<Article> resultList = new List<Article>();
            
            //Заполнение списков, у которых есть совпадения с заданными параметрами поиска
            var indexResult =from t in main.mArticles
                where t.Index == ProductIndex.Text
                select t;
            if (indexResult.Any())
            {
                myList.Add(indexResult);
            }

            var shopResult = from t in main.mArticles
                where t.Store == ProductShop.Text
                select t;
            if (shopResult.Any())
                myList.Add(shopResult);

            var productResult = from t in main.mArticles
                where t.Product == ProductName.Text
                select t;
            if(productResult.Any())
                myList.Add(productResult);

            var priceResult = from t in main.mArticles
                where t.Price == ProductPrice.Text
                select t;
            if(priceResult.Any())
                myList.Add(priceResult);

            //Проверка на то, сколько было введено параметров поиска
            string[] input = { ProductPrice.Text,ProductName.Text,ProductIndex.Text,ProductShop.Text};
            int inputcount = 0;
            foreach (var i in input)
                if (i != "")
                    inputcount++;

            if (inputcount == myList.Count())
            {
                switch (myList.Count())
                {
                    case 4:
                        resultList = from i in myList[0]
                            from j in myList[1]
                            from k in myList[2]
                            from f in myList[3]
                            where i == j && j == k && k == f
                            select i;
                        break;
                    case 3:
                        resultList = from i in myList[0]
                            from j in myList[1]
                            from k in myList[2]
                            where i == j && j == k
                            select i;
                        break;
                    case 2:
                        resultList = from i in myList[0]
                            from j in myList[1]
                            where i == j
                            select i;
                        break;
                    case 1:
                        resultList = myList[0];
                        break;
                }
            }
            else
            {
                resultList = Array.Empty<Article>();
            }

            if (!resultList.Any())
            {
                MessageBox.Show("По заданным критериям ничего не обнаружено");
            }
            else
            {
                foreach (var i in resultList)
                {
                    resultMessage += $"Index: {i.Index}, Store; {i.Store}, Product: {i.Product}, Price: {i.Price}\n";
                }

                MessageBox.Show(resultMessage);
            }
        }
    }
}
