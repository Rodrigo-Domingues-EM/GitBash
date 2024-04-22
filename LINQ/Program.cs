using System.Linq;

namespace LINQ
{
    public class Program
    {

        static void Main()
        {//*Demonstração de alguns métodos LINQ*

            List<Aluno> listaAlunosFractal = new List<Aluno>();
            listaAlunosFractal.Add(new Aluno("Ana", "1", "Volei"));
            listaAlunosFractal.Add(new Aluno("Leonardo", "2", "Artes"));
            listaAlunosFractal.Add(new Aluno("Maria", "2", "Música"));
            listaAlunosFractal.Add(new Aluno("Leonarda", "3", "Teatro"));
            listaAlunosFractal.Add(new Aluno("Maria", "2", "Música"));

            List<Aluno> listaAlunosExpovest = new List<Aluno>();
            listaAlunosExpovest.Add(new Aluno("luiza", "2", "Volei"));
            listaAlunosExpovest.Add(new Aluno("Leandro", "1", "Xadrez"));
            listaAlunosExpovest.Add(new Aluno("marcos", "3", "Música"));
            listaAlunosExpovest.Add(new Aluno("Ana", "2", "Xadrez"));
            listaAlunosExpovest.Add(new Aluno("Maria", "2", "Música"));

            List<Materia> listaMateriasFractal = new List<Materia>();
            listaMateriasFractal.Add(new Materia(1, "geografia"));
            listaMateriasFractal.Add(new Materia(2, "português"));
            listaMateriasFractal.Add(new Materia(5, "matemática"));
            listaMateriasFractal.Add(new Materia(7, "física"));
            listaMateriasFractal.Add(new Materia(4, "filosofia"));






            //Lista de demontrãção a ser usada
            List<string> nomes = ["Rodrigo", "Maria", "Marcelo", "Leonardo", "Carlos", "Leonarda", "Leonarda", "Rodrigo"];
            Console.WriteLine("\ntodos os nomes:");
            ExibeItensDaLista(nomes);


            //*AGGREGATE* aplica uma função acumuladora sobre uma sequência
            //usando aggregate para somar o número de caracteres de todos os nomes da lista de alunos(SOMA É QUANTO JÁ SOMOU E PROXIMO É O ELEMENTO A SER SOMADO O NÚMERO DE CARACTERES)
            int somaDeCaracteres = listaAlunosFractal.Aggregate(0, (soma, proximo) => soma + proximo.Nome.Length);
            Console.WriteLine($"\nsoma de todos os caracteres dos nomes dos alunos é = {somaDeCaracteres}");

            //usando Aggregate para retornar o primeiro nome com maior número de caracteres(maior vai iniciar com o valor "" e só vai trocar de valor sempre que achar um elemento com maior numero de caracteres)
            string maiorNome = listaAlunosFractal.Aggregate("", (string maior, Aluno proximo) => proximo.Nome.Length > maior.Length ? proximo.Nome : maior);
            Console.WriteLine($"\nmaior nome da Lista de nomes: {maiorNome}");


            //*DISTINCT* retorna os elementos de uma sequência que são distintos
            IEnumerable<string> atividadesExtrasNaoRepetidas = listaAlunosFractal.Select(a => a.AtividadeExtra).Distinct();
            Console.WriteLine("\ntodas as atividades extras sem se repetir:");
            ExibeItensDaLista(atividadesExtrasNaoRepetidas);


            // Usando Except para comparar nomes dos alunos do Fractal com o do expovest
            var nomesUnicos = listaAlunosFractal.Select(n => n.Nome).Except(listaAlunosExpovest.Select(n => n.Nome));
            // Exibindo os nomes não banidos que se repetem
            Console.WriteLine("\nnomes que só existem na lista de alunos do Fractal:");
            ExibeItensDaLista(nomesUnicos);


            //*INTERSECT* compara duas sequências e retorna uma sequência com os elementos que aparecem nas duas
            var nomesComuns = listaAlunosFractal.Select(n => n.Nome).Intersect(listaAlunosExpovest.Select(n => n.Nome));
            Console.WriteLine("\nnomes que existem na lista de alunos do Fractal e na Lista de alunos do Expovest:");
            ExibeItensDaLista(nomesComuns);


            //*OFTYPE* filtra elementos de uma sequência com base em um tipo específico
            List<Object> listaSuja = ["Rodrigo", "Marcelo", 23.11, "Matheus", "Naldo", 4];
            Console.WriteLine("\n *Lista suja:");
            ExibeItensDaLista(listaSuja);
            IEnumerable<string> listaLimpa = listaSuja.OfType<string>();
            Console.WriteLine(" *Lista limpa:");
            ExibeItensDaLista(listaLimpa);


            //*SELECTMANY* projeta cada elemento de uma sequência em um IEnumerable e nivela em uma unica sequência plana
            // Aplanando a listaAlunosFractal e selecionando nome e série em um único array
            var listaPlana = listaAlunosFractal.SelectMany(aluno => new[] { aluno.Nome, aluno.Serie });
            ExibeItensDaLista(listaPlana);


            //*TODICTIONARY* retorna um dictionary  
            Dictionary<int, string> dicionarioMateriasFractal = listaMateriasFractal.ToDictionary(k => k.Id, v => v.Descricao);
            //exibindo valor da key 7
            Console.WriteLine(dicionarioMateriasFractal[7]);





            void ExibeItensDaLista(IEnumerable<object> Lista)
            {
                var resultado = Lista.Aggregate((item1, item2) => item1 + ", " + item2);
                Console.WriteLine(resultado);
            }


        }
    }
}

