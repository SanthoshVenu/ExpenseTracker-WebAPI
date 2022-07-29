using System;
using System.Collections.Generic;

#nullable disable

namespace MoneyManager.DAL.Models
{
    public partial class BudgetMaster
    {
        public int BudgetId { get; set; }
        public string BudgetName { get; set; }
        public int? TotalIncome { get; set; }
        public int? TotalExpenses { get; set; }
        public int? RemainingCash { get; set; }
        public string Month { get; set; }
        public int? Year { get; set; }
    }
}
