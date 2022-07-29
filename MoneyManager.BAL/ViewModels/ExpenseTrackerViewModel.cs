using System;

namespace MoneyManager.BAL.ViewModels
{
    public class ExpenseTrackerViewModel
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
