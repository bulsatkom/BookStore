using System.Collections.Generic;

namespace BookStore.Models
{
    public class Bookstore
    {
        private ICollection<Catalog> catalog;
        private ICollection<Category> category;

        public Bookstore()
        {
            this.catalog = new HashSet<Catalog>();
            this.category = new HashSet<Category>();
        }

        public ICollection<Catalog> Catalog
        {
            get
            {
                return this.catalog;
            }
            set
            {
                this.catalog = value;
            }
        }

        public ICollection<Category> Category
        {
            get
            {
                return this.category;
            }
            set
            {
                this.category = value;
            }
        } 
    }
}
