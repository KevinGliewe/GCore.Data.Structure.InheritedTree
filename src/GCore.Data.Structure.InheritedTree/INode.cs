using System;
using System.Collections.Generic;
using System.Text;

namespace GCore.Data.Structure.InheritedTree
{
    /// <summary>
    /// Represents one node of a tree.
    /// </summary>
    /// <typeparam name="TTree">The used <seealso cref="ITree{TTree, TNode, TKey, TValue}"/> implementation</typeparam>
    /// <typeparam name="TNode">The used <seealso cref="INode{TTree, TNode, TKey, TValue}"/> implementation</typeparam>
    /// <typeparam name="TKey">The type used for the key</typeparam>
    /// <typeparam name="TValue">The type used for the value</typeparam>
    public interface INode<TTree, TNode, TKey, TValue> :
        INotifyChildrenChanged<TNode, TKey, TValue>, INotifyPropertyChanged<TNode, TKey, TValue>
        where TNode : class, INode<TTree, TNode, TKey, TValue>
        where TTree : class, ITree<TTree, TNode, TKey, TValue>
    {
        /// <summary>
        /// The name of this node.
        /// </summary>
        String Name { get; }

        /// <summary>
        /// All names from the root to this node joined with ':'.
        /// </summary>
        String Path { get; }

        /// <summary>
        /// Distance from the root node.
        /// </summary>
        uint Depth { get; }

        /// <summary>
        /// The parent node of this node.
        /// Null if this node is the root node.
        /// </summary>
        TNode Parent { get; }

        /// <summary>
        /// Direct children of this node.
        /// </summary>
        IEnumerable<TNode> Children { get; }

        /// <summary>
        /// The tree this node belongs to.
        /// </summary>
        TTree Tree { get; }

        /// <summary>
        /// All propertys this node defines itfelf.
        /// </summary>
        IEnumerable<IProperty<TNode, TKey, TValue>> SelfPropertys { get; }

        /// <summary>
        /// All propertys this node has.
        /// Inherited or self-defined.
        /// </summary>
        IEnumerable<IProperty<TNode, TKey, TValue>> Propertys { get; }

        /// <summary>
        /// Initializes the tree node
        /// </summary>
        /// <param name="nodeName">The name of this node</param>
        /// <param name="tree">The tree ths node belongs to</param>
        void InitNode(string nodeName, TTree tree);

        /// <summary>
        /// Initializes the tree node
        /// </summary>
        /// <param name="name">The name of this node</param>
        /// <param name="tree">The tree ths node belongs to</param>
        /// <param name="props">Pre-populate with Properties</param>
        /// <param name="children">Pre-populate with Children</param>
        void InitNode(String name, TTree tree, IDictionary<TKey, TValue> props = null,
            IEnumerable<TNode> children = null);

        /// <summary>
        /// Initializes the tree node
        /// </summary>
        /// <param name="rawNode">The serializeable node representation</param>
        /// <param name="tree">The tree ths node belongs to</param>
        void InitNode(RawNode<TNode, TKey, TValue> rawNode, TTree tree);

        /// <summary>
        /// Returns true if the property is defined by by a parent and not
        /// by this nodes itself.
        /// </summary>
        /// <param name="key">The property identifier</param>
        /// <returns></returns>
        bool IsInherted(TKey key);

        /// <summary>
        /// Returns true if this node (re)defines this property.
        /// </summary>
        /// <param name="key">The property identifier</param>
        /// <returns></returns>
        bool Defines(TKey key);

        /// <summary>
        /// Returns true if this node has the defined property.
        /// Either througth inheritance of self defining.
        /// </summary>
        /// <param name="key">The property identifier</param>
        /// <returns></returns>
        bool Has(TKey key);

        /// <summary>
        /// Returns the property the node has either througth inheritance of self defining.
        /// Returns null if the property is not denined for this node.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        TValue Get(TKey key);

        /// <summary>
        /// (Re)Defines the property for this node.
        /// This overrides a inherted property.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool Set(TKey key, TValue value);

        /// <summary>
        /// Removes the definition of a property.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool ResetDefinition(TKey key);

        /// <summary>
        /// Gets all propertys this node has.
        /// Either througth inheritance of self defining.
        /// </summary>
        /// <returns></returns>
        IEnumerable<IProperty<TNode, TKey, TValue>> GetAll();

        /// <summary>
        /// Returns the property the node has either througth inheritance of self defining.
        /// Returns null if the property is not denined for this node.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        TValue this[TKey key]
        {
            get;
            set;
        }

        /// <summary>
        /// Returns all propertys beween the root and this nodes in order.
        /// Ignores if the property is overritten by a child node.
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        IEnumerable<IProperty<TNode, TKey, TValue>> CollectPropertys(TKey keys);

        /// <summary>
        /// Get all child nodes beneeth this node recursive.
        /// </summary>
        /// <param name="mexDepth">The maximal depth for the recursion</param>
        /// <returns></returns>
        IEnumerable<TNode> GetChildren(uint mexDepth = 0);

        /// <summary>
        /// Returns all nodes from the root node to this node (inclusive) in this order.
        /// </summary>
        /// <returns></returns>
        IEnumerable<TNode> GetParents();

        /// <summary>
        /// Sets the parent of this node.
        /// Throws exception if a parent is already defined.
        /// </summary>
        /// <param name="parent">The new parent node</param>
        void SetParent(TNode parent);

        /// <summary>
        /// Resets the parent node.
        /// </summary>
        void RemoveParent();

        /// <summary>
        /// Gets the child node by its name.
        /// This is NOT recursive!
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        TNode GetChild(string name);

        /// <summary>
        /// Adds a new child to this node.
        /// </summary>
        /// <param name="child"></param>
        void AddChild(TNode child);

        /// <summary>
        /// Adds multible children to this node.
        /// </summary>
        /// <param name="child"></param>
        void AddChildren(IEnumerable<TNode> child);

        /// <summary>
        /// Creates a new node and adds it as a child.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        TNewNode CreateChild<TNewNode>(string name) where TNewNode : TNode, new();

        /// <summary>
        /// Creates a new node and adds it as a child.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        TNode CreateChild(string name);

        /// <summary>
        /// Removes a child from this node.
        /// </summary>
        /// <param name="child"></param>
        /// <returns>False if it wasn't a child of this node</returns>
        bool RemoveChild(TNode child);

        /// <summary>
        /// Find a node by its relative path.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        TNode FindNode(String path);

        /// <summary>
        /// Find a node by its relative path.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        TNode FindNode(IEnumerable<string> path);

        /// <summary>
        /// Converts the node to a serializeable RawNode
        /// </summary>
        /// <returns></returns>
        RawNode<TNode, TKey, TValue> ToRawNode();

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
