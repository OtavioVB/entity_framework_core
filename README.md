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

### DataBase First
Cria as classes no domínio da aplicação por meio de um banco de dados já existente e implementado, usando comando do **EF Core**. Ou seja, os modelos criados na aplicação são criado por meio do banco de dados.


// Pomelo.EntityFrameworkCore.MySql/src/Shared/Check.cs /
// if (value is not null && value.Length == 0)