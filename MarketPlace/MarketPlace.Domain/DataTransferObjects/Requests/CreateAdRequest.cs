using MediatR;
namespace MarketPlace.Domain.DataTransferObjects.Requests
{
    public class CreateAdRequest : IRequest<int>
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
    }
}
