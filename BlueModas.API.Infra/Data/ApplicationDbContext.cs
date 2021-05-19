using BlueModas.API.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace BlueModas.API.Infra.Data
{
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// DbSet para a entidade Users.
        /// </summary>
        public DbSet<Users> Users { get; set; }
        public DbSet<Telefone> Telefone { get; set; }
        public DbSet<Endereco> Endereco { get; set; }

        /// <summary>
        /// Construtor Padrão.
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
