using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BellInterviewServer.Models;
using BellInterviewServer.SQLServer.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;

namespace BellInterviewServer
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
            services.AddDbContext<ServerAPIContext>(i => i.UseSqlServer(Configuration.GetConnectionString("SQLServerContext")));
            services.AddControllers();
            if (Configuration["AppSettings:ClientRepository"] == "EF")
            {
                services.AddSingleton<IClientRepository, ClientRepository>();
            }
            else
            {
                services.AddSingleton<IClientRepository, FileClientRepository>();
            }

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("AllowAllOrigins");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            try
            {
                using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    using var context = serviceScope.ServiceProvider.GetService<ServerAPIContext>();
                    context.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                //TO DO: log error here
            }

        }
    }
}
