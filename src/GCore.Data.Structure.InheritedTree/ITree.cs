using System;
using System.Collections.Generic;
using System.Text;

namespace GCore.Data.Structure.InheritedTree
{
    public interface ITree<TTree, TNode, TKey, TValue>
        where TNode : INode<TTree, TNode, TKey, TValue>
        where TTree : ITree<TTree, TNode, TKey, TValue>
    {
        string Separator { get; }

        TNode Root { get; }
        TNode CreateNode(String name);

        TNode FindNode(string path);

        IEnumerable<IProperty<TNode, TKey, TValue>> CollectPropertys(TKey keys);

        void Update<TArgs>(TKey key, TArgs args);

        void UpdateOverrides();
    }
}
