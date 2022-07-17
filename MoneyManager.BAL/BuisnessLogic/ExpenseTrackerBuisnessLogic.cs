using MoneyManager.BAL.Interfaces;
using MoneyManager.BAL.ViewModels;
using MoneyManager.DAL.Contracts;
using MoneyManager.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

namespace MoneyManager.BAL.BuisnessLogic
{
    public class ExpenseTrackerBuisnessLogic : Profile, IExpenseTrackerBuisnessLogic
    {
        private readonly IRepository<ExpenseTrackerModel> _repository;

        public ExpenseTrackerBuisnessLogic()
        {

        }
        public ExpenseTrackerBuisnessLogic(IRepository<ExpenseTrackerModel> repository)
        {
            _repository = repository;

            //CreateMap<ExpenseTrackerModel, ExpenseTrackerViewModel>()
            //    .ForMember(x => x.AccountNavigation, opt => opt.Ignore())
            //    .ForMember(x => x.CategoryNavigation, opt => opt.Ignore())
            //    .ForMember(x => x.SubCategoryNavigation, opt => opt.Ignore());
        }

 
        public async Task<List<ExpenseTrackerModel>> GetAllExpenseData()
        {
          List<ExpenseTrackerModel> expenseDataList = new List<ExpenseTrackerModel>();
            expenseDataList = await _repository.FindAll();
            return expenseDataList;
        }

        public async Task<ExpenseTrackerModel> CreateData(ExpenseTrackerModel expenseData)
        {
            //ExpenseTrackerModel newData = new ExpenseTrackerModel()
            //{
            //    Id = 1,
            //    Account="Cash",
            //    Category= "Household",

            //}
           return await _repository.Create(expenseData);

        }

    }
}
