using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class Aluno
    {
        public string Nome { get; set; }
        public string Serie { get; set; }
        public string AtividadeExtra { get; set; }


        public Aluno(string nome, string serie, string atividadeExtra)
        {
            Nome = nome; Serie = serie; AtividadeExtra = atividadeExtra;
        }
    }
}
        