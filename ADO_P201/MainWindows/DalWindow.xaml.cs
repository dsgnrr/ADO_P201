using ADO_P201.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ADO_P201.MainWindows
{
    public partial class DalWindow : Window
    {
        private readonly DataContext dataContext;
      
        public ObservableCollection<Entity.Department> DepartmentsList { get; set; }
       
        public DalWindow()
        {
            InitializeComponent();
            dataContext = new();
            DepartmentsList = new(dataContext.Departments.GetAll());
            this.DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(dataContext.Departments.GetAll().Count.ToString());
        }

        private void DepartmentsItems_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(sender is ListViewItem item)
            {
                if(item.Content is Entity.Department department)
                {
                    MessageBox.Show(department.ToString());
                }
            }
        }

        private void AddDepartmentButton_Click(object sender, RoutedEventArgs e)
        {
            DepartmentCrudWindow dialog = new();

            if(dialog.ShowDialog()==true)
            {
                if(dataContext.Departments.Add(dialog.Department))
                {
                    MessageBox.Show("Додано успішно");
                    DepartmentsList.Add(dialog.Department);
                }
                else
                    MessageBox.Show("Помилка додавання");
            }
        }
    }
}
