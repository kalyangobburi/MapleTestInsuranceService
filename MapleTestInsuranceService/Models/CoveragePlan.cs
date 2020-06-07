using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MapleTestInsuranceService.Models
{
    public class CoveragePlan
    {
        [Key]
        public long PlanId { get; set; }
        public string CoveragePlanName { get; set; }
        public DateTime? EligibilityDateFrom { get; set; }
        public DateTime? EligibilityDateTo { get; set; }
        public string EligibilityCountry { get; set; }
    }
}
