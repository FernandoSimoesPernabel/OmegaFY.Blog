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

            builder.Property(p => p.Id).ValueGeneratedNever();

            builder.Property(p => p.UsuarioId).IsRequired();

            builder.Property(p => p.PostagemId).IsRequired();

            builder.OwnsOne(p => p.Corpo,
                            c => c.Property(p => p.Conteudo)
                                  .HasColumnType($"varchar({ComentariosConstantes.TAMANHO_MAX_COMENTARIO})")
                                  .HasColumnName("Corpo")
                                  .IsRequired());

            builder.OwnsOne(p => p.DetalhesModificacao,
                            dm =>
                            {
                                dm.Property(p => p.DataCriacao).HasColumnType("datetime").HasColumnName("DataCriacao").IsRequired();
                                dm.Property(p => p.DataModificacao).HasColumnType("datetime").HasColumnName("DataModificacao");
                            });

            builder.HasMany(p => p.Reacoes).WithOne().OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("SubComentarios");

        }

    }

}
