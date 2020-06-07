using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MapleTestInsuranceService.Data.Repository
{
    public interface IMasterDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
    }
}
