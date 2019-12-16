namespace BookStore.DB
{
    public class Category
    {
        private int startID = 0;

        public  int Id { get; private set; }

        public string Name { get; private set; }

        public double Discount { get; private set; }

        public Category(string name, double discount)
        {
            this.Id = startID++;
            this.Name = name;
            this.Discount = discount;
        }
    }
}
