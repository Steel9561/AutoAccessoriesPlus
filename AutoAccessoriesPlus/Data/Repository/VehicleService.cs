using AutoAccessoriesPlus.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace AutoAccessoriesPlus.Data.Repository
{
    public class VehicleService : IVehicle
    {
        private readonly AutoAccessoriesPlusDbContext _vehicleContext;

        public VehicleService(AutoAccessoriesPlusDbContext vehicleContext)
        {
            _vehicleContext = vehicleContext;
        }

        public int GetVehicleCount()
        {           
            IQueryable<Vehicle> records = _vehicleContext.Vehicles;
            var count = records.Count();
         
            return count;            
        }

        public List<Vehicle> VehiclePagination(int? page, int vehiclesPerPage)
        {
            IQueryable<Vehicle> vehiclePaginationList;
                      
            vehiclePaginationList = _vehicleContext.Vehicles.FromSqlRaw("exec dbo.VehiclePagination {0}, {1}", page, vehiclesPerPage);

            return vehiclePaginationList.ToList();
        }

        List<Vehicle> IVehicle.SearchVehicle(string SearchTerm)
        {
            IQueryable<Vehicle> vehicleSearch;

            vehicleSearch = _vehicleContext.Vehicles.FromSqlRaw("exec dbo.FindVehicle {0}",SearchTerm);

            return vehicleSearch.ToList();
        }
    }
}
