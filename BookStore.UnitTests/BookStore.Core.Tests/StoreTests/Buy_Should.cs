using BookStore.Core;
using BookStore.Core.Interfaces;
using BookStore.DB.Interfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace BookStore.UnitTests.BookStore.Core.Tests.StoreTests
{
    [TestFixture]
    public class Buy_Should
    {
        [Test]
        public void Return_Correct_Price_When_Pass_One_Book()
        {
            //Arrange            
            var rules = new HashSet<ICalculatePriceRule>()
            {
                new SinglePriceRule()
            };

            var dbCatalog = new DB.Catalog("TEST1", "TEST1", 4, 4);
            var dbCollectionCategory = new List<DB.Category>()
            {
                new DB.Category("TEST1", 0.1)
            };

            var dbCollection = new List<DB.Catalog>()
            {
                dbCatalog
            };

            var myDbMock = new Mock<IMyDB>();
            myDbMock.Setup(x => x.Catalogs).Returns(dbCollection);
            myDbMock.Setup(x => x.Categories).Returns(dbCollectionCategory);

            var categoryService = new CategoryService(myDbMock.Object);
            var catalogService = new CatalogService(myDbMock.Object);
            var commonServiceMock = new CommonService(categoryService, catalogService);
            var store = new Store(commonServiceMock, categoryService, catalogService, rules);

            //Act
            var result = store.Buy("TEST1");

            //Assert
            Assert.AreEqual(4, result);
        }

        [Test]
        public void Return_Correct_Price_When_Pass_Two_Books_From_Same_Category()
        {
            //Arrange                      
            var rules = new List<ICalculatePriceRule>()
            {
                new SeveralBooksRule()
            };

            var dbCatalog = new DB.Catalog("TEST1", "TEST1", 10, 4);
            var dbCatalog2 = new DB.Catalog("TEST2", "TEST1", 10, 4);
            var dbCollectionCategory = new List<DB.Category>()
            {
                new DB.Category("TEST1", 0.1)
            };

            var dbCollection = new List<DB.Catalog>()
            {
                dbCatalog,
                dbCatalog2
            };

            var myDbMock = new Mock<IMyDB>();
            myDbMock.Setup(x => x.Catalogs).Returns(dbCollection);
            myDbMock.Setup(x => x.Categories).Returns(dbCollectionCategory);

            var categoryService = new CategoryService(myDbMock.Object);
            var catalogService = new CatalogService(myDbMock.Object);
            var commonServiceMock = new CommonService(categoryService, catalogService);
            var store = new Store(commonServiceMock, categoryService, catalogService, rules);

            //Act
            var result = store.Buy("TEST1", "TEST2");

            //Assert
            Assert.AreEqual(18, result);
        }
    }
}
