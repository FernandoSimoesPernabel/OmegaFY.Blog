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

            builder.Property(c => c.Id).ValueGeneratedNever();

            builder.Property(c => c.UsuarioId).IsRequired();

            builder.Property(c => c.PostagemId).IsRequired();

            builder.OwnsOne(c => c.Corpo,
                            c => c.Property(c => c.Conteudo)
                                  .HasColumnType($"varchar({ComentariosConstantes.TAMANHO_MAX_COMENTARIO})")
                                  .HasColumnName("Corpo")
                                  .IsRequired());

            builder.OwnsOne(c => c.DetalhesModificacao,
                            dm =>
                            {
                                dm.Property(c => c.DataCriacao).HasColumnType("datetime").HasColumnName("DataCriacao").IsRequired();
                                dm.Property(c => c.DataModificacao).HasColumnType("datetime").HasColumnName("DataModificacao");
                            });

            builder
                .HasMany(c => c.Reacoes)
                .WithOne()
                .HasForeignKey(c => c.ComentarioId)
                .HasConstraintName("FK_ReacaoComentarioId");

            builder.HasMany(c => c.SubComentarios).WithOne().OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("Comentarios");

        }

    }

}
