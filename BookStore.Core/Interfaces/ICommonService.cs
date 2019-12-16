using BookStore.Models;
using BookStore.Models.ViewModels;
using System.Collections.Generic;

namespace BookStore.Core.Interfaces
{
    public interface ICommonService
    {
        ViewAllViewModel GetData();

        IDictionary<string, PriceModel> GetBooks(params string[] basketByNames);
    }
}
