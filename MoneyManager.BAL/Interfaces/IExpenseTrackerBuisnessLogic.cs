using MoneyManager.BAL.ViewModels;
using MoneyManager.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.BAL.Interfaces
{
    public interface IExpenseTrackerBuisnessLogic
    {
        Task<List<ExpenseTrackerViewModel>> GetAllExpenseData();
        Task<ExpenseTrackerViewModel> CreateData(ExpenseTracker expenseData);
    }
}
