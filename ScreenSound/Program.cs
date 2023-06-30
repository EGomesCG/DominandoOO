//Quando uma classe tem muitas linhas, significa que ela tem mais de uma responsabilidade
using ScreenSound.Menus;
using ScreenSound.Modelos;
using OpenAI_API;

//Aqui é a classe principal do sistema - O programa começa por aqui
internal class Program
{
    //O sistema é iniciado pelo método principal Main()
    //Que começa recebendo uma lista de string
    private static void Main(string[] args)
    {
        var cliente = new OpenAIAPI();

        Banda ira = new("Ira!");
        ira.AdicionarNota(new Avaliacao(10));
        ira.AdicionarNota(new Avaliacao(8));
        ira.AdicionarNota(new Avaliacao(6));
        Banda beatles = new Banda("The Beatles");
        //Classe Dictionary é uma classe interna do: System.Collections.Generic que é possivel ser visivel em todo sistema
        //Chave do dicionario é uma string e a lista são as notas, ou seja,
        //Nosso dicionário tem um tipo (string) banda e é composto por uma lista de notas d inteiros
        //Queremos achar no dicionário a banda e sua lista de notas
        Dictionary<string, Banda> bandasRegistradas = new();
        bandasRegistradas.Add(ira.Nome, ira);
        bandasRegistradas.Add(beatles.Nome, beatles);
        //A chave é int. pois, é o que queremos achar
        //Do tipo Menu
        Dictionary<int, Menu> opcoes = new();
        opcoes.Add(1, new MenuRegistrarBanda());
        opcoes.Add(2, new MenuRegistrarAlbum());
        opcoes.Add(3, new MenuMostrarBanda());
        opcoes.Add(4, new MenuAvaliarBanda());
        opcoes.Add(5, new MenuAvaliarAlbum());
        opcoes.Add(6, new MenuExibirDetalhes());
        opcoes.Add(-1, new MenuSair());

        void ExibirLogo()
        {
            Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
            Console.WriteLine("Boas vindas ao Screen Sound 2.0!");
        }

        void ExibirOpcoesDoMenu()
        {
            ExibirLogo();
            Console.WriteLine("\nDigite 1 para registrar uma banda");
            Console.WriteLine("Digite 2 para registrar o álbum de uma banda");
            Console.WriteLine("Digite 3 para mostrar todas as bandas");
            Console.WriteLine("Digite 4 para avaliar uma banda");
            Console.WriteLine("Digite 5 para avaliar uma álbum");
            Console.WriteLine("Digite 6 para exibir os detalhes de uma banda");
            Console.WriteLine("Digite -1 para sair");

            Console.Write("\nDigite a sua opção: ");
            string opcaoEscolhida = Console.ReadLine()!;
            int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

            if (opcoes.ContainsKey(opcaoEscolhidaNumerica))
            {
                Menu menuExibido = opcoes[opcaoEscolhidaNumerica];
                menuExibido.Executar(bandasRegistradas);
                if(opcaoEscolhidaNumerica > 0) { ExibirOpcoesDoMenu(); }
            } else
            {
                Console.WriteLine("Opção inválida");
            }            
        }
        ExibirOpcoesDoMenu();
    }
}