using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace GCore.Data.Structure.InheritedTree
{
    /// <summary>
    /// Raw representation of a Node.
    /// This type is used as a intermediate structure for (de)serialization.
    /// <a href="https://kevingliewe.github.io/GCore.Data.Structure.InheritedTree/api/GCore.Data.Structure.InheritedTree.RawNode-3.html">see more</a>
    /// </summary>
    /// <typeparam name="TNode">The used <seealso cref="INode{TTree, TNode, TKey, TValue}"/> implementation</typeparam>
    /// <typeparam name="TKey">The type used for the key</typeparam>
    /// <typeparam name="TValue">The type used for the value</typeparam>
    public class RawNode<TNode, TKey, TValue>
    {
        /// <summary>
        /// The .NET type of the node.
        /// </summary>
        public String? NodeType { get; set; }

        /// <summary>
        /// Additional properties of the node.
        /// </summary>
        public Object? NodeData { get; set; }

        /// <summary>
        /// The name of the node.
        /// </summary>
        public String? Name { get; set; }

        /// <summary>
        /// The child nodes of the node.
        /// </summary>
        public RawNode<TNode, TKey, TValue>[]? Children { get; set; }

        /// <summary>
        /// The properties of the node.
        /// </summary>
        public Dictionary<TKey, TValue>? Propertys { get; set; }
    }
}
