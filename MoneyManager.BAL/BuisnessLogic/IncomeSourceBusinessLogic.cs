using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MoneyManager.BAL.Interfaces;
using MoneyManager.BAL.ViewModels;
using MoneyManager.DAL.Contracts;
using MoneyManager.DAL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.BAL.BuisnessLogic
{
    public class IncomeSourceBusinessLogic : IIncomeSource
    {
        private readonly IGenericRepository<IncomeSourceMaster> _repository;
        private readonly IGenericRepository<BudgetMaster> _budgetrepository;
        private readonly MONEYMANAGERContext _dbcontext;
        private Mapper _mapper;

        public IncomeSourceBusinessLogic(IGenericRepository<IncomeSourceMaster> repository, MONEYMANAGERContext dbcontext, IGenericRepository<BudgetMaster> budgetrepository)
        {
            _repository = repository;
            _budgetrepository = budgetrepository;
            _dbcontext = dbcontext;
            var _config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<IncomeSourceMaster, IncomeSourceMasterViewModel>();
                cfg.CreateMap<BudgetMaster, BudgetMasterViewModel>();
            });
            _mapper = new Mapper(_config);
        }

        public IncomeSourceBusinessLogic()
        {

        }

        public Task<List<BudgetMasterViewModel>> AddNewBudget()
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<IncomeSourceMasterViewModel>> GetIncomeSources()
        {
            var incomeSources = await _repository.GetAll();
            var result = _mapper.Map<List<IncomeSourceMaster>, List<IncomeSourceMasterViewModel>>(incomeSources);
            return result;
        }

        public async Task<BudgetMasterViewModel> UpdateIncomeDetails(InsertUpdateIncomeDetailsViewModal incomeDetails)
        {
            BudgetMasterViewModel updatedBudgetTableData = new BudgetMasterViewModel();
            var result = await _dbcontext.Database.ExecuteSqlInterpolatedAsync($"EXEC mm.sp_Insert_Update_IncomeDetails @budgetName={incomeDetails.BudgetName},@incomeSourceName = {incomeDetails.IncomeSourceName},@sourceId={incomeDetails.SourceId} , @newIncome = {incomeDetails.NewIncome} , @currentExpenses = {incomeDetails.CurrentExpenses},@month = {incomeDetails.Month}, @year={incomeDetails.Year}");
            if (result == -1)
            {
                var allBudgetData = await _budgetrepository.GetAll();
                var modifiedBudgetData = allBudgetData.Where(x => x.Month == incomeDetails.Month && x.Year == incomeDetails.Year).FirstOrDefault();
                var outputBudgetData = _mapper.Map<BudgetMaster, BudgetMasterViewModel>(modifiedBudgetData);
                return outputBudgetData;

            }
            return updatedBudgetTableData;
        }

    }
}
