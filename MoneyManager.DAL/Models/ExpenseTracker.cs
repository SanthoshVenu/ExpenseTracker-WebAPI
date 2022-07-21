using System;
using System.Collections.Generic;

#nullable disable

namespace MoneyManager.DAL.Models
{
    public partial class ExpenseTracker
    {
        public int Id { get; set; }
        public string ExpenseName { get; set; }
        public string Account { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string IncomeExpenses { get; set; }
        public double? Cost { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }
        public bool? IsActive { get; set; }
    }
}
