namespace AdminPanelUITests.Pages.OrganizationUnitPage
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class OrganizationUnitPage
    {
        public void AssertDepartments()
        {
            Assert.AreEqual("Маркетинг", this.Marketing.Text);
            Assert.AreEqual("Продажби", this.Sales.Text);
            Assert.AreEqual("IT", this.It.Text);
        }

        public void AssertUnitName(string name)
        {
            Assert.AreEqual(name, this.InputName.GetAttribute("value"));
        }
    }
}
