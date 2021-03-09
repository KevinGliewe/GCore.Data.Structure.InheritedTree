using System;
using System.Collections.Generic;
using System.Text;

namespace GCore.Data.Structure.InheritedTree
{
    public interface ITree<TImpl, TKey, TValue>
        where TImpl : INode<TImpl, TKey, TValue>
    {
        string Separator { get; }

        TImpl Root { get; }
        TImpl CreateNode(String name);

        TImpl FindNode(string path);

        IEnumerable<IProperty<TImpl, TKey, TValue>> CollectPropertys(TKey keys);

        void Update<TArgs>(TKey key, TArgs args);

        void UpdateOverrides();
    }
}
