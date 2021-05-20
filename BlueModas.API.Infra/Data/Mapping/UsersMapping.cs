using BlueModas.API.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueModas.API.Infra.Data.Mapping
{
    public class UsersMapping : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.ToTable("TB_USERS");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id);
            builder.Property(p => p.DataCadastro);
            builder.Property(p => p.Password);
            builder.Property(p => p.NivelAcesso);
            builder.Property(p => p.Name);
            builder.Property(p => p.UserName);
        }
    }
}
