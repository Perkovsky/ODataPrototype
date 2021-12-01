using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OData.Edm;
using ODataPrototype.Models;
using System.Linq;

namespace ODataPrototype
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
            });

            services.AddControllers();
            services.AddOData()
                .EnableApiVersioning();
            services.AddMvcCore()
                .AddNewtonsoftJson();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapODataRoute("odata", "odata", a =>
                {
                    a.AddService(Microsoft.OData.ServiceLifetime.Singleton, typeof(IEdmModel), sp => GetEmdModel());
                });

                endpoints.EnableDependencyInjection();
                endpoints
                    .Expand()
                    .Select()
                    .Count()
                    .OrderBy()
                    .Filter()
                    .SkipToken()
                    .MaxTop(100);
                endpoints.MapControllers();
            });
        }

        private static IEdmModel GetEmdModel()
        {
            var builder = new ODataConventionModelBuilder();

            builder.EntitySet<Entry>("Entries").EntityType
                .HasKey(x => x.EntryId).Filter().Count().Expand(1).OrderBy().Page().Select();

            return builder.GetEdmModel();
        }
    }
}
