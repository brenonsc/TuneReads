namespace TuneReads;

class Program
{
    private static ConsoleKeyInfo consoleKeyInfo;
    
    static void Main(string[] args)
    {
        int opcao;
        
        while(true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            
            Console.Write("\n************************************************************\n\n" +
                          "\t\t\tTuneReads\n" +
                          "\t      SEU MUNDO DE LIVROS E MÚSICAS\n\n" +
                          "************************************************************\n\n" +
                          "\t\t1 - Cadastrar produto\n" +
                          "\t\t2 - Listar todos os Produtos\n" +
                          "\t\t3 - Consultar Produto por número\n" +
                          "\t\t4 - Atualizar dados do Produto\n" +
                          "\t\t5 - Apagar Produto\n" +
                          "\t\t6 - Consulta por nome do Produto\n" +
                          "\t\t7 - Consulta por tipo do Produto\n" +
                          "\t\t8 - Sair\n\n" +
                          "************************************************************");
            
            Console.Write("\nDigite a opção desejada: ");

            //Tratamento de exceção para entrada de dados em formato incorreto
            try
            {
                opcao = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nDigite um valor inteiro entre 1 e 9!\n");
                opcao = 0;
                Console.ResetColor();
                KeyPress();
                continue;
            }

            if (opcao == 8)
            {
                Console.WriteLine("\nA TuneReads agradece a preferência!\n");
                Sobre();
                Console.ResetColor();
                System.Environment.Exit(0);
            }

            switch (opcao)
            {
                case 1:
                    Console.Write("\nCadastrar Produto\n");
                    Console.ResetColor();
                    KeyPress();
                    break;
                case 2:
                    Console.Write("\nListar todos os Produtos\n");
                    Console.ResetColor();
                    KeyPress();
                    break;
                case 3:
                    Console.Write("\nConsultar Produto por número\n");
                    Console.ResetColor();
                    KeyPress();
                    break;
                case 4:
                    Console.Write("\nAtualizar dados do Produto\n");
                    Console.ResetColor();
                    KeyPress();
                    break;
                case 5:
                    Console.Write("\nApagar Produto por número\n");
                    Console.ResetColor();
                    KeyPress();
                    break;
                case 6:
                    Console.Write("\nConsulta por Nome do Produto\n");
                    Console.ResetColor();
                    KeyPress();
                    break;
                case 7:
                    Console.Write("\nConsulta por Tipo do Produto\n");
                    Console.ResetColor();
                    KeyPress();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nOpção Inválida!\n");
                    Console.ResetColor();
                    
                    KeyPress();
                    break;
            }
        } 
        
        static void Sobre()
        {
            Console.Write("####################################################\n" +
                          "\tProjeto desenvolvido por: \n" +
                          "\tBreno Henrique - brenonsc@gmail.com\n" +
                          "\tgithub.com/brenonsc\n" +
                          "####################################################");
        }
        
        static void KeyPress()
        {
            do
            {
                Console.Write("Pressione Enter para continuar...");
                consoleKeyInfo = Console.ReadKey();
            } while (consoleKeyInfo.Key != ConsoleKey.Enter);
        }
    }
}

