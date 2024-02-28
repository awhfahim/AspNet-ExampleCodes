using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public class AdoNetUtililty
    {
        private SqlConnection SqlConnection = new SqlConnection
            ("Data Source=.\\SQLEXPRESS;Initial Catalog=AspnetB9;User ID=aspnetb9; Password=123456;TrustServerCertificate=True;");
         

        public void Insert(string entityName, Dictionary<string, object> parameters)
        {
            var paramsName = new StringBuilder();
            var paramsNameWith = new StringBuilder();
            using SqlCommand command = new ();

            foreach (var parameter in parameters)
            {
                if (paramsName.Length > 0)
                {
                    paramsName.Append(",");
                    paramsNameWith.Append(",");
                }
                command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                paramsName.Append(parameter.Key);
                paramsNameWith.Append("@" + parameter.Key);
            }

            string cmdText = $"Insert into [{entityName}] ({paramsName}) values ({paramsNameWith});";
            command.CommandText = cmdText ;
            command.Connection = SqlConnection;
            if(command.Connection.State != System.Data.ConnectionState.Open)
                command.Connection.Open();

            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        public void Update(string entityName, Dictionary<string, object> parameters, object key) 
        {
            using SqlCommand command = new();
            StringBuilder cmdText = new();

            foreach(var parameter in parameters)
            {
                command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                if(cmdText.Length > 0) cmdText.Append(",");
                cmdText.Append($"{parameter.Key} = @{parameter.Key}");
            }

            string updateStatement = $"UPDATE [{entityName}] SET {cmdText} WHERE Id = '{key}'";
            command.CommandText = updateStatement;
            command.Connection = SqlConnection;
            if (command.Connection.State != System.Data.ConnectionState.Open)
                command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        public void DeleteById(string tableName, string name, object id)
        {
            using SqlCommand command = new();
            string deleteTxt = $"DELETE FROM [{tableName}] WHERE {name} = '{id}' ";
            command.CommandText = deleteTxt ;
            command.Connection = SqlConnection;
            if (command.Connection.State != System.Data.ConnectionState.Open)
                command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        public IList<(string columnName, object value)[]> GetById(string entityName, string name, object id)
        {
            using SqlCommand command = new();
            string getStatement = $"Select * from [{entityName}] where {name} = '{id}'";
            command.CommandText = getStatement;
            command.Connection = SqlConnection;
            if (command.Connection.State != System.Data.ConnectionState.Open)
                command.Connection.Open();

            var reader = command.ExecuteReader();

            List<(string, object)[]> data = new();

            while (reader.Read())
            {
                (string, object)[] row = new (string, object)[reader.FieldCount];

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    row[i] = (reader.GetName(i), reader.GetValue(i));
                }

                data.Add(row);
            }
            command.Connection.Close();
            return data;
        }

        public IList<(string columnName, object value)[]> GetAll(string tableName)
        {
            try
            {
                using SqlCommand command = new();
                string getSqlQuery = $"Select * from [{tableName}]";
                command.CommandText = getSqlQuery ;
                command.Connection = SqlConnection;
                if (command.Connection.State != System.Data.ConnectionState.Open)
                    command.Connection.Open();

                var reader = command.ExecuteReader();
            
                List<(string, object)[]> data = new();

                while (reader.Read())
                {
                    (string,object)[] row = new (string, object)[reader.FieldCount];

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        row[i] = (reader.GetName(i),reader.GetValue(i));
                    }

                    data.Add(row);
                }
                command.Connection.Close();
                return data;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        
        public IList<object> GetPrimaryKey(string tableName,string name,object id)
        {
            using SqlCommand command = new SqlCommand();
            string cmdText = $"Select Id from [{tableName}] where {name} = '{id}'";
            command.CommandText = cmdText ;
            command.Connection = SqlConnection;
            if(command.Connection.State!= System.Data.ConnectionState.Open)
               command.Connection.Open();

            try
            {
                var reader = command.ExecuteReader();

                List<object> data = new();

                while (reader.Read())
                {
                    object row = new object[reader.FieldCount];

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        row = reader.GetValue(i);
                    }

                    data.Add(row);
                }
                command.Connection.Close();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            
        }
    }
}

