using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoAccessoriesPlus.Models
{    
    public class Vehicle
    {
        public enum VehicleType
        {
            Economy,
            Truck,
            FullSize
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Vehicle Make is required.")]
        [MaxLength(50)]
        public string Make { get; set; }

        [Required(ErrorMessage = "Vehicle Model is required.")]
        [MaxLength(50)]
        public string Model { get; set; }

        [Required(ErrorMessage = "Vehicle Type is required.")]
        public VehicleType Type {get; set; }        
        public int? Year { get; set; }
        public byte[] VehicleImage { get; set; }
        public IEnumerable<VehicleBrandAccessories> VehicleBrandAccessories { get; set; }

    }
}
