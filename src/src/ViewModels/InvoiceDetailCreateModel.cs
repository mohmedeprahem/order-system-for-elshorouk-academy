namespace src.ViewModels
{
    public class InvoiceDetailCreateModel
    {
        public long InvoiceHeaderId { get; set; }
        public string ItemName { get; set; }
        public float ItemCount { get; set; }
        public float ItemPrice { get; set; }
    }
}
