namespace DataDriven.Models.CRM.Offer
{
    public class AutoOffer
    {
        public string Number { get; set; }

        public string TestName { get; set; }

        public string Pid { get; set; } = string.Empty;

        public bool IsForigner { get; set; } = false;

        public string RequestedPayment { get; set; } = string.Empty;

        public string RequestedLoanAmount { get; set; } = string.Empty;

        public string RequestedRate { get; set; } = string.Empty;

        public string TotalIncomes { get; set; } = string.Empty;

        public bool HasUnofficialIncomes { get; set; } = false;

        public string OtherIncomes { get; set; } = string.Empty;

        public string TotalDebts { get; set; } = string.Empty;

        public string TotalExpenses { get; set; } = string.Empty;

        public string CurrentJobTimeWorking { get; set; } = string.Empty;

        public string Age { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string SecondName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public bool InternalRefinancing { get; set; } = false;

        public string LoanNumberForRefinancing { get; set; } = string.Empty;

        public bool ExternalRefinancing { get; set; } = false;

        public string RemainingDebt { get; set; } = string.Empty;

        public string RemainingDebtPayment { get; set; } = string.Empty;
    }
}
