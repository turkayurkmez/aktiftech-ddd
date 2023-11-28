using MarketPlace.Domain;
using MarketPlace.Domain.ValueObjects;

namespace Marketplace.Tests
{
    public class CodingTests
    {
        [Fact]
        public void Create_Ad()
        {
            Guid adId = Guid.NewGuid();
            Guid ownerId = Guid.NewGuid();

            ClassifiedAdId classifiedAdId = new ClassifiedAdId(adId);
            UserId userId = new UserId(ownerId);

            var classifiedAd = new ClassifiedAd(classifiedAdId, userId, null);


            //entity: Domain'de tek başına var olabilen, kendi türünde diğerlerinden id ile ayrılabilen

            //value object: Sadece bir entity ile anlamlıdır. Kendi başına var olamaz. Id'si ile ayrılamaz!

            //aggregate: Birden fazla entity'den oluşan bir entity. Onu gördüğünüzde başka varlıkları kapsamak zorunda olduğunu anlarsınız.
        }

        /*
         * Bunu yazarken service ve domain'i kirletmemek için servisin nasıl olması gerektiğine dair örnek göstermek istedim:
         */
        public async Task Handle(RequestToPublish command)
        {
            ClassifiedAd entity = null; // bu entity db'den geliyor!

            entity.RequestToPublish();

            //db'ye kaydet

            entity.GetEvents().ToList().ForEach(e =>
            {
                //olayı fırlat
                //message bus
                //rabbit mq
                //arka arkaya operasyon...
            });
        }
    }

    public class RequestToPublish
    {
        public Guid Id { get; set; }

    }
}