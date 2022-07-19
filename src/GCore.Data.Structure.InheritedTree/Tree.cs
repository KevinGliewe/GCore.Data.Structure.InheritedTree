using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GCore.Data.Structure.InheritedTree
{
    /// <summary>
    /// Tree representation with inherited properties.
    /// Generic <seealso cref="ITree{TTree, TNode, TKey, TValue}"/> implamentation.
    /// </summary>
    /// <typeparam name="TTree">The used <seealso cref="ITree{TTree, TNode, TKey, TValue}"/> implementation</typeparam>
    /// <typeparam name="TNode">The used <seealso cref="INode{TTree, TNode, TKey, TValue}"/> implementation</typeparam>
    /// <typeparam name="TKey">The type used for the key</typeparam>
    /// <typeparam name="TValue">The type used for the value</typeparam>
    public class Tree<TTree, TNode, TKey, TValue> :
        ITree<TTree, TNode, TKey, TValue>
        where TNode : class, INode<TTree, TNode, TKey, TValue>, new()
        where TTree : Tree<TTree, TNode, TKey, TValue>
    {

        protected TNode _root;
        public TNode Root => _root;

        public string Separator { get; private set; }

        public Tree(TNode root, String rootName = null, String separator = ":")
        {
            Separator = separator;

            _root = root;
            _root.InitNode(rootName ?? _root.Name ?? throw new Exception("Root node needs a name!"), (TTree)this);
        }

        public Tree(String root = "root", String separator = ":")
        {
            Separator = separator ?? throw new Exception("Separator can't be null!");

            _root = Activator.CreateInstance<TNode>();
            _root.InitNode(root ?? throw new Exception("Root node needs a name!"), (TTree)this);
        }

        public Tree(RawNode<TNode, TKey, TValue> rawNode, String separator = ":")
        {
            Separator = separator;

            _root = Activator.CreateInstance<TNode>();
            _root.InitNode(rawNode ?? throw new Exception("Root node needs a name!"), (TTree)this);
        }

        /// <inheritdoc/>
        public TNewNode CreateNode<TNewNode>(string name) where TNewNode : TNode, new()
        {
            //var node = Activator.CreateInstance<TNewNode>();
            var node = new TNewNode();
            node.InitNode(name ?? throw new Exception("Root node needs a name!"), (TTree)this);
            return node;
        }

        /// <inheritdoc/>
        public TNode CreateNode(string name) => CreateNode<TNode>(name);

        /// <inheritdoc/>

        public TNewNode CreateNode<TNewNode>(string name, IDictionary<TKey, TValue> props = null, params TNode[] children) where TNewNode : TNode, new()
        {
            var node = new TNewNode();
            node.InitNode(name ?? throw new Exception("Root node needs a name!"), (TTree)this, props, children);

            return node;
        }

        /// <inheritdoc/>
        public TNode FindNode(string path)
        {
            var p = path.Split(new []{ Separator }, StringSplitOptions.None);
            if (p[0] == _root.Name)
                return _root.FindNode(p.Skip(1));
            else
                return null;
        }

        /// <inheritdoc/>
        public IEnumerable<IProperty<TNode, TKey, TValue>> CollectProperties(TKey keys)
        {
            return _root?.CollectPropertys(keys) ?? new IProperty<TNode, TKey, TValue>[0];
        }

        /// <inheritdoc/>
        public RawNode<TNode, TKey, TValue> ToRawNodes()
        {
            return _root?.ToRawNode();
        }

        /// <inheritdoc/>
        public void Update<TArgs>(TKey key, TArgs args)
        {
            _root?.Update(key, args);
        }

        /// <inheritdoc/>
        public void UpdateOverrides()
        {
            _root?.UpdateOverrides();
        }
    }

    public class Tree<TValue> :
        Tree<Tree<TValue>, Node<TValue>, String, TValue>
    {
    }
}
