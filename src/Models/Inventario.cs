public class Inventario
{
    private Dictionary<int, int> _itens; 

    public Inventario(int id, Dictionary<int, int> itens)
    {
        Id = id;
        Itens = itens ?? new Dictionary<int,int>();
    }

    public int Id{
        get {return _idIventario;}
        set {_idIventario = value;}
    }

    public Dictionary<int, int> Itens{
        get {return _itens;}
        set {_itens = value ?? new Dictionary<int, int>();}
    }
}