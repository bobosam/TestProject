namespace CRMUITests.Pages.Applicaton.AddressPage
{
    using DataDriven.Models.CRM.Applicaton;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class AddressPage
    {
        public void AssertForIndenticalAddres()
        {
            Assert.AreEqual(this.IdenticalAddressesRadioButton.GetAttribute("class"), "ui-radiobutton-box ui-widget ui-state-default ui-state-active");
            Assert.AreEqual(this.DifferentAddressesRadioButton.GetAttribute("class"), "ui-radiobutton-box ui-widget ui-state-default");
        }

        public void AssertForDifferentAddres()
        {
            Assert.AreEqual(this.IdenticalAddressesRadioButton.GetAttribute("class"), "ui-radiobutton-box ui-widget ui-state-default");
            Assert.AreEqual(this.DifferentAddressesRadioButton.GetAttribute("class"), "ui-radiobutton-box ui-widget ui-state-default ui-state-active");
        }

        public void AssertForNotIndenticalAddres()
        {
            Assert.AreEqual(this.IdenticalAddressesRadioButton.GetAttribute("class"), "ui-radiobutton-box ui-widget ui-state-default");
            Assert.AreEqual(this.DifferentAddressesRadioButton.GetAttribute("class"), "ui-radiobutton-box ui-widget ui-state-default ui-state-active");
            Assert.AreEqual(this.NotIdenticalAddressesRadioButton.GetAttribute("class"), "ui-radiobutton-box ui-widget ui-state-default");
        }

        public void AssertCountMissingData(int count)
        {
            Assert.AreEqual(count, this.AlertMissingData.Count);
        }

        public void AssertAutoFieldsData(Address address, int index)
        {
            var region = this.Regions[index].GetAttribute("value");
            var area = this.Areas[index].GetAttribute("value");
            var zip = this.Zips[index].GetAttribute("value");

            Assert.IsTrue(region == address.Region);
            Assert.IsTrue(area == address.Area);
            Assert.IsTrue(zip == address.Zip);
        }
    }
}
