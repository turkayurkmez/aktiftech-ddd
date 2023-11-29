using MarketPlace.Domain.Core;

namespace MarketPlace.Domain
{
    public class OrderLine : EntityBase
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public override void EnsureValidState()
        {
        }

        public override void When(object @event)
        {

        }
        public DeliveryStatus DeliveryStatus { get; set; }
    }

    public enum DeliveryStatus
    {
        Shipped,
        Canceled
    }
}