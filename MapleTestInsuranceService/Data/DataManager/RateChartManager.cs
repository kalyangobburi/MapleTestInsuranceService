using MapleTestInsuranceService.Data.Repository;
using MapleTestInsuranceService.Models;
using Microsoft.VisualStudio.Web.CodeGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MapleTestInsuranceService.Data.DataManager
{
    public class RateChartManager : IMasterDataRepository<RateChart>
    {
        //readonly MapleInsuranceContext mapleInsuranceContext;
        readonly MapleInsuranceContext mapleInsuranceContext=new MapleInsuranceContext();
        public IEnumerable<RateChart> GetAll()
        {
            try
            {
                return mapleInsuranceContext.RateCharts.ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
