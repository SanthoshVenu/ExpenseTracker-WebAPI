using System;
using System.Collections.Generic;

#nullable disable

namespace MoneyManager.Models
{
    public partial class CategoryMaster
    {
        public CategoryMaster()
        {
            SubCategoryMasters = new HashSet<SubCategoryMaster>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<SubCategoryMaster> SubCategoryMasters { get; set; }
    }
}
