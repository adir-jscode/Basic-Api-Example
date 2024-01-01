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

        

        //updated with new repo

    }
}
