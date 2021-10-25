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
        private IRepository<TransactionsHistory> _tHistory;

        [SetUp]
        public void Init()
        {
            //_contectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            _categoryRepository = new CategoryRepository(new ApplicationContext());
            _tHistory = new TransctionsRepository(new ApplicationContext());
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
            _categoryRepository.Save();
        }

        [Test]
        public void AddNewTransactionsHistory()
        {
            //arrange
            var tHistory = new TransactionsHistory()
            {
                CategoryId = 2,
                History = "test history"
            };

            //act
            _tHistory.Add(tHistory);
            _tHistory.Save();

            // Assert
            Assert.NotZero(tHistory.Id);
            _tHistory.Delete(tHistory.Id);
            _tHistory.Save();
        }

        [Test]
        public void DeleteTransactionHistory_ShouldReturnNull()
        {
            // Arrange
            var tHistory = new TransactionsHistory()
            {
                CategoryId = 2,
                History = "test history"
            };

            // Act
            _tHistory.Add(tHistory);
            _tHistory.Save();
            var tHistoryId = tHistory.Id;
            _tHistory.Delete(tHistoryId);
            _tHistory.Save();
            var foundTHistory = _tHistory.Find(tHistoryId);
            Assert.Null(foundTHistory);
        }

        [Test]
        public void FindtHistory_ShouldFindCreatedTHistory()
        {
            // Arrange
            var tHistory = new TransactionsHistory()
            {
                CategoryId = 2,
                History = "test history"
            };

            //Act
            _tHistory.Add(tHistory);
            _tHistory.Save();

            var foundtHistory = _tHistory.Find(tHistory.Id);

            //Assert 
            Assert.AreEqual(tHistory.Id, foundtHistory.Id);
            Assert.AreEqual(tHistory.History, foundtHistory.History);

            _tHistory.Delete(tHistory.Id);
            _tHistory.Save();
        }

        [Test]
        public void UpdateTHistory_ShouldFindUpdatedTHistory()
        {
            //Arrange
            var tHistory = new TransactionsHistory()
            {
                CategoryId = 2,
                History = "test history"
            };

            //Act
            _tHistory.Add(tHistory);
            _tHistory.Save();
            tHistory.CategoryId = 3;
            tHistory.History = "test 2";
            _tHistory.Update(tHistory);
            _tHistory.Save();

            var foundTHistory = _tHistory.Find(tHistory.Id);

            //Assert
            Assert.AreEqual(tHistory.CategoryId, foundTHistory.CategoryId);
            Assert.AreEqual(tHistory.History, foundTHistory.History);

            _tHistory.Delete(tHistory.Id);
            _tHistory.Save();
        }
    }
}
