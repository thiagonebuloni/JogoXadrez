namespace JogoXadrez.Utils;

    public class Jogador
    {
        public string NomeJogador { get; set; }
        public string Senha { get; set; }
        public int Vitorias { get; protected set; }
        public int Derrotas { get; protected set; }
        public int Empates { get; protected set; }
        
        
        public Jogador(string nomeJogador, string senha, int vitorias, int derrotas, int empates)
        {
            NomeJogador = nomeJogador;
            Senha = senha;
            Vitorias = vitorias;
            Derrotas = derrotas;
            Empates = empates;
        }

    

        public void IncrementaVitorias()
        {
            Vitorias++;
        }

        public void IncrementaDerrotas()
        {
            Derrotas++;
        }

        public void IncrementaEmpates()
        {
            Empates++;
        }


        private static string GetPass()
        {
            string pass = string.Empty;
            ConsoleKey key;

            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    Console.Write("\b \b");
                    pass = pass[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    pass += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);
            
            Console.WriteLine();
            return pass;
        }

        public static void RegistrarJogador(List<Jogador> jogadores, int numeroJogador)
        {
            Console.Clear();
            
            string nomeJogador = "";

            do
            {
                Console.Write($"Digite o nome do(a) jogador(a) {numeroJogador + 1}: ");
                nomeJogador = Console.ReadLine()!;
                
                if (string.IsNullOrEmpty(nomeJogador))
                {
                    Interface.ICores("Digite um nome válido\n Não pode ser vazio.", ConsoleColor.Red);
                    Interface.ICores("Tecle qualquer coisa para continuar", ConsoleColor.Red);
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            while (string.IsNullOrEmpty(nomeJogador));

            string senha = "";
            bool pass = false;

            do
            {
                Console.Write($"Digite uma senha: ");
                senha = GetPass();

                if (string.IsNullOrEmpty(senha))
                {
                    Interface.ICores("\nDigite uma senha válida\nMínimo 8 caracteres e não pode ser vazia.", ConsoleColor.Red);
                    Interface.ICores("\nPressione qualquer tecla para voltar", ConsoleColor.Red);
                    Console.ReadKey();
                    break;
                }
                

                if (senha.Length < 8)
                {
                    pass = false;
                    Interface.ICores("\nDigite uma senha válida\nMínimo 8 caracteres.", ConsoleColor.Red);
                    Interface.ICores("\nPressione qualquer tecla para voltar", ConsoleColor.Red);
                    Console.ReadKey();
                    break;
                }
                pass = true;
            }
            while (!pass);

            if (pass)
            {
                Jogador novoJogador = new Jogador(nomeJogador, senha, 0, 0, 0);
                jogadores.Add(novoJogador);
            }
        }


        public static void OrdenarJogadores(List<Jogador> jogadores)
        {
            
            for (int i = 0; i < jogadores.Count() - 1; i++)
            {
                for (int j = i + 1; j < jogadores.Count(); j++)
                {
                    if (jogadores[i].Vitorias < jogadores[j].Vitorias)
                    {
                        Jogador tmp = jogadores[i];
                        jogadores[i] = jogadores[j];
                        jogadores[j] = tmp;
                    }
                }
            }
        }
}