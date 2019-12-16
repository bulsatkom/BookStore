namespace BookStore.Models
{
    public class Category
    {
        public string Name { get; set; }

        public double Discount { get; set; }

        public override bool Equals(object obj)
        {
            var currentObj = obj as Category;

            return this.Discount == currentObj.Discount && this.Name == currentObj.Name;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() + this.Discount.GetHashCode();
        }
    }
}