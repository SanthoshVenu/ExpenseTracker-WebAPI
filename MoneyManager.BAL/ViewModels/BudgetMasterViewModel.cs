using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.BAL.ViewModels
{
    public class BudgetMasterViewModel
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
