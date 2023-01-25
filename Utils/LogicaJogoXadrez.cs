namespace JogoXadrez.Utils;


    public class LogicaJogoXadrez
    {
        public static void Jogar(List<Jogador> jogadores)
        {
            int indexJogadorAtivo1 = -1;
            int indexJogadorAtivo2 = -1;


            // se não existirem jogadores registrados, cria 2 novos
            if (jogadores.Count() == 0)
            {    
                Jogador.RegistrarJogador(jogadores, jogadores.Count());
                Jogador.RegistrarJogador(jogadores, jogadores.Count());
                indexJogadorAtivo1 = 0;
                indexJogadorAtivo2 = 1;
            }
            else if (jogadores.Count() == 1)
            {   // se existir apenas 1 jogador criado, cria o segundo
                Jogador.RegistrarJogador(jogadores, 1);

            }
            else    // seleciona jogadores já cadastrados
            {
                while (true)
                {
                    // usuário seleciona os jogadores
                    while (indexJogadorAtivo1 < 0 || indexJogadorAtivo1 >= jogadores.Count())    // valida entrada para jogador 1
                    {
                        Console.Clear();
                        for (int i = 0; i < jogadores.Count(); i++)
                        {
                            if (i % 2 == 0) Console.ForegroundColor = ConsoleColor.DarkGreen;
                            else Console.ForegroundColor = ConsoleColor.Green;

                            Console.WriteLine($"{i + 1} - {jogadores[i].NomeJogador}");
                        }
                        Console.ForegroundColor = ConsoleColor.Green;

                        try
                        {
                            Console.Write("Selecione o jogador(a) 1: ");
                            indexJogadorAtivo1 = (int.Parse(Console.ReadLine()!) - 1);
                        }
                        catch (Exception)
                        {
                            Interface.ICores("Número de jogador inválido. Escolha novamente.\n", ConsoleColor.Red);
                            Interface.ICores("Aperte qualquer tecla para continuar...", ConsoleColor.Red);
                            Console.ReadKey();
                        }
                    }

                    while (indexJogadorAtivo2 < 0 || indexJogadorAtivo2 >= jogadores.Count() || indexJogadorAtivo2 == indexJogadorAtivo1)    // valida entrada para jogador 2
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;

                        Console.Clear();
                        for (int i = 0; i < jogadores.Count(); i++)
                        {
                            if (i % 2 == 0) Console.ForegroundColor = ConsoleColor.DarkGreen;
                            else Console.ForegroundColor = ConsoleColor.Green;

                            Console.WriteLine($"{i + 1} - {jogadores[i].NomeJogador}");
                        }
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        
                        try
                        {
                            Console.Write("Selecione o jogador(a) 2: ");
                            indexJogadorAtivo2 = (int.Parse(Console.ReadLine()!) - 1);
                            if (indexJogadorAtivo1 == indexJogadorAtivo2)
                            {
                                Interface.ICores("Jogador(a) 2 deve ser diferente de jogador(a) 1.\nAperte qualquer tecla para continuar. ", ConsoleColor.Red);
                                Console.ReadKey();
                            }

                        }
                        catch (Exception)
                        {
                            Interface.ICores("Número de jogador inválido. Escolha novamente.\n", ConsoleColor.Red);
                            Interface.ICores("Aperte qualquer tecla para continuar...", ConsoleColor.Red);
                            Console.ReadKey();
                        }

                    }
                    Jogador.OrdenarJogadores(jogadores);
                    break;
                }


                // cria e popula posicoes
                Peca[,] posicoes = new Peca[8,8];

                // instancia peças e posicoes iniciais

                // pretas
                Peca torrePreto0 = new Peca(0, ConsoleColor.Black, Peca.Pecas.TORRE, "8A");
                posicoes[0,0] = torrePreto0;
                Peca cavaloPreto0 = new Peca(1, ConsoleColor.Black, Peca.Pecas.CAVALO, "8B");
                posicoes[0,1] = cavaloPreto0;
                Peca bispoPreto0 = new Peca(2, ConsoleColor.Black, Peca.Pecas.BISPO, "8C");
                posicoes[0,2] = bispoPreto0;
                Peca rainhaPreto = new Peca(3, ConsoleColor.Black, Peca.Pecas.RAINHA, "8D");
                posicoes[0,3] = rainhaPreto;
                Peca reiPreto = new Peca(4, ConsoleColor.Black, Peca.Pecas.REI, "8E");
                posicoes[0,4] = reiPreto;
                Peca bispoPreto1 = new Peca(5, ConsoleColor.Black, Peca.Pecas.BISPO, "8F");
                posicoes[0,5] = bispoPreto1;
                Peca cavaloPreto1 = new Peca(6, ConsoleColor.Black, Peca.Pecas.CAVALO, "8G");
                posicoes[0,6] = cavaloPreto1;
                Peca torrePreto1 = new Peca(7, ConsoleColor.Black, Peca.Pecas.TORRE, "8H");
                posicoes[0,7] = torrePreto1;
                Peca peaoPreto0 = new Peca(8, ConsoleColor.Black, Peca.Pecas.PEAO, "7A");
                posicoes[1,0] = peaoPreto0;
                Peca peaoPreto1 = new Peca(9, ConsoleColor.Black, Peca.Pecas.PEAO, "7B");
                posicoes[1,1] = peaoPreto1;
                Peca peaoPreto2 = new Peca(10, ConsoleColor.Black, Peca.Pecas.PEAO, "7C");
                posicoes[1,2] = peaoPreto2;
                Peca peaoPreto3 = new Peca(11, ConsoleColor.Black, Peca.Pecas.PEAO, "7D");
                posicoes[1,3] = peaoPreto3;
                Peca peaoPreto4 = new Peca(12, ConsoleColor.Black, Peca.Pecas.PEAO, "7E");
                posicoes[1,4] = peaoPreto4;
                Peca peaoPreto5 = new Peca(13, ConsoleColor.Black, Peca.Pecas.PEAO, "7F");
                posicoes[1,5] = peaoPreto5;
                Peca peaoPreto6 = new Peca(14, ConsoleColor.Black, Peca.Pecas.PEAO, "7G");
                posicoes[1,6] = peaoPreto6;
                Peca peaoPreto7 = new Peca(15, ConsoleColor.Black, Peca.Pecas.PEAO, "7H");
                posicoes[1,7] = peaoPreto7;
                
                // brancas
                Peca peaoBranco0 = new Peca(8, ConsoleColor.White, Peca.Pecas.PEAO, "2A");
                posicoes[6,0] = peaoBranco0;
                Peca peaoBranco1 = new Peca(9, ConsoleColor.White, Peca.Pecas.PEAO, "2B");
                posicoes[6,1] = peaoBranco1;
                Peca peaoBranco2 = new Peca(10, ConsoleColor.White, Peca.Pecas.PEAO, "2C");
                posicoes[6,2] = peaoBranco2;
                Peca peaoBranco3 = new Peca(11, ConsoleColor.White, Peca.Pecas.PEAO, "2D");
                posicoes[6,3] = peaoBranco3;
                Peca peaoBranco4 = new Peca(12, ConsoleColor.White, Peca.Pecas.PEAO, "2E");
                posicoes[6,4] = peaoBranco4;
                Peca peaoBranco5 = new Peca(13, ConsoleColor.White, Peca.Pecas.PEAO, "2F");
                posicoes[6,5] = peaoBranco5;
                Peca peaoBranco6 = new Peca(14, ConsoleColor.White, Peca.Pecas.PEAO, "2G");
                posicoes[6,6] = peaoBranco6;
                Peca peaoBranco7 = new Peca(15, ConsoleColor.White, Peca.Pecas.PEAO, "2H");
                posicoes[6,7] = peaoBranco7;
                Peca torreBranco0 = new Peca(0, ConsoleColor.White, Peca.Pecas.TORRE, "1A");
                posicoes[7,0] = torreBranco0;
                Peca cavaloBranco0 = new Peca(1, ConsoleColor.White, Peca.Pecas.CAVALO, "1B");
                posicoes[7,1] = cavaloBranco0;
                Peca bispoBranco0 = new Peca(2, ConsoleColor.White, Peca.Pecas.BISPO, "1C");
                posicoes[7,2] = bispoBranco0;
                Peca rainhaBranco = new Peca(3, ConsoleColor.White, Peca.Pecas.RAINHA, "1D");
                posicoes[7,3] = rainhaBranco;
                Peca reiBranco = new Peca(4, ConsoleColor.White, Peca.Pecas.REI, "1E");
                posicoes[7,4] = reiBranco;
                Peca bispoBranco1 = new Peca(5, ConsoleColor.White, Peca.Pecas.BISPO, "1F");
                posicoes[7,5] = bispoBranco1;
                Peca cavaloBranco1 = new Peca(6, ConsoleColor.White, Peca.Pecas.CAVALO, "1G");
                posicoes[7,6] = cavaloBranco1;
                Peca torreBranco1 = new Peca(7, ConsoleColor.White, Peca.Pecas.TORRE, "1H");
                posicoes[7,7] = torreBranco1;

                
                Peca nulo = new Peca(99, ConsoleColor.White, Peca.Pecas.NULL, "  "); // espaços vazios

                for (int i = 2; i < 6; i++) {
                    for (int j = 0; j < 8; j++) {
                        posicoes[i,j] = nulo;
                    }
                }

                // int contador = 1;
                
                // for (int i = 0; i < 8; i++) {
                //     for (int j = 0; j < 8; j++) {
                //         if (posicoes[i,j] == null) posicoes[i,j] = $"  ";
                //         contador++;
                //     }

                // }


                string jogadorTurno = "Brancas";
                // int jogadaAtual = 0;


                // laço do jogo
                while (true)
                {
                    Interface.IMostraTabuleiroAtual(posicoes);

                    // alterna turnos
                    if (jogadorTurno == "Brancas") jogadorTurno = "Pretas";
                    else jogadorTurno = "Brancas";
                    Console.ReadKey();
                    break;

                }

                Jogador.OrdenarJogadores(jogadores);
                ManipulaArquivo.AtualizaArquivo(jogadores);

            }



        }

        
        
}