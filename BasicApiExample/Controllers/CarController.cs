using BasicApiExample.Context;
using BasicApiExample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicApiExample.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        ApplicationDbContext _applicationDbContext = new ApplicationDbContext();
        public CarController(ApplicationDbContext applicationDbContext) 
        { 
            _applicationDbContext = applicationDbContext;
        }


        [HttpPost]
        public void PostCar(string Name, string Description)
        {
            var car = new Car()
            {
                Name = Name,
                Description = Description,
                CreatedDate = DateTime.Now,

            };
            _applicationDbContext.cars.Add(car);
            _applicationDbContext.SaveChanges();

        }

        [HttpPost]
        public Car AddCar(Car car)
        {
            car.CreatedDate = DateTime.Now;
            _applicationDbContext.cars.Add(car);
            bool isSaved = _applicationDbContext.SaveChanges() > 0;
            if (isSaved)
            {
                return car;
            }
            return null;

        }

        [HttpGet]
        public List<Car> GetAllCar()
        {
            var cars = _applicationDbContext.cars.ToList();
            return cars;
        }


    }
}
