// <copyright file="Category.cs" company="MyCompany.com">
//       MyCompany.com. All rights reserved.
// </copyright>
// <summary>A sample project for Endava</summary>
// <author>Boyko Andonov</author>

namespace DataDriven.Models
{
    /// <summary>
    /// Contain all category properties.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Gets or sets property contains test name for get data from excel.
        /// </summary>
        /// <value>The name of the test case.</value>
        public string TestName { get; set; }

        /// <summary>
        /// Gets or sets property contains string for search category.
        /// </summary>
        /// <value>The string for search category.</value>
        public string CurrentCategory { get; set; }
    }
}
