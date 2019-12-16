using BookStore.DB.Interfaces;
using System.Collections.Generic;

namespace BookStore.DB
{
    public class MyDB : IMyDB
    {
        public ICollection<Catalog> Catalogs { get; private set; }

        public ICollection<Category> Categories { get; private set; }

        public MyDB()
        {
            this.Catalogs = new HashSet<Catalog>();
            this.Categories = new HashSet<Category>();
        }

        public void AddCategory(Category category)
        {
            this.Categories.Add(category);
        }

        public void AddCatalog(Catalog catalog)
        {
            this.Catalogs.Add(catalog);
        }
    }
}
