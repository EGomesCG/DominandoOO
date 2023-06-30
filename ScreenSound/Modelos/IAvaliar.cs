namespace ScreenSound.Modelos;
//Toda classe que possui essa interface tem um contrato, ou seja, precisa implementar tudo que contem no seu corpo.
//Aqui não defino como a função ou a propriedade se comporta, mas, sim na classe
internal interface IAvaliar
{
    //Tudo que tem dentro se chama assinatura - clausa do contrato
    void AdicionarNota(Avaliacao nota);
    double Media { get; }
}
