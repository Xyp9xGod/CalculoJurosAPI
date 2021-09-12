using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Net.Mime;

namespace TaxaJuros.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxaJurosController : ControllerBase
    {
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public double Get()
        {
            //var taxaJuros = 0.01;
            //return taxaJuros.ToString("N2", CultureInfo.CreateSpecificCulture("pt-BR"));
            return 0.01;
        }
    }
}
