using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_P201.DAL
{
    internal class ManagerApi
    {
        private readonly SqlConnection _connection;
        public ManagerApi(SqlConnection connection)
        {
            _connection = connection;
            
        }
        public List<Entity.Manager> GetAll(bool includeDeleteDt = false)
        {
            var list = new List<Entity.Manager>();
            string query = @"SELECT M.*
                                FROM Managers M";
            if (!includeDeleteDt)
                query += " WHERE DeleteDt IS NULL";
            try
            {
                using SqlCommand cmd = new()
                {
                    Connection = _connection,
                    CommandText = query
                };

                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                    list.Add(new(reader));
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
            }
            return list;
        }

        public bool Add(Entity.Manager manager)
        {
            try
            {
                using SqlCommand cmd = new()
                {
                    Connection = _connection,
                    CommandText = @"INSERT INTO Managers(Id, Surname, Name, Secname, Id_main_dep, Id_sec_dep, Id_chief)
                                    VALUES(@id,@name);",

                };
                cmd.Parameters.AddWithValue("@id", manager.Id);
                cmd.Parameters.AddWithValue("@surname", manager.Surname);
                cmd.Parameters.AddWithValue("@name", manager.Name);
                cmd.Parameters.AddWithValue("@secname", manager.Secname);
                cmd.Parameters.AddWithValue("@IdMainDep", manager.IdMainDep);
                if (manager.IdSecDep != null)
                    cmd.Parameters.AddWithValue("@IdSecDep", manager.IdSecDep);
                else
                    cmd.Parameters.AddWithValue("@IdSecDep", DBNull.Value);

                if (manager.IdChief != null)
                    cmd.Parameters.AddWithValue("@IdChief", manager.IdChief);
                else
                    cmd.Parameters.AddWithValue("@IdChief", DBNull.Value);
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

    }
}
