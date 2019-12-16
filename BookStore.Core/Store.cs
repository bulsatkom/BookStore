using BookStore.Core.Interfaces;
using BookStore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Core
{
    public class Store : IStore
    {
        private readonly ICommonService commonService;
        private readonly ICategoryService categoryService;
        private readonly ICatalogService catalogService;
        private readonly ICollection<ICalculatePriceRule> rules;

        public Store(ICommonService commonService, ICategoryService categoryService, ICatalogService catalogService, ICollection<ICalculatePriceRule> rules)
        {
            this.commonService = commonService ?? throw new ArgumentNullException("CommonService can`t be null!");
            this.categoryService = categoryService ?? throw new ArgumentNullException("CategoryService can`t be null!");
            this.catalogService = catalogService ?? throw new ArgumentNullException("CatalogService can`t be null!");
            this.rules = rules ?? throw new ArgumentNullException("Rules can`t be null!");
        }

        public double Buy(params string[] basketByNames)
        {
            double result = 0;

            var books = this.commonService.GetBooks(basketByNames);
            var categories = this.categoryService.GetAll();

            foreach (var rule in this.rules)
            {
                if (rule.MatchCondition(books))
                {
                    books = rule.CalculateDiscount(books);
                }
            }

            foreach (var book in books)
            {
                result += book.Value.Price * book.Value.Quantity;

                if (book.Value.HaveDiscount)
                {
                    var currentDiscountPercent = categories.Where(x => x.Name == book.Value.CategoryName).FirstOrDefault().Discount;
                    var currentDiscount = book.Value.Price * currentDiscountPercent;
                    result -= currentDiscount;
                }
            }
         
            return result;
        }

        public void Import(string catalogAsJson)
        {
            Bookstore bookstore = JsonConvert.DeserializeObject<Bookstore>(catalogAsJson);

            if(bookstore != null)
            {
                foreach (var catalog in bookstore.Catalog)
                {
                    this.catalogService.addCatalog(catalog);
                }

                foreach (var category in bookstore.Category)
                {
                    this.categoryService.addCategory(category);
                }
            }
        }

        public int Quantity(string name)
        {
            int result = 0;

            var searchedCatalog = this.catalogService.GetCatalog(name);

            if(searchedCatalog != null)
            {
                result = searchedCatalog.Quantity;
            }

            return result;
        }
    }
}
