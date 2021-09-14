using System;
using System.ComponentModel.DataAnnotations;

namespace CalculaJuros
{
    public class CalculaJuros
    {
        [Required(ErrorMessage = "valorInicial é obrigatório")]
        [Range(1.0, Double.MaxValue, ErrorMessage = "O campo {0} deve ser maior que 1.")]
        public decimal valorInicial { get; set; }

        [Required(ErrorMessage = "meses é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O campo {0} deve ser maior que 0.")]
        public int meses { get; set; }
    }
}
