using MTechneTeste.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MTechneTeste.Domain.Interfaces.Repository.Base
{
    public interface IBaseDB<T> where T : Entity
    {
        /// <summary>
        /// Busca todos os itens de uma entidade
        /// </summary>
        /// <remarks>Criado por Igor Monteiro </remarks>
        IList<T> GetAll();
        void OpenTransaction();
        void CommitTransaction();
        Task CommitTransactionAsync();
        void RoolbackTransaction();
        Task RoolbackTransactionAsync();
        /// <summary>
        /// Cria um Criteria a partir do nome da coluna e do valor retornando uma lista tipada
        /// </summary>
        /// <remarks>Criado por Igor Monteiro </remarks>
        IList<T> GetByColumnName(string columnName, object value);

        /// <summary>
        /// Busca Entidade pelo Id (Usar somente para entidades sem composity Id
        /// </summary>
        /// <remarks>Criado por Igor Monteiro </remarks>
        T GetById(int id);
        /// <summary>
        ///Salva uma coleção de  entidades no escopo de uma transação ( é necessário o flush e commit durante o processo)
        /// </summary>
        /// <remarks>Criado por Igor Monteiro </remarks>
        void SaveInUniqueTransaction(IEnumerable<T> entities);
        /// <summary>
        ///Salva uma colecao de entidaddes sem Composity Id
        /// </summary>
        /// <remarks>Criado por Igor Monteiro </remarks>
        void Save(IEnumerable<T> entities);
        /// <summary>
        ///Salva uma Entidadde sem Composity Id
        /// </summary>
        /// <remarks>Criado por Igor Monteiro </remarks>
        T Save(T entity, bool setEntity = true);
        /// <summary>
        ///Salva uma entidade no escopo de uma transação ( é necessário o flush e commit durante o processo)
        /// </summary>
        /// <remarks>Criado por Igor Monteiro </remarks>
        void SaveInUniqueTransaction(T entity);
        /// <summary>
        ///Salva ou edita uma entidade no escopo de uma transação ( é necessário o flush e commit durante o processo)
        /// </summary>
        /// <remarks>Criado por Igor Monteiro </remarks>
        void SaveOrUpdateInUniqueTransaction(T entity);
        /// <summary>
        ///Edita uma entidade no escopo de uma transação ( é necessário o flush e commit durante o processo)
        /// </summary>
        /// <remarks>Criado por Igor Monteiro </remarks>
        void UpdateInUniqueTransaction(T entity);
        /// <summary>
        ///deleta uma entidade no escopo de uma transação ( é necessário o flush e commit durante o processo)
        /// </summary>
        /// <remarks>Criado por Igor Monteiro </remarks>
        void DeleteInUniqueTransaction(T entity);
        /// <summary>
        ///deleta uma coleção de entidades no escopo de uma transação ( é necessário o flush e commit durante o processo)
        /// </summary>
        /// <remarks>Criado por Igor Monteiro </remarks>
        void DeleteInUniqueTransaction(IEnumerable<T> entities);
        /// <summary>
        ///Deleta uma entidade criando a transação e setando a entidade para o cd login e DateStamp  não é necessário flush e commit 
        /// </summary>
        /// <remarks>Criado por Igor Monteiro </remarks>
        void Delete(T entity);
        /// <summary>
        ///Edita uma entidade criando a transação e setando a entidade para o cd login e DateStamp  não é necessário flush e commit 
        /// </summary>
        /// <remarks>Criado por Igor Monteiro </remarks>
        T Update(T entity);
        /// <summary>
        ///Salva uma entidade criando a transação e setando a entidade para o cd login e DateStamp  não é necessário flush e commit 
        /// </summary>
        /// <remarks>Criado por Igor Monteiro </remarks>
        T Save(T entity);
        /// <summary>
        ///Pré - persistência de um objeto
        /// </summary>
        /// <remarks>Criado por Igor Monteiro </remarks>
        void Flush();

        void Refresh(T entity);
        /// <summary>
        /// Cria um Criteria a partir do nome da coluna e do valor retornando uma lista tipada ex: db.GetByColumns<Estado>(Parameter.Of('SiglaEstado', 'SP'))
        /// </summary>
        /// <remarks>Criado por Igor Monteiro </remarks>
        IList<T> GetByColumns(params KeyValuePair<string, object>[] parameters);
        /// <summary>
        /// GetAll Paginado  
        /// </summary>
        /// <remarks>Criado por Igor Monteiro </remarks>
        IList<T> GetAllPaged(int page, int maxRecords);
        /// <summary>
        /// faz uma consulta Linq sem a necessidade que criar uma classe de pesquisa para isso 
        /// </summary>
        /// <param name="restriction">exmpressão linq</param>
        /// <returns> retorna uma lista Tipada</returns>
        IList<T> Find(Expression<Func<T, bool>> restriction);
        /// <summary>
        /// faz uma consulta Linq sem a necessidade que criar uma classe de pesquisa para isso ASYNC
        /// </summary>
        /// <param name="restriction">exmpressão linq</param>
        /// <returns> retorna uma lista Tipada</returns>
        Task<IList<T>> FindAsync(Expression<Func<T, bool>> restriction);
        /// <summary>
        ///Salva uma entidade criando a transação e setando a entidade para o cd login e DateStamp  não é necessário flush e commit  ASYNC
        /// </summary>
        /// <remarks>Criado por Igor Monteiro </remarks>
        Task<T> SaveAsync(T entity);
        /// <summary>
        ///Edita uma entidade criando a transação e setando a entidade para o cd login e DateStamp  não é necessário flush e commit  ASYNC
        /// </summary>
        /// <remarks>Criado por Igor Monteiro </remarks>
        Task UpdateAsync(T entity);
        /// <summary>
        ///Deleta uma entidade criando a transação e setando a entidade para o cd login e DateStamp  não é necessário flush e commit  ASYNC
        /// </summary>
        /// <remarks>Criado por Igor Monteiro </remarks>
        Task DeleteAsync(T entity);
    }
}
