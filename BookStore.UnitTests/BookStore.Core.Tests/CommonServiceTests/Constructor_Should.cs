using BookStore.Core;
using BookStore.Core.Interfaces;
using Moq;
using NUnit.Framework;
using System;

namespace BookStore.UnitTests.BookStore.Core.Tests.CommonServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Return_An_Instance_When_Parameters_Is_NotNull()
        {
            //Arrange
            var categoryServiceMock = new Mock<ICategoryService>();
            var catalogServiceMock = new Mock<ICatalogService>();

            //Act
            var commonService = new CommonService(categoryServiceMock.Object, catalogServiceMock.Object);

            //Assert
            Assert.IsNotNull(commonService);
        }

        [Test]
        public void Throw_Exception_Wnen_CategoryService_IsNull()
        {
            //Arrange
            var catalogServiceMock = new Mock<ICatalogService>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new CommonService(null, catalogServiceMock.Object));
        }

        [Test]
        public void Throw_Exception_Wnen_CatalogService_IsNull()
        {
            //Arrange
            var categoryServiceMock = new Mock<ICategoryService>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new CommonService(categoryServiceMock.Object,null));
        }
    }
}
