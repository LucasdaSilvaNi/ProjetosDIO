using System;
using System.Collections.Generic;

namespace Calculadora
{

    public class Calculadora
    {
        List<string> Historico { get; set; }


        enum Operacoes
        {
            Soma,
            Subtracao,
            Multiplicacao,
            Divisao
        }

        public Calculadora()
        {
            Historico = new List<string>();
        }

        public double Somar(double num1, double num2)
        {
            AdicionarHistorico(num1, num2, num1 + num2, Operacoes.Soma);
            return num1 + num2;
        }

        public double Subtrair(double num1, double num2)
        {
            AdicionarHistorico(num1, num2, num1 - num2, Operacoes.Subtracao);
            return num1 - num2;
        }

        public double Multiplicar(double num1, double num2)
        {
            AdicionarHistorico(num1, num2, num1 * num2, Operacoes.Multiplicacao);
            return num1 * num2;
        }

        public double Dividir(double num1, double num2)
        {
            if (num2 == 0)
                throw new DivideByZeroException();
            
            AdicionarHistorico(num1, num2, num1 / num2, Operacoes.Divisao);
            return num1 / num2;
        }

        private void AdicionarHistorico(double num1, double num2, double resultado, Operacoes operacao)
        {
            if (Historico.Count == 3)
                Historico.RemoveAt(0);

            string sinal = "";

            switch (operacao)
            {
                case Operacoes.Soma:
                    sinal = "+";
                    break;
                case Operacoes.Subtracao:
                    sinal = "-";
                    break;
                case Operacoes.Multiplicacao:
                    sinal = "*";
                    break;
                case Operacoes.Divisao:
                    sinal = "/";
                    break;
            }

            Historico.Add($"{num1} {sinal} {num2} = {resultado} ");
        }

        public List<string> RetornarHistorico()
        { 
            List<string> retorno = new List<string>();

            for (int i = Historico.Count - 1; i >= 0; i--)
                retorno.Add(Historico[i]);

            return retorno;
        }
    }
}
