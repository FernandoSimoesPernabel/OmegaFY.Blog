using Flunt.Validations;
using OmegaFY.Blog.Common.Constantes;
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

    public class Postagem : Entity, IAggregateRoot<Postagem>
    {

        private readonly List<Avaliacao> _avaliacoes;

        private readonly List<Comentario> _comentarios;

        private readonly List<Compartilhamento> _compartilhamentos;

        public Guid UsuarioId { get; }

        public bool Oculta { get; private set; }

        public Cabecalho Cabecalho { get; private set; }

        public Corpo Corpo { get; private set; }

        public DetalhesModificacao DetalhesModificacao { get; private set; }

        public IReadOnlyCollection<Avaliacao> Avaliacoes => _avaliacoes.AsReadOnly();

        public IReadOnlyCollection<Comentario> Comentarios => _comentarios.AsReadOnly();

        public IReadOnlyCollection<Compartilhamento> Compartilhamentos => _compartilhamentos.AsReadOnly();

        protected Postagem()
        {
            _avaliacoes = new List<Avaliacao>();
            _comentarios = new List<Comentario>();
            _compartilhamentos = new List<Compartilhamento>();
        }

        public Postagem(Guid usuarioId, Cabecalho cabecalho, string conteudoPostagem) : this()
        {
            new Contract<Postagem>()
                .ValidarUsuarioId(usuarioId)
                .EnsureContractIsValid();

            UsuarioId = usuarioId;

            DefinirCabecalho(cabecalho);

            DefinirCorpoDaPostagem(conteudoPostagem);

            DetalhesModificacao = new DetalhesModificacao();
        }

        public void DefinirCabecalho(Cabecalho cabecalho)
        {
            new Contract<Postagem>().IsNotNull(cabecalho, nameof(cabecalho), "Não foi informado o Título e Subtítulo da postagem").EnsureContractIsValid();

            Cabecalho = cabecalho;

            Modificado();
        }

        public void DefinirCorpoDaPostagem(string conteudoPostagem)
        {
            new Contract<Postagem>()
                .IsBetweenLength(conteudoPostagem,
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
            new Contract<Postagem>()
                .IsFalse(Oculta, nameof(Oculta), $"A Postagem '{Cabecalho.Titulo}' já está oculta e não pode ser ocultada novamente.")
                .EnsureContractIsValid<Postagem, DomainInvalidOperationException>();

            Oculta = true;
        }

        public void Desocultar()
        {
            new Contract<Postagem>()
                .IsTrue(Oculta, nameof(Oculta), $"A Postagem '{Cabecalho.Titulo}' já está visível e não pode ser desocultada novamente.")
                .EnsureContractIsValid<Postagem, DomainInvalidOperationException>();

            Oculta = false;
        }

        public Comentario ObterComentarioDaPostagem(Guid comentarioId)
            => Comentarios.FirstOrDefault(c => c.Id == comentarioId && c.PostagemId == Id);

        public void Comentar(Comentario comentario)
        {
            CriticarSeAcaoFoiRealizadaPeloAutor(comentario?.UsuarioId ?? Guid.Empty, "O autor da postagem pode apenas responder outros comentários.");

            _comentarios.Add(comentario);
        }

        public void EditarComentario(Guid comentarioId, Guid usuarioModificacaoId, string comentario)
        {
            Comentario comentarioQueSeraEditado = _comentarios.FirstOrDefault(c => c.Id == comentarioId);

            new Contract<Postagem>()
                .IsNotNull(comentarioQueSeraEditado, nameof(comentarioQueSeraEditado), "O comentário informado não existe.")
                .EnsureContractIsValid()
                .AreEquals(comentarioQueSeraEditado.UsuarioId,
                           usuarioModificacaoId,
                           nameof(usuarioModificacaoId),
                           "O comentário apenas pode ser editado pelo autor do comentário.")
                .EnsureContractIsValid<Postagem, DomainInvalidOperationException>();

            comentarioQueSeraEditado.Editar(comentario);
        }

        public void EditarSubComentario(Guid comentarioId, Guid subComentarioId, Guid usuarioModificacaoId, string comentario)
        {
            Comentario comentarioPai = ObterComentarioDaPostagem(comentarioId);

            new Contract<Postagem>()
                .IsNotNull(comentarioPai, nameof(comentarioPai), "Não foi encontrado o comentário informado nessa postagem.")
                .EnsureContractIsValid();

            comentarioPai.EditarSubComentario(subComentarioId, usuarioModificacaoId, comentario);
        }

        public void RemoverComentario(Guid comentarioId, Guid usuarioId)
        {
            Comentario comentarioQueSeraRemovido = _comentarios.FirstOrDefault(c => c.Id == comentarioId);

            new Contract<Postagem>()
                .IsNotNull(comentarioQueSeraRemovido, nameof(comentarioQueSeraRemovido), "O comentário informado não existe.")
                .EnsureContractIsValid()
                .AreEquals(comentarioQueSeraRemovido.UsuarioId,
                           usuarioId,
                           nameof(usuarioId),
                           "O comentário apenas pode ser removido pelo autor do comentário.")
                .EnsureContractIsValid<Postagem, DomainInvalidOperationException>();

            _comentarios.Remove(comentarioQueSeraRemovido);
        }

        public int TotalDeComentarios() => _comentarios.Count;

        public int? TotalDeSubComentarios(Guid comentarioId) => ObterComentarioDaPostagem(comentarioId)?.TotalDeComentarios();

        public void Compartilhar(Compartilhamento compartilhamento)
        {
            new Contract<Postagem>()
                .IsNotNull(compartilhamento, nameof(compartilhamento), "Não foi informado nenhum compartilhamento para essa postagem.")
                .EnsureContractIsValid();

            CriticarSeAcaoFoiRealizadaPeloAutor(compartilhamento.UsuarioId, "O autor da postagem não pode compartilhar sua própria postagem.");

            _compartilhamentos.Add(compartilhamento);
        }

        public void Descompartilhar(Guid compartilhamentoId, Guid usuarioId)
        {
            Compartilhamento compartilhamentoQueSeraRemovido = _compartilhamentos.FirstOrDefault(c => c.Id == compartilhamentoId);

            new Contract<Postagem>()
                .IsNotNull(compartilhamentoQueSeraRemovido, nameof(compartilhamentoQueSeraRemovido), "O compartilhamento informado não existe.")
                .EnsureContractIsValid()
                .AreEquals(compartilhamentoQueSeraRemovido.UsuarioId,
                           usuarioId,
                           nameof(usuarioId),
                           "O compartilhamento apenas pode ser descompartilhado pelo usuário que o realizou.")
                .EnsureContractIsValid<Postagem, DomainInvalidOperationException>();

            _compartilhamentos.Remove(compartilhamentoQueSeraRemovido);
        }

        public int TotalDeCompartilhamentos() => _compartilhamentos.Count;

        public void Avaliar(Avaliacao avaliacao)
        {
            CriticarSeAcaoFoiRealizadaPeloAutor(avaliacao?.UsuarioId ?? Guid.Empty, "O autor da postagem não pode avaliar sua própria postagem.");

            _avaliacoes.Add(avaliacao);
        }

        public void RemoverAvaliacao(Guid avaliacaoId, Guid usuarioId)
        {
            Avaliacao avaliacaoQueSeraRemovida = _avaliacoes.FirstOrDefault(c => c.Id == avaliacaoId);

            new Contract<Postagem>()
                .IsNotNull(avaliacaoQueSeraRemovida, nameof(avaliacaoQueSeraRemovida), "A avaliação informada não existe.")
                .EnsureContractIsValid()
                .AreEquals(avaliacaoQueSeraRemovida.UsuarioId,
                           usuarioId,
                           nameof(usuarioId),
                           "A avaliação apenas pode ser removida pelo usuário que a realizou.")
                .EnsureContractIsValid<Postagem, DomainInvalidOperationException>();

            _avaliacoes.Remove(avaliacaoQueSeraRemovida);
        }

        public int TotalDeAvaliacoes() => _avaliacoes.Count;

        public float CalcularNotaMedia()
        {
            if (Avaliacoes.Count() == 0) return 0;
            return Avaliacoes.Sum(avaliacao => avaliacao.Nota) / Avaliacoes.Count();
        }

        private void Modificado()
        {
            if (DetalhesModificacao is not null)
                DetalhesModificacao = new DetalhesModificacao(DetalhesModificacao.DataCriacao);
        }

        private bool VerificarSeAcaoFoiRealizadaPeloAutor(Guid usuarioId) => usuarioId == UsuarioId;

        private void CriticarSeAcaoFoiRealizadaPeloAutor(Guid usuarioId, string mensagemCritica) =>
            new Contract<Postagem>()
                .IsFalse(VerificarSeAcaoFoiRealizadaPeloAutor(usuarioId), nameof(usuarioId), mensagemCritica)
                .EnsureContractIsValid<Postagem, DomainInvalidOperationException>();

        public override string ToString() => Corpo.ToString();

    }

}