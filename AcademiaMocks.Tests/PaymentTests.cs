using AcademiaMocks.Features.Facturacion.Dtos;
using AcademiaMocks.Features.Facturacion.Interfaces;
using FluentAssertions;
using NSubstitute;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AcademiaMocks.Tests
{
    public class PaymentTests
    {
        [Fact]
        public async void ProcessPayment_Successful()
        {
            //Arrange
            IPaymentService paymentService = Substitute.For<IPaymentService>();
            PaymentResult paymentResult = new PaymentResult
            { 
                Message = "Bien",
                Success = true,
                TransactionId = "1"
            };

            paymentService.ProcessPayment(default).ReturnsForAnyArgs(paymentResult);

            //Act 
            var resultado = await paymentService.ProcessPayment(default);

            //Assert
            resultado.Success.Should().BeTrue();
        }

        [Fact]
        public async void ProcessPayment_Failed()
        {
            //Arrange
            IPaymentService paymentService = Substitute.For<IPaymentService>();
            PaymentResult paymentResult = new PaymentResult
            {
                Message = "Bien",
                Success = false,
                TransactionId = "1"
            };

            paymentService.ProcessPayment(default).ReturnsForAnyArgs(paymentResult);

            //Act 
            var resultado = await paymentService.ProcessPayment(default);

            //Assert
            resultado.Success.Should().BeFalse();
        }

        [Fact]
        public void LicenseValid_True()
        {
            //Arrange
            IPaymentService paymentService = Substitute.For<IPaymentService>();
            ILicenseData license = Substitute.For<ILicenseData>();

            license.LicenseKey.Returns("123", "456", "789");

            paymentService.LicenseData.Returns(license);

            ////Act 
            //var resultado = await paymentService.ProcessPayment(default);

            //Assert
            paymentService.LicenseData.Should().Subject.As<ILicenseData>().LicenseKey.Should().Be("123");
            paymentService.LicenseData.Should().Subject.As<ILicenseData>().LicenseKey.Should().Be("456");
            paymentService.LicenseData.Should().Subject.As<ILicenseData>().LicenseKey.Should().Be("789");

            paymentService.LicenseData.Should().Be(license);
        }
    }
}