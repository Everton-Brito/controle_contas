using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaContas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaContas.Data.Mappings
{
    public class ContaMapping : IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder.ToTable("CONTA");

            builder.HasKey(c => c.IdConta);

            builder.Property(c => c.IdConta)
                .HasColumnName("IDCONTA")
                .IsRequired();

            builder.Property(c => c.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(c => c.Data)
                .HasColumnName("DATA")
                .IsRequired();

            builder.Property(c => c.Valor)
                .HasColumnName("VALOR")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(c => c.Tipo)
                .HasColumnName("TIPO")
                .IsRequired();
        }
    }
}
