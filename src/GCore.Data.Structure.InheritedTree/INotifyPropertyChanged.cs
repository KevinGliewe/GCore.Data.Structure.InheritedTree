using System;
using System.Collections.Generic;
using System.Text;

namespace GCore.Data.Structure.InheritedTree
{
    public interface INotifyPropertyChanged<TKey, TValue>
    {
        event PropertyChangedEventHandler<TKey, TValue> PropertyChanged;
    }

    //
    public class PropertyChangedEventArgs<TKey, TValue>
    {
        public PropertyChangedEventArgs(IProperty<TKey, TValue> property, TValue oldValue)
        {
            Property = property;
            OldValue = oldValue;
        }
        
        public IProperty<TKey, TValue> Property { get; private set; }
        public TValue OldValue { get; private set; }
    }

    public delegate void PropertyChangedEventHandler<TKey, TValue>(INode<TKey, TValue> sender, PropertyChangedEventArgs<TKey, TValue> e);
}
