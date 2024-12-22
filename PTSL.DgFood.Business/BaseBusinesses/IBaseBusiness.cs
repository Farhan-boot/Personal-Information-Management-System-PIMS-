using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.QuerySerialize.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.Business.BaseBusinesses
{
    public interface IBaseBusiness<T> where T : BaseEntity
    {
        Task<(ExecutionState executionState, T entity, string message)> CreateAsync(T entity);
        Task<(ExecutionState executionState, T entity, string message)> GetAsync(long key);
        Task<(ExecutionState executionState, T entity, string message)> GetAsync(FilterOptions<T> filterOptions);
        Task<(ExecutionState executionState, IQueryable<T> entity, string message)> List(QueryOptions<T> queryOptions = null);
        Task<(ExecutionState executionState, string message)> DoesExistAsync(long key);
        Task<(ExecutionState executionState, string message)> DoesExistAsync(FilterOptions<T> filterOptions);
        Task<(ExecutionState executionState, T entity, string message)> UpdateAsync(T entity);
        Task<(ExecutionState executionState, T entity, string message)> RemoveAsync(long key);
        Task<(ExecutionState executionState, long entityCount, string message)> CountAsync(CountOptions<T> countOptions = null);
        Task<(ExecutionState executionState, T entity, string message)> MarkAsActiveAsync(long key);
        Task<(ExecutionState executionState, T entity, string message)> MarkAsInactiveAsync(long key);

    }
}
