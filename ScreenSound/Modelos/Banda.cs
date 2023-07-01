//Tudo que estiver debaixo dessa declaração fará parte dela.
//Posso declara e usar ponto-vírgula, ou,
//Declara-la e abri fechar chaves e colocar minhas classe dentro das chaves, irá funcionar do mesmo jeito
namespace ScreenSound.Modelos;
internal class Banda : IAvaliar
{
    private List<Album> albuns = new List<Album>();
    private List<Avaliacao> notas = new List<Avaliacao>();

    public Banda(string nome)
    {
        Nome = nome;
    }

    public string Nome { get; }
    //Para cada avaliação vc utiliza a propriedade nota
    //Propriedade que faz parte do contarto
    public double Media
    {
        get
        {
            if (notas.Count == 0) return 0;
            else return notas.Average(c => c.Nota);
        }
    }
    public string Resumo { get; set; }
    public IEnumerable<Album> Albuns => albuns;
    //Método que faz parte da propriedade
    public void AdicionarAlbum(Album album) 
    { 
        albuns.Add(album);
    }

    public void AdicionarNota(Avaliacao nota)
    {
        notas.Add(nota);
    }

    public void ExibirDiscografia()
    {
        Console.WriteLine($"Discografia da banda {Nome}");
        foreach (Album album in albuns)
        {
            Console.WriteLine($"Álbum: {album.Nome} ({album.DuracaoTotal})");
        }
    }
}