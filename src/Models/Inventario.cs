public class Inventario {
    private Guid _Id;
    private Guid _IdCatalogo;

    public Inventario (Guid id, Guid idCatalogo){
        Id = id;
        IdCatalogo = idCatalogo;
    }

    public Guid Id{
        get {return _Id;}
        private set {_Id = value;}
    }

    public Guid IdCatalogo{
        get {return _IdCatalogo;}
        private set {_IdCatalogo = value;}
    }
}