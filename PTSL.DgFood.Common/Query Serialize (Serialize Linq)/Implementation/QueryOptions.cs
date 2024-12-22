using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.QuerySerialize.Interfaces;

namespace PTSL.DgFood.Common.QuerySerialize.Implementation
{
    public class QueryOptions<TEntity> : IQueryOptions<TEntity>
    {
        public Expression<Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>> IncludeExpression { get; set; }
        public Expression<Func<TEntity, bool>> FilterExpression { get; set; }
        public Expression<Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>> SortingExpression { get; set; }
        public Pagination Pagination { get; set; }
        public ListCondition ListCondition { get; set; }

        
        public static QueryOptions<TEntity> FromQueryOptionsNodes (QueryOptionsNodes nodes)
        {
            if (nodes == null)
            {
                return null;
            }
            
            QueryOptions<TEntity> queryOptions = new QueryOptions<TEntity> ();

            if (nodes.IncludeExpressionNode != null)
            {
                queryOptions.IncludeExpression =
                    nodes.IncludeExpressionNode.ToExpression<Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>> ();
            }

            if (nodes.FilterExpressionNode != null)
            {
                queryOptions.FilterExpression = 
                    nodes.FilterExpressionNode.ToBooleanExpression<TEntity> ();
            }

            if (nodes.SortingExpressionNode != null)
            {
                queryOptions.SortingExpression = 
                    nodes.SortingExpressionNode.ToExpression<Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>> ();
            }

            queryOptions.Pagination = nodes?.Pagination;

            queryOptions.ListCondition = (ListCondition) nodes?.ListCondition;

            return queryOptions;
        }
    }
}