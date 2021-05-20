using BlueModas.API.Domain.Entidades;
using BlueModas.API.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace BlueModas.API.Infra.Data
{
    public class BlueModasDbContext : DbContext
    {
        /// <summary>
        /// DbSet para a entidade Users.
        /// </summary>
        public DbSet<Users> Users { get; set; }
        public DbSet<Telefone> Telefone { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Venda> Venda { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Categorias> Categorias { get; set; }

        /// <summary>
        /// Construtor Padrão.
        /// </summary>
        /// <param name="options"></param>
        public BlueModasDbContext(DbContextOptions<BlueModasDbContext> options) : base(options) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMapping());
            modelBuilder.ApplyConfiguration(new ClientesMapping());
            modelBuilder.ApplyConfiguration(new UsersMapping());
            modelBuilder.ApplyConfiguration(new CategoriasMapping());
            modelBuilder.ApplyConfiguration(new VendaMapping());
            modelBuilder.ApplyConfiguration(new TelefoneMapping());
            modelBuilder.ApplyConfiguration(new EnderecoMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
