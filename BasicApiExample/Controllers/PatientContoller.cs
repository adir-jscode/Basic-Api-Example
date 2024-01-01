using BasicApiExample.Models;
using BasicApiExample.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicApiExample.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PatientContoller : ControllerBase
    {
        private readonly IPatient _patient;
        public PatientContoller(IPatient patient)
        {
            _patient = patient;
        }

        [HttpGet]
        //[Route("Index")]
        public IActionResult Index()
        {
            var patient = _patient.GetAllPatients();
            if(patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        [HttpPost]
        public IActionResult Create(Patient patient)
        {
            var newPatient = _patient.CreatePatient(patient);
            if(newPatient <=0)
            {
                return BadRequest("Falied");
            }
            else
            return Ok("Done " + newPatient);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var patient = _patient.GetPatient(id);
            if(patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        [HttpPut]
        public IActionResult Edit(Patient patient)
        {
            var UpdatedPatient = _patient.UpdatePatient(patient);
            if(UpdatedPatient <=0)
            {
                return BadRequest();
            }
            return Ok("Updated : " + UpdatedPatient);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var paiient = _patient.DeletePatient(id);
            if(paiient !=null)
            {
                return Ok(paiient);
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
