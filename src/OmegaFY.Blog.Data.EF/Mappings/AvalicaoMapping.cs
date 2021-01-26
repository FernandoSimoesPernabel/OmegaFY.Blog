using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Domain.Entities.Postagens;

namespace OmegaFY.Blog.Data.EF.Mappings
{

    public class AvaliacaoMapping : IEntityTypeConfiguration<Avaliacao>
    {

        public void Configure(EntityTypeBuilder<Avaliacao> builder)
        {

            builder.Property(a => a.Id).ValueGeneratedNever();          

            builder.Property(a => a.UsuarioId).IsRequired();

            builder.Property(a => a.PostagemId).IsRequired();

            builder.Property(a => a.Nota).IsRequired();

            builder.Property(a => a.Estrelas).HasConversion<byte>().IsRequired();

            builder.Property(a => a.DataAvaliacao).IsRequired();

            builder.ToTable("Avaliacoes");

        }

    }

}
