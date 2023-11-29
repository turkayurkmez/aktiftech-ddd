using MediatR;

namespace MarketPlace.Domain.DataTransferObjects.Requests
{
    public class ChangeTitleCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}
