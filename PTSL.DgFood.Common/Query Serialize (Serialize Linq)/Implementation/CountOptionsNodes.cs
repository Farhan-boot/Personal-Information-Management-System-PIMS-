using Serialize.Linq.Nodes;
using PTSL.DgFood.Common.QuerySerialize.Interfaces;
using PTSL.DgFood.Common.Enum;

namespace PTSL.DgFood.Common.QuerySerialize.Implementation
{
    public class CountOptionsNodes : BaseSerializeLinq,ICountOptionsNodes
    {
        public ExpressionNode IncludeExpressionNode { get; set; }
        public ExpressionNode FilterExpressionNode { get; set; }
        public ListCondition ListCondition { get; set; }
    }
}