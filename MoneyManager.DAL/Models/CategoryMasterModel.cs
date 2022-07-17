using System;
using System.Collections.Generic;

#nullable disable

namespace MoneyManager.DAL.Models
{
    public partial class CategoryMasterModel
    {
        public CategoryMasterModel()
        {
            SubCategoryMasters = new HashSet<SubCategoryMasterModel>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<SubCategoryMasterModel> SubCategoryMasters { get; set; }
    }
}
