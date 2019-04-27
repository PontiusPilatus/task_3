using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApi_Transit_PSQL_Dapper.BusinessLogic;
using WebApi_Transit_PSQL_Dapper.Services;
using MassTransit;
using MassTransit.ExtensionsDependencyInjectionIntegration;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.Extensions.Hosting;
using WebApi_Transit_PSQL_Dapper.Bus;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using WebApi_Transit_PSQL_Dapper.BusinessLogic.Consumers;

namespace WebApi_Transit_PSQL_Dapper
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Dependency Injection
            services.AddScoped<GetCoursesInfoRequestHandler>();
            services.AddScoped<AddCourseInfoRequestHandler>();
            services.AddScoped<GetAllCoursesInfoRequestHandler>();
            services.AddScoped<UpdateCourseInfoRequestHandler>();
            services.AddScoped<DeleteCourseInfoRequestHandler>();
            services.AddScoped<ICourseInfoService, CourseInfoService>();
            
            // Bus configuration
            services.AddScoped<UpdateCourseInfoMessageHandler>();
            services.AddMassTransit(c =>
            {
                c.AddConsumer<UpdateCourseInfoMessageHandler>();
            });
            

            services.AddSingleton(provider => MassTransit.Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host("localhost", "/", h => { });

                cfg.ReceiveEndpoint(host, "web-service-endpoint", e =>
                {
                    e.PrefetchCount = 16;
                    e.LoadFrom(provider);
                });
            }));

            //services.AddSingleton<IPublishEndpoint>(provider => provider.GetRequiredService<IBusControl>());
            //services.AddSingleton<ISendEndpointProvider>(provider => provider.GetRequiredService<IBusControl>());
            services.AddSingleton<IBus>(provider => provider.GetRequiredService<IBusControl>());
            //if do this we can use IRequestClient in controller at this time being I only use IBus
            //services.AddScoped(provider => provider.GetRequiredService<IBus>().CreateRequestClient<SendMessageConsumer>());
            services.AddSingleton<IHostedService, BusService>();  
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}