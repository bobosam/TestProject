// <copyright file="Book.cs" company="MyCompany.com">
//       MyCompany.com. All rights reserved.
// </copyright>
// <summary>A sample project</summary>
// <author>Boyko Andonov</author>
namespace DataDriven.Models
{
    /// <summary>
    /// Public class Book contains all books properties.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Gets or sets property contains the books Id.
        /// </summary>
        /// <value>Books Id - required.</value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets property contains the books title.
        /// </summary>
        /// <value>Books title - required.</value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets property contains the books description.
        /// </summary>
        /// <value>Books description - optional.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets property contains the books author.
        /// </summary>
        /// <value>Books author - required.</value>
        public string Author { get; set; }
    }
}
