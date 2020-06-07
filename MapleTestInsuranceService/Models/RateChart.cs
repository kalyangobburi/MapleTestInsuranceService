using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MapleTestInsuranceService.Models
{
    public class RateChart
    {
        [Key]
        public long Id { get; set; }
        public string CoveragePlanName { get; set; }
        public char CustomerGender { get; set; }
        public int CustomerAgeFrom { get; set; }
        public int CustomerAgeTo { get; set; }
        public double NetPrice { get; set; }
    }
}
