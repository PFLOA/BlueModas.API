using BlueModas.API.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlueModas.API.Infra.Data.Mapping
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("TB_PRODUTO");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id);
            builder.Property(p => p.Descricao);
            builder.Property(p => p.Imagem);
            builder.Property(p => p.Nome);
            builder.Property(p => p.Preco);
            builder.HasOne(p => p.Categoria).WithMany().HasForeignKey(fk => fk.CategoriaId);
        }
    }
}
