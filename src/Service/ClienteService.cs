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
            var cliente = clienteDto.ToCliente();
            _clienteRepository.Adicionar(cliente);
        }

        public void AtualizarCliente(int clienteId, AtualizarClienteDto clienteDto)
        {
            var cliente = _clienteRepository.ObterPorId(clienteId);
            if (cliente != null)
            {
                cliente.Nome = clienteDto.Nome;
                cliente.Endereco = clienteDto.Endereco;
                cliente.Telefone = clienteDto.Telefone;
                cliente.Email = clienteDto.Email;
                cliente.DataNascimento = clienteDto.DataNascimento;
                cliente.CPF = clienteDto.CPF;
                _clienteRepository.Atualizar(cliente);
            }
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
