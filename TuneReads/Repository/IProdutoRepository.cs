using TuneReads.Model;
namespace TuneReads.Repository;

public interface IProdutoRepository
{
    //Métodos CRUD
    public void ProcurarPorNumero(int numero);
    public void ListarProdutos();
    public void Cadastrar(Produto produto);
    public void Atualizar(Produto produto);
    public void Deletar(int numero);
    
    public void ListarProdutosPorTitulo(string titulo);
    public void ListarProdutosPorTipo(int tipo);
}