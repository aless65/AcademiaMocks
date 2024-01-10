using AcademiaMocks.Features.Facturacion.Dtos;

namespace AcademiaMocks.Features.Facturacion.Interfaces
{
    public interface IPaymentService
    {
        // Método para procesar un pago
        Task<PaymentResult> ProcessPayment(PaymentDetails? paymentDetails);

        // Método para obtener el estado de un pago
        Task<PaymentStatus> GetPaymentStatus(string transactionId);

        // Método para obtener el historial de pagos por cliente
        Task<List<PaymentHistory>> GetPaymentHistory(string clienteId, DateTime From, DateTime To);

        // Método para validar los detalles de la tarjeta
        bool ValidateCardDetails(CardDetails cardDetails);

        bool IsAvailable { get; set; }

        ILicenseData LicenseData { get; }
    }

    public interface ILicenseData
    {
        string LicenseKey { get; }
    }
}
