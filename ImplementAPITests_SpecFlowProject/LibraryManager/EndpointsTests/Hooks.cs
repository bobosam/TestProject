// <copyright file="Hooks.cs" company="MyCompany.com">
//       MyCompany.com. All rights reserved.
// </copyright>
// <summary>A sample project</summary>
// <author>Boyko Andonov</author>
namespace EndpointsTests
{
    using System.Diagnostics;
    using System.IO;

    using DataDriven;
    using EndpointsTests.HelpMethods;
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    /// <summary>
    /// Public class Hooks contains all before and after test methods.
    /// </summary>
    [Binding]
    public sealed class Hooks
    {
        /// <summary>
        /// Initialize method. Restarting API server and clean DB.
        /// </summary>
        [BeforeScenario]
        public void BeforeScenario()
        {
            Process[] processes = Process.GetProcessesByName("LibraryManager");
            foreach (var process in processes)
            {
                process.Kill();
            }

            var directory = DataDrivenHelpMethods.GetDirectory();
            var path = Path.GetFullPath(Path.Combine(directory, EndpointsConstants.PartialServerlPath));
            System.Diagnostics.Process.Start(path);
            int currentCount = GetHelpMethods.ReturnAllBooksCount();

            Assert.AreEqual(0, currentCount);
        }
    }
}
