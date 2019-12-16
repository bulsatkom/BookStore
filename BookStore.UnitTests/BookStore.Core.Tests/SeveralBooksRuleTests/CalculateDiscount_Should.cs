using BookStore.Core;
using BookStore.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace BookStore.UnitTests.BookStore.Core.Tests.SeveralBooksRuleTests
{
    [TestFixture]
    public class CalculateDiscount_Should
    {
        [Test]
        public void Make_Discount_When_Have_2_Catalogs_With_Same_Category()
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
            var result = rule.CalculateDiscount(books);

            //Assert
            Assert.AreEqual(true, result["Test"].HaveDiscount);
            Assert.AreEqual(true, result["Test2"].HaveDiscount);

        }

        [Test]
        public void Not_Make_Discount_When_Dont_Have_2_Catalogs_With_Same_Category()
        {
            //Arrange
            IDictionary<string, PriceModel> books = new Dictionary<string, PriceModel>();
            books.Add("Test", new PriceModel()
            {
                AvailableQuantity = 2,
                CategoryName = "Test1",
                HaveDiscount = false,
                Price = 4,
                Quantity = 2
            });

            books.Add("Test2", new PriceModel()
            {
                AvailableQuantity = 2,
                CategoryName = "Test2",
                HaveDiscount = false,
                Price = 4,
                Quantity = 2
            });

            var rule = new SeveralBooksRule();

            //Act
            var result = rule.CalculateDiscount(books);

            //Assert
            Assert.AreEqual(false, result["Test"].HaveDiscount);
            Assert.AreEqual(false, result["Test2"].HaveDiscount);

        }
    }
}
