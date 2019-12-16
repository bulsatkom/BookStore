using BookStore.Core;
using BookStore.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace BookStore.UnitTests.BookStore.Core.Tests.NotEnoughInventoryRuleTests
{
    [TestFixture]
    public class MatchCondition_Should
    {
        [Test]
        public void ReturnTrue()
        {
            //Arange
            var rule = new NotEnoughInventoryRule();

            //Act && Assert
            Assert.AreEqual(true, rule.MatchCondition(new Dictionary<string, PriceModel>()));
        }
    }
}
