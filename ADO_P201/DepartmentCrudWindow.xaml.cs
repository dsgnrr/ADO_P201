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

namespace ADO_P201
{
    public partial class DepartmentCrudWindow : Window
    {
        //Обмінне поле - передається з викликаючого вікна
        public Entity.Department Department { get; set; }
        public DepartmentCrudWindow()
        {
            InitializeComponent();
            Department = null;
        }
        public DepartmentCrudWindow(Entity.Department department)
        {
            InitializeComponent();
            DepartmentId.Text = "ID: " + department.Id.ToString();
            DepartmentName.Text = "Name: " + department.Name;
        }
    }
}
