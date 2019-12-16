using BookStore.Core.Interfaces;
using BookStore.Models;
using System.Collections.Generic;

namespace BookStore.Core
{
    public class SeveralBooksRule : ICalculatePriceRule
    {
        public IDictionary<string, PriceModel> CalculateDiscount(IDictionary<string, PriceModel> books)
        {
            var categoriesCount = new Dictionary<string, int>();

            foreach (var book in books)
            {
                if (!categoriesCount.ContainsKey(book.Value.CategoryName))
                {
                    categoriesCount.Add(book.Value.CategoryName, 1);
                }
                else
                {
                    categoriesCount[book.Value.CategoryName] += 1;
                }
            }

            foreach (var book in books)
            {
                int currentCategoryCount = categoriesCount[book.Value.CategoryName];

                if(currentCategoryCount > 1)
                {
                    book.Value.HaveDiscount = true;
                }
            }

            return books;
        }

        public bool MatchCondition(IDictionary<string, PriceModel> books)
        {
            if(books.Count > 1)
            {
                return true;
            }

            return false;
        }
    }
}
