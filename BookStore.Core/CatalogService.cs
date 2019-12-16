using BookStore.Core.Interfaces;
using BookStore.DB.Interfaces;
using BookStore.Helpers;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Core
{
    public class CatalogService : ICatalogService
    {
        private readonly IMyDB myDB;

        public CatalogService(IMyDB myDB)
        {
            this.myDB = myDB ?? throw new ArgumentNullException("MyDB can`t be null.");
        }

        public void addCatalog(Catalog catalog)
        {
            if (catalog == null)
            {
                throw new ArgumentNullException("Catalog can`t be null!");
            }

            var dbCatalog = MyAutoMapper.FromCatalogToDBCatalog(catalog);

            this.myDB.AddCatalog(dbCatalog);

        }

        public ICollection<Catalog> GetAll()
        {
            var dbCollection = this.myDB.Catalogs;

            var result = new List<Catalog>();

            dbCollection.ToList().ForEach(x => result.Add(MyAutoMapper.FromDBCatalogToCatalog(x)));

            return result;
        }

        public Catalog GetCatalog(string name)
        {
            var dbCatalog = this.myDB.Catalogs.FirstOrDefault(x => x.Name == name);

            if (dbCatalog != null)
            {
                return MyAutoMapper.FromDBCatalogToCatalog(dbCatalog);
            }

            return  default;
        }

        public ICollection<string> GetBookTitles()
        {
            var result = new List<string>();

            var dbCollection = this.myDB.Catalogs;

            foreach (var item in dbCollection)
            {
                result.Add(item.Name);
            }

            return result;
        }
    }
}