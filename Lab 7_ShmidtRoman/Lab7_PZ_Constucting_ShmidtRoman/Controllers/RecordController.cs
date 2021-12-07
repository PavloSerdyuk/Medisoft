using Lab7_PZ_Constucting_ShmidtRoman.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab7_PZ_Constucting_ShmidtRoman.Controllers
{
    [Route("api/Record")]
    public class RecordController : ControllerBase
    {

        private IRecord recordData;
        public RecordController(IRecord data)
        {
            recordData = data;

        }

        [HttpGet]
        public IActionResult GetDoctor(int id)
        {
            var employee = recordData.GetRecord(id);
            if (employee != null)
            {
                return Ok(employee);
            }
            return NotFound($"Doctor with id {id} was not found");
        }
    }
}
