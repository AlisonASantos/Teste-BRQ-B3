using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BRQ_B3.Business.Models;

namespace BRQ_B3.Data.Mappings
{
    public class CalculoCDBMapping : IEntityTypeConfiguration<CalculoCDB>
    {
        public void Configure(EntityTypeBuilder<CalculoCDB> builder)
        {
            builder.HasKey(p => p.Id);

            // Mapeia as propriedades
            builder.Property(c => c.ValorInicial)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(c => c.Cdi)
                .IsRequired()
                .HasColumnType("decimal(18,6)");

            builder.Property(c => c.TaxaBanco)
                .IsRequired()
                .HasColumnType("decimal(18,6)");

            builder.Property(c => c.Meses)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(c => c.ValorFinal)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            // Mapeia para a tabela
            builder.ToTable("CalculosCDB");
        }
    }
}