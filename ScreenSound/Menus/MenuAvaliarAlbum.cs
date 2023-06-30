using ScreenSound.Modelos;
namespace ScreenSound.Menus;
internal class MenuAvaliarAlbum : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        //Isso quer dizer que irá executar o que está no método do menu(pai) e também que escrevemos aqui.
        base.Executar(bandasRegistradas);
        ExibirTituloDaOpcao("* Avaliar Álbum *");
        Console.Write("Digite o nome da banda que deseja conhecer melhor: ");
        string nomeDaBanda = Console.ReadLine()!;
        if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            Banda banda = bandasRegistradas[nomeDaBanda];
            Console.Write("Agora digite o título do álbum: ");
            string tituloAlbum = Console.ReadLine()!;
            //Só vai entrar no if que o título digitado existir na banda
            //Vc só vai entrar se se nome for igual algum título do album
            if(banda.Albuns.Any(a => a.Nome.Equals(tituloAlbum)))
            {
                //Na lista de álbuns irei pegar o primeiro que atenda essa condição
                Album album = banda.Albuns.First(a => a.Nome.Equals(tituloAlbum));
                Console.WriteLine($"Qual nota o álbum {tituloAlbum} merece:");
                Avaliacao nota = Avaliacao.Parse(Console.ReadLine()!);
                album.AdicionarNota(nota);
                Console.WriteLine($"\nA nota {nota.Nota} foi registrada com sucesso para o álbum {tituloAlbum} da banda {nomeDaBanda}");
                Thread.Sleep(1000);
                Console.Clear();
            } else
            {
                Console.WriteLine($"\nNão foi possivel encontrar este titulo {tituloAlbum}!");
                Console.WriteLine("Digite uma tecla para voltar ao menu principal");
                Console.ReadKey();
                Console.Clear();
            }
        } else 
        {
            Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }

 }
