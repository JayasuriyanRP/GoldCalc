using System.ComponentModel.DataAnnotations;

namespace GoldRateCalculator.Model
{
    public class GoldRateDto
    {
        [Required]
        public int GoldPricePerGram { get; set; }

        [Required]
        public int WeightInGram { get; set; }

        public int DiscountPercent { get; set; }

    }
}
