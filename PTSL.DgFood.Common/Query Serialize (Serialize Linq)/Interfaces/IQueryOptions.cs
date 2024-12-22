using System;
using System.Linq;
using System.Linq.Expressions;
using PTSL.DgFood.Common.QuerySerialize.Implementation;
using Microsoft.EntityFrameworkCore.Query;
using PTSL.DgFood.Common.Enum;

namespace PTSL.DgFood.Common.QuerySerialize.Interfaces
{
    public interface IQueryOptions<TEntity>
    {
        public Expression<Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>> IncludeExpression { get; set; }
        public Expression<Func<TEntity, bool>> FilterExpression { get; set; }
        public Expression<Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>> SortingExpression { get; set; }
        public Pagination Pagination { get; set; }
        public ListCondition ListCondition { get; set; }

        //public QueryOptions<TEntity> FromQueryOptionsNodes (QueryOptionsNodes nodes);
    }
}