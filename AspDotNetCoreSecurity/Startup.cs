using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspDotNetCoreSecurity.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace AspDotNetCoreSecurity
{
    public class Startup
    {
        private readonly IHostingEnvironment env;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940


        public Startup(IHostingEnvironment env)
        {
            this.env = env;
        }
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc();
            services.AddSingleton<ConferenceRepo>();
            services.AddSingleton<ProposalRepo>();
            services.AddSingleton<AttendeeRepo>();
            
            // cors used only for APIs
            services.AddCors(option =>
            {
                option.AddPolicy("AllowLocalHost", c => c.WithOrigins("http://localhost:5003"));
            });


            if (!env.IsDevelopment())
            {
                services.Configure<MvcOptions>(o=>o.Filters.Add(new RequireHttpsAttribute()));
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            //cors used only for APIs
            // app.UseCors(c => c.AllowAnyOrigin()); //allows all origins
            // app.UseCors(c => c.WithOrigins("http://localhost:5003")); // restricting origins -- u can create Policy in ConfigureService method and use it here- referConfigureService method
            // app.UseCors("AllowLocalHost"); // U can use same as attribute on controller or action -- refere API/Conference controller

            app.UseMvc(ConfigureRoute);

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }

        private void ConfigureRoute(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute(name:"Defalult",
                                  template:"{controller=Conference}/{action=Index}/{id?}");
        }
    }
}
