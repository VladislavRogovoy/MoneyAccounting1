using System.Linq;
using NUnit.Framework;
using System.Configuration;
using DataAccess.Temp.IRepos;
using DataAccess;
using DataAccess.Temp.Repositories;
using DataAccess.Models;
using BusinessLogicLayer.Managers;

namespace UnitTests
{
    [TestFixture]
    public class BLLTests
    {
        private IRepository<Category> _categoryRepository;
        private CategoryManager categoryManager;

        [SetUp]
        public void Init()
        {
            var dbContext = new ApplicationContext(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            _categoryRepository = new CategoryRepository(dbContext);
            categoryManager = new CategoryManager(_categoryRepository);
        }

        [Test]
        public void CreateCategory_ShouldReturnNewCategory()
        {
            //Act
            categoryManager.CreateNewCategory("TestCategory");

            //Arrange
            var allCategories = categoryManager.GetAllCategories();
            var category = allCategories.FirstOrDefault();

            //Assert
            Assert.IsNotNull(category);
            Assert.AreEqual(category.CategoryName, "TestCategory");
            categoryManager.DeleteCategory(category.Id);
        }
    }
}
