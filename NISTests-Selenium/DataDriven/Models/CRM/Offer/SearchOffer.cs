using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDriven.Models.CRM.Offer
{
    public class SearchOffer
    {
        public string Number { get; set; }

        public string TestName { get; set; }

        public string State { get; set; } = string.Empty;

        public string FromDate { get; set; } = string.Empty;

        public string Todate { get; set; } = string.Empty;

        public string SearchField { get; set; } = string.Empty;

        public string HasRefinancing { get; set; } = string.Empty;

        public string HasCodebtor { get; set; } = string.Empty;

        public string SearchFieldAdvanced { get; set; } = string.Empty;

        public string Region { get; set; } = string.Empty;

        public string Area { get; set; } = string.Empty;

        public string SubArea { get; set; } = string.Empty;
    }
}
