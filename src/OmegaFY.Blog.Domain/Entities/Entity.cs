using OmegaFY.Blog.Domain.Core.Entities;
using System;

namespace OmegaFY.Blog.Domain.Entities
{

    public abstract class Entity : IEntity, IComparable, IEquatable<Entity>
    {

        public Guid Id { get; }

        public Guid UsuarioId { get; protected set; }

        protected Entity() => Id = Guid.NewGuid();

        private static bool ValidarIgualdade(Entity entity1, Entity entity2)
        {
            //Ambos os objetos são nulos.
            if (entity1 is null && entity2 is null) return true;

            //Apenas um dos objetos está nulo.
            if (entity1 is null || entity2 is null) return false;

            //Validando efetivamente o GUID para identificar se a entidade é a mesma.
            return entity1.Id == entity2.Id;
        }

        public override bool Equals(object obj)
        {
            //Verificando se o objeto é do mesmo tipo.
            if (!(obj is Entity entity)) return false;

            //Chamando o metodo de validação de igualdade.
            return ValidarIgualdade(this, entity);
        }

        public bool Equals(Entity other) => ValidarIgualdade(this, other);

        public override int GetHashCode() => HashCode.Combine(Id);

        public override string ToString() => $"{GetType().Name}_{Id}";

        public int CompareTo(object obj) => Id.CompareTo(obj);

        public static bool operator ==(Entity entity1, Entity entity2) => ValidarIgualdade(entity1, entity2);

        public static bool operator !=(Entity entity1, Entity entity2) => !(entity1 == entity2);

        public static implicit operator Guid(Entity entity) => entity?.Id ?? Guid.Empty;

    }

}
