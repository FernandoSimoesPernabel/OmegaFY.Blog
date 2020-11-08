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

            builder.HasKey(p => p.Id).IsClustered().HasName("PK_SubComentarioId");

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
                                dm.Property(p => p.DataCriacao).HasColumnName("DataCriacao").IsRequired();
                                dm.Property(p => p.DataModificacao).HasColumnName("DataModificacao");
                            });

            builder.HasMany(p => p.Reacoes).WithOne();

            builder.ToTable("SubComentarios");

        }

    }

}
