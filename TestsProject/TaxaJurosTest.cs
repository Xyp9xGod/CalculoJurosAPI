using TaxaJuros.Controllers;
using Xunit;

namespace TestsProject
{
    public class TaxaJurosTest
    {
        TaxaJurosController _controller;
        public TaxaJurosTest()
        {
            _controller = new TaxaJurosController();
        }

        [Fact]
        public void GetTaxaJuros_ReturnCorrectValue()
        {
            // Act
            var retorno = _controller.Get();

            // Assert
            Assert.Equal("0,01", retorno.ToString());
        }

        [Fact]
        public void GetTaxaJuros_ReturnIncorrectValue()
        {
            // Act
            var retorno = _controller.Get();

            // Assert
            Assert.NotEqual("0,21", retorno.ToString());
        }
    }
}
