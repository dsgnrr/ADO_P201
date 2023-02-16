using ADO_P201.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public Entity.Manager? Manager;

        private ObservableCollection<Entity.Department> OwnerDepartments;
        public ManagerCrudWindow()
        {
            InitializeComponent();
            Manager = null;
            OwnerDepartments = null;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Owner is OrmWindow owner)
            {
                DataContext = Owner;
                OwnerDepartments = owner.Departments;
            }
            else
            {
                MessageBox.Show("Owner is not OrmWindow");
                Close();
            }

            if(this.Manager is null)
            {
                Manager = new Entity.Manager();
                CrudButtons.RowDefinitions.RemoveAt(1);
                CrudButtons.Children.Remove(DeleteButton);
            }
            else
            {
                SurnameView.Text = this.Manager.Surname;
                NameView.Text = this.Manager.Name;
                SecnameView.Text = this.Manager.Secname;
                MainDepComboBox.SelectedItem =
                    OwnerDepartments
                    .Where(d => d.Id == this.Manager.IdMainDep)
                    .First();
                SecDepComboBox.SelectedItem =
                    OwnerDepartments
                    .Where(d => d.Id == this.Manager.IdSecDep)
                    .FirstOrDefault();
            }
            IdView.Text = Manager.Id.ToString();
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
            this.DialogResult = false; // те що поверне ShowDialog
        }

        #endregion
    }
}
