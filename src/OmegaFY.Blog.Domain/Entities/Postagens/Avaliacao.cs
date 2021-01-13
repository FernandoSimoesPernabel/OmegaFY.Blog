using Flunt.Validations;
using OmegaFY.Blog.Common.Enums;
using OmegaFY.Blog.Domain.Extensions;
using System;

namespace OmegaFY.Blog.Domain.Entities.Postagens
{

    public class Avaliacao : Entity
    {

        public Guid PostagemId { get; }

        public Guid UsuarioId { get; }

        public DateTime DataAvaliacao { get; }

        public float Nota { get; }

        public Estrelas Estrelas { get; }

        protected Avaliacao() { }

        public Avaliacao(Guid usuarioId, Guid postagemId, Estrelas estrelas)
        {
            new Contract()
                .ValidarUsuarioId(usuarioId)
                .ValidarPostagemId(postagemId)
                .EnsureContractIsValid();

            PostagemId = postagemId;
            UsuarioId = usuarioId;
            DataAvaliacao = DateTime.Now;
            Estrelas = estrelas;
            Nota = estrelas.NotaDaAvaliacao();
        }

    }

}