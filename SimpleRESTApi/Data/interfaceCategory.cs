using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleRESTApi.Models;

namespace SimpleRESTApi.Data
{
    public interface interfaceCategory
    {
        public List<Category> GetCategories();
        public Category GetCategoryById(int id);
        public Category AddCategory(Category category);
        public Category UpdateCategory(Category category);
        public void DeleteCategory(int categoryId);
        
    }
}