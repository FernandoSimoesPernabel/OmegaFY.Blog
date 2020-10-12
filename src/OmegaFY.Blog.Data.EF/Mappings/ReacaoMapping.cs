using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Domain.Entities.Comentarios;

namespace OmegaFY.Blog.Data.EF.Mappings
{

    public class ReacaoMapping : IEntityTypeConfiguration<Reacao>
    {

        public void Configure(EntityTypeBuilder<Reacao> builder)
        {

            builder.HasKey(p => p.Id).IsClustered().HasName("PK_ReacaoId");

            builder.Property(p => p.UsuarioId).IsRequired();

            builder.Property(p => p.ComentarioId).IsRequired();

            builder.Property(p => p.ReacaoUsuario).HasConversion<byte>().IsRequired();

            builder.ToTable("Reacoes");

        }

    }

}
