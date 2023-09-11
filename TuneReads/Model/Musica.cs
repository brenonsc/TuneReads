namespace TuneReads.Model;

public class Musica : Produto
{
    public string formato;
    
    public Musica(int id, string titulo, int tipo, string autor, decimal preco, int estoque, DateOnly dataLancamento, string formato) : base(id, titulo, tipo, autor, preco, estoque, dataLancamento)
    {
        this.formato = formato;
    }
    
    //Métodos getters e setters
    public string GetFormato()
    {
        return formato;
    }
    
    public void SetFormato(string formato)
    {
        this.formato = formato;
    }
    
    public override void Visualizar()
    {
        base.Visualizar();
        Console.WriteLine("Formato: " + formato +
                          "\n************************************************************");
    }
}