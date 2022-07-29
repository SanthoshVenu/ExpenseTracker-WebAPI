using System;
using System.Collections.Generic;

#nullable disable

namespace MoneyManager.Models
{
    public partial class SubCategoryMaster
    {
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public int CategoryId { get; set; }

        public virtual CategoryMaster Category { get; set; }
    }
}
