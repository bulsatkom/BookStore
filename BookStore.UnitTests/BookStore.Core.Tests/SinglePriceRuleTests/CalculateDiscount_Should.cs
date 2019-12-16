using BookStore.Core;
using BookStore.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace BookStore.UnitTests.SinglePriceRuleTests
{
    [TestFixture]
    class CalculateDiscount_Should
    {
        [Test]
        public void Return_False_For_Discount()
        {
            //Arrange
            IDictionary<string, PriceModel> books = new Dictionary<string, PriceModel>();
            books.Add("Test", new PriceModel()
            {
                AvailableQuantity = 2,
                CategoryName = "Test",
                HaveDiscount = true,
                Price = 4,
                Quantity = 2
            });

            var rule = new SinglePriceRule();

            //Act
            var result = rule.CalculateDiscount(books);

            //Assert
            Assert.AreEqual(false, result["Test"].HaveDiscount);
        }
    }
}
