using System.Transactions;
using AcademiaMocks.Features.Facturacion;
using AcademiaMocks.Features.Facturacion.Dtos;
using AcademiaMocks.Features.Facturacion.Interfaces;
using AcademiaMocks.Features.Facturacion.WebServices;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace AcademiaMocks
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services) {
            ServicesConfiguration servicesProvider = new(Configuration);
            servicesProvider.RegisterServices(services);

            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());
            });

            services.AddHttpContextAccessor();
            services.AddTransient<PaymentWebService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
