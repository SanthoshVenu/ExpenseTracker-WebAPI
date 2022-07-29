using System;
using System.Collections.Generic;

#nullable disable

namespace MoneyManager.DAL.Models
{
    public partial class ExpenseTracker
    {
        public int Id { get; set; }
        public string ExpenseInfoId { get; set; }
        public string UserName { get; set; }
        public string ModeOfPayment { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public double? Cost { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
        public bool? IsFavourite { get; set; }
        public bool? IsActive { get; set; }
    }
}
