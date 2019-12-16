using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Interfaces
{
    public interface ICalculatePriceRule
    {
        bool MatchCondition(IDictionary<string, PriceModel> books);

        IDictionary<string, PriceModel> CalculateDiscount(IDictionary<string, PriceModel> books);
    }
}
