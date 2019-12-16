using BookStore.Core;
using BookStore.Core.Exceptions;
using BookStore.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace BookStore.UnitTests.BookStore.Core.Tests.NotEnoughInventoryRuleTests
{
    [TestFixture]
    public class CalculateDiscount_Should
    {
        [Test]
        public void Not_Throw_Exception_When_Quantity_Is_Enough()
        {
            //Arrange
            IDictionary<string, PriceModel> books = new Dictionary<string, PriceModel>();
            books.Add("Test", new PriceModel()
            {
                AvailableQuantity = 2,
                CategoryName = "Test",
                HaveDiscount = false,
                Price = 4,
                Quantity =2
            });

            var rule = new NotEnoughInventoryRule();

            //Act & Assert
            Assert.DoesNotThrow(() => rule.CalculateDiscount(books));
        }

        [Test]
        public void Throw_Exception_When_Quantity_Is_Not_Enough()
        {
            //Arrange
            IDictionary<string, PriceModel> books = new Dictionary<string, PriceModel>();
            books.Add("Test", new PriceModel()
            {
                AvailableQuantity = 1,
                CategoryName = "Test",
                HaveDiscount = false,
                Price = 4,
                Quantity = 2
            });

            var rule = new NotEnoughInventoryRule();

            //Act & Assert
            Assert.Throws<NotEnoughInventoryException>(() => rule.CalculateDiscount(books));
        }
    }
}
