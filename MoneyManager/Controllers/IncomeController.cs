using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoneyManager.BAL.Interfaces;
using MoneyManager.BAL.ViewModels;
using MoneyManager.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MoneyManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeController : ControllerBase
    {
        private readonly IIncomeSource _incomeBL;
        private readonly IMapper _mapper;
        private readonly MONEYMANAGERContext _dbcontext;

        public IncomeController(IIncomeSource incomeBL, IMapper mapper, MONEYMANAGERContext dbcontext)
        {
            _incomeBL = incomeBL;
            _mapper = mapper;
            _dbcontext = dbcontext;
        }

        [HttpGet]
        [Route("income-source")]
        public async Task<List<IncomeSourceMasterViewModel>> GetIncomeSources()
        {
            var result = await _incomeBL.GetIncomeSources();
            return result;


        }

        [HttpPost]
        [Route("update-income")]
        public async Task<BudgetMasterViewModel> UpdateIncomeDetails([FromBody] InsertUpdateIncomeDetailsViewModal incomeDetails)
        {
            var result = await _incomeBL.UpdateIncomeDetails(incomeDetails);
            return result;
        }
    }
}
