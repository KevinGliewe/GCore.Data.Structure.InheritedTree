using System;
using System.Collections.Generic;
using System.Text;

namespace GCore.Data.Structure.InheritedTree
{
    public interface INotifyChildrenChanged<TImpl, TKey, TValue>
    {
        event ChildrenChangedEventHandler<TImpl, TKey, TValue> ChildrenChanged;
    }

    public enum ChildrenChangeAction
    {
        Added,
        Removed
    }

    public class ChildrenChangedEventArgs<TImpl, TKey, TValue>
    {
        public ChildrenChangedEventArgs(TImpl child, ChildrenChangeAction action)
        {
            Child = child;
            Action = action;
        }
        public virtual TImpl Child { get; private set; }
        public virtual ChildrenChangeAction Action { get; private set; }
    }

    public delegate void ChildrenChangedEventHandler<TImpl, TKey, TValue>(TImpl sender, ChildrenChangedEventArgs<TImpl, TKey, TValue> e);
}
