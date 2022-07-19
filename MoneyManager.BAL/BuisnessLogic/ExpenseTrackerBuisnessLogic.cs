using AutoMapper;
using MoneyManager.BAL.Interfaces;
using MoneyManager.BAL.ViewModels;
using MoneyManager.DAL.Contracts;
using MoneyManager.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneyManager.BAL.BuisnessLogic
{

    public class ExpenseTrackerBuisnessLogic : IExpenseTrackerBuisnessLogic
    {
        public dynamic mapper;
        private readonly IRepository<ExpenseTracker> _repository;
        private Mapper _mapper;

        public ExpenseTrackerBuisnessLogic()
        {

        }
        public ExpenseTrackerBuisnessLogic(IRepository<ExpenseTracker> repository)
        {
            _repository = repository;
            var _config = new MapperConfiguration(cfg => cfg.CreateMap<ExpenseTracker, ExpenseTrackerViewModel>());
            _mapper = new Mapper(_config);
            // CreateMap<ExpenseTrackerModel, ExpenseTrackerViewModel>();
            //CreateMap<ExpenseTrackerModel, ExpenseTrackerViewModel>()
            //    .ForMember(x => x.AccountNavigation, opt => opt.Ignore())
            //    .ForMember(x => x.CategoryNavigation, opt => opt.Ignore())
            //    .ForMember(x => x.SubCategoryNavigation, opt => opt.Ignore());
            // MapConfig();

        }

        //public void MapConfig()
        //{
        //    var config = new MapperConfiguration(cfg =>

        //      cfg.CreateMap<ExpenseTrackerModel, ExpenseTrackerViewModel>()

        //    );
        //    mapper = new Mapper(config);
        //}
        public async Task<List<ExpenseTrackerViewModel>> GetAllExpenseData()
        {
            var expenseDataList = await _repository.FindAll();
            var result = _mapper.Map<List<ExpenseTracker>, List<ExpenseTrackerViewModel>>(expenseDataList);
            return result;
        }

        public async Task<ExpenseTrackerViewModel> CreateData(ExpenseTracker expenseData)
        {
            //ExpenseTrackerModel newData = new ExpenseTrackerModel()
            //{
            //    Id = 1,
            //    Account="Cash",
            //    Category= "Household",

            //}
            var createdData = await _repository.Create(expenseData);
            var result = _mapper.Map<ExpenseTracker, ExpenseTrackerViewModel>(createdData);
            return result;

        }

    }
}