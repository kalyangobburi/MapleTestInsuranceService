using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MapleTestInsuranceService.Data;
using MapleTestInsuranceService.Data.DataManager;
using MapleTestInsuranceService.Data.Repository;
using MapleTestInsuranceService.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace MapleTestInsuranceService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public MapleInsuranceContext dbContext { get; set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MapleInsuranceContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:CustomerDB"]));
            Config.connectionString = Configuration["ConnectionString:CustomerDB"];
            services.AddScoped<IDataRepository<Customer>, CustomerManager>();
            services.AddScoped<IMasterDataRepository<CoveragePlan>, CoveragePlanManager>();
            services.AddScoped<IMasterDataRepository<RateChart>, RateChartManager>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MAPLE API", Version = "v1" });
            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/swagger/v1/swagger.json", "MAPLE API V1");
            });
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            dbContext = new MapleInsuranceContext();
            if (!dbContext.Database.EnsureCreated())
            dbContext.Database.MigrateAsync();
        }
    }
}
