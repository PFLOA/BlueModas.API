using BlueModas.API.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueModas.API.Infra.Data.Mapping
{
    class ItensMapping : IEntityTypeConfiguration<Itens>
    {
        public void Configure(EntityTypeBuilder<Itens> builder)
        {
            builder.ToTable("TB_ITENS_VENDA");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Quantidade);
            builder.HasOne(p => p.Produto).WithOne().HasForeignKey<Itens>(fk => fk.IdProduto);
            builder.HasOne(p => p.Venda).WithMany(b => b.Itens).HasForeignKey(fk => fk.IdVenda);
        }
    }
}
