namespace src.ViewModels
{
    public class InvoiceDetailsViewModel
    {
        public long InvoiceId { get; set; }
        public string CustomerName { get; set; }
        public DateTime InvoiceDate { get; set; }
        public long CashierId { get; set; }
        public string CashierName { get; set; }
        public List<InvoiceItemViewModel> Items { get; set; } = new List<InvoiceItemViewModel>();
        public double TotalAmount => Items.Sum(item => item.TotalPrice);
    }
}
