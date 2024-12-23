using Library.src.DTO.Clientes;
using Library.src.DTO.Emprestimos;
using Library.src.Repositories.Interfaces;
using Library.src.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Library.src.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IEmprestimoRepository _emprestimoRepository;

        public ClienteService(IClienteRepository clienteRepository, IEmprestimoRepository emprestimoRepository)
        {
            _clienteRepository = clienteRepository;
            _emprestimoRepository = emprestimoRepository;
        }

        public void CadastrarCliente(CadastrarClienteDto clienteDto)
        {
            _clienteRepository.Adicionar(clienteDto);
        }

        public void AtualizarCliente(int clienteId, AtualizarClienteDto clienteDto)
        {
            _clienteRepository.Atualizar(clienteDto, clienteId);
        }

        public DetalhesClienteDto ObterClientePorId(int clienteId)
        {
            return _clienteRepository.ObterPorId(clienteId);
        }

        public IEnumerable<DetalhesEmprestimoDto> ObterEmprestimosDoCliente(int clienteId)
        {
            return _emprestimoRepository.ObterTodos().Where(e => e.IdCliente == clienteId).ToList();
        }
    }
}
