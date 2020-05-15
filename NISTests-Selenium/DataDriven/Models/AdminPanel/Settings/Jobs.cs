using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDriven.Models.AdminPanel.Settings
{
    public class Jobs
    {
        public string Number { get; set; } = string.Empty;

        public string TestName { get; set; } = string.Empty;

        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Code { get; set; } = string.Empty;

        public string NPKDCode { get; set; } = string.Empty;

        public bool IsManager { get; set; } = false;
    }
}
