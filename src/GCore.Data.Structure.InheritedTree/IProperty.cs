using System;
using System.Collections.Generic;
using System.Text;

namespace GCore.Data.Structure.InheritedTree
{
    /// <summary>
    /// A property for <see cref="INode{TTree,TNode,TKey,TValue}"/>.
    /// <a href="https://kevingliewe.github.io/GCore.Data.Structure.InheritedTree/api/GCore.Data.Structure.InheritedTree.IProperty-3.html">see more</a>
    /// </summary>
    /// <typeparam name="TNode">The used <seealso cref="INode{TTree, TNode, TKey, TValue}"/> implementation</typeparam>
    /// <typeparam name="TKey">The type used for the key</typeparam>
    /// <typeparam name="TValue">The type used for the value</typeparam>
    public interface IProperty<TNode, TKey, TValue>
    {
        /// <summary>
        /// The node this property belongs to.
        /// </summary>
        TNode DefinedNode { get; }

        /// <summary>
        /// The identifier for this property.
        /// </summary>
        TKey Key { get; }

        /// <summary>
        /// The value this property defines.
        /// </summary>
        TValue Value { get; }
    }
}
