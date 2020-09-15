using Flunt.Validations;
using OmegaFY.Blog.Domain.Extensions;
using System;

namespace OmegaFY.Blog.Domain.Entities.Postagens
{

    public class Compartilhamento : Entity
    {

        public Guid PostagemId { get; }

        public DateTime DataCompartilhamento { get; }

        public Compartilhamento(Guid usuarioId, Guid postagemId)
        {
            new Contract()
                .ValidarUsuarioId(usuarioId)
                .ValidarPostagemId(postagemId)
                .EnsureContractIsValid();

            UsuarioId = usuarioId;
            PostagemId = postagemId;
            DataCompartilhamento = DateTime.Now;
        }

    }

}
