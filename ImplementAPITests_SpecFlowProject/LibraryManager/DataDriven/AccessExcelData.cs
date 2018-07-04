// <copyright file="AccessExcelData.cs" company="MyCompany.com">
//       MyCompany.com. All rights reserved.
// </copyright>
// <summary>A sample project</summary>
// <author>Boyko Andonov</author>
namespace DataDriven
{
    using System.Data.OleDb;
    using System.Linq;

    using Dapper;

    /// <summary>
    /// AccessExcelData contains all access to data methods.
    /// </summary>
    public class AccessExcelData
    {
        /// <summary>
        /// GetTestData takes all data from excel file by a parameter.
        /// </summary>
        /// <typeparam name="T">Generic type.</typeparam>
        /// <param name="keyName">Parameter name specifying the test case.</param>
        /// <param name="keyValue">Parameter value specifying the test case.</param>
        /// <param name="sheetName">Data sheet name.</param>
        /// <param name="fileName">Data file name.</param>
        /// <returns>Generic type value.</returns>
        public static T GetTestData<T>(string keyName, string keyValue, string sheetName, string fileName)
        {
            using (var connection = new OleDbConnection(DataDrivenHelpMethods.CreateDataConnectionStrng(fileName)))
            {
                connection.Open();

                var query = string.Format("select * from [{0}$] where {1} = '{2}'", sheetName, keyName, keyValue);
                var value = connection.Query<T>(query).FirstOrDefault();

                connection.Close();

                return value;
            }
        }
    }
}