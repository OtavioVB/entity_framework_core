
# Realizando CRUD com Entity Framework Core

## INSERT
Para realizar o **INSERT** com Entity Framework Core é necessário utilizar o método AddRange() para adicionar várias entidades, ou o Add() para adicionar uma única entidade.
Veja no código a seguir:
```csharp
using (AppDbContext dbContext = new AppDbContext()) // Chama o DbContext
{
    if (dbContext.Produtos.Any() is not false)
    {
        List<Produto> Produtos = new List<Produto>
        {
            new Produto{ Nome = "Borracha", Preço = 5.5},
            new Produto{ Nome = "Lápis", Preço = 6.2}
        }; // Cria uma lista de Produtos
        dbContext.AddRange(Produtos); // Adiciona no DbContext
        dbContext.SaveChanges(); // É passado da memória para o banco de dados
    }
}
```

## DELETE
Para realizar o **DELETE** com Entity Framework Core é necessário utilizar o método Where() para buscar a informação e o atributo do método Entry() como EntityState.Deleted, veja a seguir:
```csharp
using (AppDbContext dbContext = new AppDbContext())
{
    if (dbContext.Produtos.Any() is true)
    {
        Produto produto = dbContext.Produtos.Where(x => x.Id == 1).FirstOrDefault();
        dbContext.Entry(produto).State = EntityState.Deleted;
        dbContext.SaveChanges();
    }
}
```

## UPDATE
Para realizar o **UPDATE** é muito tranquilo, é necessário apenas localizar a entidade no dbContext e mudar seus parâmetros e salvar as alterações, veja:
```csharp
using (AppDbContext dbContext = new AppDbContext())
{
    if (dbContext.Produtos.Any() is true)
    {
        Produto produto = dbContext.Produtos.Where(x => x.Id == 2).FirstOrDefault();
        produto.Nome = "Canetinha";
        produto.Preço = 55.5;
        dbContext.SaveChanges();
    }
}
```

## SELECT 
Para realizar o **SELECT** é muito tranquilo, é necessário apenas localizar a entidade:
```csharp
using (AppDbContext dbContext = new AppDbContext())
{
    if (dbContext.Produtos.Any() is true)
    {
        Produto produto = dbContext.Produtos.Where(x => x.Id == 2).FirstOrDefault();
        Console.WriteLine("Nome do Produto: " + produto.Nome);
        Console.WriteLine("Preço do Produto: " + produto.Preço.ToString());
    }
}
```


### Observações
É possível mesclar várias operações juntas, caso elas não se afetam. Em caso de erro, o Entity Framework Core dara um RollBack e não realizará nenhuma das alterações.