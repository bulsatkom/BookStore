using BookStore.Core;
using BookStore.DB.Interfaces;
using Moq;
using NUnit.Framework;
using System;

namespace BookStore.UnitTests.BookStore.Core.Tests.CatalogServiceTests
{
    [TestFixture]
    public class addCatalog_Should
    {
        [Test]
        public void ThrowArgumentNullExceptionWhenPassemptyCatalog()
        {
            //Arange
            var myDbMock = new Mock<IMyDB>();
            var catalogService = new CatalogService(myDbMock.Object);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => catalogService.addCatalog(null));
        }
    }
}
