using BookStore.Core;
using BookStore.DB;
using BookStore.DB.Interfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace BookStore.UnitTests.BookStore.Core.Tests.CommonServiceTests
{
    [TestFixture]
    public class GetBooks_Should
    {
        [Test]
        public void Return_Correct_Data_When_DB_Contains_Books()
        {
            //Arrange
            var basketByNames = new string[]
            {
                "Test",
                "Test1",
                "Test1",
                "Test1",
                "Test",
                "Test2",
            };

            var catalogCollection = new List<Catalog>()
            {
                new Catalog("Test", "Test", 3, 5),
                new Catalog("Test1", "Test", 3, 5),
                new Catalog("Test2", "Test", 3 ,5)
            };

            var myDBMock = new Mock<IMyDB>();
            myDBMock.Setup(x => x.Catalogs).Returns(catalogCollection);
            var catalogService = new CatalogService(myDBMock.Object);
            var categoryService = new CategoryService(myDBMock.Object);
            var CommonService = new CommonService(categoryService, catalogService);

            //Act
            var result = CommonService.GetBooks(basketByNames);

            //Assert
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(3, result["Test1"].Quantity);
            Assert.AreEqual(2, result["Test"].Quantity);
            Assert.AreEqual(1, result["Test2"].Quantity);
        }

        [Test]
        public void Not_Add_Book_When_Not_Exist_In_DB()
        {
            //Arrange
            var basketByNames = new string[]
            {
                "Test",
                "Test"
            };

            var catalogCollection = new List<Catalog>()
            {
                new Catalog("Test1", "Test", 3, 5),
                new Catalog("Test2", "Test", 3 ,5)
            };

            var myDBMock = new Mock<IMyDB>();
            myDBMock.Setup(x => x.Catalogs).Returns(catalogCollection);
            var catalogService = new CatalogService(myDBMock.Object);
            var categoryService = new CategoryService(myDBMock.Object);
            var CommonService = new CommonService(categoryService, catalogService);

            //Act
            var result = CommonService.GetBooks(basketByNames);

            //Assert
            Assert.AreEqual(0, result.Count);
        }
    }
}
