namespace BookStore.Models
{
    public class PriceModel
    {
        public string CategoryName { get; set; }
        
        public int AvailableQuantity { get; set; }

        public bool HaveDiscount { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }
    }
}
