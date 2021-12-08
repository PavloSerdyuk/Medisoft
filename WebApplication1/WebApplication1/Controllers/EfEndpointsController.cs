using BLL.Interfaces;
using EF_DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EfEndpointsController : Controller
    {
        private readonly IPersonnelService personService;
        public EfEndpointsController(IPersonnelService personService)
        {
            this.personService = personService;
        }

        [HttpPost("person")]
        public IActionResult CreatePerson([FromBody] PersonModel personModel)
        {
            var person = new Person()
            {
                Name = personModel.Name,
                Surname = personModel.Surname,
                Birthday = personModel.Birthday,
            };
            personService.SetPerson(person);
            return Ok(person);
        }

        [HttpGet("person/{id}")]
        public IActionResult GetPerson(int id)
        {
            return Ok(personService.GetPersonById(id));
        }

        [HttpGet("personnel")]
        public IActionResult GetPerson()
        {
            return Ok(personService.GetPerson());
        }

        [HttpDelete("person")]
        public IActionResult DeletePerson(int id)
        {
            return Ok(personService.DeletePerson(id));
        }

        [HttpPatch("person")]
        public IActionResult UpdatePerson(int id, [FromBody] PersonModel personModel)
        {
            return Ok(personService.UpdatePerson(id, personModel.Name, personModel.Surname, personModel.Birthday));
        }
    }
}
