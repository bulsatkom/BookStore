using BookStore.Core;
using BookStore.DB.Interfaces;
using Moq;
using NUnit.Framework;
using System;

namespace BookStore.UnitTests.BookStore.Core.Tests.CategoryServiceTests
{
    [TestFixture]
    public class addCategory_Should
    {
        [Test]
        public void ThrowArgumentNullExceptionWhenPassemptyCategory()
        {
            //Arange
            var myDbMock = new Mock<IMyDB>();
            var service = new CategoryService(myDbMock.Object);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => service.addCategory(null));
        }
    }
}
