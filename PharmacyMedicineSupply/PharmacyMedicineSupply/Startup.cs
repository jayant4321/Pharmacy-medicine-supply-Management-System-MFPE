using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PharmacyMedicineSupply.DataProvider;
using PharmacyMedicineSupply.Model;
using PharmacyMedicineSupply.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyMedicineSupply
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IPharamacyMedicineRepo,PharamacyMedicineRepo>();
            services.AddTransient<IPharmacyData,PharmacyData>();
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy("MyCorsPolicy", builder => builder
                    .WithOrigins("http://localhost:3000")
                    .AllowCredentials()
                    .AllowAnyMethod()
                    .WithHeaders("Accept", "Content-Type", "Origin", "X-My-Header"));
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PharmacyMedicineSupply", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PharmacyMedicineSupply v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("MyCorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
