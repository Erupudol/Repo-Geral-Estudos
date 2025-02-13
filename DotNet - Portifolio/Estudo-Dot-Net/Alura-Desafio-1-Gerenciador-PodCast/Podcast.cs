using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Alura_Desafio_1_Gerenciador_PodCast
{
    public class Podcast
    {
        public string Nome { get; set; }
        public string Host { get; set; }
        public int? TotalEpisodio { get => Episodios.Count(); }
        public IEnumerable<Episodio> Episodios { get; set; }

        public Podcast(string nome, string host) 
        {
            Nome = nome;
            Host = host;
        }

        public string ExibirDetalhes() 
        {
            return @$"Detalhes do Podcast:
                      Nome: {Nome}.
                      Host: {Host}
                      Total de Episodios:{TotalEpisodio}
                      Episodios:
                            {string.Join(@" \n ",Episodios)}";
        }

        public void AdicionarEpisodio() 
        {
            var episodio = new Episodio();

            Console.WriteLine("Digite o numero do episodio:");
            episodio.Numero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Titulo do episodio:");
            episodio.Titulo = Console.ReadLine();

            Console.WriteLine("Digite a duração do episodio:");
            episodio.Duracao = TimeSpan.Parse(Console.ReadLine());            

            Console.WriteLine("Deseja Adicionar um convidado?(S/N)");
            var adicionar = Console.ReadLine();
            while (adicionar == "S") 
            {
                Console.WriteLine("Digite o nome do convidado:");
                episodio.AdicionarConvidado(episodio, Console.ReadLine());
                
                Console.WriteLine("Deseja adicionar outro convidado?(S/N)");
                adicionar = Console.ReadLine();
            }

            Episodios.Append(episodio);
        }
    }

    public class Episodio
    {
        public int Numero { get; set; }
        public string Titulo { get; set; }
        public TimeSpan Duracao { get; set; }
        public string[] Convidados { get; set; }

        public override string ToString()
        {
            return  $"{Numero} - {Titulo}. Duração:{Duracao}. Condidados:{string.Join(", ",Convidados)}";
        }

        public void AdicionarConvidado(Episodio episodio, string convidado)
        {
            episodio.Convidados.Append(convidado);
        }
       
    }
}
