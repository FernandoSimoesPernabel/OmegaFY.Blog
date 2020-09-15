using FluentAssertions;
using OmegaFY.Blog.Common.Constantes;
using OmegaFY.Blog.Common.Enums;
using OmegaFY.Blog.Domain.Entities.Postagens;
using OmegaFY.Blog.Domain.Exceptions;
using System;
using System.Collections.Generic;
using Xunit;

namespace OmegaFY.Blog.Test.Unit.Domain.Entities.Postagens
{

    public class AvaliacaoTests
    {

        private readonly Guid _usuarioId;

        private readonly Guid _postagemId;

        private readonly Estrelas _cincoEstrelas;

        public AvaliacaoTests()
        {
            _usuarioId = Guid.NewGuid();
            _postagemId = Guid.NewGuid();
            _cincoEstrelas = Estrelas.CincoEstrelas;
        }

        public static IEnumerable<object[]> CriarAvaliacaoInvalidaTheory
        {
            get
            {
                yield return new object[] { Guid.Empty, Guid.NewGuid(), Estrelas.ZeroEstrelas };
                yield return new object[] { Guid.NewGuid(), Guid.Empty, Estrelas.MeiaEstrela };
                yield return new object[] { Guid.Empty, Guid.Empty, Estrelas.UmaEstrela };
            }
        }

        [Fact(DisplayName = nameof(CriarAvaliacao_AvaliacaoValida_CriadaComSucesso))]
        [Trait(nameof(AvaliacaoTests), "Criação")]
        public void CriarAvaliacao_AvaliacaoValida_CriadaComSucesso()
        {
            //Act
            Avaliacao avaliacao = new Avaliacao(_usuarioId, _postagemId, _cincoEstrelas);

            //Assert
            avaliacao.UsuarioId.Should().Be(_usuarioId);
            avaliacao.PostagemId.Should().Be(_postagemId);
            avaliacao.DataAvaliacao.Should().BeCloseTo(DateTime.Now, 1000);
            avaliacao.Estrelas.Should().Be(_cincoEstrelas);
        }

        [Theory(DisplayName = nameof(CriarAvaliacao_AvaliacaoInvalida_DeveJogarDomainArgumentExceptionComDoisErros))]
        [Trait(nameof(AvaliacaoTests), "Criação")]
        [MemberData(nameof(CriarAvaliacaoInvalidaTheory))]
        public void CriarAvaliacao_AvaliacaoInvalida_DeveJogarDomainArgumentExceptionComDoisErros(Guid usuarioId,
                                                                                                  Guid postagemId,
                                                                                                  Estrelas estrelas)
        {
            //Act
            Action avaliacao = () => new Avaliacao(usuarioId, postagemId, estrelas);

            //Assert
            avaliacao.Should().ThrowExactly<DomainArgumentException>()
                .And.ErrorCode.Should().Be(DomainErrorCodes.DOMAIN_ARGUMENT_ERROR_CODE);

        }

        [Theory(DisplayName = nameof(NotaDaAvaliacao_NotaCalculada_ValorDaNotaCondizComNumeroDeEstrelas))]
        [Trait(nameof(AvaliacaoTests), "NotaCalculada")]
        [InlineData(Estrelas.ZeroEstrelas, 0)]
        [InlineData(Estrelas.MeiaEstrela, 0.5)]
        [InlineData(Estrelas.UmaEstrela, 1)]
        [InlineData(Estrelas.UmaEstrelaMeia, 1.5)]
        [InlineData(Estrelas.DuasEstrelas, 2)]
        [InlineData(Estrelas.DuasEstrelasMeia, 2.5)]
        [InlineData(Estrelas.TresEstrelas, 3)]
        [InlineData(Estrelas.TresEstrelasMeia, 3.5)]
        [InlineData(Estrelas.QuatroEstrelas, 4)]
        [InlineData(Estrelas.QuatroEstrelasMeia, 4.5)]
        [InlineData(Estrelas.CincoEstrelas, 5)]
        public void NotaDaAvaliacao_NotaCalculada_ValorDaNotaCondizComNumeroDeEstrelas(Estrelas estrelas, float nota)
        {

            //Act
            Avaliacao avaliacao = new Avaliacao(_usuarioId, _postagemId, estrelas);

            //Assert
            avaliacao.Estrelas.Should().Be(estrelas);
            avaliacao.Nota.Should().Be(nota);

        }


    }

}
