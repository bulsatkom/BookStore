using BookStore.Models;
using System.Collections.Generic;

namespace BookStore.Core.Interfaces
{
    public interface ICategoryService
    {
        void addCategory(Category category);

        ICollection<Category> GetAll();
    }
}
