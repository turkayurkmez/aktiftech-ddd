using MarketPlace.Domain.Core;
using MarketPlace.Domain.Events;
using MarketPlace.Domain.Services;
using MarketPlace.Domain.ValueObjects;

namespace MarketPlace.Domain
{
    public class ClassifiedAd : EntityBase
    {
        public ClassifiedAdId Id { get; private set; }

        private string title;
        private UserId ownerId;
        private readonly ISender notificationService;
        private string text;
        private Price price;


        public ClassifiedAd(ClassifiedAdId id, UserId ownerId, ISender notificationService)
        {
            Id = id;
            this.ownerId = ownerId;
            this.notificationService = notificationService;
            AdState = ClassifiedStatus.Inactive;
        }

        public void ChangeTitle(string title)
        {
            this.title = title;
            EnsureValidState();
            notificationService.SendNotification(title);
            Raise(new DomainEvents.ClassifiedAdTitleChanged { Id = Guid.NewGuid(), Title = title });

        }
        public void UpdateText(string text) => this.text = text;
        public void UpdatePrice(Price price) => this.price = price;

        public void RequestToPublish()
        {
            if (string.IsNullOrEmpty(title)) throw new ArgumentNullException("title");
            if (string.IsNullOrEmpty(text)) throw new ArgumentNullException("text");
            if (price.Amount == 0) throw new ArgumentException("price");
            Apply(new DomainEvents.ClassifiedAdSentForReview() { Id = Guid.NewGuid() });
        }

        public ClassifiedStatus AdState { get; set; }

        public override void EnsureValidState()
        {
            var isValid = Id != null &&
                          ownerId != null &&
                          (AdState switch
                          {
                              ClassifiedStatus.Pending => title != null && text != null && price?.Amount > 0

                          });

            if (!isValid)
            {
                throw new Exception("Ad is not valid");
            }
        }

        public override void When(object @event)
        {
            switch (@event)
            {
                case DomainEvents.ClassifiedAdTitleChanged e:
                    title = e.Title;
                    break;
                case DomainEvents.ClassifiedAdPriceChanged e:
                    price.Amount = e.Price;
                    break;
                case DomainEvents.ClassifiedAdCreated e:
                    Id = new ClassifiedAdId(e.Id);
                    ownerId = new UserId(e.Id);
                    AdState = ClassifiedStatus.Inactive;
                    break;
                case DomainEvents.ClassifiedAdTextChanged e:
                    text = e.Text;
                    break;
                case DomainEvents.ClassifiedAdSentForReview e:
                    AdState = ClassifiedStatus.Pending;
                    break;
                default:
                    break;
            }

        }
    }



    public enum ClassifiedStatus
    {
        Pending,
        Active,
        Inactive,
        MarkedAsSold
    }
}
