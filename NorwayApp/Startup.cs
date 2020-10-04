using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NorwayApp.DAL;
using NorwayApp.Models;

namespace NorwayApp
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

            services.AddControllers().AddNewtonsoftJson(options =>
                            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                // må være med når det skal serialiseres "kompliserte" strukturer til JSON. 
                // i tillegg må Microsoft.AspNetCore.NewtonsoftJson installeres som pakke
                );
            services.AddDbContext<ReiseContext>(options =>
                            options.UseSqlite("Data Source=norwayBuss.db"));

            services.AddScoped<IReiseRepository, ReiseRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerfactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                loggerfactory.AddFile("Logs/ReiseLog.txt");
                DBInit.Initialize(app);// må fjernes hvis vi vil beholde dataene i databasen
            }

            app.UseRouting();

            //app.UseAuthorization();

            app.UseStaticFiles(); // merk denne!

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
