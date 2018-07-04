// <copyright file="Search.cs" company="MyCompany.com">
//       MyCompany.com. All rights reserved.
// </copyright>
// <summary>A sample project for Endava</summary>
// <author>Boyko Andonov</author>

namespace DataDriven.Models
{
    /// <summary>
    /// Search class contains all search properties.
    /// </summary>
    public class Search
    {
        /// <summary>
        /// Gets or sets property contains test name for get data from excel.
        /// </summary>
        /// <value>The name of the test case.</value>
        public string TestName { get; set; }

        /// <summary>
        /// Gets or sets property contains string for search items.
        /// </summary>
        /// <value>The string for search group.</value>
        public string SearchString { get; set; }
    }
}
