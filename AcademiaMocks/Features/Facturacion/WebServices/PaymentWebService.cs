using AcademiaMocks.Features.Facturacion.Dtos;
using AcademiaMocks.Features.Facturacion.Interfaces;

namespace AcademiaMocks.Features.Facturacion.WebServices
{
    public class PaymentWebService : IPaymentService
    {
        public bool IsAvailable { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ILicenseData LicenseData => throw new NotImplementedException();

        public Task<List<PaymentHistory>> GetPaymentHistory(string clienteId, DateTime From, DateTime To)
        {
            throw new NotImplementedException("Simulate this real dependency being hard to use");
        }

        public Task<PaymentStatus> GetPaymentStatus(string transactionId)
        {
            throw new NotImplementedException("Simulate this real dependency being hard to use");
        }

        public Task<PaymentResult> ProcessPayment(PaymentDetails? paymentDetails)
        {
            throw new NotImplementedException("Simulate this real dependency being hard to use");
        }

        public bool ValidateCardDetails(CardDetails cardDetails)
        {
            throw new NotImplementedException("Simulate this real dependency being hard to use");
        }
    }
}
