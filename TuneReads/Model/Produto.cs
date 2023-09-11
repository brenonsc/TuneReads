using TuneReads.Repository;

namespace TuneReads.Model;

public abstract class Produto
{
    private int id;
    private string titulo;
    private int tipo;
    private string autor;
    private decimal preco;
    private int estoque;
    private DateOnly dataLancamento;
    
    public Produto(int id, string titulo, int tipo, string autor, decimal preco, int estoque, DateOnly dataLancamento)
    {
        this.id = id;
        this.titulo = titulo;
        this.tipo = tipo;
        this.autor = autor;
        this.preco = preco;
        this.estoque = estoque;
        this.dataLancamento = dataLancamento;
    }
    
    //Métodos getters e setters
    public int GetId()
    {
        return id;
    }
    
    public void SetId(int id)
    {
        this.id = id;
    }
    
    public string GetTitulo()
    {
        return titulo;
    }
    
    public void SetTitulo(string titulo)
    {
        this.titulo = titulo;
    }
    
    public int GetTipo()
    {
        return tipo;
    }
    
    public void SetTipo(int tipo)
    {
        this.tipo = tipo;
    }
    
    public string GetAutor()
    {
        return autor;
    }
    
    public void SetAutor(string autor)
    {
        this.autor = autor;
    }
    
    public decimal GetPreco()
    {
        return preco;
    }
    
    public void SetPreco(decimal preco)
    {
        this.preco = preco;
    }
    
    public int GetEstoque()
    {
        return estoque;
    }
    
    public void SetEstoque(int estoque)
    {
        this.estoque = estoque;
    }
    
    public DateOnly GetDataLancamento()
    {
        return dataLancamento;
    }
    
    public void SetDataLancamento(DateOnly dataLancamento)
    {
        this.dataLancamento = dataLancamento;
    }
    
    public virtual void Visualizar()
    {
        string tipo = "";

        switch (this.tipo)
        {
            case 1:
                tipo = "Música";
                break;
            case 2:
                tipo = "Livro";
                break;
        }

        Console.WriteLine($"\nDados do Produto: {this.id}\n" +
                          "************************************************************" +
                          "\nTítulo: " + this.titulo +
                          "\nAutor ou artista: " + this.autor +
                          "\nTipo: " + tipo +
                          "\nValor: " + (this.preco).ToString("C") +
                          "\nEstoque: " + this.estoque +
                          "\nData de lançamento: " + this.dataLancamento.ToString("dd/MM/yyyy"));
    }
}