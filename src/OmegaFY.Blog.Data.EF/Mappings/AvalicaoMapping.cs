using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Domain.Entities.Postagens;

namespace OmegaFY.Blog.Data.EF.Mappings
{

    public class AvaliacaoMapping : IEntityTypeConfiguration<Avaliacao>
    {

        public void Configure(EntityTypeBuilder<Avaliacao> builder)
        {

            builder.HasKey(p => p.Id).IsClustered().HasName("PK_AvaliacaoId");

            builder.Property(p => p.UsuarioId).IsRequired();

            builder.Property(p => p.PostagemId).IsRequired();

            builder.Property(p => p.Nota).IsRequired();

            builder.Property(p => p.Estrelas).HasConversion<byte>().IsRequired();

            builder.Property(p => p.DataAvaliacao).IsRequired();

            builder.ToTable("Avaliacoes");

        }

    }

}
