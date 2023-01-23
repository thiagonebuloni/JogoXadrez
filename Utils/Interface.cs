namespace JogoXadrez.Utils;

    public class Interface {

        public static void IShowMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[1] - Jogar");
            Console.WriteLine("[2] - Registrar jogador");
            Console.WriteLine("[3] - Ver ranking");
            Console.WriteLine("[0] - Sair\n");
            
        }


        public static void ICores(string txt, ConsoleColor color) {
            // printa texto na cor selecionada e reseta para cor padrão
            Console.ForegroundColor = color;
            Console.Write(txt);
            Console.ResetColor();
        }


        public static void IVerRanking(List<Jogador> jogadores) {
            
            // ordena jogadores

            // tenta definir a distância entre campos da tabela com base no comprimento dos nomes dos jogadores
            string tab = "\t";
            Console.Clear();
            for (int i = 0; i < jogadores.Count(); i++) {
                if (jogadores[i].NomeJogador.Length > 7) {
                    tab += "\t";
                    break;
                }
            }
            Console.WriteLine("\nJogadores" + tab + "| Vitórias\t| Derrotas\t| Empates");
            Console.WriteLine("=================================================================");

            for (int i = 0; i < jogadores.Count(); i++) {
                // alterna cores na tabela
                if (i % 2 == 0) Console.ForegroundColor = ConsoleColor.DarkGreen;
                else Console.ForegroundColor = ConsoleColor.Green;

                if (jogadores[i].NomeJogador.Length > 14) {
                    Console.WriteLine($"{jogadores[i].NomeJogador}{tab}| {jogadores[i].Vitorias}\t\t| {jogadores[i].Derrotas}\t\t| {jogadores[i].Empates}");
                }
                else if (jogadores[i].NomeJogador.Length < 8){
                    Console.WriteLine($"{jogadores[i].NomeJogador}{tab}\t| {jogadores[i].Vitorias}\t\t| {jogadores[i].Derrotas}\t\t| {jogadores[i].Empates}");
                }
                else {
                    Console.WriteLine($"{jogadores[i].NomeJogador}{tab}| {jogadores[i].Vitorias}{tab}| {jogadores[i].Derrotas}{tab}| {jogadores[i].Empates}");
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("");
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }


        public static void IMostraTabuleiroAtual(string[,] posicoes)
        {   
            
            string[] letras = ("A B C D E F G H").Split();
            string[] numeros = ("8 7 6 5 4 3 2 1").Split();
            
            Console.Clear();
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" ");
            
            int contador = 1;
            bool inverteCores = true;

            for (int i = 0; i < 8; i++)
            {
                Console.Write(" __");
            }
            Console.WriteLine("");
            for (int i = 0; i < 8; i++) {
                Console.Write($"{numeros[i]}");
                for (int j = 0; j < 8; j++) {
                    Console.Write("|");
                    if (inverteCores)
                    {
                        if (contador % 2 != 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.Write(posicoes[i,j]);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write(posicoes[i,j]);
                        }
                    }
                    else
                    {
                        if (contador % 2 != 0)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write(posicoes[i,j]);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.Write(posicoes[i,j]);
                        }
                    }
                    contador++;
                    // if (j == 7) Interface.ICores("|", ConsoleColor.DarkGreen);
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;
                    
                }
                if (inverteCores) inverteCores = false;
                else inverteCores = true;
                // for (int j = 0; j < 8; j++) {
                //     if (posicoes[i,j] == "_X_")
                //         {
                //             Interface.ICores($"{posicoes[i,j]}", ConsoleColor.DarkBlue);
                //         }
                //     else if (posicoes[i,j] == "_O_") Interface.ICores($"{posicoes[i,j]}", ConsoleColor.DarkRed);
                //     else Interface.ICores($"{posicoes[i,j]}", ConsoleColor.DarkGreen);
                //     if (j != 7) Interface.ICores("|", ConsoleColor.DarkGreen);
                // }
                Console.WriteLine("|");
            }
            Console.Write(" ");
            for (int k = 0; k < 8; k++)
            {
                Console.Write($" {letras[k]} ");
            }

        }


}