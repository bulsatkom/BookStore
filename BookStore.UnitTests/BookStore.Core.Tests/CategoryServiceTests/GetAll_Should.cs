using BookStore.Core;
using BookStore.DB.Interfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace BookStore.UnitTests.BookStore.Core.Tests.CategoryServiceTests
{
    [TestFixture]
    class GetAll_Should
    {
        [Test]
        public void ReturnCorrectData()
        {
            //Arange
            var dbCategory = new DB.Category("Test", 0.1);
                
            var dbCollection = new List<DB.Category>()
            {
                dbCategory
            };

            var myDbMock = new Mock<IMyDB>();
            myDbMock.Setup(x => x.Categories).Returns(dbCollection);

            var service = new CategoryService(myDbMock.Object);

            //Act
            var result = service.GetAll();

            //Assert
            Assert.AreEqual(1, result.Count);
        }
    }
}
