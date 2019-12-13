using System;
using Camunda.Worker;
using Camunda.Worker.Extensions;
using CamundaWorker.Handlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

// Teste fro Camunda.Worker nuget pacakge
//Github project: https://github.com/AMalininHere/camunda-worker-dotnet

namespace CamundaWorker
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

            services.AddCamundaWorker(options =>
                {
                    options.WorkerId = "sampleWorker";
                    options.WorkerCount = 1;
                    options.BaseUri = new Uri("http://localhost:8080/engine-rest");
                })
//                .AddHandler<SayHelloHandler>()
//                .AddHandler<SayHelloGuestHandler>()
                .AddHandler<ChargeCardHandler>()
                .ConfigurePipeline(pipeline =>
                {
                    pipeline.Use(next => async context =>
                    {
//                        var logger = context.ServiceProvider.GetRequiredService<ILogger<Startup>>();
//                        logger.LogInformation("Started processing of task {Id}", context.Task.Id);
                        Console.WriteLine($"Started processing of task {context.Task.Id}");
                        await next(context);
//                        logger.LogInformation("Finished processing of task {Id}", context.Task.Id);
                        Console.WriteLine($"Finished processing of task {context.Task.Id}");
                    });
                });
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
        }
    }
}