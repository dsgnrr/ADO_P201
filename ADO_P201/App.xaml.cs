using ADO_P201.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ADO_P201
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //public static readonly String ConnectionString = @"
        //    Data Source=(LocalDB)\MSSQLLocalDB;
        //    AttachDbFilename=C:\Users\Seme_i7uf\Documents\GitHub\ADO_P201\ADO_P201\ADO201.mdf;
        //    Integrated Security=True";
        public static readonly String ConnectionString = @"
            Data Source=(LocalDB)\MSSQLLocalDB;
            AttachDbFilename=C:\Users\dsgnrr\source\repos\ADO_P201\ADO_P201\DataBase\ADO201.mdf;
            Integrated Security=True";
        internal static readonly Logger Logger = new("log.txt");
    }
}
