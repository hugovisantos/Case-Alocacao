using System;
using Xunit;

namespace Case_Alocacao.Test
{
    public class AlocacaoTest
    {
        [Fact (DisplayName = "Deve calcular o total de dias uteis")]      
        public void RetornaNumeroTotalDeDiasUteis()
        {
            var projeto = new Projetos();
            var empregado = new Empregados();
            var alocacao = new Alocacao(empregado, projeto);
            alocacao.InicioDaAlocacao = new DateTime(2019, 02, 11);
            alocacao.FimDaAlocacao = new DateTime(2019, 02, 17);

            var valorEsperado = 5;
;           var valorAtual = alocacao.CountadorDiasUteis();

            Assert.Equal(valorEsperado, valorAtual);
        }

        [Fact (DisplayName = "Deve calcular o custo de alocação do empregado")]
        public void DeveCalcularOCustoDaAlocacao()
        {
            var projeto = new Projetos();
            var empregado = new Empregados();
            var alocacao = new Alocacao(empregado, projeto);
            var periodoDoProjeto = alocacao.CountadorDiasUteis();
            alocacao.InicioDaAlocacao = new DateTime(2019, 02, 11);
            alocacao.FimDaAlocacao = new DateTime(2019, 02, 17);
            alocacao.CargaHoraria = 8;
            empregado.CustoDeHorasTrabalhadas = 100;

            var valorEsperado = 4000;
            var valorAtual = alocacao.CalcularCustoDeAlocacaoDoEmpregado();

            Assert.Equal(valorEsperado, valorAtual);
        }

        [Fact(DisplayName = "Deve calcular a soma dos custos das alocacoes")]
        public void DeveCalcularOCustoDeTodasAsAlocacoes()
        {
            var projeto = new Projetos();
            //Empregado 1
            var empregado = new Empregados();
            var alocacao = new Alocacao(empregado, projeto);
            empregado.CustoDeHorasTrabalhadas = 200;
            alocacao.CargaHoraria = 8;
            alocacao.InicioDaAlocacao = new DateTime(2019, 02, 11);
            alocacao.FimDaAlocacao = new DateTime(2019, 02, 18);

            //Empregado 2
            var empregado2 = new Empregados();
            empregado2.CustoDeHorasTrabalhadas = 300;
            var alocacao2 = new Alocacao(empregado2, projeto);            
            alocacao2.CargaHoraria = 6;
            alocacao2.InicioDaAlocacao = new DateTime(2019, 02, 11);
            alocacao2.FimDaAlocacao = new DateTime(2019, 02, 17);

            var valorEsperado = 18600;
            var valorAtual = alocacao.CalcularASomaDasAlocacoes();

            Assert.Equal(valorEsperado, valorAtual);

        }

    }
}
