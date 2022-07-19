using System;
using System.Collections.Generic;
using System.Text;

namespace GCore.Data.Structure.InheritedTree
{
    /// <summary>
    /// Possible trait for Node types.
    /// Notifies the node if children changes.
    /// </summary>
    /// <typeparam name="TNode"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public interface INotifyChildrenChanged<TNode>
    {
        event ChildrenChangedEventHandler<TNode> ChildrenChanged;
    }

    /// <summary>
    /// The type of change.
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
    /// </summary>
    /// <typeparam name="TNode">The used <seealso cref="INode{TTree, TNode, TKey, TValue}"/> implementation</typeparam>
    public class ChildrenChangedEventArgs<TNode>
    {
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
    /// </summary>
    /// <typeparam name="TNode"></typeparam>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void ChildrenChangedEventHandler<TNode>(TNode sender, ChildrenChangedEventArgs<TNode> e);
}
