using System;
using Xunit;

namespace Calculadora.Tests
{
    public class TestesCalculadora
    {
        private Calculadora calc;

        public TestesCalculadora()
        {
            calc = new Calculadora();
        }

        [Fact]
        public void SomarDoisNumerosInteiros()
        {

            double resultado = calc.Somar(1, 2);

            Assert.Equal(3, resultado);
        }

        [Fact]
        public void SomarDoisNumerosDecimais()
        {

            double resultado = calc.Somar(1.5, 2.2);

            Assert.Equal(3.7, resultado);
        }

        [Fact]
        public void SubtraiDoisNumerosInteiros()
        {

            double resultado = calc.Subtrair(1, 2);

            Assert.Equal(-1, resultado);
        }

        [Fact]
        public void SubtraiDoisNumerosDecimais()
        {

            double resultado = calc.Somar(2.2, 1.50);

            Assert.Equal(0.7, resultado);
        }

        [Theory]
        [InlineData(1,2,2)]
        [InlineData(0.5, 2, 1)]
        public void MultiplicaDoisNumeros(double num1, double num2, double resultado)
        {

            double resultadoCalculadora = calc.Multiplicar(num1, num2);

            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Theory]
        [InlineData(1, 2, 0.5)]
        [InlineData(0.5, 2, 0.25)]
        public void DividirSemDivisaoPorZero(double num1, double num2, double resultado)
        {

            double resultadoCalculadora = calc.Dividir(num1, num2);

            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Fact]
        public void DividirPorZero()
        {
            Assert.Throws<DivideByZeroException>(() => calc.Dividir(1, 0));
        }

        [Fact]
        public void CasoNaoTerFeitoOperacaoRetornaHistoricoVazio()
        {
            var resultado = calc.RetornarHistorico();

            Assert.True(resultado.Count == 0);
        }

        [Fact]
        public void CasoFezOperacoesRetornaHistoricoPreenchidoComMesmaQuantidadeDeOperacoes()
        {
            calc.Somar(1, 2);
            calc.Subtrair(3, 4);
            calc.Multiplicar(5, 6);

            var resultado = calc.RetornarHistorico();

            Assert.True(resultado.Count == 3);
        }

        [Fact]
        public void CasoFacaMaisDe4OperacoesRetornaHistoricoPreenchidoCom3Operacoes()
        {
            calc.Somar(1, 2);
            calc.Subtrair(3, 4);
            calc.Multiplicar(5, 6);
            calc.Dividir(7, 8);

            var resultado = calc.RetornarHistorico();

            Assert.True(resultado.Count == 3);
        }

    }
}
