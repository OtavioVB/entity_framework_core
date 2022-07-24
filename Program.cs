using System;
using EFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
        }
    }
}