using System;
using System.Collections.Generic;
using System.Text;

namespace GCore.Data.Structure.InheritedTree
{
    public interface IProperty<TImpl, TKey, TValue>
    {
        TImpl DefinedNode { get; }

        TKey Key { get; }
        TValue Value { get; }
    }
}
