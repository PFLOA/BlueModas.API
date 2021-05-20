using BlueModas.API.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueModas.API.Infra.Data.Mapping
{
    public class VendaMapping : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.ToTable("TB_VENDA");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id);
            builder.HasOne(p => p.Cliente).WithMany().HasForeignKey(fk => fk.ClienteId);
            builder.HasOne(p => p.Produto).WithMany().HasForeignKey(fk => fk.ProdutoId);
        }
    }
}
