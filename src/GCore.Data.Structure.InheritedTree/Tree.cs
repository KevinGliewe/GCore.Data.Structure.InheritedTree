using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GCore.Data.Structure.InheritedTree
{
    public class Tree<TKey, TValue> : ITree<TKey, TValue>
    {

        protected Node<TKey, TValue> _root;
        public INode<TKey, TValue> Root => _root;

        public Tree(String root)
        {
            _root = new Node<TKey, TValue>(root, this);
        }

        public Tree(RawNode<TKey, TValue> rawNode)
        {
            _root = new Node<TKey, TValue>(rawNode, this);
        }

        public INode<TKey, TValue> CreateNode(string name)
        {
            return new Node<TKey, TValue>(name, this);
        }

        public INode<TKey, TValue> CreateNode(string name, IDictionary<TKey, TValue> props = null, params INode<TKey, TValue>[] childs)
        {
            return new Node<TKey, TValue>(name, this, props, childs);
        }

        public INode<TKey, TValue> FindNode(string path)
        {
            var p = path.Split(Node<TKey, TValue>.SEPARATOR);
            if (p[0] == _root.Name)
                return _root?.FindNode(p.Skip(1)) ?? null;
            else
                return null;
        }

        public IEnumerable<IProperty<TKey, TValue>> CollectPropertys(TKey keys)
        {
            return _root?.CollectPropertys(keys) ?? new IProperty<TKey, TValue>[0];
        }

        public RawNode<TKey, TValue> ToRawNodes()
        {
            return _root?.ToRawNode();
        }
    }
}
