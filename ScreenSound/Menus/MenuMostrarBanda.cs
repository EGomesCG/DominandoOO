using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuMostrarBanda : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        //Isso quer dizer que irá executar o que está no método do menu e também que escrevemos aqui.
        base.Executar(bandasRegistradas);
        ExibirTituloDaOpcao("* Exibindo todas as bandas registradas na nossa aplicação *");

        foreach (string banda in bandasRegistradas.Keys)
        {
            Console.WriteLine($"Banda: {banda}");
        }

        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }


}
