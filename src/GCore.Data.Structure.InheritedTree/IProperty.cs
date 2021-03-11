using System;
using System.Collections.Generic;
using System.Text;

namespace GCore.Data.Structure.InheritedTree
{
    public interface IProperty<TNode, TKey, TValue>
    {
        TNode DefinedNode { get; }

        TKey Key { get; }
        TValue Value { get; }
    }
}
