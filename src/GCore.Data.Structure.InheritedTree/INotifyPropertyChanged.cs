using System;
using System.Collections.Generic;
using System.Text;

namespace GCore.Data.Structure.InheritedTree
{
    public interface INotifyPropertyChanged<TNode, TKey, TValue>
    {
        event PropertyChangedEventHandler<TNode, TKey, TValue> PropertyChanged;
    }

    //
    public class PropertyChangedEventArgs<TNode, TKey, TValue>
    {
        public enum PropertyChangedMode
        {
            Changed,
            Removed
        }

        public PropertyChangedEventArgs(IProperty<TNode, TKey, TValue> property, TValue oldValue, PropertyChangedMode mode = PropertyChangedMode.Changed)
        {
            Property = property;
            OldValue = oldValue;
            Mode = mode;
        }
        
        public IProperty<TNode, TKey, TValue> Property { get; private set; }
        public TValue OldValue { get; private set; }
        public PropertyChangedMode Mode { get; private set; }
    }

    public delegate void PropertyChangedEventHandler<TNode, TKey, TValue>(TNode sender, PropertyChangedEventArgs<TNode, TKey, TValue> e);
}
