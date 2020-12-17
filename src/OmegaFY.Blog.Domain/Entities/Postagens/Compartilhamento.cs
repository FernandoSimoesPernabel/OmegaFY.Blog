using Flunt.Validations;
using OmegaFY.Blog.Domain.Core.Entities;
using OmegaFY.Blog.Domain.Extensions;
using System;

namespace OmegaFY.Blog.Domain.Entities.Postagens
{

    public class Compartilhamento : EntityWithUserId
    {

        public Guid PostagemId { get; }

        public DateTime DataCompartilhamento { get; }

        protected Compartilhamento() { }

        public Compartilhamento(Guid usuarioId, Guid postagemId) : base(usuarioId)
        {
            new Contract()
                .ValidarUsuarioId(usuarioId)
                .ValidarPostagemId(postagemId)
                .EnsureContractIsValid();

            PostagemId = postagemId;
            DataCompartilhamento = DateTime.Now;
        }

    }

}
