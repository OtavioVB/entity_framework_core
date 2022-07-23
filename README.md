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



### DataBase First
Cria as classes no domínio da aplicação por meio de um banco de dados já existente e implementado, usando comando do **EF Core**. Ou seja, os modelos criados na aplicação são criado por meio do banco de dados.

# Pacotes Nuget Utilizados
-	Pomelo.EntityFrameworkCore.MySql;
-	Microsoft.EntityFrameworkCore;
-	Microsoft.EntityFrameworkCore.Tools;