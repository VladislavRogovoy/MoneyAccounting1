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
        private IRepository<Category> _categoryRepository;
        private IRepository<Transaction> _transactions;

        [SetUp]
        public void Init()
        {
            var dbContext = new ApplicationContext(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            _categoryRepository = new CategoryRepository(dbContext);
            _transactions = new TransctionsRepository(dbContext);
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
        public void AddNewTransaction()
        {
            //arrange
            var trns = new Transaction()
            {
                CategoryId = 2,
                IsAddition = true,
                Amount = 15
            };

            //act
            _transactions.Add(trns);
            _transactions.Save();

            //Assert
            Assert.NotZero(trns.Id);
            _transactions.Delete(trns.Id);
            _transactions.Save();
        }

        [Test]
        public void DeleteTransaction_ShouldReturnNull()
        {
            //Arrange
            var trns = new Transaction()
            {
                CategoryId = 2,
                IsAddition = true,
                Amount = 15
            };

            //Act
            _transactions.Add(trns);
            _transactions.Save();

            var trnsId = trns.Id;
            _transactions.Delete(trnsId);
            _transactions.Save();
            var foundTrns = _transactions.Find(trnsId);
            Assert.Null(foundTrns);
        }

        [Test]
        public void FindTransaction_ShouldFindCreatedTransaction()
        {
            //Arrange
            var trns = new Transaction()
            {
                CategoryId = 2,
                IsAddition = true,
                Amount = 15
            };

            //Act
            _transactions.Add(trns);
            _transactions.Save();

            var foundTransaction = _transactions.Find(trns.Id);

            //arrange
            Assert.AreEqual(trns.Id, foundTransaction.Id);
            Assert.AreEqual(trns.IsAddition, foundTransaction.IsAddition);
            Assert.AreEqual(trns.CategoryId, foundTransaction.CategoryId);
            Assert.AreEqual(trns.Amount, foundTransaction.Amount);

            _transactions.Delete(trns.Id);
            _transactions.Save();
        }

        [Test]
        public void UpdateTransaction_ShouldReturnUpdatedTransaction()
        {
            //Act
            var trns = new Transaction()
            {
                CategoryId = 2,
                IsAddition = true,
                Amount = 15
            };

            //Arrange
            _transactions.Add(trns);
            _transactions.Save();

            trns.CategoryId = 3;
            trns.IsAddition = false;
            trns.Amount = 10;
            _transactions.Update(trns);
            _transactions.Save();

            var foundTrns = _transactions.Find(trns.Id);

            //Assert
            Assert.AreEqual(trns.CategoryId, foundTrns.CategoryId);
            Assert.AreEqual(trns.Amount, foundTrns.Amount);
            Assert.AreEqual(trns.IsAddition, foundTrns.IsAddition);

            _transactions.Delete(trns.Id);
            _transactions.Save();
        }
    }
}
