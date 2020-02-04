using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Flurl.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Movie.Api
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
            services.AddControllers();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            var hostName = Dns.GetHostName();
            
            "http://localhost:8001/services"
                .AllowAnyHttpStatus()
                .PostMultipartAsync(content => content
                    .AddString("name", "demo-movies-api")
                    .AddString("url", $"http://{hostName}:5000"))
                .Wait();

            "http://localhost:8001/services/demo-movies-api/routes"
                .AllowAnyHttpStatus()
                .PostMultipartAsync(content => content
                    .AddString("name", "demo-movies-api")
                    .AddString("hosts[]", "localhost")
                    .AddString("paths[]", "/(?i)Movies/Api"))
                .Wait();
        }
    }
}