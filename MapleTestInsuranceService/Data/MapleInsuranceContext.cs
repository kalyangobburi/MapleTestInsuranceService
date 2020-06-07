using MapleTestInsuranceService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MapleTestInsuranceService.Data
{
    public class MapleInsuranceContext : DbContext
    {
        public MapleInsuranceContext()
        {

        }
        public MapleInsuranceContext(DbContextOptions options): base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Config.connectionString);
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CoveragePlan> CoveragePlans { get; set; }
        public DbSet<RateChart> RateCharts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<Customer>().HasKey("CustomerId");
            
            modelBuilder.Entity<CoveragePlan>().ToTable("CoveragePlans");
            modelBuilder.Entity<CoveragePlan>().HasKey("PlanId");
            
            modelBuilder.Entity<RateChart>().ToTable("RateCharts");
            modelBuilder.Entity<RateChart>().HasKey("Id");
            
            BuildCoveragePlansData(modelBuilder);
            
            BuildRateChartsData(modelBuilder);
            
        }

        private void BuildRateChartsData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RateChart>().HasData(new RateChart
            {
                Id=1,
                CoveragePlanName = "Gold",
                CustomerGender = 'M',
                CustomerAgeFrom = 18,
                CustomerAgeTo = 40,
                NetPrice = 1000

            }, new RateChart
            {
                Id=2,
                CoveragePlanName = "Gold",
                CustomerGender = 'M',
                CustomerAgeFrom = 41,
                CustomerAgeTo = 100,
                NetPrice = 2000

            }, new RateChart
            {
                Id=3,
                CoveragePlanName = "Gold",
                CustomerGender = 'F',
                CustomerAgeFrom = 18,
                CustomerAgeTo = 40,
                NetPrice = 1200

            }, new RateChart
            {
                Id=4,
                CoveragePlanName = "Gold",
                CustomerGender = 'F',
                CustomerAgeFrom = 41,
                CustomerAgeTo = 100,
                NetPrice = 2500

            }, new RateChart
            {
                Id=5,
                CoveragePlanName = "Silver",
                CustomerGender = 'M',
                CustomerAgeFrom = 18,
                CustomerAgeTo = 40,
                NetPrice = 1500

            }, new RateChart
            {
                Id=6,
                CoveragePlanName = "Silver",
                CustomerGender = 'M',
                CustomerAgeFrom = 41,
                CustomerAgeTo = 100,
                NetPrice = 2600

            }, new RateChart
            {
                Id=7,
                CoveragePlanName = "Silver",
                CustomerGender = 'F',
                CustomerAgeFrom = 18,
                CustomerAgeTo = 40,
                NetPrice = 1900

            }, new RateChart
            {
                Id=8,
                CoveragePlanName = "Silver",
                CustomerGender = 'F',
                CustomerAgeFrom = 41,
                CustomerAgeTo = 100,
                NetPrice = 2800

            }, new RateChart
            {
                Id=9,
                CoveragePlanName = "Platinum",
                CustomerGender = 'M',
                CustomerAgeFrom = 18,
                CustomerAgeTo = 40,
                NetPrice = 1900

            }, new RateChart
            {
                Id=10,
                CoveragePlanName = "Platinum",
                CustomerGender = 'M',
                CustomerAgeFrom = 41,
                CustomerAgeTo = 100,
                NetPrice = 2900

            }, new RateChart
            {
                Id=11,
                CoveragePlanName = "Platinum",
                CustomerGender = 'F',
                CustomerAgeFrom = 18,
                CustomerAgeTo = 40,
                NetPrice = 2100

            }, new RateChart
            {
                Id=12,
                CoveragePlanName = "Platinum",
                CustomerGender = 'F',
                CustomerAgeFrom = 41,
                CustomerAgeTo = 100,
                NetPrice = 3200

            });
        }

        private void BuildCoveragePlansData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CoveragePlan>().HasData(new CoveragePlan
            {
                PlanId=1,
                CoveragePlanName = "Gold",
                EligibilityDateFrom = new DateTime(2009, 01, 01),
                EligibilityDateTo = new DateTime(2021, 01, 01),
                EligibilityCountry = "USA"

            }, new CoveragePlan
            {
                PlanId=2,
                CoveragePlanName = "Platinum",
                EligibilityDateFrom = new DateTime(2005, 01, 01),
                EligibilityDateTo = new DateTime(2023, 01, 01),
                EligibilityCountry = "CAN"

            }, new CoveragePlan
            {
                PlanId=3,
                CoveragePlanName = "Silver",
                EligibilityDateFrom = new DateTime(2001, 01, 01),
                EligibilityDateTo = new DateTime(2026, 01, 01),
                EligibilityCountry = "OTHER"

            });

        }
    }
}
