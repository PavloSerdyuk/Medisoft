using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using webApi7.Models;

namespace webApi7.Controllers
{
    [Route("api/[controller]")]
    public class DeclCRUDController : Controller
    {

        IDecl obj;

            public DeclCRUDController(IDecl _obj)
            {
            obj = _obj;
            }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes(MediaTypeNames.Application.Json)]
        [HttpGet(Name = "GetAllDecls")]
            public IEnumerable<Declaration> Get()
            {
                return obj.Get();
            }
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes(MediaTypeNames.Application.Json)]
        [HttpGet("{id}", Name = "GetDecl")]
            public IActionResult Get(int Id)
            {
                Declaration item = obj.Get(Id);

                if (item == null)
                {
                    return NotFound();
                }

                return new ObjectResult(item);
            }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes(MediaTypeNames.Application.Json)]
        [HttpPost]
            public IActionResult Create([FromBody] Declaration decl)
            {
                if (decl == null)
                {
                    return BadRequest();
                }
                obj.Create(decl);
                return CreatedAtRoute("GetDecl", new { id = decl.Id }, decl);
            }
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
            public IActionResult Update(int Id, [FromBody] Declaration updateddecl)
            {
                if (updateddecl == null || updateddecl.Id != Id)
                {
                    return BadRequest();
                }

                var item = obj.Get(Id);
                if (item == null)
                {
                    return NotFound();
                }

                obj.Update(updateddecl);
                return RedirectToRoute("GetAllDecls");
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(int Id)
            {
                var deletedDecl = obj.Delete(Id);

                if (deletedDecl == null)
                {
                    return BadRequest();
                }

                return new ObjectResult(deletedDecl);
            }
        
    }
}
