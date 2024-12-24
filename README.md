# Projeto de Backend - Biblioteca

Este projeto é uma aplicação de backend para um sistema de gerenciamento de biblioteca, desenvolvida em C# utilizando uma arquitetura em camadas. A aplicação permite gerenciar usuários, catálogo de livros, inventário e empréstimos de livros.

## Camadas do Projeto

A estrutura do projeto é organizada da seguinte forma:

```
Library Project
│
├── DTO (Data Transfer Object)
│   └── Objetos para transferência de dados entre as camadas.
│
├── Infra
│   └── Implementações da infraestrutura (configurações de banco de dados, conexões, etc.).
│
├── Models
│   └── Classes que representam as entidades e as tabelas no banco de dados (Usuario, Catalogo, Inventario, Emprestimo).
│
├── Repositories (com Interfaces)
│   ├── Interfaces para os repositórios.
│   └── Implementações de acesso ao banco de dados (CRUD).
│
├── Services (com Interfaces)
│   ├── Interfaces para os serviços.
│   └── Implementações da lógica de negócios.
│
└── UI (User Interface)
    └── APIs ou interfaces para interação com o usuário.
```

## Funcionalidades

- **Cadastro de Usuários**: Adicionar, editar e remover usuários.
- **Gerenciamento de Catálogo**: Adicionar, editar e excluir livros no catálogo da biblioteca.
- **Controle de Inventário**: Gerenciar a quantidade de livros disponíveis para empréstimo.
- **Empréstimos**: Registrar empréstimos de livros, com prazos e devoluções.
  
## Tecnologias Utilizadas

- **[C#](https://learn.microsoft.com/en-us/dotnet/csharp/)**: Linguagem de programação principal.
- **[Entity Framework](https://learn.microsoft.com/en-us/ef/core/)**: Para interagir com o banco de dados.
- **[MySQL](https://www.mysql.com/)**: Banco de dados utilizado para persistência.
- **[Docker](https://www.docker.com/)**: Usado para executar o MySQL em um contêiner.
- **[ASP.NET Core](https://dotnet.microsoft.com/en-us/apps/aspnet)**: Framework utilizado para criar APIs e gerenciar a comunicação entre o backend e o frontend.

## Como Executar

1. Clone o repositório:
   ```bash
   git clone https://github.com/SeuUsuario/library.git
   ```

2. Navegue até a pasta do projeto:
   ```bash
   cd library
   ```

3. Restaure os pacotes NuGet:
   ```bash
   dotnet restore
   ```

4. Execute o projeto:
   ```bash
   dotnet run
   ```


## Como Contribuir

1. Faça um fork do repositório.
2. Crie uma branch para sua modificação:
   ```bash
   git checkout -b minha-modificacao
   ```
3. Commit suas alterações:
   ```bash
   git commit -m "Descrição da minha modificação"
   ```
4. Push para sua branch:
   ```bash
   git push origin minha-modificacao
   ```
5. Abra um pull request no GitHub.

## Licença

Este projeto está licenciado sob a licença MIT - veja o arquivo [LICENSE](LICENSE) para mais detalhes.

## Autor

- **Tiago Bahiense** - [GitHub](https://github.com/tiagobahiense)

## Agradecimentos

Agradecimentos a todos que colaboraram para o desenvolvimento deste projeto.
