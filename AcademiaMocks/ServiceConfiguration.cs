using AcademiaMocks.Features.Facturacion.Dtos;
using AcademiaMocks.Features.Facturacion.Interfaces;
using AcademiaMocks.Features.Facturacion.WebServices;
using Moq;

namespace AcademiaMocks
{
    public class ServicesConfiguration
    {
        private readonly IConfiguration _configuration;

        public ServicesConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void RegisterServices(IServiceCollection services)
        {
            services.AddTransient(ResolveIPaymentService);
        }

        public IPaymentService ResolveIPaymentService(IServiceProvider serviceProvider)
        {
            //var cadenaConexion = provider.GetService<ConfiguracionesClientService>()!.ObtenerCadenaDeConexionLocal();
            bool esEntrenamiento = false;  // cadenaConexion.Contains(".1.240") || cadenaConexion.Contains("entrenamiento");

            if (esEntrenamiento)
            {
                var PaymentWebServiceMock = new Mock<IPaymentService>(MockBehavior.Loose);
                SetupPaymentWebService(ref PaymentWebServiceMock);

                return PaymentWebServiceMock.Object;
            }

            return serviceProvider.GetService<PaymentWebService>()!;
        }

        public void SetupPaymentWebService(ref Mock<IPaymentService> mock)
        {
            mock.DefaultValue = DefaultValue.Mock;

            mock.Setup(x => x.ProcessPayment(It.IsAny<PaymentDetails>()))
                .ReturnsAsync(new PaymentResult { Success = true });

            mock.Setup(x => x.ProcessPayment(It.IsNotNull<PaymentDetails>()))
                .ReturnsAsync(new PaymentResult { Success = true });

            mock.Setup(x => x.ProcessPayment(It.Is<PaymentDetails>(y => y.CVV == "098")))
                .ReturnsAsync(new PaymentResult { Success = false, Message = "CVV Invalid" });

            mock.Setup(x => x.IsAvailable).Returns(true);
        }
    }
}
