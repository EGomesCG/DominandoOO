using ScreenSound.Modelos;
namespace ScreenSound.Menus;
internal class Menu
{
    public void ExibirTituloDaOpcao(string titulo)
    {
        int quantidadeDeLetras = titulo.Length;
        string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '=');
        Console.WriteLine(asteriscos);
        Console.WriteLine(titulo);
        Console.WriteLine(asteriscos + "\n");
    }
    public virtual void Executar(Dictionary<string, Banda> bandasRegistradas) 
    {
        //O executar pai tem conteúdo. A implementação nas classes filhas é opcional.
        Console.Clear();
    }
}
