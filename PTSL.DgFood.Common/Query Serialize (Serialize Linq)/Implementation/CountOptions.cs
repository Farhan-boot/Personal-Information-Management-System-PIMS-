using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.QuerySerialize.Interfaces;

namespace PTSL.DgFood.Common.QuerySerialize.Implementation
{
    public class CountOptions<TEntity> : ICountOptions<TEntity>
    {
        public Expression<Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>> IncludeExpression { get; set; }
        public Expression<Func<TEntity, bool>> FilterExpression { get; set; }
        public ListCondition ListCondition { get; set; }

        
        public static CountOptions<TEntity> FromCountOptionsNodes (CountOptionsNodes nodes)
        {
            if (nodes == null)
            {
                return null;
            }

            CountOptions<TEntity> countOptions = new CountOptions<TEntity> ();

            if (nodes.IncludeExpressionNode != null)
            {
                countOptions.IncludeExpression =
                    nodes.IncludeExpressionNode.ToExpression<Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>> ();
            }

            if (nodes.FilterExpressionNode != null)
            {
                countOptions.FilterExpression = 
                    nodes.FilterExpressionNode.ToBooleanExpression<TEntity> ();
            }

            countOptions.ListCondition = (ListCondition) nodes?.ListCondition;

            return countOptions;
        }
    }
}