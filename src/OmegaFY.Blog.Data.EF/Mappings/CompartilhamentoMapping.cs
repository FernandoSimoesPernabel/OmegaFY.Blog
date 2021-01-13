using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Domain.Entities.Postagens;

namespace OmegaFY.Blog.Data.EF.Mappings
{

    public class CompartilhamentoMapping : IEntityTypeConfiguration<Compartilhamento>
    {

        public void Configure(EntityTypeBuilder<Compartilhamento> builder)
        {

            builder.Property(p => p.Id).ValueGeneratedNever();

            builder.Property(p => p.UsuarioId).IsRequired();

            builder.Property(p => p.PostagemId).IsRequired();

            builder.Property(p => p.DataCompartilhamento).HasColumnType("datetime").IsRequired();

            builder.ToTable("Compartilhamentos");

        }

    }

}
