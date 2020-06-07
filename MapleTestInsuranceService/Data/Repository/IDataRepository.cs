using MapleTestInsuranceService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MapleTestInsuranceService.Data.Repository
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(long id);
        TEntity Get(string name);
        void Add(TEntity entity);
        void Update(Customer customer, TEntity entity);
        void Delete(Customer customer);
    }
}
