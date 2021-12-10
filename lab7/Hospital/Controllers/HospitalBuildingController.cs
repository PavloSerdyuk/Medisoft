using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Hospital.Models;
using Hospital.Services;

namespace Hospital.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HospitalBuildingController : ControllerBase
    {
        private readonly IDepartmentService _department;
        public HospitalBuildingController(IDepartmentService department)
        {
            _department = department;
        }

       [HttpGet]
        public ActionResult<List<HospitalBuilding>> GetAll() =>
        HospitalBuildingService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<HospitalBuilding> Get(int id)
        {
            var hospitalBuilding = HospitalBuildingService.Get(id);
            var departmentPatients = _department.getPatients();
            hospitalBuilding.addPatients(departmentPatients);

            if(hospitalBuilding == null)
                return NotFound();

            return hospitalBuilding;
        }

        [HttpPost]
        public IActionResult Create(HospitalBuilding hospitalBuilding)
        {            
            HospitalBuildingService.Add(hospitalBuilding);
            return CreatedAtAction(nameof(Create), new { id = hospitalBuilding.id }, hospitalBuilding);        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, HospitalBuilding hospitalBuilding)
        {
            if (id != hospitalBuilding.id)
                return BadRequest();

            var existingHospital = HospitalBuildingService.Get(id);
            if(existingHospital is null)
                return NotFound();

            HospitalBuildingService.Update(hospitalBuilding);           

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var hospitalBuilding = HospitalBuildingService.Get(id);

            if (hospitalBuilding is null)
                return NotFound();

            HospitalBuildingService.Delete(id);

            return NoContent();
        }
    }
}