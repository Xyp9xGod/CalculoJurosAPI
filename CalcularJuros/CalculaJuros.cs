using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace CalculaJuros
{
    public class CalculaJuros
    {
        [Required(ErrorMessage = "valorInicial is Required")]
        [Range(0, Double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public decimal valorInicial { get; set; }

        [Required(ErrorMessage = "meses is Required")]
        [Range(0, int.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public int meses { get; set; }
    }
}
