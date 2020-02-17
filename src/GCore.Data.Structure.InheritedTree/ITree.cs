using System;
using System.Collections.Generic;
using System.Text;

namespace GCore.Data.Structure.InheritedTree
{
    public interface ITree<TKey, TValue>
    {
        INode<TKey, TValue> Root { get; }
        INode<TKey, TValue> CreateNode(String name);

        INode<TKey, TValue> FindNode(string path);

        IEnumerable<IProperty<TKey, TValue>> CollectPropertys(TKey keys);

        void Update<TArgs>(TKey key, TArgs args);

        void UpdateOverrides();
    }
}
