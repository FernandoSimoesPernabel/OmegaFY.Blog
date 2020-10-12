using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Domain.Entities.Postagens;

namespace OmegaFY.Blog.Data.EF.Mappings
{

    public class CompartilhamentoMapping : IEntityTypeConfiguration<Compartilhamento>
    {

        public void Configure(EntityTypeBuilder<Compartilhamento> builder)
        {

            builder.HasKey(p => p.Id).IsClustered().HasName("PK_CompartilhamentoId");

            builder.Property(p => p.UsuarioId).IsRequired();

            builder.Property(p => p.PostagemId).IsRequired();

            builder.Property(p => p.DataCompartilhamento).IsRequired();

            builder.ToTable("Compartilhamentos");

        }

    }

}
