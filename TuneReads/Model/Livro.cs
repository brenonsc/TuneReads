namespace TuneReads.Model;

public class Livro : Produto
{
    private string editora;
    private int numeroPaginas;
    
    public Livro(int id, string titulo, int tipo, string autor, decimal preco, int estoque, DateOnly dataLancamento, string editora, int numeroPaginas) : base(id, titulo, tipo, autor, preco, estoque, dataLancamento)
    {
        this.editora = editora;
        this.numeroPaginas = numeroPaginas;
    }
    
    //Métodos getters e setters
    public string GetEditora()
    {
        return editora;
    }
    
    public void SetEditora(string editora)
    {
        this.editora = editora;
    }
    
    public int GetNumeroPaginas()
    {
        return numeroPaginas;
    }
    
    public void SetNumeroPaginas(int numeroPaginas)
    {
        this.numeroPaginas = numeroPaginas;
    }

    public override void Visualizar()
    {
        base.Visualizar();
        Console.WriteLine("Editora: " + editora +
                          "\nNúmero de páginas: " + numeroPaginas +
                          "\n************************************************************");
    }
}