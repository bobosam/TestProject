// <copyright file="AccessExcelData.cs" company="MyCompany.com">
//       MyCompany.com. All rights reserved.
// </copyright>
// <summary>A sample project for Endava</summary>
// <author>Boyko Andonov</author>

namespace DataDriven
{
    using System.Data.OleDb;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    using Dapper;

    /// <summary>
    /// AccessExcelData class provide the selected data from excel file to the tests.
    /// </summary>
    public class AccessExcelData
    {
        /// <summary>
        /// A generic method that returns data from excel.
        /// </summary>
        /// <typeparam name="T">Generic type.</typeparam>
        /// <param name="keyName">Key for choose case.</param>
        /// <param name="keyValue">Key value for choose case.</param>
        /// <param name="sheetName">Excel sheet name.</param>
        /// <param name="fileName">Excel file name.</param>
        /// <returns>Selected data from excel.</returns>
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

        /// <summary>
        /// CreateDataConnectionStrng method gets current directory
        /// and creates a connection string.
        /// </summary>
        /// <param name="fileName">Excel file name.</param>
        /// <returns>Connection string.</returns>
        private static string CreateDataConnectionStrng(string fileName)
        {
            var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var path = Path.GetFullPath(Path.Combine(directory, @"..\..\..\DataDriven\DataDriven\" + fileName));
            var connectionString = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = {0}; Extended Properties=Excel 12.0;", path);

            return connectionString;
        }
    }
}
