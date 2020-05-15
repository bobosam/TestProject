namespace DataDriven
{
    using System.Collections.Generic;
    using System.Data.OleDb;
    using System.IO;
    using System.Linq;
    using Dapper;

    public class AccessExcelData
    {
        public static T GetTestData<T>(string keyName, string keyValue, string sheetName, string fileName)
        {
            using (var connection = new OleDbConnection(CreateDataConnectionStrng(fileName)))
            {
                connection.Open();

                var query = string.Format("select * from [{0}$] where {1} = '{2}'", sheetName, keyName, keyValue);
                var value = connection.Query<T>(query).FirstOrDefault();

                connection.Close();

                return value;
            }
        }

        public static List<string> GetAllKeys(string keyName, string sheetName, string fileName)
        {
            using (var connection = new OleDbConnection(CreateDataConnectionStrng(fileName)))
            {
                connection.Open();

                var query = string.Format("select {0} from [{1}$]", keyName, sheetName);
                var value = connection.Query<string>(query).ToList();

                connection.Close();

                return value;
            }
        }

        public static int GetTestsCount(string sheetName, string fileName)
        {
            int count = 0;

            string sqlString = string.Format("select count(*) from [{0}$]", sheetName);
            using (OleDbConnection conn = new OleDbConnection(CreateDataConnectionStrng(fileName)))
            {
                using (OleDbCommand command = new OleDbCommand(sqlString, conn))
                {
                    conn.Open();
                    count = (int)command.ExecuteScalar();
                }
            }

            return count;
        }

        private static string CreateDataConnectionStrng(string fileName)
        {
            var directory = HelpMethods.GetDirectory();
            var path = Path.GetFullPath(Path.Combine(directory, @"..\..\DataDriven\\DataDrivenTests\" + fileName));
            var connectionString = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = {0}; Extended Properties=Excel 12.0;", path);

            return connectionString;
        }
    }
}
