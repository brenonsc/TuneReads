using System.ComponentModel.Design;
using TuneReads.Controller;
using TuneReads.Model;

namespace TuneReads;

class Program
{
    private static ConsoleKeyInfo consoleKeyInfo;
    
    static void Main(string[] args)
    {
        int opcao, tipo = 0, numero, estoque, numeroPaginas, formato;
        string? titulo, autor, editora;
        decimal preco;
        DateOnly dataLancamento;
        ProdutoController prod = new();
        
        while(true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            
            Console.Write("\n************************************************************\n\n" +
                          "\t\t\tTuneReads\n" +
                          "\t      SEU MUNDO DE LIVROS E MÚSICAS\n\n" +
                          "                ,..........   ..........,\n            ,..,'          '.'          ',..,\n           ,' ,'            :            ', ',\n          ,' ,'             :             ', ',\n         ,' ,'              :              ', ',\n        ,' ,'............., : ,.............', ',\n       ,'  '............   '.'   ............'  ',\n        '''''''''''''''''';''';''''''''''''''''''\n                           '''\n\n" +
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
                Console.WriteLine("\nDigite um valor inteiro entre 1 e 8!\n");
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
                    
                    Console.Write("Digite o título do produto: ");
                    titulo = Console.ReadLine();
                    
                    titulo ??= string.Empty;
                    
                    do
                    {
                        Console.Write("Digite o tipo do produto (1 - Música | 2 - Livro): ");
                        tipo = int.Parse(Console.ReadLine());

                        if (tipo != 1 && tipo != 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nOpção Inválida!\n");
                            Console.ResetColor();
                        }
                    } while (tipo != 1 && tipo != 2);
                    
                    Console.Write("Digite o autor/artista do produto: ");
                    autor = Console.ReadLine();
                    
                    autor ??= string.Empty;
                    
                    Console.Write("Digite o preço do produto: ");
                    preco = decimal.Parse(Console.ReadLine());
                    
                    Console.Write("Digite a quantidade em estoque do produto: ");
                    estoque = int.Parse(Console.ReadLine());
                    
                    Console.Write("Digite a data de lançamento do produto (dd/mm/aaaa): ");
                    dataLancamento = DateOnly.Parse(Console.ReadLine());
                    
                    switch (tipo)
                    {
                        case 1:
                            string formatoStr = string.Empty;
                            
                            do
                            {
                                Console.Write("Digite o formato do produto (1 - CD | 2 - Vinil | 3 - Digital): ");
                                formato = int.Parse(Console.ReadLine());
                                
                                if (formato != 1 && formato != 2 && formato != 3)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\nOpção Inválida!\n");
                                    Console.ResetColor();
                                }
                            }
                            while(formato != 1 && formato != 2 && formato != 3);

                            switch (formato)
                            {
                                case 1:
                                    formatoStr = "CD";
                                    break;
                                case 2:
                                    formatoStr = "Vinil";
                                    break;
                                case 3:
                                    formatoStr = "Digital";
                                    break;
                            }
                        
                            Musica ms = new Musica(prod.GerarNumero(), titulo, tipo, autor, preco, estoque, dataLancamento, formatoStr);
                            prod.Cadastrar(ms);
                            break;
                        case 2:
                            Console.Write("Digite a editora do produto: ");
                            editora = Console.ReadLine();

                            editora ??= string.Empty;
                            
                            Console.Write("Digite o número de páginas do produto: ");
                            numeroPaginas = int.Parse(Console.ReadLine());
                            
                            Livro lv = new Livro(prod.GerarNumero(), titulo, tipo, autor, preco, estoque, dataLancamento, editora, numeroPaginas);
                            prod.Cadastrar(lv);
                            break;
                    }
                    KeyPress();
                    break;
                case 2:
                    Console.Write("\nListar todos os Produtos\n");
                    Console.ResetColor();
                    prod.ListarProdutos();
                    KeyPress();
                    Console.Write("\n");
                    break;
                case 3:
                    Console.Write("\nConsultar Produto por número\n");
                    Console.ResetColor();
                    Console.Write("Digite o número do produto: ");
                    numero = int.Parse(Console.ReadLine());

                    prod.ProcurarPorNumero(numero);
                    KeyPress();
                    Console.Write("\n");
                    break;
                case 4:
                    Console.Write("\nAtualizar dados do Produto\n");
                    Console.ResetColor();
                    
                    Console.Write("Digite o número do produto: ");
                    numero = int.Parse(Console.ReadLine());

                    var produto = prod.BuscarNaCollection(numero);

                    if (produto is not null)
                    {
                        Console.Write("Digite o título do produto: ");
                        titulo = Console.ReadLine();
                        titulo ??= string.Empty;
                        
                        Console.Write("Digite o autor/artista do produto: ");
                        autor = Console.ReadLine();
                        
                        autor ??= string.Empty;
                        
                        Console.Write("Digite o preço do produto: ");
                        preco = decimal.Parse(Console.ReadLine());
                        
                        Console.Write("Digite a quantidade em estoque do produto: ");
                        estoque = int.Parse(Console.ReadLine());
                        
                        Console.Write("Digite a data de lançamento do produto (dd/mm/aaaa): ");
                        dataLancamento = DateOnly.Parse(Console.ReadLine());
                        
                        switch (produto.GetTipo())
                        {
                            case 1:
                                string formatoStr = string.Empty;
                                
                                do
                                {
                                    Console.Write("Digite o formato do produto (1 - CD | 2 - Vinil | 3 - Digital): ");
                                    formato = int.Parse(Console.ReadLine());
                                    
                                    if (formato != 1 && formato != 2 && formato != 3)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\nOpção Inválida!\n");
                                        Console.ResetColor();
                                    }
                                }
                                while(formato != 1 && formato != 2 && formato != 3);

                                switch (formato)
                                {
                                    case 1:
                                        formatoStr = "CD";
                                        break;
                                    case 2:
                                        formatoStr = "Vinil";
                                        break;
                                    case 3:
                                        formatoStr = "Digital";
                                        break;
                                }
                            
                                Musica ms = new Musica(numero, titulo, produto.GetTipo(), autor, preco, estoque, dataLancamento, formatoStr);
                                prod.Atualizar(ms);
                                break;
                            case 2:
                                Console.Write("Digite a editora do produto: ");
                                editora = Console.ReadLine();

                                editora ??= string.Empty;
                                
                                Console.Write("Digite o número de páginas do produto: ");
                                numeroPaginas = int.Parse(Console.ReadLine());
                                
                                Livro lv = new Livro(numero, titulo, produto.GetTipo(), autor, preco, estoque, dataLancamento, editora, numeroPaginas);
                                prod.Atualizar(lv);
                                break;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"\nO produto número {numero} não foi encontrado!\n");
                        Console.ResetColor();
                    }
                    KeyPress();
                    break;
                case 5:
                    Console.Write("\nApagar Produto por número\n");
                    Console.ResetColor();
                    
                    Console.Write("Digite o número da conta: ");
                    numero = int.Parse(Console.ReadLine());
                    
                    Console.Write("\n");
                    prod.Deletar(numero);
                    KeyPress();
                    break;
                case 6:
                    Console.Write("\nConsulta por Nome do Produto\n");
                    Console.ResetColor();
                    
                    Console.Write("Digite o título do produto: ");
                    titulo = Console.ReadLine();
                    
                    prod.ListarProdutosPorTitulo(titulo);
                    KeyPress();
                    break;
                case 7:
                    Console.Write("\nConsulta por Tipo do Produto\n");
                    Console.ResetColor();
                    
                    do
                    {
                        Console.Write("Digite o tipo do produto (1 - Música | 2 - Livro): ");
                        tipo = int.Parse(Console.ReadLine());

                        if (tipo != 1 && tipo != 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nOpção Inválida!\n");
                            Console.ResetColor();
                        }
                    } while (tipo != 1 && tipo != 2);
                    
                    prod.ListarProdutosPorTipo(tipo);
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

