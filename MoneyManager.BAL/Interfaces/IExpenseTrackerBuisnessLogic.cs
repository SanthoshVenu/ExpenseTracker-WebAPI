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
        Task<List<ExpenseTrackerModel>> GetAllExpenseData();
        Task<ExpenseTrackerModel> CreateData(ExpenseTrackerModel expenseData);
    }
}
