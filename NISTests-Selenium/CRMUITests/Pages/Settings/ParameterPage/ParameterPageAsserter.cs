namespace CRMUITests.Pages.Settings.ParameterPage
{
    using System;

    using DataDriven.Models.CRM.Settings;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class ParameterPage
    {
        /// <summary>
        /// Asserts no button Add exist on page Parameters.
        /// </summary>
        public void AssertNoAddExist()
        {
            bool cond = false;
            try
            {
                this.ClickAdd();
            }
            catch (Exception)
            {
                cond = true;
            }

            Assert.IsTrue(cond, "Button Add exist on Page Parameters");
        }

        /// <summary>
        /// Asserts no button Delete exist on page Parameters.
        /// </summary>
        public void AssertNoDeleteExist()
        {
            bool cond = false;
            try
            {
                this.ClickDelete();
            }
            catch (Exception)
            {
                cond = true;
            }

            Assert.IsTrue(cond, "Button Delete exist on Page Parameters");
        }

        /// <summary>
        /// Assert new data is saved succesfully.
        /// </summary>
        /// <param name="param"></param>
        internal void AssertChanges(Parameter param)
        {
            this.GetResult(1);

            if (!param.Value.Trim().Equals(string.Empty))
            {
                Assert.IsTrue(this.Value.GetAttribute("value").Equals(param.Value), "Unsuccesfull Edit on field Value. Actual is: " + this.Value.GetAttribute("value").ToString() + " expected is: " + param.Value);
            }

            if (!param.Description.Trim().Equals(string.Empty))
            {
                Assert.IsTrue(this.Description.GetAttribute("value").Equals(param.Description), "Unsuccesfull Edit on field Description. Actual is: " + this.Description.GetAttribute("value").ToString() + " expected is: " + param.Description);
            }
        }

        /// <summary>
        /// Asserts field are not editable thru UI.
        /// </summary>
        internal void AssertFieldsNotEditable()
        {
            Assert.IsFalse(CRMHelpMethods.IsEditable(this.Module), "Полето не трябва да може да се редактира: Модул");
            Assert.IsFalse(CRMHelpMethods.IsEditable(this.ParamType), "Полето не трябва да може да се редактира: Тип");
            Assert.IsFalse(CRMHelpMethods.IsEditable(this.ParamName), "Полето не трябва да може да се редактира: Име");
            Assert.IsFalse(CRMHelpMethods.IsEditable(this.Code), "Полето не трябва да може да се редактира: Код");
        }
    }
}
