using Microsoft.EntityFrameworkCore.Storage;
using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.QuerySerialize.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.DAL.Repositories.Interface
{
    public interface IBaseRepository<T> : IDisposable where T : BaseEntity
    {
        Task<bool> SaveAsync(IDbContextTransaction transaction);
        Task<(ExecutionState executionState, T entity, string message)> CreateAsync(T entity);
        Task<(ExecutionState executionState, T entity, string message)> GetAsync(long key, RetrievalPurpose retrievalPurpose = RetrievalPurpose.Consumption);
        Task<(ExecutionState executionState, T entity, string message)> GetAsync(IFilterOptions<T> filterOptions, RetrievalPurpose retrievalPurpose = RetrievalPurpose.Consumption);
        Task<(ExecutionState executionState, IQueryable<T> entity, string message)> List(IQueryOptions<T> queryOptions = null);
        Task<(ExecutionState executionState, string message)> DoesExistAsync(long key);
        Task<(ExecutionState executionState, string message)> DoesExistAsync(IFilterOptions<T> filterOptions);
        Task<(ExecutionState executionState, T entity, string message)> UpdateAsync(T entity);
        Task<(ExecutionState executionState, T entity, string message)> RemoveAsync(long key);
        Task<(ExecutionState executionState, long entityCount, string message)> CountAsync(ICountOptions<T> countOptions = null);
        Task<(ExecutionState executionState, T entity, string message)> MarkAsActiveAsync(long key);
        Task<(ExecutionState executionState, T entity, string message)> MarkAsInactiveAsync(long key);
    }
}
