using System;
using System.Collections.Generic;
using System.Text;

namespace GCore.Data.Structure.InheritedTree
{
    /// <summary>
    /// Possible trait for Node types.
    /// Notifies the node if a property changes.
    /// </summary>
    /// <typeparam name="TNode">The used <seealso cref="INode{TTree, TNode, TKey, TValue}"/> implementation</typeparam>
    /// <typeparam name="TKey">The type used for the key</typeparam>
    /// <typeparam name="TValue">The type used for the value</typeparam>
    public interface INotifyPropertyChanged<TNode, TKey, TValue>
    {
        event PropertyChangedEventHandler<TNode, TKey, TValue> PropertyChanged;
    }

    /// <summary>
    /// The type of change.
    /// </summary>
    public enum PropertyChangedMode
    {
        /// <summary>
        /// Property changed
        /// </summary>
        Changed,

        /// <summary>
        /// Property removed
        /// </summary>
        Removed
    }

    /// <summary>
    /// Argument for <see cref="PropertyChangedEventHandler{TNode,TKey,TValue}"/>.
    /// </summary>
    /// <typeparam name="TNode">The used <seealso cref="INode{TTree, TNode, TKey, TValue}"/> implementation</typeparam>
    /// <typeparam name="TKey">The type used for the key</typeparam>
    /// <typeparam name="TValue">The type used for the value</typeparam>
    public class PropertyChangedEventArgs<TNode, TKey, TValue>
    {
        public PropertyChangedEventArgs(IProperty<TNode, TKey, TValue> property, TValue oldValue, PropertyChangedMode mode = PropertyChangedMode.Changed)
        {
            Property = property;
            OldValue = oldValue;
            Mode = mode;
        }

        /// <summary>
        /// The property that changed.
        /// </summary>
        public IProperty<TNode, TKey, TValue> Property { get; private set; }

        /// <summary>
        /// The old value before the change.
        /// </summary>
        public TValue OldValue { get; private set; }

        /// <summary>
        /// The kind of change that triggered this event.
        /// </summary>
        public PropertyChangedMode Mode { get; private set; }
    }

    /// <summary>
    /// Delegate for the <see cref="Node{TTree,TNode,TKey,TValue}.PropertyChanged"/> event.
    /// </summary>
    /// <typeparam name="TNode">The used <seealso cref="INode{TTree, TNode, TKey, TValue}"/> implementation</typeparam>
    /// <typeparam name="TKey">The type used for the key</typeparam>
    /// <typeparam name="TValue">The type used for the value</typeparam>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void PropertyChangedEventHandler<TNode, TKey, TValue>(TNode sender, PropertyChangedEventArgs<TNode, TKey, TValue> e);
}
