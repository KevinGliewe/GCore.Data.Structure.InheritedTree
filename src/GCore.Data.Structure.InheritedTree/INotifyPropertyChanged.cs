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
        public enum PropertyChangedMode
        {
            Changed,
            Removed
        }

        public PropertyChangedEventArgs(IProperty<TKey, TValue> property, TValue oldValue, PropertyChangedMode mode = PropertyChangedMode.Changed)
        {
            Property = property;
            OldValue = oldValue;
            Mode = mode;
        }
        
        public IProperty<TKey, TValue> Property { get; private set; }
        public TValue OldValue { get; private set; }
        public PropertyChangedMode Mode { get; private set; }
    }

    public delegate void PropertyChangedEventHandler<TKey, TValue>(INode<TKey, TValue> sender, PropertyChangedEventArgs<TKey, TValue> e);
}
