using System;
namespace GCore.Data.Structure.InheritedTree
{
    public interface IOverridingProperty<TImpl, TKey, TValue>
    {
        void OnOverridesProperty(IProperty<TImpl, TKey, TValue> property);
    }
}
