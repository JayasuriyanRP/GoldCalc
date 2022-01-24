using GoldService.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GoldService.Service
{
    public interface IGoldRateService
    {
        public Task<IActionResult> CalculateGoldRate(GoldRateModel goldRateDto);
    }
}
