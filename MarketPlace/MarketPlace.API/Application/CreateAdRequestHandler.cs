using MarketPlace.API.Application.Repositories;
using MarketPlace.Domain;
using MarketPlace.Domain.DataTransferObjects.Requests;
using MarketPlace.Domain.ValueObjects;
using MediatR;
using ISender = MarketPlace.Domain.Services.ISender;

namespace MarketPlace.API.Application
{
    public class ClassifiedAdsService : IRequestHandler<CreateAdRequest, int>
    {
        private readonly ISender sender;
        private readonly IRepository<ClassifiedAd> repository;

        public ClassifiedAdsService(ISender sender, IRepository<ClassifiedAd> repository)
        {
            this.sender = sender;
            this.repository = repository;
        }

        //public void Handle(CreateAdRequest request)
        //{
        //    //burada ilan oluşturulacak!
        //    //
        //    var classifiedAd = new ClassifiedAd(new ClassifiedAdId(request.Id), new UserId(request.OwnerId), sender);

        //    //repository.Save(classifiedAd);

        //}

        public async Task<int> Handle(CreateAdRequest request, CancellationToken cancellationToken)
        {
            //burada ilan oluşturulacak!
            //
            var classifiedAd = new ClassifiedAd(new ClassifiedAdId(request.Id), new UserId(request.OwnerId), sender);


            var id = await repository.Save(classifiedAd);
            await Task.CompletedTask;
            return id;
        }

        //public void CreateAd() { }
        //public void DeleteAd() { }
        //public void UpdateAd() { }

    }
}
