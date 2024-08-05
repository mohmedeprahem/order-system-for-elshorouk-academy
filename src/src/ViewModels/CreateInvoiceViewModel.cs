namespace src.ViewModels
{
    public class CreateInvoiceViewModel
    {
        public string CustomerName { get; set; }
        public DateTime InvoiceDate { get; set; }
        public long CashierId { get; set; }
        public int BranchId { get; set; }
        public List<CreateItemsViewModel> Items { get; set; } = new List<CreateItemsViewModel>();
        public double TotalAmount => Items.Sum(item => item.TotalPrice);
    }
}
