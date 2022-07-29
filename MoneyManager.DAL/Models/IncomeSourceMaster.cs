using System;
using System.Collections.Generic;

#nullable disable

namespace MoneyManager.DAL.Models
{
    public partial class IncomeSourceMaster
    {
        public IncomeSourceMaster()
        {
            IncomeDetails = new HashSet<IncomeDetail>();
        }

        public int IncomeId { get; set; }
        public string IncomeSource { get; set; }

        public virtual ICollection<IncomeDetail> IncomeDetails { get; set; }
    }
}
