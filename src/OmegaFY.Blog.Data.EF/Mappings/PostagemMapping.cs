using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmegaFY.Blog.Common.Constantes;
using OmegaFY.Blog.Domain.Entities.Postagens;

namespace OmegaFY.Blog.Data.EF.Mappings
{

    public class PostagemMapping : IEntityTypeConfiguration<Postagem>
    {

        public void Configure(EntityTypeBuilder<Postagem> builder)
        {

            builder.HasKey(p => p.Id).IsClustered().HasName("PK_PostagemId");

            builder.Property(p => p.UsuarioId).IsRequired();

            builder.Property(p => p.Oculta).IsRequired();

            builder.OwnsOne(p => p.Corpo,
                            c => c.Property(p => p.Conteudo)
                                  .HasColumnType($"varchar({PostagensConstantes.TAMANHO_MAX_CORPO})")
                                  .HasColumnName("Corpo")
                                  .IsRequired());

            builder.OwnsOne(p => p.DetalhesModificacao,
                            dm =>
                            {
                                dm.Property(p => p.DataCriacao).HasColumnName("DataCriacao").IsRequired();
                                dm.Property(p => p.DataModificacao).HasColumnName("DataModificacao");
                            });

            builder.OwnsOne(p => p.Cabecalho,
                            cab =>
                            {
                                cab.Property(p => p.Titulo)
                                   .HasColumnType($"varchar({PostagensConstantes.TAMANHO_MAX_TITULO})")
                                   .HasColumnName("Titulo")
                                   .IsRequired();

                                cab.Property(p => p.SubTitulo)
                                   .HasColumnType($"varchar({PostagensConstantes.TAMANHO_MAX_SUB_TITULO})")
                                   .HasColumnName("SubTitulo")
                                   .IsRequired();
                            });

            builder
                .HasMany(p => p.Avaliacoes)
                .WithOne()
                .HasForeignKey(p => p.PostagemId)
                .HasConstraintName("FK_AvaliacaoPostagemId");

            builder
                .HasMany(p => p.Comentarios)
                .WithOne()
                .HasForeignKey(p => p.PostagemId)
                .HasConstraintName("FK_ComentarioPostagemId");

            builder
                .HasMany(p => p.Compartilhamentos)
                .WithOne()
                .HasForeignKey(p => p.PostagemId)
                .HasConstraintName("FK_CompartilhamentoPostagemId");

            builder.ToTable("Postagens");

        }

    }

}
