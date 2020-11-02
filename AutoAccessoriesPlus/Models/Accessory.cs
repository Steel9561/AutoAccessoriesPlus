using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoAccessoriesPlus.Models
{
    public class Accessory
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required...")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Price is required...")]
        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}
