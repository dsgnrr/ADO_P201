using ADO_P201.Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Shapes;

namespace ADO_P201.CRUDWindows
{
    /// <summary>
    /// Логика взаимодействия для ManagerCrudWindow.xaml
    /// </summary>
    public partial class ManagerCrudWindow : Window
    {
        public ManagerCrudWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = Owner;
        }
        #region BUTTONS_EVENTS
        private void SaveButton_MouseEnter(object sender, MouseEventArgs e)
        {
            //if (!SaveButtonState)
            //{
            //    ErrorText.Visibility = Visibility.Visible;
            //}
        }
        private void SaveButton_MouseLeave(object sender, MouseEventArgs e)
        {
            //if (!SaveButtonState)
            //{
            //    ErrorText.Visibility = Visibility.Hidden;
            //}
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //if (SaveButtonState)
            //{
            //    Product.Name = NameView.Text;
            //    try
            //    {
            //        Product.Price = double.Parse(
            //            PriceView.Text.Replace(',', '.'),
            //            CultureInfo.InvariantCulture);
            //    }
            //    catch
            //    {
            //        MessageBox.Show("Неправильний формат числа для ціни");
            //        return;
            //    }
            //    this.DialogResult = true;
            //}
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            //var result = MessageBox.Show(
            //     $"Do you really want to remove: {Product.Name}",
            //     "Delete field",
            //     MessageBoxButton.YesNo,
            //     MessageBoxImage.Question);
            //if (result == MessageBoxResult.Yes)
            //{
            //    Product = null;
            //    this.DialogResult = true;
            //}
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            //this.DialogResult = false; // те що поверне ShowDialog
        }

        #endregion
    }
}
