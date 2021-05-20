using BlueModas.API.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlueModas.API.Infra.Data.Mapping
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("TB_ENDERECO");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Observacoes);
            builder.Property(p => p.Rua);
            builder.Property(p => p.Bairro);
            builder.Property(p => p.Cidade);
            builder.Property(p => p.Cep);
            builder.Property(p => p.Estado);
            builder.HasOne(p => p.Cliente).WithMany(b => b.Enderecos).HasForeignKey(fk => fk.ClienteId);
        }
    }
}
