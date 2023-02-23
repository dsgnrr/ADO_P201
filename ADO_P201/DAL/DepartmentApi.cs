using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ADO_P201.DAL
{
    internal class DepartmentApi
    {
        private readonly SqlConnection _connection;
        public DepartmentApi(SqlConnection connection)
        {
            _connection = connection;
        }

        public List<Entity.Department> GetAll()
        {
            var list = new List<Entity.Department>();
            try
            {
                using SqlCommand cmd = new()
                {
                    Connection = _connection,
                    CommandText = @"SELECT S.*
                                    FROM Sales S 
                                    WHERE DeleteDt IS NULL"
                };
                
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                    list.Add(new(reader));
            }
            catch(Exception ex)
            {
                String msg =
                    DateTime.Now + ": " +
                    this.GetType().Name +
                    System.Reflection.MethodBase.GetCurrentMethod()?.Name +
                    " " + ex.Message;
                
                // TODO: LOG
                MessageBox.Show(msg);
            }
            //reader.Close();
            //cmd.Dispose();
            return list;
        }
    }
}
