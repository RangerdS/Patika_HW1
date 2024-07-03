using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Patika_HwFirstWeek.Models;

namespace Patika_HwFirstWeek.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : Controller
    {
        private List<Car> cars;

        public CarController()
        {
            cars = new List<Car>
            {
                new Car
                {
                    Id = 1,
                    Brand = "BMW",
                    Model = "3.20i",
                    Year = 2018,
                    Price = 200000,
                    Km = 100000,
                    LastUserPhone = "5555523555",
                    CreateTime = DateTime.Now,
                    UpdateTime = DateTime.Now
                },
                new Car
                {
                    Id = 2,
                    Brand = "Mercedes",
                    Model = "C180",
                    Year = 2016,
                    Price = 350000,
                    Km = 120000,
                    LastUserPhone = "5555554355",
                    CreateTime = DateTime.Now,
                    UpdateTime = DateTime.Now
                },
                new Car
                {
                    Id = 3,
                    Brand = "Audi",
                    Model = "A3",
                    Year = 2017,
                    Price = 300000,
                    Km = 140000,
                    LastUserPhone = "5555525555",
                    CreateTime = DateTime.Now,
                    UpdateTime = DateTime.Now
                }
            };
        }




        [HttpGet]
        public IActionResult GetCars(){
            if (cars.Count == 0)
            {
                return NotFound();
            }
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public IActionResult GetCar(int id){
            var car = cars.FirstOrDefault(x => x.Id == id);
            if(car == null){
                return NotFound();
            }
            return Ok(car);
        }

        [HttpPost]
        public IActionResult CreateCar(Car car){
            car.Id = cars.Max(x => x.Id) + 1;
            car.CreateTime = DateTime.Now;
            car.UpdateTime = car.CreateTime;
            cars.Add(car);
            return CreatedAtAction(nameof(this.GetCar), new { id = car.Id }, car);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCar(int id, Car car){
            
            // If the given id is different from the car object's id, return BadRequest
            if(id != car.Id){
                return BadRequest();
            }

            var carToUpdate = cars.FirstOrDefault(x => x.Id == id);

            // If there is no car object with the given id, return NotFound
            if(carToUpdate == null){
                return NotFound();
            }

            // If there is no change in the car object, return NoContent
            if (carToUpdate == car)
            {
                return NoContent();
            }

            carToUpdate.Brand = car.Brand;
            carToUpdate.Model = car.Model;
            carToUpdate.Year = car.Year;
            carToUpdate.Price = car.Price;
            carToUpdate.Km = car.Km;
            carToUpdate.LastUserPhone = car.LastUserPhone;
            carToUpdate.UpdateTime = DateTime.Now;
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCar(int id){
            var carToDelete = cars.FirstOrDefault(x => x.Id == id);
            if(carToDelete == null){
                return NotFound();
            }
            cars.Remove(carToDelete);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PatchPrice(int id, [FromBody] int price){
            var car = cars.FirstOrDefault(x => x.Id == id);
            if(car == null){
                return NotFound();
            }
            car.Price = price;
            car.UpdateTime = DateTime.Now;
            return NoContent();
        }
        
        [HttpGet("list")]
        public IActionResult ListCars([FromQuery] string? brand, [FromQuery] string? maxPrice, [FromQuery] string? minPrice){
            var filteredCars = cars;
            if(brand != null){
                filteredCars = filteredCars.Where(x => x.Brand.ToLower().Contains(brand.ToLower())).ToList();
            }
            if(maxPrice != null){
                filteredCars = filteredCars.Where(x => x.Price <= Convert.ToInt32(maxPrice)).ToList();
            }
            if(minPrice != null){
                filteredCars = filteredCars.Where(x => x.Price >= Convert.ToInt32(minPrice)).ToList();
            }
            return Ok(filteredCars);
        }

        [HttpGet("sort")]
        public IActionResult SortCars([FromQuery] string? sortBy){
            var sortedCars = cars;
            if(sortBy == "price"){
                sortedCars = sortedCars.OrderBy(x => x.Price).ToList();
            }
            else if(sortBy == "year"){
                sortedCars = sortedCars.OrderBy(x => x.Year).ToList();
            }
            return Ok(sortedCars);
        }
    }
}