public class Inventario {
    private int _Id;
    private int _IdCatalogo;

    public Inventario (int id, int idCatalogo){
        Id = id;
        IdCatalogo = idCatalogo;
    }

    public int Id{
        get {return _Id;}
        private set {_Id = value;}
    }

    public int IdCatalogo{
        get {return _IdCatalogo;}
        private set {_IdCatalogo = value;}
    }
}