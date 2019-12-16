using BookStore.Core.Interfaces;
using BookStore.Models;
using BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;

namespace BookStore.Core
{
    public class CommonService : ICommonService
    {
        private readonly ICategoryService categoryService;
        private readonly ICatalogService catalogService;

        public CommonService(ICategoryService categoryService, ICatalogService catalogService)
        {
            this.catalogService = catalogService ?? throw new ArgumentNullException("catalogService can`t be null!");
            this.categoryService = categoryService ?? throw new ArgumentNullException("categoryService can`t be null!");
        }

        public IDictionary<string, PriceModel> GetBooks(params string[] basketByNames)
        {
            var result = new Dictionary<string, PriceModel>();

            foreach (var item in basketByNames)
            {
                var currentCatalog = this.catalogService.GetCatalog(item);

                if(currentCatalog != null)
                {
                    if (!result.ContainsKey(item))
                    {
                        result.Add(item, new PriceModel()
                        {
                            AvailableQuantity = currentCatalog.Quantity,
                            Quantity = 1,
                            HaveDiscount = false,
                            CategoryName = currentCatalog.Category,
                            Price = currentCatalog.Price
                        });
                    }
                    else
                    {
                        result[item].Quantity += 1;
                    }
                }
            }

            return result;
        }

        public ViewAllViewModel GetData()
        {
            var result = new ViewAllViewModel();

            var categories = this.categoryService.GetAll();
            var catalogs = this.catalogService.GetAll();

            foreach (var category in categories)
            {
                if (!result.Catalogs.ContainsKey(category.Name))
                {
                    result.Catalogs.Add(category.Name, new List<ViewAllCatalogViewModel>());
                }

                if (!result.Discounts.ContainsKey(category.Name))
                {
                    result.Discounts.Add(category.Name, category.Discount);
                }
            }

            foreach (var catalog in catalogs)
            {
                if (result.Catalogs.ContainsKey(catalog.Category))
                {
                    result.Catalogs[catalog.Category].Add(new ViewAllCatalogViewModel()
                    {
                        Name = catalog.Name,
                        Price = catalog.Price,
                        Quantity = catalog.Quantity
                    });
                }
            }

            return result;
        }
    }
}
