using GoldService.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GoldService.Command
{
    public class GoldRateCommand : IRequest<IActionResult>
    {
        public GoldRateModel GoldRateDto { get; set; }
    }
}
