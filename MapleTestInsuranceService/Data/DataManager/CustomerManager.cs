using MapleTestInsuranceService.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MapleTestInsuranceService.Data.Repository;
using Microsoft.VisualStudio.Web.CodeGeneration;

namespace MapleTestInsuranceService.Data.DataManager
{
    public class CustomerManager : IDataRepository<Customer>
    {
        //readonly MapleInsuranceContext _mapleInsuranceContext;
        readonly MapleInsuranceContext _mapleInsuranceContext=new MapleInsuranceContext();
        public void Add(Customer entity)
        {
            try
            {
                _mapleInsuranceContext.Customers.Add(entity);
                _mapleInsuranceContext.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(Customer customer)
        {
            try
            {
                _mapleInsuranceContext.Customers.Remove(customer);
                _mapleInsuranceContext.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Customer Get(long id)
        {
            try
            {
                return _mapleInsuranceContext.Customers.FirstOrDefault(c => c.CustomerId == id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Customer Get(string name)
        {
            try
            {
                return _mapleInsuranceContext.Customers.FirstOrDefault(c => c.CustomerName == name);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Customer> GetAll()
        {
            try
            {
                return _mapleInsuranceContext.Customers.ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Customer customer, Customer entity)
        {
            try
            {
                customer.CustomerName = entity.CustomerName;
                customer.CustomerAddress = entity.CustomerAddress;
                customer.CustomerGender = entity.CustomerGender;
                customer.CustomerDateOfBirth = entity.CustomerDateOfBirth;
                customer.CustomerCountry = entity.CustomerCountry;
                customer.CoveragePlan = entity.CoveragePlan;
                customer.SaleDate = entity.SaleDate;
                customer.NetPrice = entity.NetPrice;
                _mapleInsuranceContext.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
