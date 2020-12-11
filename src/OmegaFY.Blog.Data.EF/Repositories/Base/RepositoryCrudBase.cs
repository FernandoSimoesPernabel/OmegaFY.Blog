using Microsoft.EntityFrameworkCore;
using OmegaFY.Blog.Domain.Core.Entities;
using OmegaFY.Blog.Domain.Core.Repositories;
using OmegaFY.Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Data.EF.Repositories.Base
{

    /// <summary>
    /// Implementação base de um repositorio de crud para uma entidade.
    /// Contem metodos basicos de adicionar, atualizar e remover, assim como os basicos de leitura.
    /// </summary>
    /// <typeparam name="T">Uma entidade raiz de agregação que herde da classe abstrata Entity.</typeparam>
    public abstract class RepositoryCrudBase<T> : IRepository<T> where T : Entity, IAggregateRoot<T> //, new()
    {

        /// <summary>
        /// Contexto referente ao banco de dados.
        /// </summary>
        protected readonly DbContext _context;

        /// <summary>
        /// DbSet referente a entidade ao qual o repositorio é responsavel.
        /// </summary>
        protected readonly DbSet<T> _dbSet;

        /// <summary>
        /// Construtor da classe base.
        /// </summary>
        /// <param name="dbContext">Contexto referente ao banco de dados.</param>
        public RepositoryCrudBase(DbContext dbContext)
        {
            _context = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        ///// <summary>
        ///// Desconstrutor da classe, chama o Dispose da mesma.
        ///// </summary>
        //~RepositoryCrudBase() => Dispose();

        /// <summary>
        /// Adiciona ao banco de dados uma instancia nova da entidade informada.
        /// Toda vez que for chamado será criado um novo registro no banco de dados.
        /// </summary>
        /// <param name="entity">Entidade de negocio que vai ser adicionada no banco de dados.</param>
        protected async virtual Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

        /// <summary>
        /// Verifica se uma entidade se encontra desatachada ou com estado diferente de modificado.
		/// Apenas nessas duas situações esse metodo realiza alguma operação, caso contrario deixa o proprio EF cuidar do estado da entidade.
        /// </summary>
        /// <param name="entity">Entidade de negocio que vai ser atualizada no banco de dados.</param>
        protected virtual void Update(T entity)
        {
			if (_context.Entry(entity).State != EntityState.Detached)
                _dbSet.Attach(entity);
			
            if (_context.Entry(entity).State != EntityState.Modified)
                _dbSet.Update(entity);
        }

        /// <summary>
        /// Deleta uma entidade fisicamente no banco de dados.
        /// </summary>
        /// <param name="entity">Entidade de negocio que vai ser removida fisicamente no banco de dados.</param>
        protected virtual void Delete(T entity) => _dbSet.Remove(entity); //_dbSet.Remove(new T { Id = id});

        /// <summary>
        /// Recupera uma entidade pela sua chave identificadora unica.
        /// </summary>
        /// <param name="guid">Guid de identificação da entidade.</param>
        /// <returns>Uma instancia da entidade, ou nulo caso nao encontre.</returns>
        protected virtual async Task<T> Get(Guid guid) => await Get(guid, null);

        /// <summary>
        /// Recupera uma entidade pela sua chave identificadora unica.
        /// </summary>
        /// <param name="guid">Guid de identificação da entidade.</param>
        /// <param name="includes">Array de includes a ser realizado na consulta.</param>
        /// <returns>Uma instancia da entidade, ou nulo caso nao encontre.</returns>
        protected virtual async Task<T> Get(Guid guid, params Expression<Func<T, object>>[] includes) => await Get(x => x.Id == guid, includes);

        ///// <summary>
        ///// Recupera uma entidade pelo seu identificador numerico.
        ///// </summary>
        ///// <param name="id">Inteiro identificador da entidade.</param>
        ///// <returns>Uma instancia da entidade, ou nulo caso nao encontre.</returns>
        //protected virtual async Task<T> Get(long id) => await Get(id, null);

        ///// <summary>
        ///// Recupera uma entidade pelo seu identificador numerico.
        ///// </summary>
        ///// <param name="id">Inteiro identificador da entidade.</param>
        ///// <param name="includes">Array de includes a ser realizado na consulta.</param>
        ///// <returns>Uma instancia da entidade, ou nulo caso nao encontre.</returns>
        //protected virtual async Task<T> Get(long id, params Expression<Func<T, object>>[] includes) => await Get(x => x.Id == id, includes);

        /// <summary>
        /// Recupera uma entidade na base de dados conforme o filtro informado.
        /// </summary>
        /// <param name="filter">Filtro a ser realizado na consulta da entidade.</param>
        /// <returns>Uma instancia da entidade, ou nulo caso nao encontre.</returns>
        protected virtual async Task<T> Get(Func<T, bool> filter) => await Get(filter, null);

        /// <summary>
        /// Recupera uma entidade na base de dados conforme o filtro informado.
        /// </summary>
        /// <param name="filter">Filtro a ser realizado na consulta da entidade.</param>
        /// <param name="includes">Array de includes a ser realizado na consulta.</param>
        /// <returns>Uma instancia da entidade, ou nulo caso nao encontre.</returns>
        protected virtual async Task<T> Get(Func<T, bool> filter, params Expression<Func<T, object>>[] includes)
            => await CreateAsTrackingQueryWithInclude(includes).Where(filter).AsQueryable().FirstOrDefaultAsync();

        /// <summary>
        /// Recupera um conjunto de entidades na base de dados conforme o filtro informado.
        /// </summary>
        /// <param name="filter">Filtro a ser realizado na consulta das entidades.</param>
        /// <returns>Conjunto de entidades com a quantidade recuperada pelo filtro.</returns>
        protected virtual async Task<IEnumerable<T>> List(Func<T, bool> filter) => await List(filter, null);

        /// <summary>
        /// Recupera um conjunto de entidades na base de dados conforme o filtro informado.
        /// </summary>
        /// <param name="filter">Filtro a ser realizado na consulta das entidades.</param>
        /// <param name="includes">Array de includes a ser realizado na consulta.</param>
        /// <returns>Conjunto de entidades com a quantidade recuperada pelo filtro.</returns>
        protected virtual async Task<IEnumerable<T>> List(Func<T, bool> filter, params Expression<Func<T, object>>[] includes)
            => await CreateAsNoTrackingQueryWithInclude(includes).Where(filter).AsQueryable().ToListAsync();

        /// <summary>
        /// Recupera um conjunto de entidades na base de dados conforme o filtro informado.
        /// É informado uma expressão para que nao seja retornado todos os dados, apenas os campos que desejar.
        /// </summary>
        /// <param name="filter">Filtro a ser realizado na consulta das entidades.</param>
        /// <param name="expression">Expressão com os campos a serem retornados.</param>
        /// <returns>Conjunto de dados com base na expressao informada e com a quantidade recuperada pelo filtro.</returns>
        protected virtual async Task<IEnumerable<object>> Report(Expression<Func<T, bool>> filter, Expression<Func<T, object>> expression)
            => await Report(filter, expression, null);

        /// <summary>
        /// Recupera um conjunto de entidades na base de dados conforme o filtro informado.
        /// É informado uma expressão para que nao seja retornado todos os dados, apenas os campos que desejar.
        /// </summary>
        /// <param name="filter">Filtro a ser realizado na consulta das entidades.</param>
        /// <param name="expression">Expressão com os campos a serem retornados.</param>
        /// <param name="includes">Array de includes a ser realizado na consulta.</param>
        /// <returns>Conjunto de dados com base na expressao informada e com a quantidade recuperada pelo filtro.</returns>
        protected virtual async Task<IEnumerable<object>> Report(Expression<Func<T, bool>> filter,
                                                                 Expression<Func<T, object>> expression,
                                                                 params Expression<Func<T, object>>[] includes)
            => await CreateAsNoTrackingQueryWithInclude(includes).Where(filter).Select(expression).AsQueryable().ToListAsync();

        /// <summary>
        /// Cria uma query onde o EF adicionara seu proxy para que acompanhe as mudanças realizadas.
        /// Deve ser usado caso queria modificar a entidade de alguma forma.
        /// </summary>
        /// <param name="includes">Array de includes a ser realizado na consulta.</param>
        /// <returns>Um IQueryable do tipo AsTracking com os includes preenchidos.</returns>
        private IQueryable<T> CreateAsTrackingQueryWithInclude(Expression<Func<T, object>>[] includes)
            => AddIncludesToQuery(_dbSet.AsTracking(), includes);

        /// <summary>
        /// Cria uma query onde o EF não adicionara seu proxy para que acompanhe as mudanças realizadas.
        /// Deve ser usado caso queria apenas recuperar dados sem realizar diretamente modificações a essa entidade.
        /// </summary>
        /// <param name="includes">Array de includes a ser realizado na consulta.</param>
        /// <returns>Um IQueryable do tipo AsNoTracking com os includes preenchidos.</returns>
        private IQueryable<T> CreateAsNoTrackingQueryWithInclude(Expression<Func<T, object>>[] includes)
            => AddIncludesToQuery(_dbSet.AsNoTracking(), includes);

        /// <summary>
        /// Preenche um IQueryable com os includes informados.
        /// </summary>
        /// <param name="includes">Array de includes a ser realizado na consulta.</param>
        /// <returns>O IQueryable informado com os includes preenchidos.</returns>
        private IQueryable<T> AddIncludesToQuery(IQueryable<T> query, Expression<Func<T, object>>[] includes)
        {
            includes?.ToList()?.ForEach(x => query.Include(x));
            return query;
        }

        ///// <summary>
        ///// Aplica efetivamente as alterações na base de dados.
        ///// </summary>
        //public virtual async Task SaveChangesAsync() => await _context.SaveChangesAsync();

        /// <summary>
        /// Dispose da interface IDisposable, chama o metodo DisposeAsync() do contexto.
        /// </summary>
        public virtual void Dispose() => _context?.DisposeAsync();

    }

}
