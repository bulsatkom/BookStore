using BookStore.Models;
using System.Collections.Generic;

namespace BookStore.Core.Interfaces
{
    public interface ICatalogService
    {
        void addCatalog(Catalog catalog);

        ICollection<Catalog> GetAll();

        Catalog GetCatalog(string name);

        ICollection<string> GetBookTitles();
    }
}
