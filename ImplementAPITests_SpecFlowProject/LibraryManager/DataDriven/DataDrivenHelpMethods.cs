// <copyright file="DataDrivenHelpMethods.cs" company="MyCompany.com">
//       MyCompany.com. All rights reserved.
// </copyright>
// <summary>A sample project</summary>
// <author>Boyko Andonov</author>
namespace DataDriven
{
    using System.IO;
    using System.Reflection;

    /// <summary>
    /// Public class DataDrivenHelpMethods contains all DataDriven help methods.
    /// </summary>
    public class DataDrivenHelpMethods
    {
        /// <summary>
        /// Read directory path of executing assembly file.
        /// </summary>
        /// <returns>Directory path.</returns>
        public static string GetDirectory()
        {
            var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            return directory;
        }

        /// <summary>
        /// Gets full path to the data file and create the connection string.
        /// </summary>
        /// <param name="fileName">Data file name.</param>
        /// <returns>Connection string.</returns>
        public static string CreateDataConnectionStrng(string fileName)
        {
            var directory = DataDrivenHelpMethods.GetDirectory();
            var path = Path.GetFullPath(Path.Combine(directory, Constants.PartialExcelPath + fileName));
            var connectionString = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = {0}; Extended Properties=Excel 12.0;", path);

            return connectionString;
        }
    }
}
