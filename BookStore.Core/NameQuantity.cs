using BookStore.Core.Interfaces;

namespace BookStore.Core
{
    public class NameQuantity : INameQuantity
    {
        public NameQuantity(string name, int quantity)
        {
            this.Name = name;
            this.Quantity = quantity;
        }

        public string Name { get; }

        public int Quantity { get; }

        public override string ToString()
        {
            return $"{this.Name} - {this.Quantity}";
        }
    }
}
