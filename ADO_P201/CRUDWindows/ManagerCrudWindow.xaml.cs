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
using System.Windows.Threading;

namespace ADO_P201.CRUDWindows
{
    /// <summary>
    /// Логика взаимодействия для ManagerCrudWindow.xaml
    /// </summary>
    public partial class ManagerCrudWindow : Window
    {
        public Entity.Manager? Manager;

        private ObservableCollection<Entity.Department> OwnerDepartments;

        private bool SaveButtonState;
        private bool inputWasChaged;
        private bool stringIsEmpty;
        private DispatcherTimer timer;
        public ManagerCrudWindow()
        {
            InitializeComponent();
            Manager = null;
            OwnerDepartments = null;
            BaseOptions();
        }
        private void BaseOptions()
        {
            SaveButtonState = true;
            inputWasChaged = false;
            stringIsEmpty = false;

            timer = new();
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += new EventHandler(CheckFields);
            timer.Start();
        }
        #region CONDITIONS
        private void CheckFields(object sender, EventArgs args)
        {
            if (NameView.Text == Manager.Name)
            {
                SaveButtonState = false;
                SaveButton.Background = Brushes.Gray;
                SaveButton.Foreground = Brushes.Black;
                ErrorText.Text = "*The text field contains the original value";
                inputWasChaged = false;
            }
            else
            {
                inputWasChaged = true;
                if (!stringIsEmpty)
                {
                    SaveButtonState = true;
                    SaveButton.Background = Brushes.DarkGreen;
                    SaveButton.Foreground = Brushes.White;
                }
            }

            if (NameView.Text.Trim() == String.Empty )
            {
                SaveButtonState = false;
                SaveButton.Background = Brushes.Gray;
                SaveButton.Foreground = Brushes.Black;
                ErrorText.Text = "*Field is empty or contains only spaces";
                stringIsEmpty = true;
            }
            else
            {
                stringIsEmpty = false;
                if (inputWasChaged)
                {
                    SaveButtonState = true;
                    SaveButton.Background = Brushes.DarkGreen;
                    SaveButton.Foreground = Brushes.White;
                }
            }
        }


        #endregion

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

                WindowName.Text = "CREATE PRODUCT";
                CrudButtons.ColumnDefinitions.RemoveAt(1);
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
                ChiefComboBox.SelectedItem =
                    (Owner as OrmWindow)?
                    .Managers
                    .FirstOrDefault(m => m.Id == this.Manager.IdChief);
            }
            IdView.Text = Manager.Id.ToString();
        }
        #region BUTTONS_EVENTS
        private void SaveButton_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!SaveButtonState)
            {
                ErrorText.Visibility = Visibility.Visible;
            }
        }
        private void SaveButton_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!SaveButtonState)
            {
                ErrorText.Visibility = Visibility.Hidden;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (SaveButtonState)
            {
                this.Manager.Surname = SurnameView.Text;
                this.Manager.Name = NameView.Text;
                this.Manager.Secname = SecnameView.Text;
                this.Manager.IdMainDep = 
                    (MainDepComboBox.SelectedItem as Entity.Department).Id;

                if (SecDepComboBox.SelectedItem is null)
                    this.Manager.IdSecDep = null;
                else if (SecDepComboBox.SelectedItem is Entity.Department secdep)
                    this.Manager.IdSecDep = secdep.Id;
                else MessageBox.Show("SecDepComboBox.SelectedItem CAST Error");

                if (ChiefComboBox.SelectedItem is null)
                    this.Manager.IdChief = null;
                else if (ChiefComboBox.SelectedItem is Entity.Manager manager)
                    this.Manager.IdChief = manager.Id;
                else MessageBox.Show("ChiefComboBox.SelectedItem CAST Error");

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
                this.DialogResult = true;
            }
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

        private void ClearSecDepButton_Click(object sender, RoutedEventArgs e)
        {
            SecDepComboBox.SelectedIndex = -1;
        }

        private void ClearChiefButton_Click(object sender, RoutedEventArgs e)
        {
            ChiefComboBox.SelectedItem = null;
        }
    }
}
