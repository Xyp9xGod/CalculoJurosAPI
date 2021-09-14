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
    [Route("api/[controller]")]
    public class CalculaJurosController : ControllerBase
    {
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<string> GetCalculoJurosAsync([FromQuery] CalculaJuros calculaJuros)
        {
            try
            {
                if (calculaJuros.valorInicial < 1)
                {
                    return "Valor inicial dever ser maior que 0.";
                }
                if (calculaJuros.meses <= 0)
                {
                    return "Número de meses deve ser maior que 0.";
                }
                double taxaJuros = 0;
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("https://localhost:44391/api/TaxaJuros"))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            taxaJuros = double.Parse(apiResponse, CultureInfo.InvariantCulture);
                        }
                        else
                        {
                            return "Erro ao buscar Taxa de Juros, tente novamente.";
                        }
                    }
                }

                var valorTotal = Decimal.ToDouble(calculaJuros.valorInicial) * Math.Pow((1 + taxaJuros), calculaJuros.meses);
                return valorTotal.ToString("N2", CultureInfo.CreateSpecificCulture("pt-BR"));
            }
            catch (Exception ex)
            {
                return String.Format("Erro no Cálculo de Juros. Ex: {0}", ex.Message);
            }
        }

        [HttpGet("/ShowMeTheCode")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public string GetProjectGitHubUrl()
        {
            try
            {
                return "https://github.com/Xyp9xGod/CalculoJurosAPI";
            }
            catch (Exception ex)
            {
                return String.Format("Erro no Cálculo de Juros. Ex: {0}", ex.Message);
            }
        }
    }
}
