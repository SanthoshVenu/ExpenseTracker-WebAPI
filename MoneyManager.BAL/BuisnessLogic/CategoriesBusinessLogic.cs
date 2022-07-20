using AutoMapper;
using MoneyManager.BAL.Interfaces;
using MoneyManager.BAL.ViewModels;
using MoneyManager.DAL.Contracts;
using MoneyManager.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.BAL.BuisnessLogic
{
    public class CategoriesBusinessLogic : ICategories
    {
        private readonly IGenericRepository<CategoryMaster> _repository;
        private Mapper _mapper;
        public CategoriesBusinessLogic()
        {

        }
        public CategoriesBusinessLogic(IGenericRepository<CategoryMaster> repository)
        {
            _repository = repository;
            var config = new MapperConfiguration(config => config.CreateMap<CategoryMaster, CategoryMasterViewModel>());
            _mapper = new Mapper(config);
        }

        public async Task<List<CategoryMasterViewModel>> GetCategoriesData()
        {
            var categoryDataList = await _repository.GetAll();
            var result = _mapper.Map<List<CategoryMaster>, List<CategoryMasterViewModel>>(categoryDataList);
            return result;
        }

    }
}
