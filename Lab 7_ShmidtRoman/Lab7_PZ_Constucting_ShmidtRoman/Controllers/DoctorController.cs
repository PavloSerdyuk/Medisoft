using Lab7_PZ_Constucting_ShmidtRoman.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab7_PZ_Constucting_ShmidtRoman.Controllers
{
    [Route("api/Doctor")]
    public class DoctorController : ControllerBase
    {
        private IDoctor doctorData;
        public DoctorController(IDoctor data)
        {
            doctorData = data;

        }

        [HttpGet]
        public IActionResult GetDoctors()
        {
            return Ok(doctorData.GetDoctors());
        }

        [HttpGet("{id}")]
        public IActionResult GetDoctor([FromRoute] int id)
        {
            var employee = doctorData.GetDoctor(id);
            if (employee != null)
            {
                return Ok(employee);
            }
            return NotFound($"Doctor with id {id} was not found");
        }

        [HttpPost]
        public IActionResult AddDoctors([FromBody] Doctor customer)
        {           
            doctorData.AddDoctor(customer);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host +
                HttpContext.Request.Path + '/' + customer.Id, customer);
        }

        [HttpDelete]
        public IActionResult DeleteDoctors(int id)
        {
            var cus = doctorData.GetDoctor(id);
            if (cus != null)
            {
                doctorData.DeleteDoctor(id);
                return Ok();
            }
            return NotFound($"Cannot find the doctor with Id: {id}");
        }

        [HttpPatch]
        public IActionResult EditDoctors(int id, Doctor customer)
        {
            var cus = doctorData.GetDoctor(id);
            if (cus != null)
            {
                customer.Id = cus.Id;
                var cust = doctorData.EditDoctor(customer);
                return Ok(cust);
            }
            return NotFound($"Cannot find the doctor with Id: {id}");
        }
    }
}
