using System;
using System.Collections.Generic;
using System.Text;

namespace GCore.Data.Structure.InheritedTree
{
    public interface IProperty<TKey, TValue>
    {
        INode<TKey, TValue> DefinedNode { get; }

        TKey Key { get; }
        TValue Value { get; }
    }
}
