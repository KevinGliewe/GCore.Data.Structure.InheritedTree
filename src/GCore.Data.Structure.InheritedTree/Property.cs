using System;
using System.Collections.Generic;
using System.Text;

namespace GCore.Data.Structure.InheritedTree
{
    public class Property<TNode, TKey, TValue> : IProperty<TNode, TKey, TValue>
    {
        public Property(TNode node, TKey key, TValue value)
        {
            DefinedNode = node;
            Key = key;
            Value = value;
        }

        public TNode DefinedNode { get; protected set; }

        public TKey Key { get; protected set; }

        public TValue Value { get; protected set; }
    }
}
