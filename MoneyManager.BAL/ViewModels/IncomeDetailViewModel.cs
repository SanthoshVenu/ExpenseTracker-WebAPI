using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.BAL.ViewModels
{
    public class IncomeDetailViewModel
    {
        public int Id { get; set; }
        public int? Income { get; set; }
        public string IncomeSourceName { get; set; }
        public int? SourceId { get; set; }
        public string Month { get; set; }
        public int? Year { get; set; }
    }
}
