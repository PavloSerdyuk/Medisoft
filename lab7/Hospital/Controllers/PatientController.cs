using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Hospital.Models;
using Hospital.Services;

namespace Hospital.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController : ControllerBase
    {
        public PatientController()
        {
        }

       [HttpGet]
        public ActionResult<List<Patient>> GetAll() =>
        PatientService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Patient> Get(int id)
        {
            var patient = PatientService.Get(id);

            if(patient == null)
                return NotFound();

            return patient;
        }

        [HttpPost]
        public IActionResult Create(Patient patient)
        {            
            PatientService.Add(patient);
            return CreatedAtAction(nameof(Create), new { id = patient.id }, patient);        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Patient patient)
        {
            if (id != patient.id)
                return BadRequest();

            var existingPatient = PatientService.Get(id);
            if(existingPatient is null)
                return NotFound();

            PatientService.Update(patient);           

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var patient = PatientService.Get(id);

            if (patient is null)
                return NotFound();

            PatientService.Delete(id);

            return NoContent();
        }
    }
}