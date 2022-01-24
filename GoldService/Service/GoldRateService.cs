using GoldService.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace GoldService.Service
{
    public class GoldRateService : IGoldRateService
    {
        public async Task<IActionResult> CalculateGoldRate(GoldRateModel goldRateModel)
        {
            var goldPrice = goldRateModel.WeightInGram * goldRateModel.GoldPricePerGram;
            if (goldRateModel.DiscountPercent > 0)
            {
                var oncePercentOfPrice = goldPrice / 100;
                goldPrice = goldPrice - (oncePercentOfPrice * goldRateModel.DiscountPercent);
            }

            return new OkObjectResult(goldPrice)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
