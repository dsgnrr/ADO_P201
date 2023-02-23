using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace ADO_P201.DAL
{
    internal class DepartmentApi
    {
        private readonly SqlConnection _connection;
        public DepartmentApi(SqlConnection connection)
        {
            _connection = connection;
        }

        public bool Add(Entity.Department department)
        {
            try
            {
                using SqlCommand cmd = new()
                {
                    Connection = _connection,
                    CommandText = @"INSERT INTO Departments(Id, Name)
                                    VALUES(@id,@name);"
                };
                cmd.Parameters.AddWithValue("@id", department.Id);
                cmd.Parameters.AddWithValue("@Name", department.Name);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                String msg =
                    DateTime.Now + ": " +
                    this.GetType().Name +
                    System.Reflection.MethodBase.GetCurrentMethod()?.Name +
                    " " + ex.Message;

                // TODO: LOG
                App.Logger.Log(msg, "SEVERE");
                return false;
            }
            return true;
        }

        public List<Entity.Department> GetAll()
        {
            var list = new List<Entity.Department>();
            try
            {
                using SqlCommand cmd = new()
                {
                    Connection = _connection,
                    CommandText = @"SELECT D.*
                                    FROM Departments D 
                                    WHERE DeleteDt IS NULL"
                };
                
                using var reader = cmd.ExecuteReader();

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
                App.Logger.Log(msg, "SEVERE");
            }
            //reader.Close();
            //cmd.Dispose();
            return list;
        }
    }
}
