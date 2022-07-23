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