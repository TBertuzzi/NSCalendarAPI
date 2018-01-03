using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NSCalendarAPI.Services;
using NSCalendarAPI.Repository;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;

namespace NSCalendarAPI
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
             services.AddMvc(); //Retirei para usar o do CORE

        //    services
        //.AddMvcCore(options =>
        //{
        //    options.RequireHttpsPermanent = true; // does not affect api requests
        //    options.RespectBrowserAcceptHeader = true; // false by default
 
        //})
        //.AddFormatterMappings()
        //.AddJsonFormatters(); // JSON, pode ser adicionado um formato customizavel

            //Instancia uma dependencia por transação
            services.AddTransient<GameService>(); 
            services.AddTransient<ScreenshotService>();
            services.AddTransient<ScreenshotRepository>();
            services.AddTransient<GameRepository>();

            // Registrando o Swaagger generator
            services.AddSwaggerGen(c =>
            {
                //c.SwaggerDoc("v1", new Info { Title = "NSCalendarAPI", Version = "v1" });

                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "NSCalendarAPI",
                    Description = "API de Games para o Aplicativo NSCalendar",
                    TermsOfService = "None",
                    Contact = new Contact { Name = "Thiago Bertuzzi", Email = "", Url = "https://twitter.com/tbertuzzi" }
                });

                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "NSCalendarAPI.xml");
                c.IncludeXmlComments(xmlPath);

            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "NSCalendarAPI V1");
            });


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
