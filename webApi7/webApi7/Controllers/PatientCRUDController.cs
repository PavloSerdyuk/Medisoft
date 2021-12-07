using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi7.Models;

namespace webApi7.Controllers
{
    [Route("api/[controller]")]
    public class PatientCRUDController : Controller
    {

        IPatient obj;

            public PatientCRUDController(IPatient _obj)
            {
            obj = _obj;
            }

            [HttpGet(Name = "GetAllPatients")]
            public IEnumerable<Patient> Get()
            {
                return obj.Get();
            }

            [HttpGet("{id}", Name = "GetPatient")]
            public IActionResult Get(int Id)
            {
                Patient p = obj.Get(Id);

                if (p == null)
                {
                    return NotFound();
                }

                return new ObjectResult(p);
            }
        
            [HttpPost]
            public IActionResult Create([FromBody] Patient p)
            {
                if (p == null)
                {
                    return BadRequest();
                }
                obj.Create(p);
                return CreatedAtRoute("GetPatient", new { id = p.Id }, p);
            }

            [HttpPut("{id}")]
            public IActionResult Update(int Id, [FromBody] Patient updated)
            {
                if (updated == null || updated.Id != Id)
                {
                    return BadRequest();
                }

                var patient = obj.Get(Id);
                if (patient == null)
                {
                    return NotFound();
                }

                obj.Update(updated);
                return RedirectToRoute("GetAllPatients");
            }
        
    }
}
