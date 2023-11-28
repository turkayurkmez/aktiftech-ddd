using MarketPlace.Domain;
using MarketPlace.Domain.Services;
using MarketPlace.Domain.ValueObjects;

namespace Marketplace.Tests
{
    public class UnitTests
    {
        [Fact]
        public void Money_objects_are_equals()
        {
            var first = new Money(5, "EUR", null);
            var second = new Money(5, "EUR", null);

            Assert.Equal(first, second);

        }
        [Fact]
        public void Sum_of_money()
        {
            var first = new Money(5, "EUR", null);
            var second = new Money(5, "EUR", null);
            var third = new Money(5, "EUR", null);

            var total = new Money(5, "EUR", null);

            Assert.Equal(total, first + second + third);
        }

        [Fact]
        public void test_notification()
        {
            var notificationService = new FakeSender();
            var adId = Guid.NewGuid();
            var ownerId = Guid.NewGuid();

            ClassifiedAd classifiedAd = new ClassifiedAd(new ClassifiedAdId(adId), new UserId(ownerId), notificationService);

            //classifiedAd.ChangeTitle("test");
            Assert.Equal("test gönderildi", notificationService.SendNotification("test"));
        }


    }
}
