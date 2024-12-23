using Library.src.DTO.Clientes;
using Library.src.DTO.Emprestimos;
using Library.src.Models;
using Library.src.Repositories.Interfaces;
using Library.src.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Library.src.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
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
            var cliente = _clienteRepository.ObterPorId(clienteId);
            return cliente != null ? new DetalhesClienteDto(cliente) : null;
        }

        public IEnumerable<DetalhesEmprestimoDto> ObterEmprestimosDoCliente(int clienteId)
        {
            var emprestimos = _clienteRepository.ObterEmprestimosDoCliente(clienteId);
            return emprestimos.Select(e => new DetalhesEmprestimoDto(e));
        }
    }
}
