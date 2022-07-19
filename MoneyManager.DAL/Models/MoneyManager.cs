using System;
using System.Collections.Generic;

#nullable disable

namespace MoneyManager.DAL.Models
{
    public partial class MoneyManager
    {
        public int ExpenseId { get; set; }
        public string UserName { get; set; }
        public string Account { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
        public string IncomeExpense { get; set; }
        public double? Cost { get; set; }
        public string Currency { get; set; }
        public string SpecificNotes { get; set; }
        public DateTime? Date { get; set; }
        public bool? IsActive { get; set; }
    }
}
