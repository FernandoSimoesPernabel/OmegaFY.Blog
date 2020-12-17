using System;

namespace OmegaFY.Blog.Domain.Entities
{

    public abstract class EntityWithUserId : Entity
    {

        public Guid UsuarioId { get; }

        protected EntityWithUserId() { }

        public EntityWithUserId(Guid usuarioId)
        {
            UsuarioId = usuarioId;
        }

    }

}
