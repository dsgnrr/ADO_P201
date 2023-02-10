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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ADO_P201
{
    /// <summary>
    /// Логика взаимодействия для NewDepartmentWindow.xaml
    /// </summary>
    public partial class NewDepartmentWindow : Window
    {
        public Entity.Department Department { get; set; }

        private DispatcherTimer timer;

        private bool SaveButtonState;
        private bool stringIsFilled;
        public NewDepartmentWindow()
        {
            InitializeComponent();
            Department = null;
            SaveButtonState = true;
            stringIsFilled = false;

            timer = new();
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += new EventHandler(CheckNameField);
            timer.Start();
        }


        #region CONDITIONS
        private void CheckNameField(object sender, EventArgs args)
        {
            if (NameView.Text.Trim() == String.Empty || IdView.Text == String.Empty) 
            {
                SaveButtonState = false;
                SaveButton.Background = Brushes.Gray;
                SaveButton.Foreground = Brushes.Black;
                ErrorText.Text = "*Field's is empty or contains only spaces";
                stringIsFilled = false;
            }
            else
            {
                stringIsFilled = true;
                SaveButtonState = true;
                SaveButton.Background = Brushes.DarkGreen;
                SaveButton.Foreground = Brushes.White;
            }
        }
        #endregion

        private void generateIdButton_Click(object sender, RoutedEventArgs e)
        {
            IdView.Text = Guid.NewGuid().ToString();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if(stringIsFilled)
            {
                Department.Id = Guid.Parse(IdView.Text);
                Department.Name = NameView.Text;
                DialogResult = true;
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Department = null;
            this.DialogResult = false;
        }

        private void SaveButton_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!SaveButtonState)
                ErrorText.Visibility = Visibility.Visible;
        }
        private void SaveButton_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!SaveButtonState)
                ErrorText.Visibility = Visibility.Hidden;
        }

        private void Window_Closed(object sender, EventArgs e)
        {

        }
    }
}
