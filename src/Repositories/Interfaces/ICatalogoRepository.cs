public interface ICatalogoRepository
{
    Catalogo ObterPorId(int id);
    IEnumerable<Catalogo> ObterTodos();
    void Adicionar(Catalogo catalogo);
    void Atualizar(Catalogo catalogo);
    void Remover(int id);
}
