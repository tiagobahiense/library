using Library.src.DTO.Clientes;
using Library.src.DTO.Catalogos;
using Library.src.DTO.Inventarios;
using Library.src.DTO.Emprestimos;
using Library.src.Service.Interfaces;
using System;
using System.Collections.Generic;

namespace LibraryApp.UI
{
    public class Menu
    {
        private readonly IClienteService _clienteService;
        private readonly ICatalogoService _catalogoService;
        private readonly IInventarioService _inventarioService;
        private readonly IEmprestimoService _emprestimoService;

        public Menu(IClienteService clienteService, ICatalogoService catalogoService, IInventarioService inventarioService, IEmprestimoService emprestimoService)
        {
            _clienteService = clienteService;
            _catalogoService = catalogoService;
            _inventarioService = inventarioService;
            _emprestimoService = emprestimoService;
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("Menu Principal:");
                Console.WriteLine("1. Gerenciar Clientes");
                Console.WriteLine("2. Gerenciar Catálogos");
                Console.WriteLine("3. Gerenciar Inventário");
                Console.WriteLine("4. Gerenciar Empréstimos");
                Console.WriteLine("5. Sair");
                Console.Write("Escolha uma opção: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        GerenciarClientes();
                        break;
                    case "2":
                        GerenciarCatalogos();
                        break;
                    case "3":
                        GerenciarInventario();
                        break;
                    case "4":
                        GerenciarEmprestimos();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        private void GerenciarClientes()
        {
            while (true)
            {
                Console.WriteLine("Gerenciar Clientes:");
                Console.WriteLine("1. Cadastrar Cliente");
                Console.WriteLine("2. Atualizar Cliente");
                Console.WriteLine("3. Obter Cliente por ID");
                Console.WriteLine("4. Obter Empréstimos do Cliente");
                Console.WriteLine("5. Voltar");
                Console.Write("Escolha uma opção: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CadastrarCliente();
                        break;
                    case "2":
                        AtualizarCliente();
                        break;
                    case "3":
                        ObterClientePorId();
                        break;
                    case "4":
                        ObterEmprestimosDoCliente();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        private void CadastrarCliente()
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Endereço: ");
            string endereco = Console.ReadLine();
            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Data de Nascimento (YYYY-MM-DD): ");
            DateTime dataNascimento = DateTime.Parse(Console.ReadLine());
            Console.Write("CPF: ");
            string cpf = Console.ReadLine();

            var clienteDto = new CadastrarClienteDto(nome, endereco, telefone, email, dataNascimento, cpf);
            _clienteService.CadastrarCliente(clienteDto);
            Console.WriteLine("Cliente cadastrado com sucesso!");
        }

        private void AtualizarCliente()
        {
            Console.Write("ID do Cliente: ");
            int clienteId = int.Parse(Console.ReadLine());
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Endereço: ");
            string endereco = Console.ReadLine();
            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Data de Nascimento (YYYY-MM-DD): ");
            DateTime dataNascimento = DateTime.Parse(Console.ReadLine());
            Console.Write("CPF: ");
            string cpf = Console.ReadLine();

            var clienteDto = new AtualizarClienteDto(nome, endereco, telefone, email, dataNascimento, cpf);
            _clienteService.AtualizarCliente(clienteId, clienteDto);
            Console.WriteLine("Cliente atualizado com sucesso!");
        }

        private void ObterClientePorId()
        {
            Console.Write("ID do Cliente: ");
            int clienteId = int.Parse(Console.ReadLine());
            var cliente = _clienteService.ObterClientePorId(clienteId);
            Console.WriteLine($"Cliente: {cliente.Nome}, Endereço: {cliente.Endereco}, Telefone: {cliente.Telefone}, Email: {cliente.Email}, Data de Nascimento: {cliente.DataNascimento}, CPF: {cliente.CPF}");
        }

        private void ObterEmprestimosDoCliente()
        {
            Console.Write("ID do Cliente: ");
            int clienteId = int.Parse(Console.ReadLine());
            var emprestimos = _clienteService.ObterEmprestimosDoCliente(clienteId);
            foreach (var emprestimo in emprestimos)
            {
                Console.WriteLine($"Emprestimo ID: {emprestimo.Id}, Data de Emprestimo: {emprestimo.DataEmprestimo}, Data de Devolução: {emprestimo.DataDevolucao}");
            }
        }

        private void GerenciarCatalogos()
        {
            while (true)
            {
                Console.WriteLine("Gerenciar Catálogos:");
                Console.WriteLine("1. Adicionar Catálogo");
                Console.WriteLine("2. Remover Catálogo");
                Console.WriteLine("3. Buscar Catálogo por ID");
                Console.WriteLine("4. Buscar Todos os Catálogos");
                Console.WriteLine("5. Voltar");
                Console.Write("Escolha uma opção: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AdicionarCatalogo();
                        break;
                    case "2":
                        RemoverCatalogo();
                        break;
                    case "3":
                        BuscarCatalogoPorId();
                        break;
                    case "4":
                        BuscarTodosOsCatalogos();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        private void AdicionarCatalogo()
        {
            Console.Write("Título: ");
            string titulo = Console.ReadLine();
            Console.Write("Autor: ");
            string autor = Console.ReadLine();
            Console.Write("Ano de Lançamento: ");
            int anoLancamento = int.Parse(Console.ReadLine());
            Console.Write("Gênero: ");
            string genero = Console.ReadLine();
            Console.Write("Número de Páginas: ");
            int numeroPaginas = int.Parse(Console.ReadLine());

            var catalogoDto = new CadastrarCatalogoDto(titulo, autor, anoLancamento, genero, numeroPaginas);
            _catalogoService.AdicionarCatalogo(catalogoDto);
            Console.WriteLine("Catálogo adicionado com sucesso!");
        }

        private void RemoverCatalogo()
        {
            Console.Write("ID do Catálogo: ");
            int catalogoId = int.Parse(Console.ReadLine());
            _catalogoService.RemoverCatalogo(catalogoId);
            Console.WriteLine("Catálogo removido com sucesso!");
        }

        private void BuscarCatalogoPorId()
        {
            Console.Write("ID do Catálogo: ");
            int catalogoId = int.Parse(Console.ReadLine());
            var catalogo = _catalogoService.BuscarCatalogoPorId(catalogoId);
            Console.WriteLine($"Catálogo: {catalogo.Titulo}, Autor: {catalogo.Autor}, Ano de Lançamento: {catalogo.AnoLancamento}, Gênero: {catalogo.Genero}, Número de Páginas: {catalogo.NumeroPaginas}");
        }

        private void BuscarTodosOsCatalogos()
        {
            var catalogos = _catalogoService.BuscarTodosOsCatalogos();
            foreach (var catalogo in catalogos)
            {
                Console.WriteLine($"Catálogo: {catalogo.Titulo}, Autor: {catalogo.Autor}, Ano de Lançamento: {catalogo.AnoLancamento}, Gênero: {catalogo.Genero}, Número de Páginas: {catalogo.NumeroPaginas}");
            }
        }

        private void GerenciarInventario()
        {
            while (true)
            {
                Console.WriteLine("Gerenciar Inventário:");
                Console.WriteLine("1. Adicionar Catálogo ao Inventário");
                Console.WriteLine("2. Remover Catálogo do Inventário");
                Console.WriteLine("3. Obter Detalhes do Catálogo no Inventário");
                Console.WriteLine("4. Obter Quantidade do Catálogo no Inventário");
                Console.WriteLine("5. Voltar");
                Console.Write("Escolha uma opção: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AdicionarCatalogoAoInventario();
                        break;
                    case "2":
                        RemoverCatalogoDoInventario();
                        break;
                    case "3":
                        ObterDetalhesCatalogoNoInventario();
                        break;
                    case "4":
                        ObterQuantidadeCatalogoNoInventario();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        private void AdicionarCatalogoAoInventario()
        {
            Console.Write("ID do Inventário: ");
            int inventarioId = int.Parse(Console.ReadLine());
            Console.Write("ID do Catálogo: ");
            int catalogoId = int.Parse(Console.ReadLine());
            Console.Write("Quantidade: ");
            int quantidade = int.Parse(Console.ReadLine());

            var adicionarDto = new CadastrarInventarioDto(new Dictionary<int, int> { { catalogoId, quantidade } });
            _inventarioService.AdicionarCatalogoAoInventario(inventarioId, adicionarDto);
            Console.WriteLine("Catálogo adicionado ao inventário com sucesso!");
        }

        private void RemoverCatalogoDoInventario()
        {
            Console.Write("ID do Inventário: ");
            int inventarioId = int.Parse(Console.ReadLine());
            Console.Write("ID do Catálogo: ");
            int catalogoId = int.Parse(Console.ReadLine());
            Console.Write("Quantidade: ");
            int quantidade = int.Parse(Console.ReadLine());

            var removerDto = new AtualizarInventarioDto(new Dictionary<int, int> { { catalogoId, quantidade } });
            _inventarioService.RemoverCatalogoDoInventario(inventarioId, removerDto);
            Console.WriteLine("Catálogo removido do inventário com sucesso!");
        }

        private void ObterDetalhesCatalogoNoInventario()
        {
            Console.Write("ID do Catálogo: ");
            int catalogoId = int.Parse(Console.ReadLine());
            var catalogo = _inventarioService.ObterDetalhesCatalogoNoInventario(catalogoId);
            Console.WriteLine($"Catálogo: {catalogo.Titulo}, Autor: {catalogo.Autor}, Ano de Lançamento: {catalogo.AnoLancamento}, Gênero: {catalogo.Genero}, Número de Páginas: {catalogo.NumeroPaginas}");
        }

        private void ObterQuantidadeCatalogoNoInventario()
        {
            Console.Write("ID do Inventário: ");
            int inventarioId = int.Parse(Console.ReadLine());
            Console.Write("ID do Catálogo: ");
            int catalogoId = int.Parse(Console.ReadLine());
            int quantidade = _inventarioService.QuantidadeCatalogoNoInventario(inventarioId, catalogoId);
            Console.WriteLine($"Quantidade do Catálogo no Inventário: {quantidade}");
        }

        private void GerenciarEmprestimos()
        {
            while (true)
            {
                Console.WriteLine("Gerenciar Empréstimos:");
                Console.WriteLine("1. Registrar Empréstimo");
                Console.WriteLine("2. Devolver Empréstimo");
                Console.WriteLine("3. Obter Empréstimos do Cliente");
                Console.WriteLine("4. Voltar");
                Console.Write("Escolha uma opção: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        RegistrarEmprestimo();
                        break;
                    case "2":
                        DevolverEmprestimo();
                        break;
                    case "3":
                        ObterEmprestimosDoClientePorMenu();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        private void RegistrarEmprestimo()
        {
            Console.Write("ID do Cliente: ");
            int clienteId = int.Parse(Console.ReadLine());
            var emprestimos = new List<CadastrarEmprestimoDto>();

            while (true)
            {
                Console.Write("ID do Inventário: ");
                int idInventario = int.Parse(Console.ReadLine());
                Console.Write("Data de Emprestimo (YYYY-MM-DD): ");
                DateTime dataEmprestimo = DateTime.Parse(Console.ReadLine());

                var emprestimoDto = new CadastrarEmprestimoDto { IdInventario = idInventario, DataEmprestimo = dataEmprestimo };
                emprestimos.Add(emprestimoDto);

                Console.Write("Deseja adicionar mais empréstimos? (s/n): ");
                string choice = Console.ReadLine();
                if (choice.ToLower() != "s")
                {
                    break;
                }
            }

            _emprestimoService.RegistrarEmprestimo(clienteId, emprestimos);
            Console.WriteLine("Empréstimo registrado com sucesso!");
        }

        private void DevolverEmprestimo()
        {
            Console.Write("ID do Cliente: ");
            int clienteId = int.Parse(Console.ReadLine());
            var devolucoes = new List<DevolucaoEmprestimoDto>();

            while (true)
            {
                Console.Write("ID do Empréstimo: ");
                int emprestimoId = int.Parse(Console.ReadLine());
                Console.Write("Data de Devolução (YYYY-MM-DD): ");
                DateTime dataDevolucao = DateTime.Parse(Console.ReadLine());

                var devolucaoDto = new DevolucaoEmprestimoDto { EmprestimoId = emprestimoId, DataDevolucao = dataDevolucao };
                devolucoes.Add(devolucaoDto);

                Console.Write("Deseja adicionar mais devoluções? (s/n): ");
                string choice = Console.ReadLine();
                if (choice.ToLower() != "s")
                {
                    break;
                }
            }

            _emprestimoService.DevolverEmprestimo(clienteId, devolucoes);
            Console.WriteLine("Empréstimo devolvido com sucesso!");
        }

        private void ObterEmprestimosDoClientePorMenu()
        {
            Console.Write("ID do Cliente: ");
            int clienteId = int.Parse(Console.ReadLine());
            var emprestimos = _emprestimoService.ObterEmprestimosDoCliente(clienteId);
            foreach (var emprestimo in emprestimos)
            {
                Console.WriteLine($"Emprestimo ID: {emprestimo.Id}, Data de Emprestimo: {emprestimo.DataEmprestimo}, Data de Devolução: {emprestimo.DataDevolucao}");
            }
        }
    }
}
