using System;
namespace GCore.Data.Structure.InheritedTree
{
    public interface IOverridingProperty<TNode, TKey, TValue>
    {
        void OnOverridesProperty(IProperty<TNode, TKey, TValue> property);
    }
}
