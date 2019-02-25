using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Case_Alocacao
{
    public class Alocacao
    {
        public bool ELider { get; set; }
        public DateTime InicioDaAlocacao { get; set; }
        public DateTime FimDaAlocacao { get; set; }
        public double CargaHoraria { get; set; }

        public Projetos Projeto{get;set;}
        public Empregados Empregado { get; set; }


        public Alocacao(Empregados empregado, Projetos projeto)
        {
            this.Empregado = empregado;
            this.Projeto = projeto;

            projeto.Alocacoes.Add(this);
        }

        public decimal CalcularCustoDeAlocacaoDoEmpregado()
        {
            var custoDeAlocacao = (decimal)CargaHoraria * CountadorDiasUteis() * Empregado.CustoDeHorasTrabalhadas;
            return custoDeAlocacao;
        }

        public int CountadorDiasUteis()
        {
            var contador = 0; 

            for (DateTime i = InicioDaAlocacao.Date; i <= FimDaAlocacao.Date; i = i.AddDays(1))
            {
                
                if (i.DayOfWeek != DayOfWeek.Saturday && i.DayOfWeek != DayOfWeek.Sunday)
                    contador++;                                
            }
            return contador;
        }

        public decimal CalcularASomaDasAlocacoes()
        {
            decimal contador = 0;

            foreach (Alocacao item in this.Projeto.Alocacoes)
            {
                contador += item.CalcularCustoDeAlocacaoDoEmpregado();                
            }
            return contador;
        }

        

        

    }
}
