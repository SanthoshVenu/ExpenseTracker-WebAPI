using System;
using System.Collections.Generic;

#nullable disable

namespace MoneyManager.DAL.Models
{
    public partial class IncomeDetail
    {
        public int Id { get; set; }
        public string IncomeSourceName { get; set; }
        public decimal? Amount { get; set; }
        public int? SourceId { get; set; }
        public string Month { get; set; }
        public int? Year { get; set; }

        public virtual IncomeSourceMaster Source { get; set; }
    }
}
