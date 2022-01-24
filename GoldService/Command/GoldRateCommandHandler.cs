using GoldService.Service;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace GoldService.Command
{
    public class GoldRateCommandHandler : IRequestHandler<GoldRateCommand, IActionResult>
    {
        private readonly IGoldRateService goldRateService;

        public GoldRateCommandHandler(IGoldRateService goldRateService)
        {
            this.goldRateService = goldRateService;
        }
        public Task<IActionResult> Handle(GoldRateCommand request, CancellationToken cancellationToken)
        {
            return goldRateService.CalculateGoldRate(request.GoldRateDto);
        }
        
    }
}
