namespace src.ViewModels
{
    public class CreateItemsViewModel
    {
        public string ItemName { get; set; }
        public double ItemCount { get; set; }
        public double ItemPrice { get; set; }
        public double TotalPrice => ItemCount * ItemPrice;
    }
}
