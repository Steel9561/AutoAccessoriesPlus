using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoAccessoriesPlus.Data;
using AutoAccessoriesPlus.Data.Migrations;
using AutoAccessoriesPlus.Data.Repository;
using AutoAccessoriesPlus.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal.Account.Manage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace AutoAccessoriesPlus.Controllers
{
    public class VehicleController : Controller
    {
        IVehicle _IVehicle;
        private readonly AutoAccessoriesPlusDbContext _vehicleContext;

        public VehicleController(IVehicle IVehicle, AutoAccessoriesPlusDbContext VehicleContext)
        {
            _IVehicle = IVehicle;
            _vehicleContext = VehicleContext;
        }

        private bool VehicleExists(int id)
        {
            return _vehicleContext.Vehicles.Any(e => e.Id == id);
        }

        private bool AllowUserToUploadImage(IFormFile fileToUpload)
        {
            bool allowUpload = true;
            const int imgMinimumSize = 512;
            bool myTestVariable=true;

            if (fileToUpload.Length > 0)
            {   myTestVariable=false;
            
                var postedFileExtension = Path.GetExtension(fileToUpload.FileName);

                //Allow only jpgs, make sure they are readable and have a file size
                if (string.Equals(fileToUpload.ContentType, "image/jpg", StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(fileToUpload.ContentType, "image/jpeg", StringComparison.OrdinalIgnoreCase)
                        &&
                        string.Equals(postedFileExtension, ".jpg", StringComparison.OrdinalIgnoreCase)
                        || string.Equals(postedFileExtension, ".jpeg", StringComparison.OrdinalIgnoreCase)
                        && fileToUpload.OpenReadStream().CanRead
                        && fileToUpload.Length < imgMinimumSize)
                {
                    //Prevent malicious attacks
                    byte[] buffer = new byte[imgMinimumSize];
                    fileToUpload.OpenReadStream().Read(buffer, 0, imgMinimumSize);
                    string content = System.Text.Encoding.UTF8.GetString(buffer);

                    if (Regex.IsMatch(content, @"<script|<html|<head|<title|<body|<pre|<table|<a\s+href|<img|<plaintext|<cross\-domain\-policy",
                        RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Multiline))
                    {
                        allowUpload = false;
                    }
                }
                else
                {
                    allowUpload = false;
                }
            }
            else
            {
                allowUpload = false;
            }

            return allowUpload;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
                                        [Bind("Id,Make,Model,Type,Year,VehicleImage")] Vehicle vehicle,
                                        IFormFile fileToUpload = null)
        {           
            var vehicleClone = _vehicleContext.Vehicles.AsNoTracking().Where(Id => Id.Id == id).FirstOrDefault();
            vehicle.VehicleImage = vehicleClone.VehicleImage;

            if (id != vehicle.Id)
            {
                return NotFound();
            }
          
            if (ModelState.IsValid)
            {
                if (fileToUpload != null)
                {
                        if (AllowUserToUploadImage(fileToUpload))
                        { 
                                using (var stream = new MemoryStream())
                                {
                                    await fileToUpload.CopyToAsync(stream);
                                    vehicle.VehicleImage = stream.ToArray();
                                }
                        }                        
                        else
                        {
                            ViewBag.ErrorUploadingImage = "Please try a different jpg image.";
                            return View("EditVehicle", vehicle);                            
                        }
                }            
                else
                {
                    if (vehicle.VehicleImage == null)
                    {
                        ViewBag.ErrorUploadingImage = "Vehicle image is required.";
                        return View("EditVehicle", vehicle);
                    }
                }
                try
                {                   
                    _vehicleContext.Update(vehicle);
                    await _vehicleContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(vehicle.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction("ListVehicles");
            }

            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        public async Task<IActionResult> EditVehicle(int? id)
        {
          
            if (id == null)
            {
                return NotFound();
            }
            
            var vehicle = await _vehicleContext.Vehicles.FindAsync(id);
            
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var vehicle = await _vehicleContext.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            _vehicleContext.Vehicles.Remove(vehicle);
            await _vehicleContext.SaveChangesAsync();

            return RedirectToAction("ListVehicles");
        }

        //Used for main screen that displays all vehicles
        public IActionResult ListVehicles(int? page=1,string searchByMake = "")
        {
            VehiclePagingInfo vehiclePagingInfo = new VehiclePagingInfo();

            if(page<0)            
                page = 1;

            var vehiclePageIndex = (page ?? 1) - 1;
            var vehiclesPerPage = 5;

            //Values used for pagination functionality
            int totalVehicleCount = _IVehicle.GetVehicleCount();
            var vehicles = _IVehicle.VehiclePagination(page, vehiclesPerPage).ToList();

            //Create paginated list
            var pagedVehicles = new StaticPagedList<Vehicle>
                   (vehicles, vehiclePageIndex + 1, vehiclesPerPage, totalVehicleCount);
            
            //If user entered a search term
            if (!String.IsNullOrEmpty(searchByMake))
            {              
                vehicles = _IVehicle.SearchVehicle(searchByMake);

                pagedVehicles = new StaticPagedList<Vehicle>(vehicles.Where
                   (s => s.Make.Contains(searchByMake)), (int)page, vehiclesPerPage, vehicles.Count
                   (s => s.Make.Contains(searchByMake)));
            }

            vehiclePagingInfo.Vehicles = pagedVehicles;
            vehiclePagingInfo.pageSize = page;
            
            //Return paginated results
            return View(vehiclePagingInfo);
        }

        // GET: Vehicles/Details/5
        public async Task<IActionResult> VehicleDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _vehicleContext.Vehicles
                .FirstOrDefaultAsync(m => m.Id == id);

            IEnumerable<Models.VehicleBrandAccessories> accessories = await _vehicleContext.VehicleBrandAccessories.Where
                 (va => va.Vehicle.Id == id).Include(m => m.RelatedAccessory).ToListAsync();
           
            vehicle.VehicleBrandAccessories= accessories;          

            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // GET: Vehicles/Create
        public IActionResult AddVehicle()
        {
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddVehicle([Bind("Id,Make,Model,Type,Year,VehicleImage")] Vehicle vehicle,
                                                IFormFile fileToUpload = null)
        {
            if (ModelState.IsValid)
            {
                if (fileToUpload != null)
                {
                    if (AllowUserToUploadImage(fileToUpload))
                    {
                        using (var stream = new MemoryStream())
                        {
                            await fileToUpload.CopyToAsync(stream);
                            vehicle.VehicleImage = stream.ToArray();
                        }
                    }
                    else
                    {
                        ViewBag.ErrorUploadingImage = "Please try a different jpg image.";
                        return View("AddVehicle", vehicle);
                    }
                }
                else
                {
                    if (vehicle.VehicleImage == null)
                    {
                        ViewBag.ErrorUploadingImage = "Vehicle image is required.";
                        return View("AddVehicle", vehicle);
                    }
                }

                _vehicleContext.Add(vehicle);
                await _vehicleContext.SaveChangesAsync();
                return RedirectToAction("ListVehicles");
            }

            return View(vehicle);
        }

        public FileContentResult RetriveImageFromDB(int id)
        {            
            Vehicle vehicleToFind = _vehicleContext.Vehicles.Find(id);
            byte[] imagedata = vehicleToFind.VehicleImage;            

            if (imagedata == null)
            {
                var myfile = System.IO.File.ReadAllBytes("wwwroot/images/NoPicAvailable.jpg");
                return new FileContentResult(myfile, "image/jpg");
            }            

            return File(imagedata, "image/jpg");            
        }

    }
}
