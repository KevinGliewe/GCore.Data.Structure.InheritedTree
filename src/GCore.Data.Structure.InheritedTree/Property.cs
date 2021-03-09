using System;
using System.Collections.Generic;
using System.Text;

namespace GCore.Data.Structure.InheritedTree
{
    public class Property<TImpl, TKey, TValue> : IProperty<TImpl, TKey, TValue>
    {
        public Property(TImpl node, TKey key, TValue value)
        {
            DefinedNode = node;
            Key = key;
            Value = value;
        }

        public TImpl DefinedNode { get; protected set; }

        public TKey Key { get; protected set; }

        public TValue Value { get; protected set; }
    }
}
