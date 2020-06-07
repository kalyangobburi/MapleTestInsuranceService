using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MapleTestInsuranceService.Data.Repository;
using MapleTestInsuranceService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MapleTestInsuranceService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IDataRepository<Customer> _dataRepository;
        private readonly IMasterDataRepository<CoveragePlan> _coverageDataRepository;
        private readonly IMasterDataRepository<RateChart> _rateChartDataRepository;
        
        public CustomersController(IDataRepository<Customer> dataRepository,IMasterDataRepository<CoveragePlan> coverageDataRepository,IMasterDataRepository<RateChart> rateChartDataRepository)
        {
            _dataRepository = dataRepository;
            _coverageDataRepository = coverageDataRepository;
            _rateChartDataRepository = rateChartDataRepository;
        }

        [HttpGet(Name ="GetCustomers")]
        //[Route("GetCustomers")]
        public IActionResult GetCustomers()
        {
            try
            {
                IEnumerable<Customer> customers = _dataRepository.GetAll();
                return Ok(customers);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}", Name = "Get")]
        //[HttpGet]
        //[Route("Get/{id}")]
        public IActionResult Get(long id)
        {
            try
            {
                Customer customer = _dataRepository.Get(id);

                if (customer == null)
                {
                    return NotFound("The Customer record couldn't be found.");
                }

                return Ok(customer);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost(Name ="SaveCustomer")]
        //[Route("SaveCustomer")]
        public IActionResult SaveCustomer([FromBody] Customer customer)
        {
            try
            {
                if (customer == null)
                {
                    return BadRequest("Customer is null.");
                }
                CoveragePlan cPlan = null;
                if (!string.IsNullOrEmpty(customer.CustomerCountry))
                {
                    if ((customer.CustomerCountry.ToLower() == "usa") || (customer.CustomerCountry.ToLower() == "can"))
                        cPlan = _coverageDataRepository.GetAll().Where(cp => (cp.EligibilityCountry == customer.CustomerCountry) && (customer.SaleDate >= cp.EligibilityDateFrom) && (customer.SaleDate <= cp.EligibilityDateTo)).FirstOrDefault();
                    else
                        cPlan = _coverageDataRepository.GetAll().Where(cp => (cp.EligibilityCountry.ToLower() == "other") && (customer.SaleDate >= cp.EligibilityDateFrom) && (customer.SaleDate <= cp.EligibilityDateTo)).FirstOrDefault();
                }
                if (cPlan != null)
                {
                    customer.CoveragePlan = cPlan.CoveragePlanName;
                    int customerage = (int)(DateTime.UtcNow - customer.CustomerDateOfBirth).Value.TotalDays / 365;
                    RateChart rc = _rateChartDataRepository.GetAll().Where(rc => (rc.CustomerGender == customer.CustomerGender) && (rc.CustomerAgeFrom <= customerage) && (rc.CustomerAgeTo >= customerage)).FirstOrDefault();
                    if (rc != null) customer.NetPrice = rc.NetPrice;
                }
                else
                    customer.CoveragePlan = " ";
                _dataRepository.Add(customer);
                return CreatedAtRoute(
                      "Get",
                      new { Id = customer.CustomerId },
                      customer);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}", Name ="DeleteCustomer")]
        //[HttpDelete]
        //[Route("DeleteCustomer/{id}")]
        public IActionResult DeleteCustomer(long id)
        {
            try
            {
                Customer customer = _dataRepository.Get(id);
                if (customer == null)
                {
                    return NotFound("The Customer record couldn't be found.");
                }

                _dataRepository.Delete(customer);
                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}",Name ="UpdateCustomer")]
        //[HttpPut]
        //[Route("UpdateCustomer/{id}")]
        public IActionResult UpdateCustomer(long id, [FromBody] Customer customer)
        {
            try
            {
                if (customer == null)
                {
                    return BadRequest("Customer is null.");
                }

                Customer customerToUpdate = _dataRepository.Get(id);
                if (customerToUpdate == null)
                {
                    return NotFound("The Customer record couldn't be found.");
                }
                CoveragePlan cPlan = null;
                if (!string.IsNullOrEmpty(customer.CustomerCountry))
                {
                    if ((customer.CustomerCountry.ToLower() == "usa") || (customer.CustomerCountry.ToLower() == "can"))
                        cPlan = _coverageDataRepository.GetAll().Where(cp => (cp.EligibilityCountry == customer.CustomerCountry) && (customer.SaleDate >= cp.EligibilityDateFrom) && (customer.SaleDate <= cp.EligibilityDateTo)).FirstOrDefault();
                    else
                        cPlan = _coverageDataRepository.GetAll().Where(cp => (cp.EligibilityCountry.ToLower() == "other") && (customer.SaleDate >= cp.EligibilityDateFrom) && (customer.SaleDate <= cp.EligibilityDateTo)).FirstOrDefault();
                }
                if (cPlan != null)
                {
                    customer.CoveragePlan = cPlan.CoveragePlanName;
                    int customerage = (int)(DateTime.UtcNow - customer.CustomerDateOfBirth).Value.TotalDays / 365;
                    RateChart rc = _rateChartDataRepository.GetAll().Where(rc => (rc.CustomerGender == customer.CustomerGender) && (rc.CustomerAgeFrom <= customerage) && (rc.CustomerAgeTo >= customerage)).FirstOrDefault();
                    if (rc != null) customer.NetPrice = rc.NetPrice;
                }
                else
                    customer.CoveragePlan = " ";
                _dataRepository.Update(customerToUpdate, customer);
                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}