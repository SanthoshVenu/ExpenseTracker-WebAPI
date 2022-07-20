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
    public class SubCategoriesBuisnessLogic : ISubCategory
    {
        private readonly IGenericRepository<SubCategoryMaster> _repository;
        private Mapper _mapper;
        public SubCategoriesBuisnessLogic()
        {

        }
        public SubCategoriesBuisnessLogic(IGenericRepository<SubCategoryMaster> repository)
        {
            _repository = repository;
            var config = new MapperConfiguration(config => config.CreateMap<SubCategoryMaster, SubCategoryMasterViewModel>());
            _mapper = new Mapper(config);
        }
        public async Task<List<SubCategoryMasterViewModel>> GetSubCategoryData()
        {
            var subcategoryDataList = await _repository.GetAll();
            var result = _mapper.Map<List<SubCategoryMaster>, List<SubCategoryMasterViewModel>>(subcategoryDataList);
            return result;
        }
        public async Task<string[]> GetSubCategoriesByCategoryId(int categoryId)
        {
            var allCategoryData = await _repository.GetAll();
            var subCategoryData = allCategoryData.Where(x => x.CategoryId == categoryId).Select(y => y.SubCategoryName).ToArray(); ;
            return subCategoryData;
        }
    }
}
