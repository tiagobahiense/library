public interface IInventarioRepository
{
    Inventario ObterPorId(int id);
    IEnumerable<Inventario> ObterTodos();
    void Adicionar(Inventario inventario);
    void Atualizar(Inventario inventario);
    void Remover(int id);
}
