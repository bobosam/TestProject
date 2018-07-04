using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace OldISSikuliTest
{
    public class Connecton
    {
        private static string connectionString = "Data Source=Invalid; Initial Catalog=Invalid; User Id=invalid; password=invalid";
        private static SqlConnection connection = new SqlConnection(connectionString);
        private static string select;
        private static SqlDataReader rd;

        public static string GetCountBySql(string sql)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand getData = new SqlCommand(sql, connection);
                    string data = getData.ExecuteScalar().ToString();

                    return data.ToString();
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public static void DeleteUser(string sql)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand deleteCommand = new SqlCommand(sql, connection);
                    deleteCommand.ExecuteNonQuery().ToString();
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
