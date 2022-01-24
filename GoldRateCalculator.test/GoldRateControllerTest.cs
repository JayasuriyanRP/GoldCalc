using GoldRateCalculator.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Xunit;

namespace GoldRateCalculator.test
{
    public class GoldRateControllerTest : TestProvider
    {
        private readonly IMediator mediator;

        public GoldRateControllerTest()
        {
            mediator = GetService<IMediator>();
        }

        [Theory]
        [InlineData(4500, 10, 1, 44550, 200)]
        [InlineData(4500, 10, 5, 42750, 200)]
        [InlineData(4500, 10, 10, 40500, 200)]
        [InlineData(4500, 10, 100, 0, 200)]
        [InlineData(4500, 10, 0, 45000, 200)]
        [InlineData(5000, 1, 0, 5000, 200)]
        public async Task GetGoldPrice_Test(int goldPrice, int grams, int discount, int expected, int statusCode)
        {
            var goldController = new GoldRateController(mediator);
            var result = await goldController.CalculateTotalPrice(new Model.GoldRateDto
            {
                GoldPricePerGram = goldPrice,
                WeightInGram = grams,
                DiscountPercent = discount
            });
            var okResult = result as OkObjectResult;
            Assert.Equal(statusCode, okResult.StatusCode);
            Assert.Equal(expected, okResult.Value);


        }
    }
}
