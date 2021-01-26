using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Common.Constantes;
using OmegaFY.Blog.Domain.Entities.Comentarios;

namespace OmegaFY.Blog.Data.EF.Mappings
{

    public class ComentarioMapping : IEntityTypeConfiguration<SubComentario>
    {

        public void Configure(EntityTypeBuilder<SubComentario> builder)
        {

            builder.Property(sc => sc.Id).ValueGeneratedNever();

            builder.Property(sc => sc.UsuarioId).IsRequired();

            builder.Property(sc => sc.PostagemId).IsRequired();

            builder.OwnsOne(sc => sc.Corpo,
                            c => c.Property(sc => sc.Conteudo)
                                  .HasColumnType($"varchar({ComentariosConstantes.TAMANHO_MAX_COMENTARIO})")
                                  .HasColumnName("Corpo")
                                  .IsRequired());

            builder.OwnsOne(sc => sc.DetalhesModificacao,
                            dm =>
                            {
                                dm.Property(sc => sc.DataCriacao).HasColumnType("datetime").HasColumnName("DataCriacao").IsRequired();
                                dm.Property(sc => sc.DataModificacao).HasColumnType("datetime").HasColumnName("DataModificacao");
                            });

            builder.HasMany(sc => sc.Reacoes).WithOne().OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("SubComentarios");

        }

    }

}
