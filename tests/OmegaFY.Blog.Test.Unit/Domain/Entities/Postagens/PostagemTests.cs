using Bogus;
using FluentAssertions;
using OmegaFY.Blog.Domain.Core.Constantes;
using OmegaFY.Blog.Domain.Entities.Comentarios;
using OmegaFY.Blog.Domain.Entities.Postagens;
using OmegaFY.Blog.Domain.Exceptions;
using OmegaFY.Blog.Domain.ValueObjects.Postagens;
using OmegaFY.Blog.Domain.ValueObjects.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace OmegaFY.Blog.Test.Unit.Domain.Entities.Postagens
{

    public class PostagemTests
    {

        public PostagemTests()
        {
        }

        private static readonly Faker _faker = new Faker();

        private static Postagem CriarPostagemValida() => new Postagem(Guid.NewGuid(), CriarCabecalhoValido(), GerarCorpoPostagem());

        private static Cabecalho CriarCabecalhoValido() => new Cabecalho(_faker.Music.Random.Word(), _faker.Music.Random.Word());

        private static string GerarCorpoPostagem() => _faker.Lorem.Word();

        public static IEnumerable<object[]> CriarPostagemInvalidaTheory
        {
            get
            {
                yield return new object[] { Guid.Empty, CriarCabecalhoValido(), GerarCorpoPostagem() };
                yield return new object[] { Guid.NewGuid(), null, GerarCorpoPostagem() };
                yield return new object[] { Guid.NewGuid(), null, null };
                yield return new object[] { Guid.NewGuid(), null, string.Empty };
                yield return new object[] { Guid.NewGuid(), null, new string('A', PostagensConstantes.TAMANHO_MAX_CORPO + 1) };
            }
        }

        [Fact(DisplayName = nameof(Construtor_PostagemValida_DeveCriarComSucesso))]
        [Trait(nameof(Postagem), "Criação da Entidade")]
        public void Construtor_PostagemValida_DeveCriarComSucesso()
        {

            //Arrange
            Guid usuarioAutorId = Guid.NewGuid();
            Cabecalho cabecalho = CriarCabecalhoValido();
            Corpo conteudoPostagem = GerarCorpoPostagem();

            //Act
            Postagem postagem = new Postagem(usuarioAutorId, cabecalho, conteudoPostagem);

            //Assert
            postagem.Id.Should().NotBeEmpty();
            postagem.UsuarioId.Should().Be(usuarioAutorId);

            postagem.Avaliacoes.Should().HaveCount(0);
            postagem.Comentarios.Should().HaveCount(0);
            postagem.Compartilhamentos.Should().HaveCount(0);

            postagem.Cabecalho.Should().BeEquivalentTo(cabecalho);
            postagem.Corpo.Should().BeEquivalentTo(conteudoPostagem);

            postagem.DetalhesModificacao.DataModificacao.Should().BeNull();
            postagem.DetalhesModificacao.DataCriacao.Should().BeCloseTo(DateTime.Now, 1000);

            postagem.Oculta.Should().BeFalse();

        }

        [Theory(DisplayName = nameof(Construtor_PostagemValida_DeveJogarDomainArgumentException))]
        [Trait(nameof(Postagem), "Criação da Entidade")]
        [MemberData(nameof(CriarPostagemInvalidaTheory))]
        public void Construtor_PostagemValida_DeveJogarDomainArgumentException(Guid usuarioAutorId,
                                                                               Cabecalho cabecalho,
                                                                               string conteudoPostagem)
        {
            //Act
            Action postagem = () => new Postagem(usuarioAutorId, cabecalho, conteudoPostagem);

            //Assert
            postagem.Should().ThrowExactly<DomainArgumentException>()
                .And.ErrorCode.Should().Be(DomainErrorCodes.DOMAIN_ARGUMENT_ERROR_CODE);

        }

        [Fact(DisplayName = nameof(Comentar_ComentarioValido_ComentarioAdicionadoComSucesso))]
        [Trait(nameof(Postagem), "Comentarios")]
        public void Comentar_ComentarioValido_ComentarioAdicionadoComSucesso()
        {
            //Arrange
            Postagem postagem = CriarPostagemValida();
            string comentario = _faker.Lorem.Word();
            string comentario2 = _faker.Lorem.Word();
            Guid usuarioId = Guid.NewGuid();

            //Act
            postagem.Comentar(comentario, usuarioId);
            postagem.Comentar(comentario2, usuarioId);

            //Assert
            postagem.TotalDeComentarios().Should().Be(2);

            postagem.Comentarios.ToList()[0].Corpo.Conteudo.Should().Be(comentario);
            postagem.Comentarios.ToList()[0].SubComentarios.Should().HaveCount(0);

            postagem.Comentarios.ToList()[1].Corpo.Conteudo.Should().Be(comentario2);
            postagem.Comentarios.ToList()[1].SubComentarios.Should().HaveCount(0);
        }

        //[Theory(DisplayName = nameof(Comentar_ComentarioInvalido_DeveJogarDomainArgumentException))]
        //[Trait(nameof(Postagem), "Comentarios")]
        //public void Comentar_ComentarioInvalido_DeveJogarDomainArgumentException()
        //{
        //    //Arrange


        //    //Act


        //    //Assert

        //}

        [Fact(DisplayName = nameof(Comentar_ComentarioDoProprioAutor_DeveJogarDomainInvalidOperationException))]
        [Trait(nameof(Postagem), "Comentarios")]
        public void Comentar_ComentarioDoProprioAutor_DeveJogarDomainInvalidOperationException()
        {
            //Arrange
            Postagem postagem = CriarPostagemValida();
            string comentario = _faker.Lorem.Word();
            Guid usuarioId = postagem.UsuarioId;

            //Act
            Action comentar = () => postagem.Comentar(comentario, usuarioId);

            //Assert
            comentar.Should().ThrowExactly<DomainInvalidOperationException>()
                .And.ErrorCode.Should().Be(DomainErrorCodes.INVALID_OPERATION_ERROR_CODE);

        }

        [Fact(DisplayName = nameof(RemoverComentario_ComentarioExistente_DeveRemoverComSucesso))]
        [Trait(nameof(Postagem), "Comentarios")]
        public void RemoverComentario_ComentarioExistente_DeveRemoverComSucesso()
        {
            //Arrange
            Postagem postagem = CriarPostagemValida();
            string comentario1 = _faker.Lorem.Word();
            string comentario2 = _faker.Lorem.Word();
            Guid usuarioId = Guid.NewGuid();

            postagem.Comentar(comentario1, usuarioId);
            postagem.Comentar(comentario2, usuarioId);

            Comentario comentario = postagem.Comentarios.FirstOrDefault();

            //Act
            postagem.RemoverComentario(comentario);

            //Assert
            postagem.TotalDeComentarios().Should().Be(1);
            postagem.Comentarios.Should().NotContain(c => c.Id == comentario.Id);
        }

        [Fact(DisplayName = nameof(RemoverComentario_ComentarioSemUsuarioOriginal_DeveJogarDomainInvalidOperationException))]
        [Trait(nameof(Postagem), "Comentarios")]
        public void RemoverComentario_ComentarioSemUsuarioOriginal_DeveJogarDomainInvalidOperationException()
        {
            //Arrange


            //Act


            //Assert

        }

        [Fact(DisplayName = nameof(RemoverComentario_ComentarioNaoExiste_DeveJogarDomainArgumentException))]
        [Trait(nameof(Postagem), "Comentarios")]
        public void RemoverComentario_ComentarioNaoExiste_DeveJogarDomainArgumentException()
        {
            //Arrange


            //Act


            //Assert

        }

        [Fact(DisplayName = nameof(RemoverComentario_ComentarioNulo_DeveJogarDomainArgumentException))]
        [Trait(nameof(Postagem), "Comentarios")]
        public void RemoverComentario_ComentarioNulo_DeveJogarDomainArgumentException()
        {
            //Arrange


            //Act


            //Assert

        }


        [Fact(DisplayName = nameof(Ocultar_PostagemVisivel_DeveOcultar))]
        [Trait(nameof(Postagem), "Ocultar/Desocultar")]
        public void Ocultar_PostagemVisivel_DeveOcultar()
        {
            //Arrange
            Postagem postagem = CriarPostagemValida();

            //Act
            postagem.Ocultar();

            //Assert
            postagem.Oculta.Should().BeTrue();
        }

        [Fact(DisplayName = nameof(Ocultar_PostagemOculta_DeveJogarDomainInvalidOperationException))]
        [Trait(nameof(Postagem), "Ocultar/Desocultar")]
        public void Ocultar_PostagemOculta_DeveJogarDomainInvalidOperationException()
        {
            //Arrange
            Postagem postagem = CriarPostagemValida();
            postagem.Ocultar();

            //Act
            Action ocultar = postagem.Ocultar;

            //Assert
            ocultar.Should().ThrowExactly<DomainInvalidOperationException>()
                .And.ErrorCode.Should().Be(DomainErrorCodes.INVALID_OPERATION_ERROR_CODE);
        }

        [Fact(DisplayName = nameof(Desocultar_PostagemOculta_DeveDesocultar))]
        [Trait(nameof(Postagem), "Ocultar/Desocultar")]
        public void Desocultar_PostagemOculta_DeveDesocultar()
        {
            //Arrange
            Postagem postagem = CriarPostagemValida();
            postagem.Ocultar();

            //Act
            postagem.Desocultar();

            //Assert
            postagem.Oculta.Should().BeFalse();
        }

        [Fact(DisplayName = nameof(Desocultar_PostagemVisivel_DeveJogarDomainInvalidOperationException))]
        [Trait(nameof(Postagem), "Ocultar/Desocultar")]
        public void Desocultar_PostagemVisivel_DeveJogarDomainInvalidOperationException()
        {
            //Arrange
            Postagem postagem = CriarPostagemValida();

            //Act
            Action desocultar = postagem.Desocultar;

            //Assert
            desocultar.Should().ThrowExactly<DomainInvalidOperationException>()
                .And.ErrorCode.Should().Be(DomainErrorCodes.INVALID_OPERATION_ERROR_CODE);
        }

        [Fact(DisplayName = nameof(DetalhesModificacao_EntidadeAlterada_DeveTerDataModificacaoPreenchida))]
        [Trait(nameof(Postagem), "DataModificacao")]
        public void DetalhesModificacao_EntidadeAlterada_DeveTerDataModificacaoPreenchida()
        {
            //Arrange
            Postagem postagem = CriarPostagemValida();

            //Act
            postagem.DefinirCorpoDaPostagem("Novo Corpo");

            //Assert
            postagem.DetalhesModificacao.DataModificacao.Should().BeCloseTo(DateTime.Now, 1000);
        }

    }

}
