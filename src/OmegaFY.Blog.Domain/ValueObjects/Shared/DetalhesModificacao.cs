using System;

namespace OmegaFY.Blog.Domain.ValueObjects.Shared
{

    public class DetalhesModificacao : ValueObject
    {

        public DateTime DataCriacao { get; }

        public DateTime? DataModificacao { get; private set; }

        public DetalhesModificacao() => DataCriacao = DateTime.Now;

        public DetalhesModificacao(DateTime dataCriacao)
        {
            DataCriacao = dataCriacao;
            DataModificacao = DateTime.Now;
        }

        public override bool Equals(ValueObject other)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
            => $@"Data de criação -> {DataCriacao.ToLongDateString()}
                  Data de Modificação -> {DataModificacao?.ToLongDateString()}";

    }

}
