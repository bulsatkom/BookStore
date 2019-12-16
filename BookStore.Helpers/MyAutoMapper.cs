namespace BookStore.Helpers
{
    public static class MyAutoMapper
    {
        public static DB.Catalog FromCatalogToDBCatalog(Models.Catalog catalog)
        {
            return new DB.Catalog(catalog.Name, catalog.Category, catalog.Price, catalog.Quantity);
        }

        public static DB.Category FromCategoryToDbCategory(Models.Category category)
        {
            return new DB.Category(category.Name, category.Discount);
        }

        public static Models.Catalog FromDBCatalogToCatalog(DB.Catalog catalog)
        {
            return new Models.Catalog()
            {
                Category = catalog.CategoryName,
                Name = catalog.Name,
                Price = catalog.Price,
                Quantity = catalog.Quantity
            };
        }

        public static Models.Category FromDbCategoryToCategory(DB.Category category)
        {
            return new Models.Category()
            {
                Name = category.Name,
                Discount = category.Discount
            }; 
        }
    }
}
