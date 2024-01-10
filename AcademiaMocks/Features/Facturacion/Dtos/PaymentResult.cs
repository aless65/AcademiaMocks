namespace AcademiaMocks.Features.Facturacion.Dtos
{
    public class PaymentResult
    {
        public string TransactionId { get; set; } = null!;
        public bool Success { get; set; }
        public string Message { get; set; } = null!;
    }
}