// <copyright file="EndpointsConstants.cs" company="MyCompany.com">
//       MyCompany.com. All rights reserved.
// </copyright>
// <summary>A sample project</summary>
// <author>Boyko Andonov</author>
namespace EndpointsTests
{
    /// <summary>
    /// Static class EndpointsConstants contains all Endpoints constants.
    /// </summary>
    public static class EndpointsConstants
    {
        /// <summary>
        /// BaseUrl - the base url to Library Manager api.
        /// </summary>
        public const string BaseUrl = "http://localhost:9000";

        /// <summary>
        /// BooksXlsxFilename - filename to data excel file.
        /// </summary>
        public const string BooksXlsxFilename = "Library.xlsx";

        /// <summary>
        /// PartialExcelPath - the partial path to API server.
        /// </summary>
        public const string PartialServerlPath = @"..\..\..\DataDriven\LibraryManager.exe";
    }
}
