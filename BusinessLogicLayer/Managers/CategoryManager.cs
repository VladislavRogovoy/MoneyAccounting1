using System;
using System.Linq;
using BusinessLogicLayer.Exceptions;
using DataAccess.Models;
using DataAccess.Temp.IRepos;

namespace BusinessLogicLayer.Managers
{
    public class CategoryManager
    {
        private IRepository<Category> _categoryRepository;
        public CategoryManager(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public void CreateNewCategory(string categoryName)
        {
            if (string.IsNullOrEmpty(categoryName))
            {
                throw new CategoryException("category name is empty");
            }
            var category = new Category()
            {
                CategoryName = categoryName
            };
            _categoryRepository.Add(category);
            _categoryRepository.Save();
        }

        public void DeleteCategory(int id)
        {
            if (id == 0)
            {
                throw new CategoryException("id cant be 0");
            }

            try
            {
                _categoryRepository.Delete(id);
            }
            catch(Exception ex)
            {

            }
        }

        public Category[] GetAllCategories()
        {
            var categories = _categoryRepository.GetQuery().ToArray();
            return categories;
        }
    }
}
