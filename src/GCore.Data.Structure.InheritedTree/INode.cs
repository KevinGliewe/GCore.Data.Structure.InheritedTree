using System;
using System.Collections.Generic;
using System.Text;

namespace GCore.Data.Structure.InheritedTree
{
    public interface INode<TKey, TValue> : INotifyChildrenChanged<TKey, TValue>, INotifyPropertyChanged<TKey, TValue>
    {

        String Name { get; }
        String Path { get; }
        uint Depth { get; }

        INode<TKey, TValue> Parent { get; }

        ITree<TKey, TValue> Tree { get; }

        IEnumerable<IProperty<TKey, TValue>> Propertys { get; }

        bool IsInherted(TKey key);
        bool Defines(TKey key);

        bool Has(TKey key);
        TValue Get(TKey key);
        bool Set(TKey key, TValue value);
        IEnumerable<IProperty<TKey, TValue>> GetAll();

        TValue this[TKey key]
        {
            get;
            set;
        }

        IEnumerable<IProperty<TKey, TValue>> CollectPropertys(TKey keys);

        IEnumerable<INode<TKey, TValue>> GetChildren(uint mexDepth = 0);
        IEnumerable<INode<TKey, TValue>> GetParents();

        void SetParent(INode<TKey, TValue> parent);
        void RemoveParent();

        INode<TKey, TValue> GetChild(string name);
        void AddChild(INode<TKey, TValue> child);
        void AddChildren(IEnumerable<INode<TKey, TValue>> child);
        INode<TKey, TValue> CreateChild(string name);

        bool RemoveChild(INode<TKey, TValue> child);

        INode<TKey, TValue> FindNode(String path);
        INode<TKey, TValue> FindNode(IEnumerable<string> path);
    }
}
