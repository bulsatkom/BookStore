namespace BookStore.DB
{
    public class Catalog
    {
        private int startID = 0;

        public int Id { get; private set; }

        public string Name { get; private set; }

        public string CategoryName { get; private set; }

        public int Price { get; private set; }

        public int Quantity { get; private set; }

        public Catalog(string name, string categoryName, int price, int quantity)
        {
            this.Id = startID++;
            this.Name = name;
            this.CategoryName = categoryName;
            this.Price = price;
            this.Quantity = quantity;
        }
    }
}
