namespace CRMUITests.Pages.Settings.IncomeTermTypePage
{
    using DataDriven.Models.CRM.Settings;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class IncomeTermTypePage
    {
        internal void AssertChanges(IncomeTermType incomeType)
        {
            this.GetResult(1);

            if (!incomeType.Name.Trim().Equals(string.Empty))
            {
                Assert.IsTrue(this.Name.GetAttribute("value").Equals(incomeType.Name), "Unsuccesfull Edit on field Name. Actual is: " + this.Name.GetAttribute("value").ToString() + "expected is: " + incomeType.Name);
            }

            if (!incomeType.Description.Trim().Equals(string.Empty))
            { 
                Assert.IsTrue(this.Description.GetAttribute("value").Equals(incomeType.Description), "Unsuccesfull Edit on field Description. Actual is: " + this.DisplayOrder.GetAttribute("value").ToString() + "expected is: " + incomeType.DisplayOrder);
            }

            if (!incomeType.Type.Trim().Equals(string.Empty))
            {
                Assert.IsTrue(this.Types.SelectedOption.GetAttribute("value").Equals(incomeType.Type), "Unsuccesfull Edit on field Group. Actual is: " + this.Types.SelectedOption.GetAttribute("value").ToString() + "expected is: " + incomeType.Type);
            }

            if (!incomeType.Code.Trim().Equals(string.Empty))
            {
                Assert.IsTrue(this.Code.GetAttribute("value").Equals(incomeType.Code), "Unsuccesfull Edit on field Code. Actual is: " + this.DisplayOrder.GetAttribute("value").ToString() + "expected is: " + incomeType.Code);
            }

            if (!incomeType.DisplayOrder.Trim().Equals(string.Empty))
            {
                Assert.IsTrue(this.DisplayOrder.GetAttribute("value").Equals(incomeType.DisplayOrder), "Unsuccesfull Edit on field DisplayOrder. Actual is: " + this.DisplayOrder.GetAttribute("value").ToString() + "expected is: " + incomeType.DisplayOrder);
            }
        }
    }
}
