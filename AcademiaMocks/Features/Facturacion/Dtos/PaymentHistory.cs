namespace AcademiaMocks.Features.Facturacion.Dtos
{
    public class PaymentHistory
    {
        public int TransactionId { get; set; }
        public decimal Amount { get; set; }
        public string CardNumber { get; set; } = null!;
    }
}
