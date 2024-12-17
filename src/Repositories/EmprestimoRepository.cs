using Library.Models;
using Library.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


public class EmprestimoRepository : IEmprestimoRepository
{
    private readonly DbContext _context;

    public EmprestimoRepository(DbContext context)
    {
        _context = context;
    }

    public Emprestimo ObterPorId(int id)
    {
        return _context.Set<Emprestimo>().Find(id);
    }

    public IEnumerable<Emprestimo> ObterTodos()
    {
        return _context.Set<Emprestimo>().ToList();
    }

    public void Adicionar(Emprestimo emprestimo)
    {
        _context.Set<Emprestimo>().Add(emprestimo);
        _context.SaveChanges();
    }

    public void Atualizar(Emprestimo emprestimo)
    {
        _context.Set<Emprestimo>().Update(emprestimo);
        _context.SaveChanges();
    }

    public void Remover(int id)
    {
        var emprestimo = ObterPorId(id);
        if (emprestimo != null)
        {
            _context.Set<Emprestimo>().Remove(emprestimo);
            _context.SaveChanges();
        }
    }
}
