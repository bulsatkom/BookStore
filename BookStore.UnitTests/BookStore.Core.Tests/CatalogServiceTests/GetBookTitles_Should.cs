using BookStore.Core;
using BookStore.DB.Interfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace BookStore.UnitTests.BookStore.Core.Tests.CatalogServiceTests
{
    [TestFixture]
    class GetBookTitles_Should
    {
        [Test]
        public void ReturnAllBookTittles()
        {
            //Arrange
            var dbCatalog = new DB.Catalog("TEST1", "TEST1", 3, 3);
            var dbCatalog2 = new DB.Catalog("TEST2", "TEST1", 3, 3);
            var dbCatalog3 = new DB.Catalog("TEST3", "TEST1", 3, 3);


            var dbCollection = new List<DB.Catalog>()
            {
                dbCatalog,
                dbCatalog2,
                dbCatalog3
            };

            var myDbMock = new Mock<IMyDB>();
            myDbMock.Setup(x => x.Catalogs).Returns(dbCollection);

            var catalogService = new CatalogService(myDbMock.Object);

            //Act
            var result = catalogService.GetBookTitles();

            //Assert
            Assert.AreEqual(3, result.Count);
        }
    }
}
