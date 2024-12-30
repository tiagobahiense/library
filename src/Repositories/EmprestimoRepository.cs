using Library.src.Models;
using Library.src.Data;
using Library.src.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace Library.src.Repositories
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly LibraryContext _context;
        private readonly ILogger<EmprestimoRepository> _logger;

        public EmprestimoRepository(LibraryContext context, ILogger<EmprestimoRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Adicionar(Emprestimo emprestimo)
        {
            _context.Emprestimos.Add(emprestimo);
            _context.SaveChanges();
            _logger.LogInformation($"Empréstimo adicionado: ID: {emprestimo.Id}, ID do Cliente: {emprestimo.IdCliente}, ID do Catálogo: {emprestimo.IdCatalogo}, ID do Inventário: {emprestimo.IdInventario}, Data de Empréstimo: {emprestimo.DataEmprestimo}, Data de Devolução: {emprestimo.DataDevolucao}");
        }

        public void Atualizar(Emprestimo emprestimo)
        {
            _context.Emprestimos.Update(emprestimo);
            _context.SaveChanges();
            _logger.LogInformation($"Empréstimo atualizado: ID: {emprestimo.Id}, Data de Devolução: {emprestimo.DataDevolucao}");
        }

        public Emprestimo? ObterPorId(int id)
        {
            var emprestimo = _context.Emprestimos
                            .Include(e => e.Catalogo)
                            .Include(e => e.Cliente)
                            .Include(e => e.Inventario)
                            .FirstOrDefault(e => e.Id == id);
            if (emprestimo != null)
            {
                _logger.LogInformation($"Empréstimo obtido por ID: ID: {emprestimo.Id}, ID do Cliente: {emprestimo.IdCliente}, ID do Catálogo: {emprestimo.IdCatalogo}, ID do Inventário: {emprestimo.IdInventario}, Data de Empréstimo: {emprestimo.DataEmprestimo}, Data de Devolução: {emprestimo.DataDevolucao}");
            }
            return emprestimo;
        }

        public IEnumerable<Emprestimo> ObterTodos()
        {
            var emprestimos = _context.Emprestimos
                            .Include(e => e.Catalogo)
                            .Include(e => e.Cliente)
                            .Include(e => e.Inventario)
                            .ToList();
            _logger.LogInformation($"Todos os empréstimos obtidos: Quantidade: {emprestimos.Count()}");
            return emprestimos;
        }
    }
}
