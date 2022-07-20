using MoneyManager.BAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.BAL.Interfaces
{
    public interface IAccount
    {
        Task<List<AccountMasterViewModel>> GetAccountsData();
    }
}
