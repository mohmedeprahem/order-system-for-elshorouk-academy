namespace src.ViewModels
{
    public class InvoiceItemViewModel
    {
        public long ItemId { get; set; }
        public string ItemName { get; set; }
        public double ItemCount { get; set; }
        public double ItemPrice { get; set; }
        public double TotalPrice => ItemCount * ItemPrice;
    }
}
