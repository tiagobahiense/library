namespace Livraria.Models.Inventario;
public class Inventario
{
    private Dictionary<int, int> _itens; 
    private int _idInventario;

    public Inventario(int id, Dictionary<int, int> itens)
    {
        _idInventario = id;
        _itens = itens ?? new Dictionary<int, int>();
    }

    public int Id
    {
        get { return _idInventario; }
        set { _idInventario = value; }
    }

    public Dictionary<int, int> Itens
    {
        get { return _itens; }
        set { _itens = value ?? new Dictionary<int, int>(); }
    }
}
