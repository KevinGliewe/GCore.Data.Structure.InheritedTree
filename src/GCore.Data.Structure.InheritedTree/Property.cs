using System;
using System.Collections.Generic;
using System.Text;

namespace GCore.Data.Structure.InheritedTree
{
    /// <summary>
    /// Default implementation of <see cref="IProperty{TNode,TKey,TValue}"/>
    /// </summary>
    /// <typeparam name="TNode">The used <seealso cref="INode{TTree, TNode, TKey, TValue}"/> implementation</typeparam>
    /// <typeparam name="TKey">The type used for the key</typeparam>
    /// <typeparam name="TValue">The type used for the value</typeparam>
    public class Property<TNode, TKey, TValue> : IProperty<TNode, TKey, TValue>
    {

        /// <summary>
        /// The key of the property
        /// </summary>
        /// <param name="node">The node this property belongs to</param>
        /// <param name="key">The identifier for this property</param>
        /// <param name="value">The value this property defines</param>
        public Property(TNode node, TKey key, TValue value)
        {
            DefinedNode = node;
            Key = key;
            Value = value;
        }

        /// <inheritdoc />
        public TNode DefinedNode { get; protected set; }

        /// <inheritdoc />
        public TKey Key { get; protected set; }

        /// <inheritdoc />
        public TValue Value { get; protected set; }
    }
}
