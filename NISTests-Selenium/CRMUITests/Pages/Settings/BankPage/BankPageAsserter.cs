namespace CRMUITests.Pages.Settings.BankPage
{
    using DataDriven.Models.CRM.Settings;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class BankPage
    {
        internal void AssertChanges(Bank bank)
        {
            this.GetResult(1);

            if (!bank.Name.Trim().Equals(string.Empty))
            {
                Assert.IsTrue(this.Name.GetAttribute("value").Equals(bank.Name), "Unsuccesfull Edit on field Name. Actual is: " + this.Name.GetAttribute("value").ToString() + "expected is: " + bank.Name);
            }

            if (!bank.DisplayOrder.Trim().Equals(string.Empty))
            {
                Assert.IsTrue(this.DisplayOrder.GetAttribute("value").Equals(bank.DisplayOrder), "Unsuccesfull Edit on field DisplayOrder. Actual is: " + this.DisplayOrder.GetAttribute("value").ToString() + "expected is: " + bank.DisplayOrder);
            }
        }
    }
}
