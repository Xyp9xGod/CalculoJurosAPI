using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.Net.Http;
using System.Net.Mime;
using System.Threading.Tasks;

namespace CalculaJuros.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculaJurosController : ControllerBase
    {
        //[HttpPost("{valorinicial}/{meses}")]
        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<string> GetCalculoJurosAsync([FromQuery] CalculaJuros calculaJuros)
        {
            try
            {
                double taxaJuros = 0;
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("https://localhost:44391/TaxaJuros"))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            taxaJuros = double.Parse(apiResponse, CultureInfo.InvariantCulture);
                        }
                        else
                        {
                            BadRequest("Erro ao buscar Taxa de Juros, tente novamente.");
                        }
                    }
                }

                var valorTotal = Decimal.ToDouble(calculaJuros.valorInicial) * Math.Pow((1 + taxaJuros), calculaJuros.meses);
                return valorTotal.ToString("N2", CultureInfo.CreateSpecificCulture("pt-BR"));
            }
            catch (Exception ex)
            {
                return String.Format("Erro no Cálculo de Juros. Ex: {0}",
                         ex.Message);
            }
        }
    }
}
