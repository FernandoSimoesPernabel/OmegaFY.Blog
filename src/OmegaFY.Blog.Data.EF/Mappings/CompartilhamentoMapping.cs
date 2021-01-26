using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Domain.Entities.Postagens;

namespace OmegaFY.Blog.Data.EF.Mappings
{

    public class CompartilhamentoMapping : IEntityTypeConfiguration<Compartilhamento>
    {

        public void Configure(EntityTypeBuilder<Compartilhamento> builder)
        {

            builder.Property(c => c.Id).ValueGeneratedNever();

            builder.Property(c => c.UsuarioId).IsRequired();

            builder.Property(c => c.PostagemId).IsRequired();

            builder.Property(c => c.DataCompartilhamento).HasColumnType("datetime").IsRequired();

            builder.ToTable("Compartilhamentos");

        }

    }

}
