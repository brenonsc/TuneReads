using TuneReads.Model;
using TuneReads.Repository;
namespace TuneReads.Controller;

public class ProdutoController : IProdutoRepository
{
    private readonly List<Produto> listaProdutos = new();
    int numero = 0;
    
    public void ProcurarPorNumero(int numero)
    {
        var produto = BuscarNaCollection(numero);

        if (produto is not null)
            produto.Visualizar();
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nO produto número {numero} não foi encontrado!");
            Console.ResetColor();
        }
    }

    public void ListarProdutos()
    {
        if (listaProdutos.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Nenhum produto cadastrado!\n");
            Console.ResetColor();
        }

        else
        {
            foreach (var produto in listaProdutos)
            {
                produto.Visualizar();
            }
        }
    }

    public void Cadastrar(Produto produto)
    {
        listaProdutos.Add(produto);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nO produto {produto.GetId()} foi criado com sucesso!\n");
        Console.ResetColor();
    }

    public void Atualizar(Produto produto)
    {
        var buscaProduto = BuscarNaCollection(produto.GetId());
        
        if (buscaProduto is not null)
        {
            var index = listaProdutos.IndexOf(buscaProduto);
            listaProdutos[index] = produto;
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nO produto {produto.GetId()} foi atualizado com sucesso!\n");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nO produto número {produto.GetId()} não foi encontrado!\n");
            Console.ResetColor();
        }
    }

    public void Deletar(int numero)
    {
        var produto = BuscarNaCollection(numero);

        if (produto is not null)
            if (listaProdutos.Remove(produto))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"O produto número {numero} foi removido com sucesso!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"O produto número {numero} não foi removido!");
                Console.ResetColor();
            }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"O produto número {numero} não foi encontrado!");
            Console.ResetColor();
        }
    }

    public void ListarProdutosPorTitulo(string titulo)
    {
        var produtosPorTitulo = from produto in listaProdutos
            where produto.GetTitulo().ToUpper().Contains(titulo.ToUpper())
            select produto;
        
        produtosPorTitulo.ToList().ForEach(p => p.Visualizar());
    }

    public void ListarProdutosPorTipo(int tipo)
    {
        var produtosPorTipo = from produto in listaProdutos
            where produto.GetTipo() == tipo
            select produto;
        
        produtosPorTipo.ToList().ForEach(p => p.Visualizar());
    }
    
    
    //Métodos Auxiliares
    public int GerarNumero()
    {
        numero++;
        return numero;
    }
    
    //Método para buscar um objeto Produto na lista de Produtos pelo número
    public Produto? BuscarNaCollection(int numero)
    {
        foreach (var produto in listaProdutos)
        {
            if (produto.GetId() == numero)
            {
                return produto;
            }
        }

        return null;
    }
}