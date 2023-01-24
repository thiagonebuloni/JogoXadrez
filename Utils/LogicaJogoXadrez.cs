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
                string[,] posicoes = new string[8,8];

                // instancia peças
                Peca peaoBranco1 = new Peca(1, Cor.BRANCA, Peca.Pecas.PEAO, "2A", true);
                posicoes[6,0] = peaoBranco1.UniCode;
                Peca peaoBranco2 = new Peca(2, Cor.BRANCA, Peca.Pecas.PEAO, "2B", true);
                posicoes[6,1] = peaoBranco2.UniCode;
                Peca peaoBranco3 = new Peca(3, Cor.BRANCA, Peca.Pecas.PEAO, "3C", true);
                posicoes[6,2] = peaoBranco3.UniCode;
                
                int contador = 1;
                
                for (int i = 0; i < 8; i++) {
                    for (int j = 0; j < 8; j++) {
                        if (posicoes[i,j] == null) posicoes[i,j] = $"  ";
                        contador++;
                    }

                }


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