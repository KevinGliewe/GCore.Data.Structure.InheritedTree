using System;
namespace GCore.Data.Structure.InheritedTree
{
    /// <summary>
    /// Possible trait for property values.
    /// <a href="https://kevingliewe.github.io/GCore.Data.Structure.InheritedTree/api/GCore.Data.Structure.InheritedTree.IOverridingProperty-3.html">see more</a>
    /// </summary>
    /// <typeparam name="TNode">The used <seealso cref="INode{TTree, TNode, TKey, TValue}"/> implementation</typeparam>
    /// <typeparam name="TKey">The type used for the key</typeparam>
    /// <typeparam name="TValue">The type used for the value</typeparam>
    public interface IOverridingProperty<TNode, TKey, TValue>
    {
        /// <summary>
        /// Gets called if the property is set.
        /// </summary>
        /// <param name="property">The property this property overrides. Null if there is no other property overwritten</param>
        void OnOverridesProperty(IProperty<TNode, TKey, TValue>? property);
    }
}
