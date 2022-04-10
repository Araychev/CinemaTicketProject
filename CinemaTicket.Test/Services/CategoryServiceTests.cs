using CinemaTicket.Core.Services;
using CinemaTicket.Infrastructure.Data.Repositories.IRepository;
using Moq;
using NUnit.Framework;
using System;
using CinemaTicket.Models;

namespace CinemaTicket.Test.Services
{
    [TestFixture]
    public class CategoryServiceTests
    {
        private MockRepository mockRepository;

        private Mock<IUnitOfWork> mockUnitOfWork;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockUnitOfWork = this.mockRepository.Create<IUnitOfWork>();
        }

        private CategoryService CreateService()
        {
            return new CategoryService(
                this.mockUnitOfWork.Object);
        }

        [Test]
        public void AddCategory_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Category model = null;

            // Act
            service.AddCategory(
                model);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void GetAllCategories_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();

            // Act
            var result = service.GetAllCategories();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void GetCategory_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            int? id = null;

            // Act
            var result = service.GetCategory(
                id);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void IfCategoryExit_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Category model = null;

            // Act
            var result = service.IfCategoryExit(
                model);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void UpdateCategory_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Category model = null;

            // Act
            service.UpdateCategory(
                model);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void DeleteCategory_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Category model = null;

            // Act
            service.DeleteCategory(
                model);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
