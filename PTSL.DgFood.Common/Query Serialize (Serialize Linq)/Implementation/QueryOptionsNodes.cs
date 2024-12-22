using Serialize.Linq.Nodes;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.QuerySerialize.Interfaces;

namespace PTSL.DgFood.Common.QuerySerialize.Implementation
{
    public class QueryOptionsNodes : BaseSerializeLinq,IQueryOptionsNodes
    {
        public ExpressionNode IncludeExpressionNode { get; set; }
        public ExpressionNode FilterExpressionNode { get; set; }
        public ExpressionNode SortingExpressionNode { get; set; }
        public Pagination Pagination { get; set; }
        public ListCondition ListCondition { get; set; }
    }
}