namespace JogoXadrez.Utils;

public class Peca
{

    public int Id { get; private set; }
    public ConsoleColor Cor { get; private set; }
    public Pecas Tipo { get; set; }
    public string UniCode { get; private set; }
    public string Posicao { get; set; } = null!;
    public bool IsAlive { get; set; } = true;

    public Peca(int id, ConsoleColor cor, Pecas tipo, string posicao)
    {
        Id = id;
        Cor = cor;
        Console.ForegroundColor = Cor;
        Tipo = tipo;
        Posicao = posicao;
        IsAlive = true;
        UniCode = Simbolo(tipo, cor)!;
    }

    private string? Simbolo(Pecas tipo, ConsoleColor cor)
    {
        if (cor == ConsoleColor.White)
        {
            switch (tipo)
            {
                case Peca.Pecas.TORRE:
                    return "\u2656 ";
                case Peca.Pecas.CAVALO:
                    return "\u2658 ";
                case Peca.Pecas.BISPO:
                    return "\u2657 ";
                case Peca.Pecas.RAINHA:
                    return "\u2655 ";
                case Peca.Pecas.REI:
                    return "\u2654 ";
                case Peca.Pecas.PEAO:
                    return "\u2659 ";
            }
        }
        else if (cor == ConsoleColor.Black)
        {
            switch (tipo)
            {
                case Peca.Pecas.TORRE:
                    return "\u265C ";
                case Peca.Pecas.CAVALO:
                    return "\u265E ";
                case Peca.Pecas.BISPO:
                    return "\u265D ";
                case Peca.Pecas.RAINHA:
                    return "\u265B ";
                case Peca.Pecas.REI:
                    return "\u265A ";
                case Peca.Pecas.PEAO:
                    return "\u265F ";
            }
        }
        return "  ";
    }

    public enum Pecas
    {
        TORRE,
        CAVALO,
        BISPO,
        REI,
        RAINHA,
        PEAO,
        NULL
    }

    


}