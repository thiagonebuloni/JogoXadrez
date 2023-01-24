namespace JogoXadrez.Utils;

public class Peca
{

    public int Id { get; private set; }
    public Cor Cor { get; private set; }
    public Pecas Tipo { get; set; }
    public string UniCode { get; private set; }
    public string Posicao { get; set; } = null!;
    public bool IsAlive { get; set; } = true;

    public Peca(int id, Cor cor, Pecas tipo, string posicao, bool isAlive)
    {
        Id = id;
        Cor = cor;
        Tipo = tipo;
        Posicao = posicao;
        IsAlive = isAlive;

        if (cor == Cor.BRANCA) UniCode = "\u2659 ";
        else UniCode = "\u265F ";
    }

    public enum Pecas
    {
        TORRE,
        CAVALO,
        BISPO,
        REI,
        RAINHA,
        PEAO
    }

    


}