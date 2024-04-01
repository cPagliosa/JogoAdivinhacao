namespace JogoAdivinhacaoConsoleApp
{
    internal class Program
    {
        static int x = 0;
        static int pontos = 0;
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                iniciar();
                Console.WriteLine("Você quer rejogar?\n[1] Sim   [2] Não");
                Console.Write("qual a sua escolha: ");
                int h = Convert.ToInt32(Console.ReadLine());
                if (h == 2) break;

            }

        }

        static void iniciar()
        {
            Console.WriteLine("****************************************");
            Console.WriteLine("** Bem vindo ao jogo da Adivinhação!! **");
            Console.WriteLine("****************************************\n");
            Console.WriteLine("->Encontre o numero segreto entre 1 e 20!\n");
            Console.WriteLine("Escolha o nivel de difilcudade:\n[1] Facil   [2] Medio   [3] Dificio");
            Console.Write("Escolha: ");
            int difi = Convert.ToInt32(Console.ReadLine());
            gerarNumero();
            difilcudade(difi);
        }

        static void gerarNumero()
        {
            Random random = new Random();
            x = random.Next(1, 20);
        }

        static void difilcudade(int f)
        {
            pontos = 1000;
            if (f == 1) game(15);
            else if (f == 2) game(10);
            else if (f == 3) game(5);
            else Console.WriteLine("Difilcudade Invalida!!");
        }

        static void valida(int n)
        {
            if (n != x)
            {
                if (n > x)
                {
                    Console.WriteLine("O seu chute é Maior que o numero segreto.");
                    penalidade(n);
                }
                else
                {
                    Console.WriteLine("O seu chute é Menor que o numero segreto.");
                    penalidade(n);
                }
            }
            else
            {
                Console.WriteLine($"\nPrabéns!!! Voce arcertou!!! \nSua pontuação foi de {pontos}.\n");
            }
        }

        static void penalidade(int n)
        {
            if (n > x)
            {
                pontos -= (n - x) / 2;
            }else if (n < x)
            {
                pontos -= (x - n) / 2;
            }
            
        }

        static void game(int tentativa)
        {
            int chute = 0;
            for (int i = 1; i <= tentativa; i++)
            {
                Console.WriteLine($"\nTentativa {i} de {tentativa}.");
                Console.WriteLine("---------------------------------------------");
                Console.Write($"Qual é o seu {i}º chute? : ");
                chute = Convert.ToInt32(Console.ReadLine());
                if (chute == x)
                {
                    valida(chute);
                    break;
                }
                else valida(chute);
                int g = i + 1;
                if ( g > tentativa)
                {
                    Console.WriteLine($"\nVocê não consegiu acertar o numero segreto que era {x}.\n");
                }
            }

        }
    }
}
