namespace src.ViewModels
{
    public class InvoiceViewModel
    {
        public long InvoiceId { get; set; }
        public string CustomerName { get; set; }
        public DateTime InvoiceDate { get; set; }
        public double TotalAmount { get; set; }
    }
}
