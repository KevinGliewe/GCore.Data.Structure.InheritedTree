using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GCore.Data.Structure.InheritedTree
{
    public class Tree<TImpl, TKey, TValue> :
        ITree<TImpl, TKey, TValue>
        where TImpl : INode<TImpl, TKey, TValue>
    {

        protected TImpl _root;
        public TImpl Root => _root;

        public string Separator { get; private set; }

        public Tree(String root, String separator = ":")
        {
            Separator = separator;

            _root = Activator.CreateInstance<TImpl>();
            _root.InitNode(root, this);
        }

        public Tree(RawNode<TImpl, TKey, TValue> rawNode, String separator = ":")
        {
            Separator = separator;

            _root = Activator.CreateInstance<TImpl>();
            _root.InitNode(rawNode, this);
        }

        public TImpl CreateNode(string name)
        {
            var node = Activator.CreateInstance<TImpl>();
            node.InitNode(name, this);
            return node;
        }

        public TImpl CreateNode(string name, IDictionary<TKey, TValue> props = null, params TImpl[] childs)
        {
            var node = Activator.CreateInstance<TImpl>();
            node.InitNode(name, this, props, childs);

            return node;
        }

        public TImpl FindNode(string path)
        {
            var p = path.Split(new []{ Separator }, StringSplitOptions.None);
            if (p[0] == _root.Name)
                return _root.FindNode(p.Skip(1));
            else
                return default(TImpl);
        }

        public IEnumerable<IProperty<TImpl, TKey, TValue>> CollectPropertys(TKey keys)
        {
            return _root?.CollectPropertys(keys) ?? new IProperty<TImpl, TKey, TValue>[0];
        }

        public RawNode<TImpl, TKey, TValue> ToRawNodes()
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
