using Flunt.Validations;
using OmegaFY.Blog.Domain.Entities;
using OmegaFY.Blog.Domain.Exceptions;
using OmegaFY.Blog.Domain.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace OmegaFY.Blog.Domain.ValueObjects
{

    public abstract class AbstractEntityCollection<T> where T : Entity
    {

        private readonly List<T> _collection;

        public AbstractEntityCollection() => _collection = new List<T>();

        public IReadOnlyCollection<T> ReadOnlyCollection => _collection;

        public int Total() => _collection.Count;

        protected virtual string CriticaEntidadeInformadaNula()
            => "Não foi informado um registro para ser removido.";

        protected virtual string CriticaEntidadeNaoEncontradaNaColecao()
            => "O registro informado não existe.";

        protected virtual string CriticaRemocaoNaoRealizadaPeloUsuarioOriginal()
            => "Essa ação apenas pode ser realizada pelo usuário que a realizou.";

        protected void Add(T entity) => _collection.Add(entity);

        protected void Remove(T entity)
        {
            CriticarSeRemocaoNaoFoiRealizadaPeloUsuarioOriginal(entity);
            _collection.Remove(entity);
        }      

        protected virtual void CriticarSeRemocaoNaoFoiRealizadaPeloUsuarioOriginal(Entity itemParaSerRemovido)
        {
            Entity itemQueSeraRemovido = _collection.FirstOrDefault(c => c.Id == itemParaSerRemovido?.Id);

            new Contract()
                .IsNotNull(itemParaSerRemovido, nameof(itemParaSerRemovido), CriticaEntidadeInformadaNula())
                .IsNotNull(itemQueSeraRemovido, nameof(itemQueSeraRemovido), CriticaEntidadeNaoEncontradaNaColecao())
                .EnsureContractIsValid()
                .AreEquals(itemQueSeraRemovido?.UsuarioId,
                           itemParaSerRemovido?.UsuarioId,
                           nameof(itemParaSerRemovido),
                           CriticaRemocaoNaoRealizadaPeloUsuarioOriginal())
                .EnsureContractIsValid<DomainInvalidOperationException>();
        }

    }

}
