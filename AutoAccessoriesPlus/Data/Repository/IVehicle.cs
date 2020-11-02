using AutoAccessoriesPlus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoAccessoriesPlus.Data.Repository
{
    public interface IVehicle
    {
        int GetVehicleCount();
        List<Vehicle> VehiclePagination(int? page, int vehiclesPerPage);
        List<Vehicle> SearchVehicle(string SearchTerm);
    }
}
