using AutoAccessoriesPlus.Data.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AutoAccessoriesPlus.Models
{
    public class VehicleBrandAccessories
    {
        public int Id { get; set; }
        public Accessory RelatedAccessory { get; set; }
        public Vehicle Vehicle { get; set; }
        public string? Comments { get; set; }
    }   
}
