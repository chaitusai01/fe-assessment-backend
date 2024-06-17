using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Linq;
using System.Data.SqlClient;
using FeAssignmentApp.Web.API.Common;
using Microsoft.EntityFrameworkCore;
using FeAssignmentApp.Web.API.Repository;

namespace FeAssignmentApp.Web.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            configuration = new ConfigurationBuilder()
              .SetBasePath(env.ContentRootPath)
              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
              .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false)
              .AddEnvironmentVariables()
              .Build();

            Configuration = configuration;

            if (env.IsDevelopment())
            {
                foreach (var keypair in Configuration.AsEnumerable())
                {
                    Console.WriteLine($"{keypair.Key}: {keypair.Value}");
                }
            }
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IFacilitiesRepository, FacilitiesRepository>();
            string connectionString = ConfigureSqlString();
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
            
            services.AddControllers();
            services.AddSwaggerGen(c => {

                c.SupportNonNullableReferenceTypes();
                c.SwaggerDoc("v1", new OpenApiInfo
                { 
                    Title = "Hospital API", 
                    Version = "v1", 
                    Description = "To Handle CRUD Operations"
                });
            });

        }

        private string ConfigureSqlString()
        {
            return new SqlConnectionStringBuilder(Configuration.GetConnectionString("Database")).ConnectionString;
            
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hospital API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
