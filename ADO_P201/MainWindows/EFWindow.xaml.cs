using ADO_P201.EFCore;
using Microsoft.EntityFrameworkCore;
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

namespace ADO_P201.MainWindows
{
    /// <summary>
    /// Логика взаимодействия для EFWindow.xaml
    /// </summary>
    public partial class EFWindow : Window
    {
        internal EfContext efContext { get; set; } = new();
        public EFWindow()
        {
            InitializeComponent();
            this.DataContext = efContext;
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateMonitor();
            efContext.Departments.Load();
            depList.ItemsSource = efContext
                .Departments
                .Local
                .ToObservableCollection();
        }
        
        public void UpdateMonitor()
        {
            MonitorBlock.Text = "Departments: " +
                efContext.Departments.Count().ToString();
            MonitorBlock.Text += "\nProducts: " +
                efContext.Products.Count().ToString();
            MonitorBlock.Text += "\nManagers: " +
                efContext.Managers.Count().ToString();
            MonitorBlock.Text += "\nSales: " +
                efContext.Sales.Count().ToString();


        }

        private void AddDepartmentButton_Click(object sender, RoutedEventArgs e)
        {
            DepartmentCrudWindow dialog = new();
            if(dialog.ShowDialog()==true)
            {
                //dialog.Department -- інша сутність, треба замінити під EF
                efContext.Departments.Add(
                    new Department()
                    {
                        Name = dialog.Department.Name,
                        Id = dialog.Department.Id
                    }
                    );
                // !! Додавання даних до контексту не додає їх до БД -- планування додавання
                efContext.SaveChanges(); // внесення змін до БД

                MonitorBlock.Text += "\nDepartments: " +
                    efContext.Departments.Count().ToString();
            }
        }
    }
}
