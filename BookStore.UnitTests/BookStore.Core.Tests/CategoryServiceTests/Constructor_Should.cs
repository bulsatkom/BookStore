using BookStore.Core;
using BookStore.DB.Interfaces;
using Moq;
using NUnit.Framework;
using System;

namespace BookStore.UnitTests.BookStore.Core.Tests.CategoryServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Return_An_Instance_When_Parameter_Is_NotNull()
        {
            //Arrange
            var myDbMock = new Mock<IMyDB>();

            //Act
            var categoryService = new CategoryService(myDbMock.Object);

            //Assert
            Assert.IsNotNull(categoryService);
        }

        [Test]
        public void Throw_Exception_Wnen_Parameter_IsNull()
        {
            //Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new CatalogService(null));
        }
    }
}
