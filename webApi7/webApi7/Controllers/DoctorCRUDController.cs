using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi7.Models;

namespace webApi7.Controllers
{
    [Route("api/[controller]")]
    public class DoctorCRUDController : Controller
    {

        IDoctor obj;

            public DoctorCRUDController(IDoctor _obj)
            {
            obj = _obj;
            }

            [HttpGet(Name = "GetAllDoctors")]
            public IEnumerable<Doctor> Get()
            {
                return obj.Get();
            }

            [HttpGet("{id}", Name = "GetDoctor")]
            public IActionResult Get(int Id)
            {
            Doctor p = obj.Get(Id);

                if (p == null)
                {
                    return NotFound();
                }

                return new ObjectResult(p);
            }
        
            [HttpPost]
            public IActionResult Create([FromBody] Doctor p)
            {
                if (p == null)
                {
                    return BadRequest();
                }
                obj.Create(p);
                return CreatedAtRoute("GetDoctor", new { id = p.Id }, p);
            }

            [HttpPut("{id}")]
            public IActionResult Update(int Id, [FromBody] Doctor updated)
            {
                if (updated == null || updated.Id != Id)
                {
                    return BadRequest();
                }

                var doctor = obj.Get(Id);
                if (doctor == null)
                {
                    return NotFound();
                }

                obj.Update(updated);
                return RedirectToRoute("GetAllDoctors");
            }
        
    }
}
