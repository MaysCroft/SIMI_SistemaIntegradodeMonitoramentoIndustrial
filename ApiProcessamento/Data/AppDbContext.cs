using Microsoft.EntityFrameworkCore;
using Shared;

namespace ApiProcessamento.Data
{
    /// <summary>
    /// AppDbContext - Classe que representa o contexto do banco de dados 
    /// da aplicação. Ela é responsável por gerenciar a conexão com o banco 
    /// de dados e as operações de CRUD (Create, Read, Update, Delete) para 
    /// a entidade SensorData. A propriedade Sensores é um DbSet que representa 
    /// a tabela de sensores no banco de dados, permitindo realizar consultas e 
    /// manipulações dos dados dos sensores. O construtor da classe recebe as opções 
    /// de configuração do DbContext, que são passadas para a classe base DbContext 
    /// para configurar a conexão com o banco de dados.
    /// </summary>
    public class AppDbContext : DbContext
    {
        public DbSet<SensorData> Sensores { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
    }
}
