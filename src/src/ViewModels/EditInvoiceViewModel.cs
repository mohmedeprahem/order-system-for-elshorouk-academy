using src.Models;

namespace src.ViewModels
{
    public class EditInvoiceViewModel
    {
        public long InvoiceId { get; set; }
        public string CustomerName { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int? CashierId { get; set; }
        public int BranchId { get; set; }
        public List<InvoiceItemViewModel> Items { get; set; } = new List<InvoiceItemViewModel>();
        public List<CashierViewModel> Cashiers { get; set; }
        public double TotalAmount => Items.Sum(item => item.TotalPrice);
    }
}
