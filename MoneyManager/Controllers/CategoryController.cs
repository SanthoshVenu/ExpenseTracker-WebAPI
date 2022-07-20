using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoneyManager.BAL.Interfaces;
using MoneyManager.BAL.ViewModels;
using MoneyManager.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneyManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategories _categoryBL;
        private readonly ISubCategory _subcategoryBL;
        private readonly IAccount _accountBL;

        private readonly IMapper _mapper;

        public CategoryController(ICategories categoryBL, ISubCategory subcategoryBL, IAccount accountBL, IMapper mapper)
        {
            _categoryBL = categoryBL;
            _subcategoryBL = subcategoryBL;
            _accountBL = accountBL;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("category-data")]
        public async Task<List<CategoryMasterViewModel>> GetAllCategoryData()
        {
            var result = await _categoryBL.GetCategoriesData();
            return result;

        }

        [HttpGet]
        [Route("subcategory-data")]
        public async Task<List<SubCategoryMasterViewModel>> GetAllSubCategoryData()
        {
            var result = await _subcategoryBL.GetSubCategoryData();
            return result;

        }

        [HttpGet]
        [Route("subcategory-data/categoryid")]

        public async Task<string[]> GetSubCategoryByCategoryId(int id)
        {
            var result = await _subcategoryBL.GetSubCategoriesByCategoryId(id);
            return result;
        }

        [HttpGet]
        [Route("account-data")]
        public async Task<List<AccountMasterViewModel>> GetAllAccountData()
        {
            var result = await _accountBL.GetAccountsData();
            return result;

        }
    }
}
