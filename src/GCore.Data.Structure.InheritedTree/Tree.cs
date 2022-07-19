using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GCore.Data.Structure.InheritedTree
{
    /// <summary>
    /// Tree representation with inherited properties.
    /// Generic <seealso cref="ITree{TTree, TNode, TKey, TValue}"/> implementation.
    /// </summary>
    /// <typeparam name="TTree">The used <seealso cref="ITree{TTree, TNode, TKey, TValue}"/> implementation</typeparam>
    /// <typeparam name="TNode">The used <seealso cref="INode{TTree, TNode, TKey, TValue}"/> implementation</typeparam>
    /// <typeparam name="TKey">The type used for the key</typeparam>
    /// <typeparam name="TValue">The type used for the value</typeparam>
    public class Tree<TTree, TNode, TKey, TValue> :
        ITree<TTree, TNode, TKey, TValue?>
        where TNode : class, INode<TTree, TNode, TKey, TValue?>, new()
        where TTree : Tree<TTree, TNode, TKey, TValue?>
        where TKey : notnull    
    {

        /// <summary>
        /// The root node of the tree.
        /// </summary>
        protected TNode _root;

        /// <summary>
        /// Converts this to the base tree type.
        /// </summary>
        public TTree AsBase => this as TTree ?? throw new Exception("this is not convert able to " + typeof(TTree));

        /// <inheritdoc/>
        public TNode Root => _root;

        /// <inheritdoc/>
        public string Separator { get; private set; }

        /// <inheritdoc/>
        public Func<RawNode<TNode, TKey, TValue?>, TNode?>? RawNodeActivator { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="rootName"></param>
        /// <param name="separator">The string separating the node names in the path</param>
        /// <exception cref="Exception"></exception>
        public Tree(TNode root, String? rootName = null, String separator = ":")
        {
            Separator = separator;

            _root = root;
            _root.InitNode(rootName ?? _root.Name ?? throw new Exception("Root node needs a name!"), this.AsBase);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="root">Name of the root node</param>
        /// <param name="separator">The string separating the node names in the path</param>
        /// <exception cref="Exception"></exception>
        public Tree(String root = "root", String separator = ":")
        {
            Separator = separator ?? throw new Exception("Separator can't be null!");
            
            _root = new TNode();
            _root.InitNode(root ?? throw new Exception("Root node needs a name!"), this.AsBase);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rawNode">Raw tree to build this one from</param>
        /// <param name="separator">The string separating the node names in the path</param>
        /// <exception cref="Exception"></exception>
        public Tree(RawNode<TNode, TKey, TValue?> rawNode, String separator = ":")
        {
            Separator = separator;

            var type = Type.GetType(rawNode.NodeType);

            _root = this.RawNodeActivator?.Invoke(rawNode) ??
                    Activator.CreateInstance(type) as TNode ??
                    throw new Exception($"Can't create {rawNode.NodeType} instance");
            
            _root.InitNode(rawNode, this.AsBase);
        }

        /// <inheritdoc/>
        public TNewNode CreateNode<TNewNode>(string name) where TNewNode : TNode, new()
        {
            var node = new TNewNode();
            node.InitNode(name ?? throw new Exception("Root node needs a name!"), this.AsBase);
            return node;
        }

        /// <inheritdoc/>
        public TNode CreateNode(string name) => CreateNode<TNode>(name);

        /// <inheritdoc/>
        public TNode CreateNode(string name, IDictionary<TKey, TValue?>? props = null, params TNode[] children) => CreateNode<TNode>(name, props, children);

        /// <inheritdoc/>

        public TNewNode CreateNode<TNewNode>(string name, IDictionary<TKey, TValue?>? props = null, params TNode[] children) where TNewNode : TNode, new()
        {
            var node = new TNewNode();
            node.InitNode(name ?? throw new Exception("Root node needs a name!"), this.AsBase, props, children);

            return node;
        }

        /// <inheritdoc/>
        public TNode? FindNode(string path)
        {
            var p = path.Split(new []{ Separator }, StringSplitOptions.None);
            if (p[0] == _root.Name)
                return _root.FindNode(p.Skip(1));
            else
                return null;
        }

        /// <inheritdoc/>
        public IEnumerable<IProperty<TNode, TKey, TValue?>> CollectProperties(TKey keys)
        {
            return _root?.CollectPropertys(keys) ?? new IProperty<TNode, TKey, TValue?>[0];
        }

        /// <inheritdoc/>
        public RawNode<TNode, TKey, TValue?> ToRawNodes()
        {
            return _root?.ToRawNode() ?? throw new Exception("Root node is null!");
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

    /// <summary>
    /// Tree representation with inherited properties.
    /// More specified version of <seealso cref="Tree{TTree, TNode, TKey, TValue}"/>.
    /// </summary>
    /// <typeparam name="TKey">The type used for the keys</typeparam>
    /// <typeparam name="TValue">The type used for the value</typeparam>
    public class Tree<TKey, TValue> :
        Tree<Tree<TKey, TValue?>, Node<TKey, TValue?>, TKey, TValue?>
        where TKey : notnull
    {
    }

    /// <summary>
    /// Tree representation with inherited properties.
    /// More specified version of <seealso cref="Tree{TTree, TNode, TKey, TValue}"/> with <seealso cref="String"/> as key.
    /// </summary>
    /// <typeparam name="TValue">The type used for the value</typeparam>
    public class Tree<TValue> :
        Tree<Tree<TValue?>, Node<TValue?>, string, TValue?>
    {
    }

    /// <summary>
    /// Tree representation with inherited properties.
    /// Non generic version of <seealso cref="Tree{TTree, TNode, TKey, TValue}"/>.
    /// </summary>
    public class Tree :
        Tree<Tree, Node, string, object?>
    {
    }    
}
