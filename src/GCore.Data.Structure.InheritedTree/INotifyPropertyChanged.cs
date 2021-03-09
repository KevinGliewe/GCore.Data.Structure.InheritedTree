using System;
using System.Collections.Generic;
using System.Text;

namespace GCore.Data.Structure.InheritedTree
{
    public interface INotifyPropertyChanged<TImpl, TKey, TValue>
    {
        event PropertyChangedEventHandler<TImpl, TKey, TValue> PropertyChanged;
    }

    //
    public class PropertyChangedEventArgs<TImpl, TKey, TValue>
    {
        public enum PropertyChangedMode
        {
            Changed,
            Removed
        }

        public PropertyChangedEventArgs(IProperty<TImpl, TKey, TValue> property, TValue oldValue, PropertyChangedMode mode = PropertyChangedMode.Changed)
        {
            Property = property;
            OldValue = oldValue;
            Mode = mode;
        }
        
        public IProperty<TImpl, TKey, TValue> Property { get; private set; }
        public TValue OldValue { get; private set; }
        public PropertyChangedMode Mode { get; private set; }
    }

    public delegate void PropertyChangedEventHandler<TImpl, TKey, TValue>(TImpl sender, PropertyChangedEventArgs<TImpl, TKey, TValue> e);
}
