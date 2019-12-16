using BookStore.Core.Exceptions;
using BookStore.Core.Interfaces;
using BookStore.Models;
using System.Collections.Generic;

namespace BookStore.Core
{
    public class NotEnoughInventoryRule : ICalculatePriceRule
    {
        public IDictionary<string, PriceModel> CalculateDiscount(IDictionary<string, PriceModel> books)
        {
            var notEnoughtInventory = new List<INameQuantity>();

            foreach (var book in books)
            {
                if(book.Value.Quantity > book.Value.AvailableQuantity)
                {
                    notEnoughtInventory.Add(new NameQuantity(book.Key, book.Value.AvailableQuantity));
                }
            }

            if(notEnoughtInventory.Count > 0)
            {
                throw new NotEnoughInventoryException(notEnoughtInventory);
            }

            return books;
        }

        public bool MatchCondition(IDictionary<string, PriceModel> books)
        {
            return true;
        }
    }
}
