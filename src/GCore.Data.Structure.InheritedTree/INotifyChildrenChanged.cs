using System;
using System.Collections.Generic;
using System.Text;

namespace GCore.Data.Structure.InheritedTree
{
    public interface INotifyChildrenChanged<TKey, TValue>
    {
        event ChildrenChangedEventHandler<TKey, TValue> ChildrenChanged;
    }

    public enum ChildrenChangeAction
    {
        Added,
        Removed
    }

    public class ChildrenChangedEventArgs<TKey, TValue>
    {
        public ChildrenChangedEventArgs(INode<TKey, TValue> child, ChildrenChangeAction action)
        {
            Child = child;
            Action = action;
        }
        public virtual INode<TKey, TValue> Child { get; private set; }
        public virtual ChildrenChangeAction Action { get; private set; }
    }

    public delegate void ChildrenChangedEventHandler<TKey, TValue>(INode<TKey, TValue> sender, ChildrenChangedEventArgs<TKey, TValue> e);
}
