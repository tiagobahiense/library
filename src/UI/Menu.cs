using Library.src.DTO.Clientes;
using Library.src.DTO.Catalogos;
using Library.src.DTO.Inventarios;
using Library.src.DTO.Emprestimos;
using Library.src.Service.Interfaces;
using System;
using System.Collections.Generic;

namespace Library.src.UI
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
                int choice = ReadInt("Escolha uma opção: ");

                switch (choice)
                {
                    case 1:
                        GerenciarClientes();
                        break;
                    case 2:
                        GerenciarCatalogos();
                        break;
                    case 3:
                        GerenciarInventario();
                        break;
                    case 4:
                        GerenciarEmprestimos();
                        break;
                    case 5:
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
                Console.WriteLine("4. Voltar");
                int choice = ReadInt("Escolha uma opção: ");

                switch (choice)
                {
                    case 1:
                        CadastrarCliente();
                        break;
                    case 2:
                        AtualizarCliente();
                        break;
                    case 3:
                        ObterClientePorId();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        private void CadastrarCliente()
        {
            string nome = ReadString("Nome: ");
            string endereco = ReadString("Endereço: ");
            string telefone = ReadString("Telefone: ");
            string email = ReadString("Email: ");
            DateTime dataNascimento = ReadDateTime("Data de Nascimento (YYYY-MM-DD): ");
            string cpf = ReadString("CPF: ");

            var clienteDto = new CadastrarClienteDto
            {
                Nome = nome,
                Endereco = endereco,
                Telefone = telefone,
                Email = email,
                DataNascimento = dataNascimento,
                CPF = cpf
            };
            _clienteService.CadastrarCliente(clienteDto);
            Console.WriteLine("Cliente cadastrado com sucesso!");
        }

        private void AtualizarCliente()
        {
            int clienteId = ReadInt("ID do Cliente: ");
            string nome = ReadString("Nome: ");
            string endereco = ReadString("Endereço: ");
            string telefone = ReadString("Telefone: ");
            string email = ReadString("Email: ");
            DateTime dataNascimento = ReadDateTime("Data de Nascimento (YYYY-MM-DD): ");
            string cpf = ReadString("CPF: ");

            var clienteDto = new AtualizarClienteDto
            {
                Nome = nome,
                Endereco = endereco,
                Telefone = telefone,
                Email = email,
                DataNascimento = dataNascimento,
                CPF = cpf
            };
            _clienteService.AtualizarCliente(clienteId, clienteDto);
            Console.WriteLine("Cliente atualizado com sucesso!");
        }

        private void ObterClientePorId()
        {
            int clienteId = ReadInt("ID do Cliente: ");
            var cliente = _clienteService.ObterClientePorId(clienteId);
            if (cliente == null)
            {
                Console.WriteLine("Cliente não encontrado.");
                return;
            }
            Console.WriteLine($"Cliente: {cliente.Nome}, Endereço: {cliente.Endereco}, Telefone: {cliente.Telefone}, Email: {cliente.Email}, Data de Nascimento: {cliente.DataNascimento}, CPF: {cliente.CPF}");
        }

        private void GerenciarCatalogos()
        {
            while (true)
            {
                Console.WriteLine("Gerenciar Catálogos:");
                Console.WriteLine("1. Adicionar Catálogo");
                Console.WriteLine("2. Remover Catálogo");
                Console.WriteLine("3. Buscar Catálogo por ID");
                Console.WriteLine("4. Voltar");
                int choice = ReadInt("Escolha uma opção: ");

                switch (choice)
                {
                    case 1:
                        AdicionarCatalogo();
                        break;
                    case 2:
                        RemoverCatalogo();
                        break;
                    case 3:
                        BuscarCatalogoPorId();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        private void AdicionarCatalogo()
        {
            string titulo = ReadString("Título: ");
            string autor = ReadString("Autor: ");
            int anoLancamento = ReadInt("Ano de Lançamento: ");
            string genero = ReadString("Gênero: ");
            int numeroPaginas = ReadInt("Número de Páginas: ");

            var catalogoDto = new CadastrarCatalogoDto
            {
                Titulo = titulo,
                Autor = autor,
                AnoLancamento = anoLancamento,
                Genero = genero,
                NumeroPaginas = numeroPaginas
            };
            _catalogoService.AdicionarCatalogo(catalogoDto);
            Console.WriteLine("Catálogo adicionado com sucesso!");
        }

        private void RemoverCatalogo()
        {
            int catalogoId = ReadInt("ID do Catálogo: ");
            _catalogoService.RemoverCatalogo(catalogoId);
            Console.WriteLine("Catálogo removido com sucesso!");
        }

        private void BuscarCatalogoPorId()
        {
            int catalogoId = ReadInt("ID do Catálogo: ");
            var catalogo = _catalogoService.BuscarCatalogoPorId(catalogoId);
            if (catalogo == null)
            {
                Console.WriteLine("Catálogo não encontrado.");
                return;
            }
            Console.WriteLine($"Catálogo: {catalogo.Titulo}, Autor: {catalogo.Autor}, Ano de Lançamento: {catalogo.AnoLancamento}, Gênero: {catalogo.Genero}, Número de Páginas: {catalogo.NumeroPaginas}");
        }

        private void GerenciarInventario()
        {
            while (true)
            {
                Console.WriteLine("Gerenciar Inventário:");
                Console.WriteLine("1. Adicionar Catálogo ao Inventário");
                Console.WriteLine("2. Remover Catálogo do Inventário");
                Console.WriteLine("3. Obter Quantidade do Catálogo no Inventário");
                Console.WriteLine("4. Voltar");
                int choice = ReadInt("Escolha uma opção: ");

                switch (choice)
                {
                    case 1:
                        AdicionarCatalogoAoInventario();
                        break;
                    case 2:
                        RemoverCatalogoDoInventario();
                        break;
                    case 3:
                        ObterQuantidadeCatalogoNoInventario();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        private void AdicionarCatalogoAoInventario()
        {
            int catalogoId = ReadInt("ID do Catálogo: ");
            int quantidade = ReadInt("Quantidade: ");

            _inventarioService.AdicionarCatalogoAoInventario(catalogoId, quantidade);
            Console.WriteLine("Catálogo adicionado ao inventário com sucesso!");
        }

        private void RemoverCatalogoDoInventario()
        {
            int catalogoId = ReadInt("ID do Catálogo: ");
            int quantidade = ReadInt("Quantidade: ");

            _inventarioService.RemoverCatalogoDoInventario(catalogoId, quantidade);
            Console.WriteLine("Catálogo removido do inventário com sucesso!");
        }

        private void ObterQuantidadeCatalogoNoInventario()
        {
            int catalogoId = ReadInt("ID do Catálogo: ");
            int quantidade = _inventarioService.QuantidadeCatalogoNoInventario(catalogoId);
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
                int choice = ReadInt("Escolha uma opção: ");

                switch (choice)
                {
                    case 1:
                        RegistrarEmprestimo();
                        break;
                    case 2:
                        DevolverEmprestimo();
                        break;
                    case 3:
                        ObterEmprestimosDoClientePorMenu();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        private void RegistrarEmprestimo()
        {
            int clienteId = ReadInt("ID do Cliente: ");
            var emprestimos = new List<CadastrarEmprestimoDto>();

            while (true)
            {
                int idCatalogo = ReadInt("ID do Catálogo: ");
                int idInventario = ReadInt("ID do Inventário: ");
                DateTime dataEmprestimo = ReadDateTime("Data de Emprestimo (YYYY-MM-DD): ");
                DateTime dataDevolucao = ReadDateTime("Data de Devolução (YYYY-MM-DD): ");

                var emprestimoDto = new CadastrarEmprestimoDto
                {
                    IdCatalogo = idCatalogo,
                    IdInventario = idInventario,
                    DataEmprestimo = dataEmprestimo,
                    DataDevolucao = dataDevolucao 
                };
                emprestimos.Add(emprestimoDto);

                if (!ReadBool("Deseja adicionar mais empréstimos? (s/n): "))
                {
                    break;
                }
            }

            _emprestimoService.RegistrarEmprestimo(clienteId, emprestimos);
            Console.WriteLine("Empréstimo registrado com sucesso!");
        }


        private void DevolverEmprestimo()
        {
            int clienteId = ReadInt("ID do Cliente: ");
            var devolucoes = new List<DevolucaoEmprestimoDto>();

            while (true)
            {
                int emprestimoId = ReadInt("ID do Empréstimo: ");
                DateTime dataDevolucao = ReadDateTime("Data de Devolução (YYYY-MM-DD): ");

                var devolucaoDto = new DevolucaoEmprestimoDto
                {
                    EmprestimoId = emprestimoId,
                    DataDevolucao = dataDevolucao
                };
                devolucoes.Add(devolucaoDto);

                if (!ReadBool("Deseja adicionar mais devoluções? (s/n): "))
                {
                    break;
                }
            }

            _emprestimoService.DevolverEmprestimo(clienteId, devolucoes);
            Console.WriteLine("Empréstimo devolvido com sucesso!");
        }

        private void ObterEmprestimosDoClientePorMenu()
        {
            int clienteId = ReadInt("ID do Cliente: ");
            var emprestimos = _emprestimoService.ObterEmprestimosDoCliente(clienteId);
            if (!emprestimos.Any())
            {
                Console.WriteLine("Nenhum empréstimo encontrado para este cliente.");
                return;
            }
            foreach (var emprestimo in emprestimos)
            {
                Console.WriteLine($"ID do Empréstimo: {emprestimo.Id}");
                Console.WriteLine($"Nome do Cliente: {emprestimo.NomeCliente}");
                Console.WriteLine($"Nome do Catálogo: {emprestimo.NomeCatalogo}");
                Console.WriteLine($"Data de Empréstimo: {emprestimo.DataEmprestimo.ToShortDateString()}");
                Console.WriteLine($"Data de Devolução: {emprestimo.DataDevolucao.ToShortDateString()}");
                Console.WriteLine("----------------------------------------");
            }
        }




        private int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int result))
                {
                    return result;
                }
                Console.WriteLine("Entrada inválida. Tente novamente.");
            }
        }

        private DateTime ReadDateTime(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();
                if (DateTime.TryParse(input, out DateTime result))
                {
                    return result;
                }
                Console.WriteLine("Data inválida. Tente novamente.");
            }
        }

        private string ReadString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine() ?? string.Empty;
        }

        private bool ReadBool(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();
                if (input?.ToLower() == "s")
                {
                    return true;
                }
                else if (input?.ToLower() == "n")
                {
                    return false;
                }
                Console.WriteLine("Entrada inválida. Tente novamente.");
            }
        }
    }
}
