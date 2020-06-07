using MapleTestInsuranceService.Data.Repository;
using MapleTestInsuranceService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MapleTestInsuranceService.Data.DataManager
{
    public class CoveragePlanManager : IMasterDataRepository<CoveragePlan>
    {
        //readonly MapleInsuranceContext _mapleInsuranceContext;
        readonly MapleInsuranceContext _mapleInsuranceContext=new MapleInsuranceContext();
        public IEnumerable<CoveragePlan> GetAll()
        {
            try
            {
                return _mapleInsuranceContext.CoveragePlans.ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
