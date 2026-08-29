using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace June2026.ConsoleApp3
{
    internal class DbService
    {
        private readonly SqlConnectionStringBuilder _connectionStringBuilder;

        public DbService(SqlConnectionStringBuilder connectionStringBuilder)
        {
            _connectionStringBuilder = connectionStringBuilder;
        }

        public DataTable Query(string query, List<SqlParameterDto>? parameters = null)
        {
            using SqlConnection connection = new(_connectionStringBuilder.ConnectionString);
            connection.Open();

            using SqlCommand cmd = new(query, connection);

            if (parameters != null)
            {
                foreach (var item in parameters)
                {
                    cmd.Parameters.AddWithValue(item.Name, item.Value);
                }
            }

            using SqlDataAdapter adapter = new(cmd);
            DataTable dt = new();
            adapter.Fill(dt);

            return dt;
        }

        public int Execute(string query, List<SqlParameterDto>? parameters = null)
        {
            using SqlConnection connection = new(_connectionStringBuilder.ConnectionString);
            connection.Open();

            using SqlCommand cmd = new(query, connection);

            if (parameters != null)
            {
                foreach (var item in parameters)
                {
                    cmd.Parameters.AddWithValue(item.Name, item.Value);
                }
            }

            return cmd.ExecuteNonQuery();
        }
    }

    public class SqlParameterDto
    {
        public string Name { get; set; }
        public object Value { get; set; }
    }
}
