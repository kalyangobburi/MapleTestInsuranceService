using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MapleTestInsuranceService.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public char CustomerGender { get; set; }
        public string CustomerCountry { get; set; }
        public DateTime? CustomerDateOfBirth { get; set; }
        public DateTime? SaleDate { get; set; }
        public string CoveragePlan { get; set; }
        public double NetPrice { get; set; }
    }
}
