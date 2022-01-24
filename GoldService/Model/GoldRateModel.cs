using System.ComponentModel.DataAnnotations;

namespace GoldService.Model
{
    public class GoldRateModel
    {
        [Required]
        public int GoldPricePerGram { get; set; }

        [Required]
        public int WeightInGram { get; set; }

        public int DiscountPercent { get; set; }

    }
}
