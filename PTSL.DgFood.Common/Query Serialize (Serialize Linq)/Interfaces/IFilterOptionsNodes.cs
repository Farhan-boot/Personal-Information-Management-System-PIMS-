using Serialize.Linq.Nodes;
using PTSL.DgFood.Common.Enum;

namespace PTSL.DgFood.Common.QuerySerialize.Interfaces
{
    public interface IFilterOptionsNodes
    {
        public ExpressionNode IncludeExpressionNode { get; set; }
        public ExpressionNode FilterExpressionNode { get; set; }
        public ListCondition ListCondition { get; set; }
    }
}