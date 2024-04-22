using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class Materia
    {
    public int Id {  get; set; }
    public string Descricao { get; set; }

      public Materia(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }
    }
}
