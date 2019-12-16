using BookStore.Core;
using BookStore.DB.Interfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace BookStore.UnitTests.BookStore.Core.Tests.CatalogServiceTests
{
    [TestFixture]
    public class GetCatalog_Should
    {
        [Test]
        public void ReturnCorrectCatalogWhenContains()
        {
            //Arrange
            var dbCatalog = new DB.Catalog("TEST1", "TEST1", 3, 3);

            var dbCollection = new List<DB.Catalog>()
            {
                dbCatalog
            };

            var myDbMock = new Mock<IMyDB>();
            myDbMock.Setup(x => x.Catalogs).Returns(dbCollection);

            var catalogService = new CatalogService(myDbMock.Object);

            //Act
            var result = catalogService.GetCatalog("TEST1");

            //Assert
            Assert.AreEqual("TEST1", result.Name);
            Assert.AreEqual("TEST1", result.Category);
            Assert.AreEqual(3, result.Price);
            Assert.AreEqual(3, result.Quantity);
        }

        [Test]
        public void ReturnDefaultWhenNotContains()
        {
            //Arrange
            var dbCatalog = new DB.Catalog("TEST1", "TEST1", 3, 3);

            var dbCollection = new List<DB.Catalog>()
            {
                dbCatalog
            };

            var myDbMock = new Mock<IMyDB>();
            myDbMock.Setup(x => x.Catalogs).Returns(dbCollection);

            var catalogService = new CatalogService(myDbMock.Object);

            //Act
            var result = catalogService.GetCatalog("TEST2");

            //Assert
            Assert.AreEqual(default(DB.Catalog), result);
        }
    }
}
