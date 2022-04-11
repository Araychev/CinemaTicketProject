using CinemaTicket.Infrastructure.Data.Repositories.IRepository;
using CinemaTicketWeb.Areas.Customer.Controllers;
using Microsoft.AspNetCore.Identity.UI.Services;
using Moq;
using NUnit.Framework;
using System;

namespace CinemaTicket.Test.Areas.Customer.Controllers
{
    [TestFixture]
    public class CartControllerTests
    {
        private MockRepository mockRepository;

        private Mock<IUnitOfWork> mockUnitOfWork;
        private Mock<IEmailSender> mockEmailSender;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockUnitOfWork = this.mockRepository.Create<IUnitOfWork>();
            this.mockEmailSender = this.mockRepository.Create<IEmailSender>();
        }

        private CartController CreateCartController()
        {
            return new CartController(
                this.mockUnitOfWork.Object,
                this.mockEmailSender.Object);
        }

        [Test]
        public void Index_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var cartController = this.CreateCartController();

            // Act
            var result = cartController.Index();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void Summary_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var cartController = this.CreateCartController();

            // Act
            var result = cartController.Summary();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void SummaryPOST_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var cartController = this.CreateCartController();

            // Act
            var result = cartController.SummaryPOST();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void OrderConfirmation_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var cartController = this.CreateCartController();
            int id = 0;

            // Act
            var result = cartController.OrderConfirmation(
                id);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void Plus_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var cartController = this.CreateCartController();
            int cartId = 0;

            // Act
            var result = cartController.Plus(
                cartId);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void Minus_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var cartController = this.CreateCartController();
            int cartId = 0;

            // Act
            var result = cartController.Minus(
                cartId);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void Remove_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var cartController = this.CreateCartController();
            int cartId = 0;

            // Act
            var result = cartController.Remove(
                cartId);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
