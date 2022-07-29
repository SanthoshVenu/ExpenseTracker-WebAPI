using System;
using System.Collections.Generic;

#nullable disable

namespace MoneyManager.Models
{
    public partial class VwAllColumnsPrimarykey
    {
        public int? ExpenseId { get; set; }
        public int? AccountId { get; set; }
        public int? CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public int CurrencyId { get; set; }
    }
}
