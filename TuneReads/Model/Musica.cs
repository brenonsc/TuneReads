namespace TuneReads.Model;

public class Musica : Produto
{
    public int formato;
    
    public Musica(int id, string titulo, int tipo, string autor, decimal preco, int estoque, DateOnly dataLancamento, int formato) : base(id, titulo, tipo, autor, preco, estoque, dataLancamento)
    {
        this.formato = formato;
    }
    
    //Métodos getters e setters
    public int GetFormato()
    {
        return formato;
    }
    
    public void SetFormato(int formato)
    {
        this.formato = formato;
    }
    
    public override void Visualizar()
    {
        base.Visualizar();
        Console.WriteLine("Formato: " + formato +
                          "\n*****************************");
    }
}