using Microsoft.EntityFrameworkCore.Storage;
using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.QuerySerialize.Implementation;
using PTSL.DgFood.DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.DAL.UnitOfWork
{
    public interface IDgFoodUnitOfWork : IDisposable
    {
        IDbContextTransaction Begin();
        void Complete(IDbContextTransaction transaction, CompletionState completionState);

        IBaseRepository<T> Select<T>(T entity) where T : BaseEntity;
        IBaseRepository<T> Select<T>() where T : BaseEntity;

        Task<(ExecutionState executionState, string message)> SaveAsync(IDbContextTransaction transaction);
        Task<(ExecutionState executionState, T entity, string message)> CreateAsync<T>(T entity) where T : BaseEntity;
        Task<(ExecutionState executionState, T entity, string message)> GetAsync<T>(long id) where T : BaseEntity;
        Task<(ExecutionState executionState, string message)> DoesExistAsync<T>(long id) where T : BaseEntity;

        Task<(ExecutionState executionState, T entity, string message)> GetAsync<T>(FilterOptions<T> filterOptions, RetrievalPurpose retrievalPurpose = RetrievalPurpose.Consumption)
            where T : BaseEntity;

        Task<(ExecutionState executionState, IQueryable<T> entity, string message)> List<T>(
            QueryOptions<T> queryOptions = null)
            where T : BaseEntity;

        Task<(ExecutionState executionState, string message)> DoesExistAsync<T>(
            FilterOptions<T> filterOptions)
            where T : BaseEntity;

        Task<(ExecutionState executionState, T entity, string message)> UpdateAsync<T>(T entity)
            where T : BaseEntity;

        Task<(ExecutionState executionState, T entity, string message)> RemoveAsync<T>(long id)
            where T : BaseEntity;

        Task<(ExecutionState executionState, long entityCount, string message)> CountAsync<T>(
            CountOptions<T> countOptions = null)
            where T : BaseEntity;

        Task<(ExecutionState executionState, T entity, string message)> MarkAsActiveAsync<T>(long id)
            where T : BaseEntity;

        Task<(ExecutionState executionState, T entity, string message)> MarkAsInactiveAsync<T>(long id)
            where T : BaseEntity;
    }
}
