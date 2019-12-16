using BookStore.Core.Interfaces;
using BookStore.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Core
{
    public class SinglePriceRule : ICalculatePriceRule
    {
        public IDictionary<string, PriceModel> CalculateDiscount(IDictionary<string, PriceModel> books)
        {
           books.FirstOrDefault().Value.HaveDiscount = false;

            return books;
        }

        public bool MatchCondition(IDictionary<string, PriceModel> books)
        {
            if(books.Count == 1)
            {
                return true;
            }

            return false;
        }
    }
}
