using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Domain.Entities.Comentarios;

namespace OmegaFY.Blog.Data.EF.Mappings
{

    public class ReacaoMapping : IEntityTypeConfiguration<Reacao>
    {

        public void Configure(EntityTypeBuilder<Reacao> builder)
        {

            builder.Property(r => r.Id).ValueGeneratedNever();

            builder.Property(r => r.UsuarioId).IsRequired();

            builder.Property(r => r.ComentarioId).IsRequired();

            builder.Property(r => r.SubComentarioId);

            builder.Property(r => r.ReacaoUsuario).HasConversion<byte>().IsRequired();

            builder.ToTable("Reacoes");

        }

    }

}
