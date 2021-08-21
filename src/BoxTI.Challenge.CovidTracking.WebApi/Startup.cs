using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoxTI.Challenge.CovidTracking.WebApi.ApplicationServices;
using BoxTI.Challenge.CovidTracking.WebApi.ApplicationServices.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace BoxTI.Challenge.CovidTracking.WebApi
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo { Title = "BoxTI.Challenge.CovidTracking.WebApi", Version = "v1" });
            });

            services.AddHttpClient<ICovid19TrackingService, Covid19TrackingService>(client =>
            {
                client.BaseAddress = new Uri(Configuration["CovidTrackingApi:BaseUrl"]);
                client.DefaultRequestHeaders.Add("x-rapidapi-key", Configuration["CovidTrackingApi:Key"]);
                client.DefaultRequestHeaders.Add("x-rapidapi-host", Configuration["CovidTrackingApi:Host"]);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "BoxTI.Challenge.CovidTracking.WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}