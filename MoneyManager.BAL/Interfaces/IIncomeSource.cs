using MoneyManager.BAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.BAL.Interfaces
{
    public interface IIncomeSource
    {
        Task<List<IncomeSourceMasterViewModel>> GetIncomeSources();
        Task<BudgetMasterViewModel> UpdateIncomeDetails(InsertUpdateIncomeDetailsViewModal incomeDetails);
        Task<List<BudgetMasterViewModel>> AddNewBudget();

    }
}
