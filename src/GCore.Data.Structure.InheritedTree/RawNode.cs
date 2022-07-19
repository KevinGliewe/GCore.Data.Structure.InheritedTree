using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace GCore.Data.Structure.InheritedTree
{
    /// <summary>
    /// Raw representation of a Node.
    /// This type is used as a intermediate structure for (de)serialization.
    /// </summary>
    /// <typeparam name="TNode">The used <seealso cref="INode{TTree, TNode, TKey, TValue}"/> implementation</typeparam>
    /// <typeparam name="TKey">The type used for the key</typeparam>
    /// <typeparam name="TValue">The type used for the value</typeparam>
    public class RawNode<TNode, TKey, TValue>
    {
        public String? NodeType { get; set; }
        public Object? NodeData { get; set; }
        public String? Name { get; set; }
        public RawNode<TNode, TKey, TValue>[]? Children { get; set; }
        public Dictionary<TKey, TValue>? Propertys { get; set; }
    }
}
