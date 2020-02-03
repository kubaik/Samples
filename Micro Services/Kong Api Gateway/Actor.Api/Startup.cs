using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using Flurl;
using Flurl.Http;
using KongRegister.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Actor.Api
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
            services.ConfigureKongRegister(Configuration);
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
            app.UseKongRegisterController();
            
            "http://localhost:8001/services"
                .AllowAnyHttpStatus()
                .PostMultipartAsync(content => content
                    .AddString("name", "demo-actors-api")
                    .AddString("url", "http://192.168.0.108:5001"))
                .Wait();

            "http://localhost:8001/services/demo-actors-api/routes"
                .AllowAnyHttpStatus()
                .PostMultipartAsync(content => content
                    .AddString("name", "demo-actors-api")
                    .AddString("hosts[]", "localhost")
                    .AddString("paths[]", "/(?i)Actors/Api"))
                .Wait();
        }
    }
}