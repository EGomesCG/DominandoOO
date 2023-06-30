using ScreenSound.Modelos;

namespace ScreenSound.Menus;
internal class MenuRegistrarBanda : Menu
{
    //Este metodo está no menu pai (virtual) - aqui preciso declarar como override
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        //Isso quer dizer que irá executar o que está no método do menu pai e também que escrevemos aqui.
        base.Executar(bandasRegistradas);
        ExibirTituloDaOpcao("* Registro das bandas *");
        Console.Write("Digite o nome da banda que deseja registrar: ");
        string nomeDaBanda = Console.ReadLine()!;
        Banda banda = new Banda(nomeDaBanda);
        bandasRegistradas.Add(nomeDaBanda, banda);
        Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
        Thread.Sleep(4000);
        Console.Clear();
    }
}
