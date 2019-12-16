using BookStore.Core;
using BookStore.Core.Interfaces;
using BookStore.DB.Interfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace BookStore.UnitTests.BookStore.Core.Tests.StoreTests
{
    [TestFixture]
    public class Quantity_Should
    {
        [Test]
        public void Return_Correct_Value_When_Contains_Passed_Catalog()
        {
            //Arrange
            var commonServiceMock = new Mock<ICommonService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var ruleMock = new Mock<ICalculatePriceRule>();
            var rules = new List<ICalculatePriceRule>()
            {
                ruleMock.Object
            };
            var dbCatalog = new DB.Catalog("TEST1", "TEST1", 3, 3);

            var dbCollection = new List<DB.Catalog>()
            {
                dbCatalog
            };

            var myDbMock = new Mock<IMyDB>();
            myDbMock.Setup(x => x.Catalogs).Returns(dbCollection);

            var catalogService = new CatalogService(myDbMock.Object);

            var store = new Store(commonServiceMock.Object, categoryServiceMock.Object, catalogService, rules);

            //Act
            var result = store.Quantity("TEST1");

            //Assert
            Assert.AreEqual(3, result);
        }

        [Test]
        public void Return_0_When_Not_Contains_Passed_Catalog()
        {
            //Arrange
            var commonServiceMock = new Mock<ICommonService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var ruleMock = new Mock<ICalculatePriceRule>();
            var rules = new List<ICalculatePriceRule>()
            {
                ruleMock.Object
            };
            var dbCatalog = new DB.Catalog("TEST1", "TEST1", 3, 3);

            var dbCollection = new List<DB.Catalog>()
            {
                dbCatalog
            };

            var myDbMock = new Mock<IMyDB>();
            myDbMock.Setup(x => x.Catalogs).Returns(dbCollection);

            var catalogService = new CatalogService(myDbMock.Object);

            var store = new Store(commonServiceMock.Object, categoryServiceMock.Object, catalogService, rules);

            //Act
            var result = store.Quantity("test4e");

            //Assert
            Assert.AreEqual(0, result);
        }
    }
}
