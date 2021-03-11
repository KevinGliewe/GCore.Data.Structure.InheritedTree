using System;
using System.Collections.Generic;
using System.Text;

namespace GCore.Data.Structure.InheritedTree
{
    public interface INotifyChildrenChanged<TNode, TKey, TValue>
    {
        event ChildrenChangedEventHandler<TNode, TKey, TValue> ChildrenChanged;
    }

    public enum ChildrenChangeAction
    {
        Added,
        Removed
    }

    public class ChildrenChangedEventArgs<TNode, TKey, TValue>
    {
        public ChildrenChangedEventArgs(TNode child, ChildrenChangeAction action)
        {
            Child = child;
            Action = action;
        }
        public virtual TNode Child { get; private set; }
        public virtual ChildrenChangeAction Action { get; private set; }
    }

    public delegate void ChildrenChangedEventHandler<TNode, TKey, TValue>(TNode sender, ChildrenChangedEventArgs<TNode, TKey, TValue> e);
}
