// <copyright file="Price.cs" company="MyCompany.com">
//       MyCompany.com. All rights reserved.
// </copyright>
// <summary>A sample project for Endava</summary>
// <author>Boyko Andonov</author>

namespace DataDriven.Models
{
    /// <summary>
    /// Price class contains all price properties.
    /// </summary>
    public class Price
    {
        /// <summary>
        /// Gets or sets property contains test name for get data from excel.
        /// </summary>
        /// <value>The name of the test case.</value>
        public string TestName { get; set; }

        /// <summary>
        /// Gets or sets property contains string for min price.
        /// </summary>
        /// <value>The string for min price.</value>
        public string MinPrice { get; set; }

        /// <summary>
        /// Gets or sets property contains string for max price.
        /// </summary>
        /// <value>The string for max price.</value>
        public string MaxPrice { get; set; }
    }
}
