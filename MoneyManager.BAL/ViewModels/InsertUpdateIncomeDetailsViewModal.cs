using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.BAL.ViewModels
{
    public class InsertUpdateIncomeDetailsViewModal
    {
        public string BudgetName { get; set; }
        public string IncomeSourceName { get; set; }
        public int SourceId { get; set; }
        public decimal? NewIncome { get; set; }
        public decimal? CurrentExpenses { get; set; }
        public string Month { get; set; }
        public int Year { get; set; }
    }
}
