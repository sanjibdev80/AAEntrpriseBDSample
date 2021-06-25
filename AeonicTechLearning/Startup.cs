using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AeonicTech.Core.Service.Manager;
using AeonicTech.Data.Infrastructure;
using AeonicTech.Data.Interfaces;
using AeonicTech.Data.Repositories;
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

namespace AeonicTechLearning
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
            services.AddCors(options => options.AddPolicy("newPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AeonicTech.WebAPI", Version = "v1" });
            });

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient(typeof(IBaseUnitOfWork<>), typeof(BaseUnitOfWork<>));
            services.AddTransient(typeof(IMultipleUnitOfWork), typeof(MultipleUnitOfWork));
            services.AddTransient(typeof(IAeonicTechResponseManager), typeof(AeonicTechResponseManager));
            services.AddTransient(typeof(IEmployeeDTOService), typeof(EmployeeDTOService));
            services.AddTransient(typeof(IOfficeDTOService), typeof(OfficeDTOService));

            services.AddDbContext<AppDBContext>(options =>
                          options.UseSqlServer(
                              Configuration.GetConnectionString("AeonicTechConn"),
                              b => b.MigrationsAssembly("AeonicTech.Data")));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AeonicTech.WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("MyPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireCors("newPolicy");
            });
        }
    }
}
