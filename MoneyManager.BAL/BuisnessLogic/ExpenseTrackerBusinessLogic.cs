using AutoMapper;
using MoneyManager.BAL.Interfaces;
using MoneyManager.BAL.ViewModels;
using MoneyManager.DAL.Contracts;
using MoneyManager.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneyManager.BAL.BuisnessLogic
{

    public class ExpenseTrackerBusinessLogic : IExpenseTracker
    {
        private readonly IGenericRepository<ExpenseTracker> _repository;
        private Mapper _mapper;

        public ExpenseTrackerBusinessLogic()
        {

        }
        public ExpenseTrackerBusinessLogic(IGenericRepository<ExpenseTracker> repository)
        {
            _repository = repository;
            var _config = new MapperConfiguration(cfg => cfg.CreateMap<ExpenseTracker, ExpenseTrackerViewModel>());
            _mapper = new Mapper(_config);
        }

        public async Task<List<ExpenseTrackerViewModel>> GetAllExpenseData()
        {
            var expenseDataList = await _repository.GetAll();
            var result = _mapper.Map<List<ExpenseTracker>, List<ExpenseTrackerViewModel>>(expenseDataList);
            return result;
        }

        public async Task<ExpenseTrackerViewModel> CreateData(ExpenseTracker expenseData)
        {
            var createdData = await _repository.Create(expenseData);
            var result = _mapper.Map<ExpenseTracker, ExpenseTrackerViewModel>(createdData);
            return result;
        }

    }
}