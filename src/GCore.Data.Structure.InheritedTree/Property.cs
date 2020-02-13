using System;
using System.Collections.Generic;
using System.Text;

namespace GCore.Data.Structure.InheritedTree
{
    public class Property<TKey, TValue> : IProperty<TKey, TValue>
    {
        public Property(INode<TKey, TValue> node, TKey key, TValue value)
        {
            DefinedNode = node;
            Key = key;
            Value = value;
        }

        public INode<TKey, TValue> DefinedNode { get; protected set; }

        public TKey Key { get; protected set; }

        public TValue Value { get; protected set; }
    }
}
