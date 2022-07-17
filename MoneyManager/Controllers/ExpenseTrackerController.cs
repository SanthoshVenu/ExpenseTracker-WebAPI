using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoneyManager.BAL.Interfaces;
using MoneyManager.BAL.ViewModels;
using MoneyManager.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
//using System.Web.Http;

namespace MoneyManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseTrackerController : ControllerBase
    {
        private readonly IExpenseTrackerBuisnessLogic _expenseTrackerBL;
        private readonly IMapper _mapper;

        public ExpenseTrackerController(IExpenseTrackerBuisnessLogic expenseTrackerBL, IMapper mapper)
        {
            _expenseTrackerBL = expenseTrackerBL;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("expenses-data")]
        public async Task<List<ExpenseTrackerViewModel>> GetAllExpenseData()
        {
           var result= await _expenseTrackerBL.GetAllExpenseData();
            return _mapper.Map<List<ExpenseTrackerViewModel>>(result);
   
        }

        [HttpPost]
        [Route("add-data")]

        public async Task<ExpenseTrackerViewModel> CreateNewData([FromBody] ExpenseTrackerModel expenseData)
        {
            var result = await _expenseTrackerBL.CreateData(expenseData);
            return _mapper.Map<ExpenseTrackerViewModel>(result);

        }
    }
}
