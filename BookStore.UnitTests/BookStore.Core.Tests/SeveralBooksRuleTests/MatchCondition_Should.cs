using BookStore.Core;
using BookStore.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace BookStore.UnitTests.BookStore.Core.Tests.SeveralBooksRuleTests
{
    [TestFixture]
    class MatchCondition_Should
    {
        [Test]
        public void Return_True()
        {
            //Arrange
            IDictionary<string, PriceModel> books = new Dictionary<string, PriceModel>();
            books.Add("Test", new PriceModel()
            {
                AvailableQuantity = 2,
                CategoryName = "Test",
                HaveDiscount = false,
                Price = 4,
                Quantity = 2
            });

            books.Add("Test2", new PriceModel()
            {
                AvailableQuantity = 2,
                CategoryName = "Test",
                HaveDiscount = false,
                Price = 4,
                Quantity = 2
            });

            var rule = new SeveralBooksRule();

            //Act
            var result = rule.MatchCondition(books);

            //Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void Return_False()
        {
            //Arrange
            IDictionary<string, PriceModel> books = new Dictionary<string, PriceModel>();
            books.Add("Test", new PriceModel()
            {
                AvailableQuantity = 2,
                CategoryName = "Test",
                HaveDiscount = false,
                Price = 4,
                Quantity = 2
            });

            var rule = new SeveralBooksRule();

            //Act
            var result = rule.MatchCondition(books);

            //Assert
            Assert.AreEqual(false, result);
        }
    }
}
