using System;
namespace GCore.Data.Structure.InheritedTree
{
    public interface IOverridingProperty<TKey, TValue>
    {
        void OnOverridesProperty(IProperty<TKey, TValue> property);
    }
}
