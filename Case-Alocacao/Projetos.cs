using System;
using System.Collections.Generic;
using System.Text;

namespace Case_Alocacao
{
    public class Projetos
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataDeInicio { get; set; }
        public DateTime DataDeFim { get; set; }
        public List<Alocacao> Alocacoes { get; set; }

        public Projetos()
        {
            this.Alocacoes = new List<Alocacao>();

        }
    }
}
