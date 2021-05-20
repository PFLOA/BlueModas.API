using BlueModas.API.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlueModas.API.Infra.Data.Mapping
{
    public class TelefoneMapping : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.ToTable("TB_TELEFONE");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Numero);
            builder.Property(p => p.TipoTelefone);
            builder.HasOne(p => p.Cliente).WithMany(b => b.Telefones).HasForeignKey(p => p.ClienteId);
        }
    }
}
