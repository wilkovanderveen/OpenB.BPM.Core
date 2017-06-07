using System.Collections;

namespace OpenB.BPM.Core.Test
{
    public interface IDataContext
    {
        IEnumerable ProcessExpression(SelectionExpressionData selectorExpressionData);
    }
}
