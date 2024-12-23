using Library.src.DTO.Emprestimos;
using Library.src.Models;
using Library.src.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Library.src.Repositories
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly DbContext _context;

        public EmprestimoRepository(DbContext context)
        {
            _context = context;
        }

        public DetalhesEmprestimoDto ObterPorId(int id)
        {
            var emprestimo = _context.Set<Emprestimo>().Find(id);
            if (emprestimo != null)
            {
                return new DetalhesEmprestimoDto(emprestimo);
            }
            throw new KeyNotFoundException($"Emprestimo com ID {id} não encontrado.");
        }

        public IEnumerable<DetalhesEmprestimoDto> ObterTodos()
        {
            return _context.Set<Emprestimo>().Select(e => new DetalhesEmprestimoDto(e)).ToList();
        }

        public void Adicionar(CadastrarEmprestimoDto emprestimoDto)
        {
            var emprestimo = emprestimoDto.ToEmprestimo(0, 0);
            _context.Set<Emprestimo>().Add(emprestimo);
            _context.SaveChanges();
        }

        public void Atualizar(CadastrarEmprestimoDto emprestimoDto, int id)
        {
            var emprestimo = _context.Set<Emprestimo>().Find(id);
            if (emprestimo != null)
            {
                emprestimo.DataEmprestimo = emprestimoDto.DataEmprestimo;
                emprestimo.DataDevolucao = emprestimoDto.DataDevolucao;
                _context.Set<Emprestimo>().Update(emprestimo);
                _context.SaveChanges();
            }
        }

        public void Remover(int id)
        {
            var emprestimo = _context.Set<Emprestimo>().Find(id);
            if (emprestimo != null)
            {
                _context.Set<Emprestimo>().Remove(emprestimo);
                _context.SaveChanges();
            }
        }
    }
}
