using BookStore.Core;
using BookStore.Core.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BookStore.UnitTests.BookStore.Core.Tests.StoreTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Throw_Exception_When_Pass_Null_CommonService()
        {
            //Arrange
            var categoryServiceMock = new Mock<ICategoryService>();
            var catalogServiceServiceMock = new Mock<ICatalogService>();
            var ruleMock = new Mock<ICalculatePriceRule>();
            var rules = new List<ICalculatePriceRule>()
            {
                ruleMock.Object
            };


            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => new Store(null, categoryServiceMock.Object, catalogServiceServiceMock.Object, rules));
        }

        [Test]
        public void Throw_Exception_When_Pass_Null_CatalogService()
        {
            //Arrange
            var commonServiceMock = new Mock<ICommonService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var ruleMock = new Mock<ICalculatePriceRule>();
            var rules = new List<ICalculatePriceRule>()
            {
                ruleMock.Object
            };


            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => new Store(commonServiceMock.Object, categoryServiceMock.Object, null, rules));
        }

        [Test]
        public void Throw_Exception_When_Pass_Null_CategoryService()
        {
            //Arrange
            var commonServiceMock = new Mock<ICommonService>();
            var catalogServiceServiceMock = new Mock<ICatalogService>();
            var ruleMock = new Mock<ICalculatePriceRule>();
            var rules = new List<ICalculatePriceRule>()
            {
                ruleMock.Object
            };


            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => new Store(commonServiceMock.Object, null, catalogServiceServiceMock.Object, rules));
        }

        [Test]
        public void Throw_Exception_When_Pass_Null_Rules()
        {
            //Arrange
            var commonServiceMock = new Mock<ICommonService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var catalogServiceServiceMock = new Mock<ICatalogService>();

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => new Store(commonServiceMock.Object, categoryServiceMock.Object, catalogServiceServiceMock.Object, null));
        }

    }
}
