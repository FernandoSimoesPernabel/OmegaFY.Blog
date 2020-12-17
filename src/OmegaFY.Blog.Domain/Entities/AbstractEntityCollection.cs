using Flunt.Validations;
using OmegaFY.Blog.Domain.Exceptions;
using OmegaFY.Blog.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OmegaFY.Blog.Domain.Entities
{

    public abstract class AbstractEntityCollection<TEntity> where TEntity : EntityWithUserId
    {

        protected readonly List<TEntity> _collection;

        public AbstractEntityCollection() => _collection = new List<TEntity>();

        public IReadOnlyCollection<TEntity> ReadOnlyCollection => _collection.AsReadOnly();

        public int Total() => _collection.Count;

        protected virtual string CriticaEntidadeInformadaNula()
            => "Não foi informado um registro para ser removido.";

        protected virtual string CriticaEntidadeNaoEncontradaNaColecao()
            => "O registro informado não existe.";

        protected virtual string CriticaRemocaoNaoRealizadaPeloUsuarioOriginal()
            => "Essa ação apenas pode ser realizada pelo usuário que a realizou.";

        protected void Add(TEntity entity) => _collection.Add(entity);

        protected void Remove(TEntity entity)
        {
            CriticarSeRemocaoNaoFoiRealizadaPeloUsuarioOriginal(entity);
            _collection.Remove(entity);
        }      

        protected virtual void CriticarSeRemocaoNaoFoiRealizadaPeloUsuarioOriginal(EntityWithUserId itemParaSerRemovido)
        {
            EntityWithUserId itemQueSeraRemovido = _collection.FirstOrDefault(c => c.Id == itemParaSerRemovido?.Id);

            CriticarOperacaoNaoRealizadaPeloUsuarioOriginal(itemParaSerRemovido, 
                                                            itemQueSeraRemovido, 
                                                            CriticaRemocaoNaoRealizadaPeloUsuarioOriginal());
        }

        protected virtual void CriticarOperacaoNaoRealizadaPeloUsuarioOriginal(EntityWithUserId novoItem,
                                                                               EntityWithUserId itemDaColecao,
                                                                               string criticaOperacaoNaoRealizadaPeloUsuarioOriginal)
        {
            new Contract()
                .IsNotNull(novoItem, nameof(novoItem), CriticaEntidadeInformadaNula())
                .IsNotNull(itemDaColecao, nameof(itemDaColecao), CriticaEntidadeNaoEncontradaNaColecao())
                .EnsureContractIsValid()
                .AreEquals(itemDaColecao.UsuarioId,
                           novoItem.UsuarioId,
                           nameof(novoItem),
                           criticaOperacaoNaoRealizadaPeloUsuarioOriginal)
                .EnsureContractIsValid<DomainInvalidOperationException>();
        }

        protected virtual void CriticarOperacaoNaoRealizadaPeloUsuarioOriginal(EntityWithUserId itemDaColecao,
                                                                               Guid usuarioModificacaoId,
                                                                               string criticaOperacaoNaoRealizadaPeloUsuarioOriginal)
        {
            new Contract()
                 .IsNotNull(itemDaColecao, nameof(itemDaColecao), CriticaEntidadeNaoEncontradaNaColecao())
                .EnsureContractIsValid()
                .AreEquals(itemDaColecao.UsuarioId,
                           usuarioModificacaoId,
                           nameof(usuarioModificacaoId),
                           criticaOperacaoNaoRealizadaPeloUsuarioOriginal)
                .EnsureContractIsValid<DomainInvalidOperationException>();
        }

    }

}
