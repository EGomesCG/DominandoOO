namespace ScreenSound.Modelos;
//o termo internal se refere a visibilidade de classes, somente o projeto pode visualiza-la
//Se declara como public outros projetos podem visualiza-las
internal class Avaliacao
{
    public Avaliacao(int nota) 
    {
        if (nota <= 0) { nota = 0; }
        else if (nota >= 10) { nota = 10; }
        Nota = nota;
    }
    public int Nota { get; }
    //O método static é usa para anexar funções do tipo da classe
    //Leitura: public static: não precisa criar uma instância pode chamar o metodo direto,
    //a avaliação é o tipo que vai retornar,
    //Parse: converte o que recebe e retorna o valor convertido
    //Este método não usar nada da classe, mas, de alguma forma irá ajudar na rotina dela
    public static  Avaliacao Parse(string texto) 
    {
        int nota = int.Parse(texto);
        return new Avaliacao(nota);
    }
}
