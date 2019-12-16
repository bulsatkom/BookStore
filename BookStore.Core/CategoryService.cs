using BookStore.Core.Interfaces;
using BookStore.DB.Interfaces;
using BookStore.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Core
{
    public class CategoryService : ICategoryService
    {
        private readonly IMyDB myDB;

        public CategoryService(IMyDB myDB)
        {
            this.myDB = myDB ?? throw new ArgumentNullException("MyDB can`t be null.");
        }

        public void addCategory(Models.Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException("Category can`t be null!");
            }

            var dbCategory = MyAutoMapper.FromCategoryToDbCategory(category);

            this.myDB.AddCategory(dbCategory);

        }

        public ICollection<Models.Category> GetAll()
        {
            var dbCollection = this.myDB.Categories;

            var result = new List<Models.Category>();

            dbCollection.ToList().ForEach(x => result.Add(MyAutoMapper.FromDbCategoryToCategory(x)));

            return result;
        }
    }
}
