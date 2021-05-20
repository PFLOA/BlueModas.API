using BlueModas.API.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlueModas.API.Infra.Data.Mapping
{
    public class ClientesMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("TB_CLIENTE");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name);
            builder.Property(p => p.Password);
            builder.Property(p => p.UserName);
            builder.Property(p => p.Email);
            builder.Property(p => p.DataCadastro);
            builder.HasMany(p => p.Enderecos)
                    .WithOne(b => b.Cliente)
                      .HasForeignKey(fk => fk.ClienteId)
                       .OnDelete(DeleteBehavior.Cascade); 
            builder.HasMany(p => p.Telefones)
                    .WithOne(b => b.Cliente)
                     .HasForeignKey(fk => fk.ClienteId)
                      .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
