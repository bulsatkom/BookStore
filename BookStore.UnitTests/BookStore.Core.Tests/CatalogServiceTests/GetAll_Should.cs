using BookStore.Core;
using BookStore.DB.Interfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace BookStore.UnitTests.BookStore.Core.Tests.CatalogServiceTests
{
    [TestFixture]
    public class GetAll_Should
    {
        [Test]
        public void ReturnCorrectData()
        {
            //Arange
            var dbCatalog = new DB.Catalog("TEST1", "TEST1", 3, 3);

            var dbCollection = new List<DB.Catalog>()
            {
                dbCatalog
            };

            var myDbMock = new Mock<IMyDB>();
            myDbMock.Setup(x => x.Catalogs).Returns(dbCollection);

            var catalogService = new CatalogService(myDbMock.Object);

            //Act
            var result = catalogService.GetAll();

            //Assert
            Assert.AreEqual(1, result.Count);
        }
    }
}
