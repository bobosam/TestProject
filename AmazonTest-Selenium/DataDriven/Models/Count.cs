// <copyright file="Count.cs" company="MyCompany.com">
//       MyCompany.com. All rights reserved.
// </copyright>
// <summary>A sample project for Endava</summary>
// <author>Boyko Andonov</author>

namespace DataDriven.Models
{
    /// <summary>
    /// Contains all count properties.
    /// </summary>
    public class Count
    {
        /// <summary>
        /// Gets or sets property contains test name for get data from excel.
        /// </summary>
        /// <value>The name of the test case.</value>
        public string TestName { get; set; }

        /// <summary>
        /// Gets or sets property contains string for purchased quantity.
        /// </summary>
        /// <value>The string for purchased quantity.</value>
        public string CurrentCount { get; set; }
    }
}
