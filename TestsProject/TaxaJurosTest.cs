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
        public void callTaxaJurosReturnCorrectValue()
        {
            // Act
            var retorno = _controller.Get();

            // Assert
            Assert.Equal("0,01", retorno.ToString());
        }

        [Fact]
        public void callTaxaJurosReturnIncorrectValue()
        {
            // Act
            var retorno = _controller.Get();

            // Assert
            Assert.NotEqual("0,21", retorno.ToString());
        }
    }
}
