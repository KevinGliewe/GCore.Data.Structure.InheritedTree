using System;
using System.Collections.Generic;
using System.Text;

namespace GCore.Data.Structure.InheritedTree
{
    /// <summary>
    /// Possible trait for Node types.
    /// Notifies the node if children changes.
    /// <a href="https://kevingliewe.github.io/GCore.Data.Structure.InheritedTree/api/GCore.Data.Structure.InheritedTree.INotifyChildrenChanged-1.html">see more</a>
    /// </summary>
    /// <typeparam name="TNode">The used <seealso cref="INode{TTree, TNode, TKey, TValue}"/> implementation</typeparam>
    public interface INotifyChildrenChanged<TNode>
    {
        /// <summary>
        /// Gets invoked after a child node changes.
        /// </summary>
        event ChildrenChangedEventHandler<TNode> ChildrenChanged;
    }

    /// <summary>
    /// The type of change.
    /// <a href="https://kevingliewe.github.io/GCore.Data.Structure.InheritedTree/api/GCore.Data.Structure.InheritedTree.ChildrenChangeAction.html">see more</a>
    /// </summary>
    public enum ChildrenChangeAction
    {
        /// <summary>
        /// Node added as child
        /// </summary>
        Added,

        /// <summary>
        /// Child removed
        /// </summary>
        Removed
    }

    /// <summary>
    /// Argument for <see cref="ChildrenChangedEventHandler{TNode}"/>.
    /// <a href="https://kevingliewe.github.io/GCore.Data.Structure.InheritedTree/api/GCore.Data.Structure.InheritedTree.ChildrenChangedEventArgs-1.html">see more</a>
    /// </summary>
    /// <typeparam name="TNode">The used <seealso cref="INode{TTree, TNode, TKey, TValue}"/> implementation</typeparam>
    public class ChildrenChangedEventArgs<TNode>
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="child">The involved child node.</param>
        /// <param name="action">The kind of change that triggered this event.</param>
        public ChildrenChangedEventArgs(TNode child, ChildrenChangeAction action)
        {
            Child = child;
            Action = action;
        }

        /// <summary>
        /// The involved child node.
        /// </summary>
        public virtual TNode Child { get; private set; }

        /// <summary>
        /// The kind of change that triggered this event.
        /// </summary>
        public virtual ChildrenChangeAction Action { get; private set; }
    }

    /// <summary>
    /// Delegate for the <see cref="Node{TTree,TNode,TKey,TValue}.ChildrenChanged"/> event.
    /// <a href="https://kevingliewe.github.io/GCore.Data.Structure.InheritedTree/api/GCore.Data.Structure.InheritedTree.ChildrenChangedEventHandler-1.html">see more</a>
    /// </summary>
    /// <typeparam name="TNode"></typeparam>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void ChildrenChangedEventHandler<TNode>(TNode sender, ChildrenChangedEventArgs<TNode> e);
}
