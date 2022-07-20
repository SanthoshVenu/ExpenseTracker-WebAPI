using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.BAL.ViewModels
{
    public class ExpenseTrackerViewModel
    {
        public int? Id { get; set; }
        public string Account { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string IncomeExpenses { get; set; }
        public string Cost { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }
        public bool? IsActive { get; set; }
    }
}
