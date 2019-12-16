using BookStore.Core;
using BookStore.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace BookStore.UnitTests.SinglePriceRuleTests
{
    [TestFixture]
    public class MatchCondition_Should
    {
        [Test]
        public void Return_True_When_Pass_One_Book()
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

            var rule = new SinglePriceRule();

            //Act
            var result = rule.MatchCondition(books);

            //Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void Return_False_When_Pass_More_Than_One_Book()
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

            var rule = new SinglePriceRule();

            //Act
            var result = rule.MatchCondition(books);

            //Assert
            Assert.AreEqual(false, result);
        }
    }
}
