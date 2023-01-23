using JogoXadrez.Utils;
using System.Text.Json;

namespace JogoXadrez;


    class Program
    {

        static void Main(string[] args)
        {

            List<Jogador> jogadores = new List<Jogador>();

            
            ManipulaArquivo.LeArquivo(jogadores);

            int opcao = -1;
            do
            {
                Interface.IShowMenu();
                Console.Write("O que você quer fazer? ");
                    try
                    {
                        opcao = int.Parse(Console.ReadLine()!);
                    }
                    catch (Exception)
                    {
                        Interface.ICores("Opção inválida. Aperte Enter para tentar novamente.", ConsoleColor.Red);
                        Console.ReadKey();
                        continue;
                    }

                switch (opcao){
                    case 0:
                        break;
                    case 1:
                        LogicaJogoXadrez.Jogar(jogadores);
                        break;
                    case 2:
                        Jogador.RegistrarJogador(jogadores, jogadores.Count());
                        break;
                    case 3:
                        Interface.IVerRanking(jogadores);
                        break;
                    default:
                        Interface.ICores("Opção inválida. Aperte enter para tentar novamente.", ConsoleColor.Red);
                        Console.ReadKey();
                        break;
                }
                    

            } while (opcao != 0);

        }
}