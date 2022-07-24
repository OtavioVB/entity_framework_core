# Entity Framework Core

Proveniente do Entity Framework 6.x. O Entity Framework Core é uma ferramenta multiplataforma **ORM (Object-Relational Mapping)** que procura aproximar o paradigma de orientação a objetos ao paradigma de banco de dados relacionais, sendo assim faz com que o desenvolvedor trabalhe **dados relacionais** na forma de objetos espeficados no domínio.

## Object-Relation Mapping

Como dito o ORM procura aproximar o paradigma da orientação a objetos ao paradigma de banco de dados relacionais, isso acontece por meio de uma técnica realizada por um **Framework** ou **Biblioteca** responsável por mapear os dados para um objeto. Veja a seguir a lista de alguns Frameworks ORM para o C#:
- Entity Framework/Entity Framework Core;
- Nhibernate
- Dapper
No entanto nesse resumo será apresentado apenas o Entity Framework Core.

## Benefícios

O Entity Framework Core por ser uma ferramenta de mapeamento de dados relacionas para objeto da orientação a objetos faz com que o **tempo e custo** de desenvolvimento sejam dimínuidos, já que **realiza comandos SQL automaticamente** a partir dos modelos criados no domínio.

## Formas de fazer o mapemaento de dados relacionais

### Code First
Quando criado as classes com suas convenções e configurações no domínio da aplicação usa-se a **migração** para criar o banco de dados, tabela e os dados. Ou seja, o banco de dados é implementado por meio dos modelos criado na aplicação.

Para realizar um Code First, crie a classe de referência como eu fiz em meu projeto:

```csharp
namespace EFCore.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preço { get; set; }
    }
}
```
Após criar sua Entidade (Modelo - Classe), crie a conexão com o Banco de Dados, nessa forma:

```csharp
using Microsoft.EntityFrameworkCore;

namespace EFCore.Models
{
    public class AppDbContext : DbContext
    {
        // Mapeamento da Identididade de Domínio para uma Tabela de Banco de Dados
        public DbSet<Produto> Produtos { get; set; }

        // Criando a conexão - Para criar a conexão é necessário utilizar o método virtual do DbContext (OnConfiguring)
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=127.0.0.1;database=efcore_migrations;uid=otavio;pwd=1234;port=3306", ServerVersion.AutoDetect(new MySqlConnector.MySqlConnection("server=127.0.0.1;database=efcore_migrations;uid=otavio;pwd=1234;port=3306")));
        }
    }
}
```
Resumindo, o **DbSet** é usado para mapear a Entidade para um variável. O método OnConfiguring é virtual de DbContext, sendo responsável por realizar a conexão com o banco de dados.

Tudo pronto, agora precisamos fazer nossa migração (Necessário ter o pacote nuget Microsoft.EntityFrameworkCore.Tools) abrindo o terminal de gerenciador de pacotes nuget:
```
add-migration "NomeMigration"
```
Após criada a migração é necessário atualizarmos a base de dados, com o comando:
```
update-database
```

Após isso será criado uma pasta contendo o histórico de migrações realizadas entre a aplicação e o banco de dados. Além também de o banco estar criado com sucesso!

#### Migrations
Como já apresentado as Migrations é responsável por manter em sincronia o banco de dados com seus modelos do EF Core. Veja a seguir a lista de comandos das migrations:
```
add-migration
drop-database
get-dbcontext
remove-migration
scaffold-dbcontext
script-migration
update-database
```

#### DbContext
DbContext é a classe **coração** do EntityFrameworkCore, ela é responsável por gerenciar a conexão com banco de dados, realizar operações CRUD, gerenciar o estado das mudanças das entidades, mapear os resultados das consultas SQL e fornecer um cache em memória para os objetos. Sendo assim ela é quem faz a grande parte das transações. Veja a seguir alguns métodos:
- Método Add() - Adiciona uma nova entidade ao contexto.
- Método AddRange() - Adiciona uma nova coleção de entidades.
- Método Attach() - Anexa uma nova entidade ao contexto.
- Método Entry() - Atualiza o status da entidade.
- Método Find() - Encontra a entidade no contexto.
- Método Remove() - Remove uma entidade do contexto.
- Método SaveChanges() - Responsável por persistir as informações no banco de dados, registrando as informações que foram realizadas em **memória** para o banco de dados.
- Método Set() - Cria um DbSet<>
- Método Update() - Anexa uma entidade desconectada com estado modified.

### DataBase First
Cria as classes no domínio da aplicação por meio de um banco de dados já existente e implementado, usando comando do **EF Core**. Ou seja, os modelos criados na aplicação são criado por meio do banco de dados.

# Conclusão
Em síntese, podemos dizer que o Entity Framework Core é um poupador de **tempo**, já que facilmente conseguimos obter informações das entidades sem precisar converter dados de uma DataTable ou outros tipos de retorno de Banco de Dados. Além disso, ele é responsável por manter o banco de dados o mais próximo da orientação a objetos, já que ele faz o chamado de Object-Relational Mapping por meio das migrações e métodos. Veja a importância da poupagem do tempo [nesse artigo](https://github.com/balta-io/blog/blob/main/eu-nao-tenho-tempo-para-testar/index.md) publicado pelo André Baltieri no blog do [Balta](Balta.io).

# Pacotes Nuget Utilizados
-	Pomelo.EntityFrameworkCore.MySql;
-	Microsoft.EntityFrameworkCore;
-	Microsoft.EntityFrameworkCore.Tools;