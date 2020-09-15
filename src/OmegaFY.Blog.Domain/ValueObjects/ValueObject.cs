using System;

namespace OmegaFY.Blog.Domain.ValueObjects
{

    public abstract class ValueObject : IEquatable<ValueObject>
    {

        public static bool operator ==(ValueObject valueObject1, ValueObject valueObject2)
        {
            //Ambos os objetos são nulos.
            if (valueObject1 is null && valueObject2 is null) return true;

            //Apenas um dos objetos está nulo.
            if (valueObject1 is null || valueObject2 is null) return false;

            //Chamando efetivamnte o Equals implementado.
            return valueObject1.Equals(valueObject2);
        }

        public static bool operator !=(ValueObject valueObject1, ValueObject valueObject2) => !(valueObject1 == valueObject2);

        public override bool Equals(object obj) => Equals(obj as ValueObject);

        public abstract bool Equals(ValueObject other);

        public override int GetHashCode() => base.GetHashCode();

        public abstract override string ToString();

    }

}
