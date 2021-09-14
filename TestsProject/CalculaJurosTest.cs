using CalculaJuros.Controllers;
using Xunit;

namespace TestsProject
{
    public class CalculaJurosTest
    {
        CalculaJurosController _controller;
        CalculaJuros.CalculaJuros _calculaJuros;
        public CalculaJurosTest()
        {
            _controller = new CalculaJurosController();
            _calculaJuros = new CalculaJuros.CalculaJuros();
        }

        [Fact]
        public void GetCalculoJuros_WithInvalidMonth_ExpectedReturn()
        {
            // Act
            _calculaJuros.valorInicial = 2;
            _calculaJuros.meses = -3;
            var retorno = _controller.GetCalculoJurosAsync(_calculaJuros);

            // Assert
            Assert.Equal("Número de meses deve ser maior que 0.", retorno.Result);
        }

        [Fact]
        public void GetCalculoJuros_WithInvalidValue_ExpectedReturn()
        {
            // Act
            _calculaJuros.valorInicial = -5;
            _calculaJuros.meses = 1;
            var retorno = _controller.GetCalculoJurosAsync(_calculaJuros);

            // Assert
            Assert.Equal("Valor inicial dever ser maior que 0.", retorno.Result);
        }

        [Fact]
        public void GetCalculoJuros_WithInitialValue100Month5_ExpectedValue()
        {
            // Act
            _calculaJuros.valorInicial = 100;
            _calculaJuros.meses = 5;
            var retorno = _controller.GetCalculoJurosAsync(_calculaJuros);

            // Assert
            Assert.Equal("105,10", retorno.Result);
        }

        [Fact]
        public void GetCalculoJuros_WithInitialValue2200Month10_ExpectedValue()
        {
            // Act
            _calculaJuros.valorInicial = 2200;
            _calculaJuros.meses = 10;
            var retorno = _controller.GetCalculoJurosAsync(_calculaJuros);

            // Assert
            Assert.Equal("2.430,17", retorno.Result);
        }

        [Fact]
        public void GetCalculoJuros_WithInitialValue8000Month19_ExpectedValue()
        {
            // Act
            _calculaJuros.valorInicial = 8000;
            _calculaJuros.meses = 19;
            var retorno = _controller.GetCalculoJurosAsync(_calculaJuros);

            // Assert
            Assert.Equal("9.664,87", retorno.Result);
        }

        [Fact]
        public void GetCalculoJuros_WithInitialValue1572Month23_IncorrectValue()
        {
            // Act
            _calculaJuros.valorInicial = 1572;
            _calculaJuros.meses = 23;
            var retorno = _controller.GetCalculoJurosAsync(_calculaJuros);

            // Assert
            Assert.NotEqual("1.976,00", retorno.Result);
        }

        [Fact]
        public void GetCalculoJuros_WithInitialValue2500Month5_IncorrectValue()
        {
            // Act
            _calculaJuros.valorInicial = 2500;
            _calculaJuros.meses = 5;
            var retorno = _controller.GetCalculoJurosAsync(_calculaJuros);

            // Assert
            Assert.NotEqual("2.627,51", retorno.Result);
        }


        [Fact]
        public void GetCalculoJuros_ReturnGitHubUrl()
        {
            // Act
            var retorno = _controller.GetProjectGitHubUrl();

            // Assert
            Assert.Equal("https://github.com/Xyp9xGod/CalculoJurosAPI", retorno);
        }

        [Fact]
        public void GetCalculoJuros_ReturnInvalidGitHubUrl()
        {
            // Act
            var retorno = _controller.GetProjectGitHubUrl();

            // Assert
            Assert.NotEqual("https://github.com/Xyp9xGod/CalculoJurosAPI2", retorno);
        }

    }
}
