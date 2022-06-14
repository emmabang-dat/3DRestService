using System.Collections.Generic;
using System.Linq;
using _3DRestService.Controllers.Manager;
using _3DRestService.Controllers.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _3DRestService.Controllers.Controller
{
    [Route("api/[controller]")]
    [ApiController]

    public class Printer3DController : Microsoft.AspNetCore.Mvc.Controller
    {
       private Printer3DManager _manager = new Printer3DManager();

       [ProducesResponseType(StatusCodes.Status204NoContent)]
       [ProducesResponseType(StatusCodes.Status200OK)]
       [HttpGet]
       public ActionResult<IEnumerable<Printer3DManager>> GetAll([FromQuery] string? brand, [FromQuery] string? model,
           [FromQuery] double? minimumGramPerHour)
       {
           IEnumerable<Printer3D> printers = _manager.GetAll(minimumGramPerHour);
           if (printers.Count() <= 0)
           {
               return NoContent();
           }
           
           return Ok(printers);
       }

       [ProducesResponseType(StatusCodes.Status404NotFound)]
       [ProducesResponseType(StatusCodes.Status200OK)]
       [HttpGet("{id}")]
       public ActionResult GetById(int id)
       {
           Printer3D printer = _manager.GetById(id);
           if (printer == null)
           {
               return NotFound();
           }

           return Ok(printer);
       }

       [ProducesResponseType(StatusCodes.Status200OK)]
       [HttpPost]
       public ActionResult<Printer3D> Add([FromBody] Printer3D newPrinter3D)
       {
           newPrinter3D = _manager.Add(newPrinter3D);
           return Ok();
       }
    }
}
