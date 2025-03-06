using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleRESTApi.Models;

namespace SimpleRESTApi.Data
{
    public class DataAccessLayerCategory : interfaceCategory
    {
        private List<Category> _categories = new List<Category>();
        public DataAccessLayerCategory()
        {
            _categories.Add(new Category { CategoryID = 1, CategoryName = "ASP.NET Core" });
            _categories.Add(new Category { CategoryID = 2, CategoryName = "ASP.NET Core MVC" });
            _categories.Add(new Category { CategoryID = 3, CategoryName = "ASP.NET Web API" });
            _categories.Add(new Category { CategoryID = 4, CategoryName = "Blazor" });
            _categories.Add(new Category { CategoryID = 5, CategoryName = "Xamarin" });
            _categories.Add(new Category { CategoryID = 6, CategoryName = "Azure" });
            _categories.Add(new Category { CategoryID = 7, CategoryName = "Windows" });
            _categories.Add(new Category { CategoryID = 8, CategoryName = "Python" });
        }
        public Category AddCategory(Category category)
        {
            _categories.Add(category);
            return category;
        }

        public void DeleteCategory(int categoryId)
        {
            var category = _categories.FirstOrDefault(c => c.CategoryID == categoryId);
            if(category == null)
            {
                throw new Exception("Category not found");
            }
            _categories.Remove(category);
        }

        public List<Category> GetCategories()
        {
            return _categories;
        }

        public Category GetCategoryById(int id)
        {
            var category = _categories.FirstOrDefault(c => c.CategoryID == id);
            if(category == null)
            {
                throw new Exception("Category not found");
            }
            return category;
        }

        public Category UpdateCategory(Category category)
        {
            var existingCategory = GetCategoryById(category.CategoryID);
            if(existingCategory == null)
            {
                throw new Exception("Category not found");
            }
            existingCategory.CategoryName = category.CategoryName;
            return category;
        }
    }
}