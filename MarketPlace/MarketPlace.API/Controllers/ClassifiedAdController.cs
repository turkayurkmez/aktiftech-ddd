using MarketPlace.Domain.DataTransferObjects.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassifiedAdController : ControllerBase
    {
        //private readonly ClassifiedAdsService _classifiedAdsService;
        private readonly IMediator mediator;

        public ClassifiedAdController(IMediator mediator)
        {
            //_classifiedAdsService = classifiedAdsService;
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateAdRequest request)
        {
            //request, db'ye kaydedilecek.

            //_classifiedAdsService.Handle(request);
            var id = await mediator.Send(request);
            return Ok(id);
        }

        [HttpPut("id")]
        public async Task<IActionResult> ChangeTitle(Guid id, ChangeTitleCommand request)
        {
            await mediator.Send(request);
            return Ok(id);
        }
    }
}
