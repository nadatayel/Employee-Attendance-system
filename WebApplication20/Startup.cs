using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;
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
using WebApplication20.models;
//using WebApplication20.models;

namespace WebApplication20
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //var cors = new EnableCorsAttribute("*", "*", "*");
            //config.EnableCors(cors);
        }
        

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApplication20", Version = "v1" });
            });
            //services.AddDbContext<EmployeeAttendanceContext>(option => option.UseSqlServer(Configuration.GetConnectionString("EmployeeDatabase")));
       
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication20 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors(x => x
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(origin => true) // allow any origin
                                                        //.WithOrigins("https://localhost:44351")); // Allow only this origin can also have multiple origins separated with comma
                    .AllowCredentials());
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    //internal class config
    //{
    //    internal static void EnableCors(EnableCorsAttribute cors)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
