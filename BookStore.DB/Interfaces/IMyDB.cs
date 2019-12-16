using System.Collections.Generic;

namespace BookStore.DB.Interfaces
{
    public interface IMyDB
    {
        ICollection<Catalog> Catalogs { get; }

        ICollection<Category> Categories { get; }

        void AddCategory(Category category);

        void AddCatalog(Catalog catalog);
    }
}
