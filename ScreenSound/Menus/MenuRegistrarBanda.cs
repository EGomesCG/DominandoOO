using OpenAI_API;
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

        var cliente = new OpenAIAPI("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");
        //Par começar uma nova conversa. 
        var chat = cliente.Chat.CreateConversation();
        //Coloque uma mensagem.
        chat.AppendSystemMessage($"Resuma a banda {nomeDaBanda}. Em 1 parágrafo. Adote um estilo informal.");
        //Vou pega a resposta numa variavel. Este método é executa de forma assincrona, ou seja,
        //Ele não vai para na linha 19 <--, O C# vai continuar seguinto para próxima linha, então, precisamos informa o C# disto, com o await.
        //Para usar o await precisamos mudar o método para async que ficaria com a Task<>, mas, existe outra alternativa, que iremos usar
        //string resposta = await chat.GetResponseFromChatbotAsync();
        //Essa tarefa irei pedi para esperar -> .GetAwaiter() e depois que esperar irei pegar o resultado -> .GetResult(), que no caso irá retorna uma string
        string resposta = chat.GetResponseFromChatbotAsync().GetAwaiter().GetResult();
        //Colocando o resultado em banda na propriedade Resumo.
        banda.Resumo = resposta;
        //Agora preciso exibir o resultado disto em exibir detalhes da banda....

        Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}
