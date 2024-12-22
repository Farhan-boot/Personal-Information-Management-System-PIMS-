using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.QuerySerialize.Implementation;

namespace PTSL.DgFood.Common.QuerySerialize.Interfaces
{
    public interface ICountOptions<TEntity>
    {
        public Expression<Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>> IncludeExpression { get; set; }
        public Expression<Func<TEntity, bool>> FilterExpression { get; set; }
        public ListCondition ListCondition { get; set; }

        //CountOptions<TEntity> FromCountOptionsNodes (CountOptionsNodes nodes);
    }
}