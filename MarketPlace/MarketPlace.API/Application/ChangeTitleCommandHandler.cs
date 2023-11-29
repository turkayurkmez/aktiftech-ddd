using MarketPlace.API.Application.Repositories;
using MarketPlace.Domain;
using MarketPlace.Domain.DataTransferObjects.Requests;
using MediatR;

namespace MarketPlace.API.Application
{
    public class ChangeTitleCommandHandler : IRequestHandler<ChangeTitleCommand, Unit>
    {
        private readonly IRepository<ClassifiedAd> repository;

        public ChangeTitleCommandHandler(IRepository<ClassifiedAd> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(ChangeTitleCommand request, CancellationToken cancellationToken)
        {

            //EF gibi ORM'lerde ChangeTracking tekniği ile güncelleme işlemi yapılır. Öyle bir durumda, gelen komutu doğrudan Update edebilirdiniz. 
            //Burada sahte repository olduğu için bu örneği kullandım.
            ClassifiedAd classifiedAd = await repository.GetById(request.Id);
            classifiedAd.ChangeTitle(request.Title);
            await repository.Save(classifiedAd);

            return Unit.Value;


        }
    }
}
