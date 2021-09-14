using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Net.Mime;

namespace TaxaJuros.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaxaJurosController : ControllerBase
    {
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public double Get()
        {
            return 0.01;
        }
    }
}
