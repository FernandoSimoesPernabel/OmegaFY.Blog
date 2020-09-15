using Flunt.Validations;
using OmegaFY.Blog.Common.Enums;
using OmegaFY.Blog.Common.Extensions;
using OmegaFY.Blog.Domain.Extensions;
using System;

namespace OmegaFY.Blog.Domain.Entities.Postagens
{

    public class Avaliacao : Entity
    {

        public Guid PostagemId { get; }

        public DateTime DataAvaliacao { get; }

        public float Nota { get; }

        public Estrelas Estrelas { get; }

        public Avaliacao(Guid usuarioId, Guid postagemId, Estrelas estrelas)
        {
            new Contract()
                .ValidarUsuarioId(usuarioId)
                .ValidarPostagemId(postagemId)
                .EnsureContractIsValid();

            UsuarioId = usuarioId;
            PostagemId = postagemId;
            DataAvaliacao = DateTime.Now;
            Estrelas = estrelas;
            Nota = estrelas.NotaDaAvaliacao();
        }

    }

}