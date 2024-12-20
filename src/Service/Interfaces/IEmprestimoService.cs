using Library.src.DTO.Emprestimo;

namespace Library.src.Service.Interfaces{
        public interface IEmprestimoService {
        void RegistrarEmprestimo(int clienteId, List<CadastrarEmprestimoDto> emprestimos);
        void DevolverEmprestimo(int clienteId, List<DevolucaoEmprestimoDto> devolucoes);
        IEnumerable<DetalhesEmprestimoDto> ObterEmprestimosDoCliente(int clienteId);
    }
}

