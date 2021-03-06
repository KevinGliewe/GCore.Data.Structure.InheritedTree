﻿using System;
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

        public TNewNode CreateNode<TNewNode>(string name) where TNewNode : TNode
        {
            var node = Activator.CreateInstance<TNewNode>();
            node.InitNode(name ?? throw new Exception("Root node needs a name!"), (TTree)this);
            return node;
        }

        public TNewNode CreateNode<TNewNode>(string name, IDictionary<TKey, TValue> props = null, params TNode[] childs) where TNewNode : TNode
        {
            var node = Activator.CreateInstance<TNewNode>();
            node.InitNode(name ?? throw new Exception("Root node needs a name!"), (TTree)this, props, childs);

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
