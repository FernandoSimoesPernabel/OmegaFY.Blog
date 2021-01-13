using Flunt.Validations;
using OmegaFY.Blog.Domain.Core.Entities;
using OmegaFY.Blog.Domain.Extensions;
using System;

namespace OmegaFY.Blog.Domain.Entities.Postagens
{

    public class Compartilhamento : Entity
    {

        public Guid PostagemId { get; }

        public Guid UsuarioId { get; }

        public DateTime DataCompartilhamento { get; }

        protected Compartilhamento() { }

        public Compartilhamento(Guid usuarioId, Guid postagemId)
        {
            new Contract()
                .ValidarUsuarioId(usuarioId)
                .ValidarPostagemId(postagemId)
                .EnsureContractIsValid();

            PostagemId = postagemId;
            UsuarioId = usuarioId;
            DataCompartilhamento = DateTime.Now;
        }

    }

}
