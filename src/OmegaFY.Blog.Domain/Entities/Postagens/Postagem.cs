using Flunt.Validations;
using OmegaFY.Blog.Common.Constantes;
using OmegaFY.Blog.Common.Enums;
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

    public class Postagem : Entity, IAggregateRoot
    {

        private readonly ComentariosColecao _comentarios;

        private readonly AvaliacoesColecao _avaliacoes;

        private readonly CompartilhamentosColecao _compartilhamentos;

        public bool Oculta { get; private set; }

        public Cabecalho Cabecalho { get; private set; }

        public Corpo Corpo { get; private set; }

        public DetalhesModificacao DetalhesModificacao { get; }

        public IReadOnlyCollection<Comentario> Comentarios => _comentarios.ReadOnlyCollection;

        public IReadOnlyCollection<Avaliacao> Avaliacoes => _avaliacoes.ReadOnlyCollection;

        public IReadOnlyCollection<Compartilhamento> Compartilhamentos => _compartilhamentos.ReadOnlyCollection;

        public Postagem(Guid usuarioAutorId, Cabecalho cabecalho, string conteudoPostagem)
        {
            new Contract()
                .ValidarUsuarioId(usuarioAutorId)
                .EnsureContractIsValid();

            DefinirCabecalho(cabecalho);

            DefinirCorpoDaPostagem(conteudoPostagem);

            _comentarios = new ComentariosColecao();
            _avaliacoes = new AvaliacoesColecao();
            _compartilhamentos = new CompartilhamentosColecao();

            UsuarioId = usuarioAutorId;
            DetalhesModificacao = new DetalhesModificacao();
        }

        public void DefinirCabecalho(Cabecalho cabecalho)
        {
            new Contract().IsNotNull(cabecalho, nameof(cabecalho), "Não foi informado o Título e Subtítulo da postagem").EnsureContractIsValid();

            Cabecalho = cabecalho;

            DetalhesModificacao?.Modificado();
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

            DetalhesModificacao?.Modificado();
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

        public void Comentar(string comentario, Guid usuarioId)
        {
            CriticarSeAcaoFoiRealizadaPeloAutor(usuarioId, "O autor da postagem pode apenas responder outros comentários.");

            _comentarios.Comentar(new Comentario(usuarioId, Id, comentario));
        }

        public void RemoverComentario(Comentario comentario) => _comentarios.RemoverComentario(comentario);

        public int TotalDeComentarios() => _comentarios.Total();

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

        public override string ToString() => Corpo.ToString();

        private bool VerificarSeAcaoFoiRealizadaPeloAutor(Guid usuarioId) => usuarioId == UsuarioId;

        private void CriticarSeAcaoFoiRealizadaPeloAutor(Guid usuarioId, string mensagemCritica) =>
            new Contract()
                .IsFalse(VerificarSeAcaoFoiRealizadaPeloAutor(usuarioId), nameof(usuarioId), mensagemCritica)
                .EnsureContractIsValid<DomainInvalidOperationException>();

    }

}