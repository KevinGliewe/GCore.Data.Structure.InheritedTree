using System;
using System.Collections.Generic;
using System.Text;

namespace GCore.Data.Structure.InheritedTree
{
    public interface INode<TImpl, TKey, TValue> :
        INotifyChildrenChanged<TImpl, TKey, TValue>, INotifyPropertyChanged<TImpl, TKey, TValue>
        where TImpl : INode<TImpl, TKey, TValue>
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
        TImpl Parent { get; }

        /// <summary>
        /// Direct children of this node.
        /// </summary>
        IEnumerable<TImpl> Children { get; }

        /// <summary>
        /// The tree this node belongs to.
        /// </summary>
        ITree<TImpl, TKey, TValue> Tree { get; }

        /// <summary>
        /// All propertys this node defines itfelf.
        /// </summary>
        IEnumerable<IProperty<TImpl, TKey, TValue>> SelfPropertys { get; }

        /// <summary>
        /// All propertys this node has.
        /// Inherited or self-defined.
        /// </summary>
        IEnumerable<IProperty<TImpl, TKey, TValue>> Propertys { get; }

        /// <summary>
        /// Initializes the tree node
        /// </summary>
        /// <param name="nodeName">The name of this node</param>
        /// <param name="tree">The tree ths node belongs to</param>
        void InitNode(string nodeName, ITree<TImpl, TKey, TValue> tree);

        /// <summary>
        /// Initializes the tree node
        /// </summary>
        /// <param name="name">The name of this node</param>
        /// <param name="tree">The tree ths node belongs to</param>
        /// <param name="props">Pre-populate with Properties</param>
        /// <param name="children">Pre-populate with Children</param>
        void InitNode(String name, Tree<TImpl, TKey, TValue> tree, IDictionary<TKey, TValue> props = null,
            IEnumerable<TImpl> children = null);

        /// <summary>
        /// Initializes the tree node
        /// </summary>
        /// <param name="rawNode">The serializeable node representation</param>
        /// <param name="tree">The tree ths node belongs to</param>
        void InitNode(RawNode<TImpl, TKey, TValue> rawNode, Tree<TImpl, TKey, TValue> tree);

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
        IEnumerable<IProperty<TImpl, TKey, TValue>> GetAll();

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
        IEnumerable<IProperty<TImpl, TKey, TValue>> CollectPropertys(TKey keys);

        /// <summary>
        /// Get all child nodes beneeth this node recursive.
        /// </summary>
        /// <param name="mexDepth">The maximal depth for the recursion</param>
        /// <returns></returns>
        IEnumerable<TImpl> GetChildren(uint mexDepth = 0);

        /// <summary>
        /// Returns all nodes from the root node to this node (inclusive) in this order.
        /// </summary>
        /// <returns></returns>
        IEnumerable<TImpl> GetParents();

        /// <summary>
        /// Sets the parent of this node.
        /// Throws exception if a parent is already defined.
        /// </summary>
        /// <param name="parent">The new parent node</param>
        void SetParent(TImpl parent);

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
        TImpl GetChild(string name);

        /// <summary>
        /// Adds a new child to this node.
        /// </summary>
        /// <param name="child"></param>
        void AddChild(TImpl child);

        /// <summary>
        /// Adds multible childs to this node.
        /// </summary>
        /// <param name="child"></param>
        void AddChildren(IEnumerable<TImpl> child);

        /// <summary>
        /// Creates a new node and adds it as a child.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        TImpl CreateChild(string name);

        /// <summary>
        /// Removes a child from this node.
        /// </summary>
        /// <param name="child"></param>
        /// <returns>False if it wasn't a child of this node</returns>
        bool RemoveChild(TImpl child);

        /// <summary>
        /// Find a node by its relative path.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        TImpl FindNode(String path);

        /// <summary>
        /// Find a node by its relative path.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        TImpl FindNode(IEnumerable<string> path);

        /// <summary>
        /// Converts the node to a serializeable RawNode
        /// </summary>
        /// <returns></returns>
        RawNode<TImpl, TKey, TValue> ToRawNode();

        /// <summary>
        /// Spawns a update-wave
        /// </summary>
        /// <typeparam name="TArgs"></typeparam>
        /// <param name="key"></param>
        /// <param name="args"></param>
        void Update<TArgs>(TKey key, TArgs args);

        /// <summary>
        /// Spawns a update-wave for propertys implementing IOverridingProperty
        /// </summary>
        void UpdateOverrides();
    }
}
