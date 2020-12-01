using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using OOP_LB7_3.Classes;
using OOP_LB7_3.Dialog_boxes;
using OOP_LB7_3.Services;

namespace OOP_LB7_3
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

        public BindingList<Article> mArticles;
        private FIleIOService mIoService;

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            mIoService = new FIleIOService("jsondata.json");
            mArticles = mIoService.LoadData();
            dgStore.ItemsSource = mArticles;
        }

        private void MenuItemAdd_OnClick(object sender, RoutedEventArgs e)
        {
            AddItemWindow addItem = new AddItemWindow(this);
            addItem.Owner = this;
            addItem.Show();
        }

        private void MenuExit_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MainWindow_OnClosed(object sender, EventArgs e)
        {
            mIoService.SaveData(mArticles);
        }

        private void MenuItemFind_OnClick(object sender, RoutedEventArgs e)
        {
            FindItemWindow findItem = new FindItemWindow(this);
            findItem.Owner = this;
            findItem.Show();
        }
    }
}
