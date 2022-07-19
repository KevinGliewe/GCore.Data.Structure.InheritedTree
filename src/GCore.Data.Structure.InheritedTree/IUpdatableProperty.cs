using System;
using System.Collections.Generic;
using System.Text;

namespace GCore.Data.Structure.InheritedTree
{
    /// <summary>
    /// A trait for the TValue of <seealso cref="ITree{TTree, TNode, TKey, TValue}"/> implementation.
    /// This trait is invoked by <seealso cref="INode{TTree,TNode,TKey,TValue}.Update{TArgs}"/>.
    /// <a href="https://kevingliewe.github.io/GCore.Data.Structure.InheritedTree/api/GCore.Data.Structure.InheritedTree.IUpdatableProperty-1.html">see more</a>
    /// </summary>
    /// <typeparam name="TArgs">The type of update arguments</typeparam>
    public interface IUpdatableProperty<TArgs>
    {
        /// <summary>
        /// Updates the property with the given arguments.
        /// </summary>
        /// <param name="args">The arguments for the update</param>
        void Update(TArgs args);
    }
}
