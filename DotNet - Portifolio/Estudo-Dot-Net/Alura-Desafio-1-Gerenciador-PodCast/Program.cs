// See https://aka.ms/new-console-template for more information


using Alura_Desafio_1_Gerenciador_PodCast;
using System.Diagnostics.CodeAnalysis;
using System.Linq;


var podcasts = new List<Podcast>() { new Podcast("Podcast 1", "Host 1"), new Podcast("Podcast 2", "Host 2"), new Podcast("Podcast 3", "Host 1"), new Podcast("Podcast 4", "Host 2") };

foreach (var podcast in podcasts)
{
    var x = new Random().Next(10);
    var episodios = new List<Episodio>();

    for (int i = 1; i <= x; i++) 
    {
        var lc = new List<string>{ };
        for (int j = 1; j <= i; j++)
            lc.Add($"Convidado{j}");
        var Ep = new Episodio() { Titulo = $"Teste{i}", Numero = i, Duracao = new TimeSpan(0, i*x, (i+x)*i), Convidados = lc.ToArray() };

        episodios.Add(Ep);
        podcast.Episodios = episodios;
    }

    Console.WriteLine(podcast.ExibirDetalhes());
}




Console.WriteLine("Hello, World!");

