﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Course.Spyshop.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "searchById",
                    template: "Search/{id:long}",
                    defaults: new {controller = "Home",action = "SearchById"}
                    
                    );
                routes.MapRoute(
                   name: "default",
                   template: "{controller = Home}/{action=Index}/{id?}"
                   //defaults: new { controller = "Home", action = "Index" }
                   );
            });

            app.UseMvcWithDefaultRoute();

            //    app.Use(async (context, next) => {
            //        if (context.Request.Path == "/spyshop")
            //            await context.Response.WriteAsync("Spy shop");
            //        else
            //            await next.Invoke();

            //});

            //    app.Run(async (context) =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
        }
    }
}
