namespace DataDriven.Models.CRM.Settings
{
    using System.Collections.Generic;

    public class Partner
    {
        public string Number { get; set; } = string.Empty;

        public string TestName { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public List<string> EntryPoints { get; set; }
    }
}
