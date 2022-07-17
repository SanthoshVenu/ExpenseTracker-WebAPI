using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MoneyManager.DAL.Contracts;
using MoneyManager.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.DAL.Repositories
{
    public class RepositoryMoneyManager <T> : IRepository<T> where T:class
    {
        private readonly DbSet<T> _dbset;
        private readonly MONEYMANAGERContext _moneyDbContext;
        private readonly ILogger _logger;
        public RepositoryMoneyManager(ILogger<T> logger, MONEYMANAGERContext moneyDbContext)
        {
            _logger = logger;
            _dbset = moneyDbContext.Set<T>();
            _moneyDbContext = moneyDbContext;
        }
        public async Task<T> Create(T _objExpenseData)
        {
            try
            {
                if(_objExpenseData != null)
                {
                    var obj = _dbset.Add(_objExpenseData);
                    await _moneyDbContext.SaveChangesAsync();
                    return obj.Entity;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       public void Delete(T _objExpenseData)
        {
            try
            {
                if(_objExpenseData != null)
                {
                    var obj = _dbset.Remove(_objExpenseData);
                    if(obj != null)
                    {
                        _moneyDbContext.SaveChangesAsync();
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

       public async Task<List<T>> FindAll()
        {
            try
            {
                var dataList =  _dbset.ToList();
                if (dataList != null) return  dataList;
                else return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

       public List<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            try
            {

                return _dbset.Where(predicate).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public T FindOne(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            try
            {

                return _dbset.FirstOrDefault(predicate);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public  void Update(T _objExpenseData)
        {
            try
            {
                if (_objExpenseData != null)
                {
                    var obj = _dbset.Update(_objExpenseData);
                    if (obj != null) _moneyDbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
