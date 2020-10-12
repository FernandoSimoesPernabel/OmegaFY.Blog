using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Common.Constantes;
using OmegaFY.Blog.Domain.Entities.Comentarios;

namespace OmegaFY.Blog.Data.EF.Mappings
{

    public class SubComentarioMapping : IEntityTypeConfiguration<Comentario>
    {

        public void Configure(EntityTypeBuilder<Comentario> builder)
        {

            builder.HasKey(p => p.Id).IsClustered().HasName("PK_ComentarioId");

            builder.Property(p => p.UsuarioId).IsRequired();

            builder.Property(p => p.PostagemId).IsRequired();

            builder.OwnsOne(p => p.Corpo,
                            c => c.Property(p => p.Conteudo)
                                  .HasColumnName($"varchar({ComentariosConstantes.TAMANHO_MAX_COMENTARIO})")
                                  .IsRequired());

            builder.OwnsOne(p => p.DetalhesModificacao,
                            dm =>
                            {
                                dm.Property(p => p.DataCriacao).IsRequired();
                                dm.Property(p => p.DataModificacao);
                            });

            builder
                .HasMany(p => p.Reacoes)
                .WithOne();

            builder
                .HasMany(p => p.SubComentarios)
                .WithOne()
                .HasForeignKey(p => p.ComentarioId)
                .HasConstraintName("FK_SubComentarioComentarioId");

            builder.ToTable("Comentarios");

        }

    }

}
