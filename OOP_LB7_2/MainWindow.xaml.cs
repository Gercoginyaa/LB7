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
using OOP_LB7_2.Classes;

namespace OOP_LB7_2
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

        private MyMatrix myMatrix;

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (IsIntNumber(Rows.Text)==true && IsIntNumber(Collums.Text)==true)
            {
                myMatrix = new MyMatrix(Convert.ToInt32(Rows.Text), Convert.ToInt32(Collums.Text));

                //Вывод базовой матрицы
                BaseSize.Text = $"Размерность матрицы {myMatrix.Rows} x {myMatrix.Collums}";
                ShowBase.Text = myMatrix.GetBaseMatrix();

                //Создание произвольных матриц
                MyMatrix matrix1 = myMatrix.GetDerMatrix1();
                MyMatrix matrix2 = myMatrix.GetDerMatrix2();
                MyMatrix matrix3 = myMatrix.GetDerMatrix3();

                //Вывод произвольных матриц
                ShowDeriative1.Text = matrix1.GetBaseMatrix();
                DeriativeSize1.Text = $"Размерность матрицы {matrix1.Rows} x {matrix1.Collums}";

                ShowDeriative2.Text = matrix2.GetBaseMatrix();
                DeriativeSize2.Text = $"Размерность матрицы {matrix2.Rows} x {matrix2.Collums}";

                ShowDeriative3.Text = matrix3.GetBaseMatrix();
                DeriativeSize3.Text = $"Размерность матрицы {matrix3.Rows} x {matrix3.Collums}";
            }
            else
            {
                MessageBox.Show("Входные данные сожержат недопустимые символы");
            }
        }

        private bool IsIntNumber(string text)
        {
            bool result = true;

            char[] symbolsChars = text.ToCharArray();

            if (text == "")
            {
                result = false;
            }
            else
            {

                foreach (var i in symbolsChars)
                {
                    if (!Char.IsNumber(i))
                    {
                        result = false;
                        break;
                    }
                }
            }

            return result;
        }
    }
}
