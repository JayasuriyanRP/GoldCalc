using GoldRateCalculator.Model;
using GoldService.Command;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GoldRateCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoldRateController : ControllerBase
    {
        private readonly IMediator mediator;

        public GoldRateController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> CalculateTotalPrice([FromQuery] GoldRateDto goldRateModel)
        {
            var result =  await mediator.Send(new GoldRateCommand
            {
                GoldRateDto = new GoldService.Model.GoldRateModel()
                {
                    GoldPricePerGram = goldRateModel.GoldPricePerGram,
                    WeightInGram = goldRateModel.WeightInGram,
                    DiscountPercent = goldRateModel.DiscountPercent,
                }
            });

            return result;
        }
    }

}
