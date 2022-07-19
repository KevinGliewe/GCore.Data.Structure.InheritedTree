using System;
using System.Collections.Generic;
using System.Text;

namespace GCore.Data.Structure.InheritedTree
{
    /// <summary>
    /// Tree representation with inherited properties.
    /// <a href="https://kevingliewe.github.io/GCore.Data.Structure.InheritedTree/api/GCore.Data.Structure.InheritedTree.ITree-4.html">see more</a>
    /// </summary>
    /// <typeparam name="TTree">The used <seealso cref="ITree{TTree, TNode, TKey, TValue}"/> implementation</typeparam>
    /// <typeparam name="TNode">The used <seealso cref="INode{TTree, TNode, TKey, TValue}"/> implementation</typeparam>
    /// <typeparam name="TKey">The type used for the key</typeparam>
    /// <typeparam name="TValue">The type used for the value</typeparam>
    public interface ITree<TTree, TNode, TKey, TValue>
        where TNode : class, INode<TTree, TNode, TKey, TValue>
        where TTree : class, ITree<TTree, TNode, TKey, TValue>
    {

        /// <summary>
        /// The string separating the node names in the path.
        /// </summary>
        string Separator { get; }

        /// <summary>
        /// Callback to create a TNode instance from a RawNode.
        /// </summary>
        Func<RawNode<TNode, TKey, TValue?>, TNode?>? RawNodeActivator { get; set; }

        /// <summary>
        /// The Root node
        /// </summary>
        TNode Root { get; }

        /// <summary>
        /// Create a node with this tree as origin.
        /// </summary>
        /// <typeparam name="TNewNode">The type of the node</typeparam>
        /// <param name="name">The name of this node</param>
        /// <returns></returns>
        TNewNode CreateNode<TNewNode>(String name) where TNewNode : TNode, new();

        /// <summary>
        /// Create a node with this tree as origin.
        /// </summary>
        /// <typeparam name="TNewNode">The type of the node</typeparam>
        /// <param name="name">The name of this node</param>
        /// <param name="props">The properties for the node</param>
        /// <param name="children">The children for the node</param>
        /// <returns></returns>
        TNewNode CreateNode<TNewNode>(string name, IDictionary<TKey, TValue>? props = null,
            params TNode[] children) where TNewNode : TNode, new();

        /// <summary>
        /// Create a node with this tree as origin.
        /// </summary>
        /// <param name="name">The name of this node</param>
        /// <returns></returns>
        TNode CreateNode(String name);

        /// <summary>
        /// Create a node with this tree as origin.
        /// </summary>
        /// <param name="name">The name of this node</param>
        /// <param name="props">The properties for the node</param>
        /// <param name="children">The children for the node</param>
        /// <returns></returns>
        TNode CreateNode(string name, IDictionary<TKey, TValue>? props = null, params TNode[] children);

        /// <summary>
        /// Find a node by its absolute path.
        /// </summary>
        /// <param name="path">node names separeted by <see cref="ITree{TTree, TNode, TKey, TValue}.Separator"/></param>
        /// <returns>The node found in this path</returns>
        TNode? FindNode(string path);

        /// <summary>
        /// Collects all properties with the specified key inside the tree.
        /// </summary>
        /// <param name="keys">The key of the properties.</param>
        /// <returns></returns>
        IEnumerable<IProperty<TNode, TKey, TValue>> CollectProperties(TKey keys);

        /// <summary>
        /// Calls <see cref="IUpdatableProperty{TArgs}.Update(TArgs)"/> on every property with this key.
        /// </summary>
        /// <typeparam name="TArgs">Argument type for <see cref="IUpdatableProperty{TArgs}"/></typeparam>
        /// <param name="key">The key of the properties</param>
        /// <param name="args">The argument for <see cref="IUpdatableProperty{TArgs}.Update(TArgs)"/></param>
        void Update<TArgs>(TKey key, TArgs args);

        /// <summary>
        /// Spawns a update-wave for propertys implementing <see cref="IOverridingProperty{TNode, TKey, TValue}"/>
        /// and invokes <see cref="Node{TTree, TNode, TKey, TValue}.PropertyChanged"/>
        /// </summary>
        void UpdateOverrides();
    }
}
