using Flunt.Validations;
using OmegaFY.Blog.Common.Constantes;
using OmegaFY.Blog.Common.Enums;
using OmegaFY.Blog.Domain.Core.Entities;
using OmegaFY.Blog.Domain.Entities.Comentarios;
using OmegaFY.Blog.Domain.Exceptions;
using OmegaFY.Blog.Domain.Extensions;
using OmegaFY.Blog.Domain.ValueObjects.Postagens;
using OmegaFY.Blog.Domain.ValueObjects.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OmegaFY.Blog.Domain.Entities.Postagens
{

    public class Postagem : EntityWithUserId, IAggregateRoot<Postagem>
    {

        private readonly ComentariosColecao _comentarios;

        private readonly AvaliacoesColecao _avaliacoes;

        private readonly CompartilhamentosColecao _compartilhamentos;

        public bool Oculta { get; private set; }

        public Cabecalho Cabecalho { get; private set; }

        public Corpo Corpo { get; private set; }

        public DetalhesModificacao DetalhesModificacao { get; private set; }

        public IReadOnlyCollection<Comentario> Comentarios => _comentarios.ReadOnlyCollection;

        public IReadOnlyCollection<Avaliacao> Avaliacoes => _avaliacoes.ReadOnlyCollection;

        public IReadOnlyCollection<Compartilhamento> Compartilhamentos => _compartilhamentos.ReadOnlyCollection;

        protected Postagem() { }

        public Postagem(Guid usuarioAutorId, Cabecalho cabecalho, string conteudoPostagem) : base(usuarioAutorId)
        {
            new Contract()
                .ValidarUsuarioId(usuarioAutorId)
                .EnsureContractIsValid();

            DefinirCabecalho(cabecalho);

            DefinirCorpoDaPostagem(conteudoPostagem);

            _comentarios = new ComentariosColecao();
            _avaliacoes = new AvaliacoesColecao();
            _compartilhamentos = new CompartilhamentosColecao();

            DetalhesModificacao = new DetalhesModificacao();
        }

        public void DefinirCabecalho(Cabecalho cabecalho)
        {
            new Contract().IsNotNull(cabecalho, nameof(cabecalho), "Não foi informado o Título e Subtítulo da postagem").EnsureContractIsValid();

            Cabecalho = cabecalho;

            Modificado();
        }

        public void DefinirCorpoDaPostagem(string conteudoPostagem)
        {
            new Contract()
                .IsBetween(conteudoPostagem,
                           PostagensConstantes.TAMANHO_MIN_CORPO,
                           PostagensConstantes.TAMANHO_MAX_CORPO,
                           nameof(conteudoPostagem),
                           $"O conteúdo da postagem precisa conter entre {PostagensConstantes.TAMANHO_MIN_CORPO} e {PostagensConstantes.TAMANHO_MAX_CORPO} caracteres.")
                .EnsureContractIsValid();

            Corpo = conteudoPostagem;

            Modificado();
        }

        public void Ocultar()
        {
            new Contract()
                .IsFalse(Oculta, nameof(Oculta), $"A Postagem '{Cabecalho.Titulo}' já está oculta e não pode ser ocultada novamente.")
                .EnsureContractIsValid<DomainInvalidOperationException>();

            Oculta = true;
        }

        public void Desocultar()
        {
            new Contract()
                .IsTrue(Oculta, nameof(Oculta), $"A Postagem '{Cabecalho.Titulo}' já está visível e não pode ser desocultada novamente.")
                .EnsureContractIsValid<DomainInvalidOperationException>();

            Oculta = false;
        }

        public Comentario ObterComentarioDaPostagem(Guid comentarioId)
            => Comentarios.FirstOrDefault(c => c.Id == comentarioId && c.PostagemId == Id);

        public void Comentar(string comentario, Guid usuarioId)
        {
            CriticarSeAcaoFoiRealizadaPeloAutor(usuarioId, "O autor da postagem pode apenas responder outros comentários.");

            _comentarios.Comentar(new Comentario(usuarioId, Id, comentario));
        }

        public void EditarComentario(Guid comentarioId, Guid usuarioModificacaoId, string comentario)
            => _comentarios.EditarComentario(comentarioId, usuarioModificacaoId, comentario);

        public void EditarSubComentario(Guid comentarioId, Guid subComentarioId, Guid usuarioModificacaoId, string comentario)
        {
            Comentario comentarioPai = ObterComentarioDaPostagem(comentarioId);

            new Contract()
                .IsNotNull(comentarioPai, nameof(comentarioPai), "Não foi encontrado o comentário informado nessa postagem.")
                .EnsureContractIsValid();

            comentarioPai.EditarSubComentario(subComentarioId, usuarioModificacaoId, comentario);
        }

        public void RemoverComentario(Comentario comentario) => _comentarios.RemoverComentario(comentario);

        public int TotalDeComentarios() => _comentarios.Total();

        public int? TotalDeSubComentarios(Guid comentarioId) => ObterComentarioDaPostagem(comentarioId)?.TotalDeComentarios();

        public void Compartilhar(Guid usuarioId)
        {
            CriticarSeAcaoFoiRealizadaPeloAutor(usuarioId, "O autor da postagem não pode compartilhar sua própria postagem.");

            _compartilhamentos.Compartilhar(new Compartilhamento(usuarioId, Id));
        }

        public void Descompartilhar(Compartilhamento compartilhamento) => _compartilhamentos.Descompartilhar(compartilhamento);

        public int TotalDeCompartilhamentos() => _compartilhamentos.Total();

        public void Avaliar(Guid usuarioId, Estrelas estrelas)
        {
            CriticarSeAcaoFoiRealizadaPeloAutor(usuarioId, "O autor da postagem não pode avaliar sua própria postagem.");

            _avaliacoes.Avaliar(new Avaliacao(usuarioId, Id, estrelas));
        }

        public void RemoverAvaliacao(Avaliacao avaliacao) => _avaliacoes.RemoverAvaliacao(avaliacao);

        public int TotalDeAvaliacoes() => _avaliacoes.Total();

        public float CalcularNotaMedia()
        {
            if (Avaliacoes.Count() == 0) return 0;
            return Avaliacoes.Sum(avaliacao => avaliacao.Nota) / Avaliacoes.Count();
        }

        private void Modificado()
        {
            if (DetalhesModificacao != null)
                DetalhesModificacao = new DetalhesModificacao(DetalhesModificacao.DataCriacao);
        }

        private bool VerificarSeAcaoFoiRealizadaPeloAutor(Guid usuarioId) => usuarioId == UsuarioId;

        private void CriticarSeAcaoFoiRealizadaPeloAutor(Guid usuarioId, string mensagemCritica) =>
            new Contract()
                .IsFalse(VerificarSeAcaoFoiRealizadaPeloAutor(usuarioId), nameof(usuarioId), mensagemCritica)
                .EnsureContractIsValid<DomainInvalidOperationException>();

        public override string ToString() => Corpo.ToString();

    }

}