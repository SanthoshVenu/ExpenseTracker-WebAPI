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
    public class AccountBuisnessLogic : IAccount
    {
        private readonly IGenericRepository<AccountMaster> _repository;
        private Mapper _mapper;
        public AccountBuisnessLogic()
        {

        }
        public AccountBuisnessLogic(IGenericRepository<AccountMaster> repository)
        {
            _repository = repository;
            var config = new MapperConfiguration(config => config.CreateMap<AccountMaster, AccountMasterViewModel>());
            _mapper = new Mapper(config);
        }

        public async Task<List<AccountMasterViewModel>> GetAccountsData()
        {
            var accountDataList = await _repository.GetAll();
            var result = _mapper.Map<List<AccountMaster>, List<AccountMasterViewModel>>(accountDataList);
            return result;
        }
    }
}
