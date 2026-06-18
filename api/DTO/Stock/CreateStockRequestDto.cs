using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTO.Stock
{
    public class CreateStockRequestDto
    {
        [Required]
        // [MinLength(5, ErrorMessage = "Title must be 5 char")]
        [MaxLength(10, ErrorMessage = "Symbol cannot be over 10 char")]
        public string Symbol { get; set; } = string.Empty;
        [Required]
        [MaxLength(10, ErrorMessage = "CompanyName cannot be over 10 char")]
        public string CompanyName { get; set; } = string.Empty;
        [Required]
        [Range(1, 1000000000)]
        public decimal Purchase { get; set; }
        [Required]
        [Range(0.001, 100)]
        public decimal LastDiv { get; set; }
        [Required]
        [MaxLength(10, ErrorMessage = "Industry cannot be over 10 char")]
        public string Industry { get; set; } = string.Empty;
        [Required]
        [Range(1, 50000000)]
        public long MarketCap { get; set; }

    }
}