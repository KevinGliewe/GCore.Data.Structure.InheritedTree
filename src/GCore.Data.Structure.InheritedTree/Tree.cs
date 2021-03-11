using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GCore.Data.Structure.InheritedTree
{
    public class Tree<TTree, TNode, TKey, TValue> :
        ITree<TTree, TNode, TKey, TValue>
        where TNode : INode<TTree, TNode, TKey, TValue>
        where TTree : Tree<TTree, TNode, TKey, TValue>
    {

        protected TNode _root;
        public TNode Root => _root;

        public string Separator { get; private set; }

        public Tree(String root = "root", String separator = ":")
        {
            Separator = separator;

            _root = Activator.CreateInstance<TNode>();
            _root.InitNode(root, (TTree)this);
        }

        public Tree(RawNode<TNode, TKey, TValue> rawNode, String separator = ":")
        {
            Separator = separator;

            _root = Activator.CreateInstance<TNode>();
            _root.InitNode(rawNode, (TTree)this);
        }

        public TNode CreateNode(string name)
        {
            var node = Activator.CreateInstance<TNode>();
            node.InitNode(name, (TTree)this);
            return node;
        }

        public TNode CreateNode(string name, IDictionary<TKey, TValue> props = null, params TNode[] childs)
        {
            var node = Activator.CreateInstance<TNode>();
            node.InitNode(name, (TTree)this, props, childs);

            return node;
        }

        public TNode FindNode(string path)
        {
            var p = path.Split(new []{ Separator }, StringSplitOptions.None);
            if (p[0] == _root.Name)
                return _root.FindNode(p.Skip(1));
            else
                return default(TNode);
        }

        public IEnumerable<IProperty<TNode, TKey, TValue>> CollectPropertys(TKey keys)
        {
            return _root?.CollectPropertys(keys) ?? new IProperty<TNode, TKey, TValue>[0];
        }

        public RawNode<TNode, TKey, TValue> ToRawNodes()
        {
            return _root?.ToRawNode();
        }

        public void Update<TArgs>(TKey key, TArgs args)
        {
            _root?.Update(key, args);
        }

        public void UpdateOverrides()
        {
            _root?.UpdateOverrides();
        }
    }
}
