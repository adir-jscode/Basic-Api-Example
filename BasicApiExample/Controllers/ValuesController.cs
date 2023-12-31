using BasicApiExample.Context;
using BasicApiExample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicApiExample.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        ApplicationDbContext _applicationDbContext = new ApplicationDbContext();
        
        public ValuesController(ApplicationDbContext applicationDbContext) 
        {
            _applicationDbContext = applicationDbContext;
        }


        [HttpGet]
        public string GetName() 
        {
            return "Start";
        }

        [HttpGet]
        public List<string> GetValues()
        {
            List<string> values = new List<string>() 
            {
                "NYC","DHAKA"
            };

            return values;
        }

        [HttpGet]

        public List<Car> GetCars()
        {
            return new List<Car>() { new Car { Id =1, Name ="Audi",Description = "2023 Model"} , new Car { Id = 2, Name = "BMW", Description = "2020 Model" } };
        }

        [HttpPost]
        public void PostCar(string Name,string Description)
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

        //updated with new repo

    }
}
