using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksDestination.Data;
using BooksDestination.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BooksDestination
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGreeter, Greeter>();
            //services.AddSingleton<IBookData, InMemoryBookRepo>();

            services.AddDbContext<BooksDestinationDbContext>(
                options => options.UseSqlServer(_configuration.GetConnectionString("BooksDestination")));

            services.AddScoped<IBookData, SqlBookData>();
            services.AddScoped<IJournalData, SqlJournalData>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            IGreeter greeter)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(ConfigureRoutes);
            app.Run(async (context) =>
            {
                var welcome_msg = greeter.GetWelcomeMessage();
                await context.Response.WriteAsync(welcome_msg);
            });
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("Default","{controller=Home}/{action=Index}/{id?}");
        }
    }
}
