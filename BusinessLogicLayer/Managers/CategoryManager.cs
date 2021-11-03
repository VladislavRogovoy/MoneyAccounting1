using System;
using System.Linq;
using BusinessLogicLayer.Exceptions;
using BusinessLogicLayer.Temp;
using DataAccess.Models;
using DataAccess.Temp.IRepos;
using MoreLinq;

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
                CategoryName = categoryName,
                Currency = "BYN"
            };
            _categoryRepository.Add(category);
            _categoryRepository.Save();
        }

        public void DeleteCategory(int id)
        {
            try
            {
                if (id == 0)
                {
                    throw new CategoryException("id cant be 0");
                }
                _categoryRepository.Delete(id);
            }
            catch(Exception ex)
            {

            }
        }

        public Category[] GetAllCategories(string currency = null)
        {
            var categories = _categoryRepository.GetQuery().ToArray();
            if (currency != null && currency != "BYN")
            {
                var converter = CurrencyConverter.GetConverter();
                categories.ForEach(x => x.Balance = converter.Convert(x.Balance, currency));
            }
            return categories;
        }
    }
}
