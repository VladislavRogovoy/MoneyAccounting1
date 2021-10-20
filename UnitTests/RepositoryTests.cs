using DataAccess;
using DataAccess.Models;
using DataAccess.Temp.IRepos;
using DataAccess.Temp.Repositories;
using NUnit.Framework;
using System.Configuration;

namespace UnitTests
{
    [TestFixture]
    public class RepositoryTests
    {
        private string _contectionString;
        private IRepository<Category> _categoryRepository;

        [SetUp]
        public void Init()
        {
            //_contectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            _categoryRepository = new CategoryRepository(new ApplicationContext());
        }

        [Test]
        public void AddNewCategory_ShouldReturnNotZeroId()
        {
            // Arrange
            var category = new Category()
            {
                CategoryName = "TestCategory",
                Balance = 15
            };

            //Act
            _categoryRepository.Add(category);
            _categoryRepository.Save();

            // Assert
            Assert.NotZero(category.Id);
            _categoryRepository.Delete(category.Id);
            _categoryRepository.Save();
        }

        [Test]
        public void DeleteCategory_ShouldReturnNull()
        {
            // Arrange
            var category = new Category()
            {
                CategoryName = "TestCategory",
                Balance = 15
            };

            // Act
            _categoryRepository.Add(category);
            _categoryRepository.Save();
            var categoryId = category.Id;
            _categoryRepository.Delete(categoryId);
            _categoryRepository.Save();
            var foundCategory = _categoryRepository.Find(categoryId);
            Assert.Null(foundCategory);
        }

        [Test]
        public void FindCategory_ShouldFindCreatedCategory()
        {
            //Arrange 
            var category = new Category()
            {
                CategoryName = "TestCategory",
                Balance = 15
            };

            //Act
            _categoryRepository.Add(category);
            _categoryRepository.Save();

            var foundCategory = _categoryRepository.Find(category.Id);

            //Assert 
            Assert.AreEqual(category.Id, foundCategory.Id);
            Assert.AreEqual(category.CategoryName, foundCategory.CategoryName);
            Assert.AreEqual(category.Balance, foundCategory.Balance);

            _categoryRepository.Delete(category.Id);
            _categoryRepository.Save();
        }

        [Test]
        public void UpdateCategory_ShouldFindUpdatedCategory()
        {
            //Arrange
            var category = new Category()
            {
                CategoryName = "TestCategory",
                Balance = 15
            };

            //Act
            _categoryRepository.Add(category);
            _categoryRepository.Save();
            category.CategoryName = "TestCategory2";
            category.Balance = 15;
            _categoryRepository.Update(category);
            _categoryRepository.Save();

            var foundCategory = _categoryRepository.Find(category.Id);

            //Assert
            Assert.AreEqual(category.CategoryName, foundCategory.CategoryName);
            Assert.AreEqual(category.Balance, foundCategory.Balance);

            _categoryRepository.Delete(category.Id);
        }
    }
}
