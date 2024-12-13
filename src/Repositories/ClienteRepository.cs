using Microsoft.EntityFrameworkCore;


public class ClienteRepository : IClienteRepository
{
    private readonly DbContext _context;

    public ClienteRepository(DbContext context)
    {
        _context = context;
    }

    public Cliente ObterPorId(int id)
    {
        return _context.Set<Cliente>().Find(id);
    }

    public IEnumerable<Cliente> ObterTodos()
    {
        return _context.Set<Cliente>().ToList();
    }

    public void Adicionar(Cliente cliente)
    {
        _context.Set<Cliente>().Add(cliente);
        _context.SaveChanges();
    }

    public void Atualizar(Cliente cliente)
    {
        _context.Set<Cliente>().Update(cliente);
        _context.SaveChanges();
    }

    public void Remover(int id)
    {
        var cliente = ObterPorId(id);
        if (cliente != null)
        {
            _context.Set<Cliente>().Remove(cliente);
            _context.SaveChanges();
        }
    }
}
