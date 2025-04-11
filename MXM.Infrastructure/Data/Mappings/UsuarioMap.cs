using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MXM.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MXM.Infrastructure.Data.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("VGUSUARIOS_VGU");

            builder.HasKey(x => x.Id);
            builder.Property(x=> x.Id).HasColumnName("VGU_IDUSUARIO");
            builder.Property(x => x.Nome).HasColumnName("VGU_NOME").IsRequired().HasMaxLength(30);
            builder.Property(x => x.Sobrenome).HasColumnName("VGU_SOBRENOME").IsRequired().HasMaxLength(30);
            builder.Property(x => x.Telefone).HasColumnName("VGU_TELEFONE");
            builder.Property(x => x.Password).HasColumnName("VGU_PASSWORDHASH").IsRequired().HasMaxLength(200);
            builder.Property(x => x.Email).HasColumnName("VGU_EMAIL").IsRequired().HasMaxLength(30);
            builder.Property(x => x.Ativo).HasColumnName("VGU_ATIVO");
        }
    }
}
