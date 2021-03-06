﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace GCore.Data.Structure.InheritedTree
{
    public class Node<TTree, TNode, TKey, TValue> :
        INode<TTree, TNode, TKey, TValue>
        where TNode : Node<TTree, TNode, TKey, TValue>
        where TTree : ITree<TTree, TNode, TKey, TValue>
    {

        protected List<Property<TNode, TKey, TValue>> _props = new List<Property<TNode, TKey, TValue>>();
        protected List<TNode> _children = new List<TNode>();
        protected TTree _tree;

        /// <inheritdoc />
        public event PropertyChangedEventHandler<TNode, TKey, TValue> PropertyChanged;

        /// <inheritdoc />
        public event ChildrenChangedEventHandler<TNode, TKey, TValue> ChildrenChanged;

        /// <inheritdoc />
        public TValue this[TKey key] { get => Get(key); set => Set(key, value); }

        /// <inheritdoc />
        public string Name { get; protected set; } = null;

        /// <inheritdoc />
        public string Path => String.Join(Tree.Separator, this.GetParents().Select(p => p.Name)) + Tree.Separator + Name;

        /// <inheritdoc />
        public uint Depth => (uint)this.GetParents().Count();

        /// <inheritdoc />
        public TNode Parent { get; protected set; }

        /// <inheritdoc />
        public IEnumerable<IProperty<TNode, TKey, TValue>> Propertys
        {
            get
            {
                if(this.Parent != null)
                {
                    foreach(var prop in this.Parent.Propertys)
                    {
                        if (_props.FirstOrDefault( p => p.Key.Equals(prop.Key)) != null)
                            yield return prop;
                    }
                }
                foreach (var prop in _props)
                    yield return prop;
                    
            }
        }

        /// <inheritdoc />
        public TTree Tree => _tree;

        /// <inheritdoc />
        public IEnumerable<IProperty<TNode, TKey, TValue>> SelfPropertys => _props;

        /// <inheritdoc />
        public IEnumerable<TNode> Children => _children;

        public Node()
        {
        }

        /// <inheritdoc />
        public void AddChild(TNode child)
        {
            if (_children.Contains(child))
                return;
            _children.Add(child);
            child.SetParent((TNode)this);

            RaiseChildrenChanged(new ChildrenChangedEventArgs<TNode, TKey, TValue>(child, ChildrenChangeAction.Added));
        }

        /// <inheritdoc />
        public void AddChildren(IEnumerable<TNode> child)
        {
            foreach (var node in child)
            {
                AddChild(node);
            }
        }

        /// <inheritdoc />
        public bool Defines(TKey key) => _props.FirstOrDefault(p => p.Key.Equals(key)) != null;

        /// <inheritdoc />
        public TValue Get(TKey key)
        {
            var val = _props.FirstOrDefault(p => p.Key.Equals(key));
            if (val != null)
                return val.Value;

            if (this.Parent != null)
                return this.Parent.Get(key);

            return default(TValue);
        }

        /// <inheritdoc />
        public bool ResetDefinition(TKey key)
        {
            var prop = _props.FirstOrDefault(p => p.Key.Equals(key));

            if (prop is null)
                return false;

            _props.Remove(prop);

            RaisePropertyChanged(
                new PropertyChangedEventArgs<TNode, TKey, TValue>(
                    new Property<TNode, TKey, TValue>((TNode)this, prop.Key, default(TValue)),
                    prop.Value,
                    PropertyChangedEventArgs<TNode, TKey, TValue>.PropertyChangedMode.Removed));

            return true;
        }

        /// <inheritdoc />
        public IEnumerable<IProperty<TNode, TKey, TValue>> CollectPropertys(TKey keys)
        {
            return GetAll().Where(p => p.Key.Equals(keys));
        }

        /// <inheritdoc />
        public IEnumerable<IProperty<TNode, TKey, TValue>> GetAll()
        {
            if (this.Parent != null)
            {
                foreach (var prop in this.Parent.Propertys)
                {
                    if (_props.FirstOrDefault(p => p.Key.Equals(prop.Key)) != null)
                        yield return prop;
                }
            }
            foreach (var prop in _props)
                yield return prop;
        }

        /// <inheritdoc />
        public IEnumerable<TNode> GetChildren(uint maxDepth = 0)
        {
            foreach(var n in _children)
            {
                yield return n;
                if(maxDepth > 0)
                {
                    foreach (var nn in n.GetChildren(maxDepth - 1))
                        yield return nn;
                }
            }
        }

        /// <inheritdoc />
        public IEnumerable<TNode> GetParents()
        {
            var parents = new List<TNode>();

            var parent = this.Parent;

            while(parent != null)
            {
                parents.Add(parent);
                parent = parent.Parent;
            }

            parents.Reverse();
            return parents;
        }

        /// <inheritdoc />
        public bool Has(TKey key)
        {
            if (_props.FirstOrDefault(p => p.Key.Equals(key)) != null)
                return true;

            return Parent?.Has(key) ?? false;
        }

        /// <inheritdoc />
        public void InitNode(string nodeName, TTree tree)
        {
            _tree = tree;
            Name = nodeName;
        }

        /// <inheritdoc />
        public void InitNode(String name, TTree tree, IDictionary<TKey, TValue> props = null, IEnumerable<TNode> children = null)
        {
            _tree = tree;
            Name = name;

            if (props != null)
                foreach (var kv in props)
                {
                    _props.Add(new Property<TNode, TKey, TValue>((TNode)this, kv.Key, kv.Value));
#pragma warning disable RECS0021
                    UpdateIOverridingProperty(kv.Key);
#pragma warning restore RECS0021
                }

            if (children != null)
                foreach (var child in children)
                    this.AddChild(child);
        }

        /// <inheritdoc />
        public void InitNode(RawNode<TNode, TKey, TValue> rawNode, TTree tree)
        {
            _tree = tree;
            Name = rawNode.Name;

            foreach (var kv in rawNode.Propertys)
            {
                _props.Add(new Property<TNode, TKey, TValue>((TNode)this, kv.Key, kv.Value));
#pragma warning disable RECS0021
                UpdateIOverridingProperty(kv.Key);
#pragma warning restore RECS0021
            }

            foreach (var child in rawNode.Children)
            {
                var type = Type.GetType(child.NodeType);
                var node = Activator.CreateInstance(type) as TNode ?? throw new Exception($"Can't create {child.NodeType} instance");
                
                node.InitNode(child, tree);
                this.AddChild(node);
            }
        }

        /// <inheritdoc />
        public bool IsInherted(TKey key)
        {
            return !Defines(key);
        }

        public void RemoveParent()
        {
            if (Parent != null)
            {
                Parent.PropertyChanged -= Parent_PropertyChanged;
                Parent.RemoveChild((TNode)this);
            }
            Parent = null;
        }

        /// <inheritdoc />
        public bool Set(TKey key, TValue value)
        {
            var old = Get(key);

            _props.RemoveAll(p => p.Key.Equals(key));

            var prop = new Property<TNode, TKey, TValue>((TNode)this, key, value);

            _props.Add(prop);

            RaisePropertyChanged(new PropertyChangedEventArgs<TNode, TKey, TValue>(prop, old));

            return old == null ? false : !old.Equals(value);
        }

        /// <inheritdoc />
        public void SetParent(TNode parent)
        {
            if (!_tree.Equals(parent.Tree))
                throw new Exception("Nodes are not from the same Tree");

            var tmp = parent;

            while(tmp != null)
            {
                if (tmp == this)
                    throw new Exception("Loop detected");
                tmp = tmp.Parent;
            }

            if (Parent is null)
            {
                Parent = parent;
                Parent.PropertyChanged += Parent_PropertyChanged;
            }
            else
                throw new Exception(Path + " already has a Parent");
        }

        /// <inheritdoc />
        public TNode GetChild(string name)
        {
            return _children.FirstOrDefault(c => c.Name == name);
        }

        /// <inheritdoc />
        public TNewNode CreateChild<TNewNode>(string name) where TNewNode : TNode
        {
            var node = _tree.CreateNode<TNewNode>(name);

            AddChild(node);

            return node;
        }

        /// <inheritdoc />
        public bool RemoveChild(TNode child)
        {
            if (_children.Remove(child))
            {
                RaiseChildrenChanged(new ChildrenChangedEventArgs<TNode, TKey, TValue>(child, ChildrenChangeAction.Removed));
                return true;
            }
            return false;
        }

        /// <inheritdoc />
        public TNode FindNode(string path)
        {
            
            return FindNode(path.Split(new []{ Tree.Separator }, StringSplitOptions.None));
        }

        /// <inheritdoc />
        public TNode FindNode(IEnumerable<string> path)
        {
            if (path.Count() == 0)
                return (TNode)this;

            return GetChild(path.ElementAt(0))?.FindNode(path.Skip(1)) ?? null;
        }

        /// <inheritdoc />
        protected void RaisePropertyChanged(PropertyChangedEventArgs<TNode, TKey, TValue> args)
        {
            if(args.Mode != PropertyChangedEventArgs<TNode, TKey, TValue>.PropertyChangedMode.Removed)
                UpdateIOverridingProperty(args.Property.Key, false);
            PropertyChanged?.Invoke((TNode)this, args);
        }

        /// <inheritdoc />
        protected void RaiseChildrenChanged(ChildrenChangedEventArgs<TNode, TKey, TValue> args)
        {
            args.Child.UpdateOverrides();
            ChildrenChanged?.Invoke((TNode)this, args);
        }

        /// <inheritdoc />
        protected virtual void UpdateIOverridingProperty(TKey key, bool raisePropertyChangedEvent = true)
        {
            var thisProp = _props.FirstOrDefault(p => p.Key.Equals(key));

            if (thisProp is null)
                return;

            if (!(thisProp.Value is IOverridingProperty<TNode, TKey, TValue>))
                return;

            IProperty<TNode, TKey, TValue> lastProp = null;

            try
            {
                lastProp = CollectPropertys(key).Reverse().Skip(1).First();
            }
            catch (Exception ex) { }

            //if (lastProp is null)
            //    return;

            (thisProp.Value as IOverridingProperty<TNode, TKey, TValue>).OnOverridesProperty(lastProp);

            if(raisePropertyChangedEvent)
                RaisePropertyChanged(new PropertyChangedEventArgs<TNode, TKey, TValue>(thisProp, thisProp.Value));
        }

        private void Parent_PropertyChanged(TNode sender, PropertyChangedEventArgs<TNode, TKey, TValue> e)
        {
            if (!this.Defines(e.Property.Key))
                RaisePropertyChanged(e);
            else
                UpdateIOverridingProperty(e.Property.Key);
        }

        /// <inheritdoc />
        public RawNode<TNode, TKey, TValue> ToRawNode()
        {
            var props = new Dictionary<TKey, TValue>();
            foreach (var prop in this._props)
                props[prop.Key] = prop.Value;

            var typeNameElements = this.GetType().AssemblyQualifiedName.Split(',');
            var typeName = typeNameElements[0] + "," + typeNameElements[1];

            return new RawNode<TNode, TKey, TValue>()
            {
                NodeType = typeName,
                NodeData = null, // No data for this implementation
                Name = this.Name,
                Propertys = props,
                Children = _children.Select(c => (c as TNode).ToRawNode()).ToArray()
            };
        }

        /// <inheritdoc />
        public void Update<TArgs>(TKey key, TArgs args)
        {
            var updateQueue = new Queue<TNode>();
            updateQueue.Enqueue((TNode)this);

            while(updateQueue.Count > 0)
            {
                var node = updateQueue.Dequeue();
                var prop = node.SelfPropertys.FirstOrDefault(
                    p => p.Key.Equals(key) && p.Value is IUpdatableProperty<TArgs>);

                if(prop != null)
                    (prop.Value as IUpdatableProperty<TArgs>)?.Update(args);

                foreach (var child in node.Children)
                    updateQueue.Enqueue(child);
            }
        }

        /// <inheritdoc />
        public void UpdateOverrides()
        {
            foreach (var key in _props.Select(p => p.Key))
                UpdateIOverridingProperty(key, false);
            foreach (var child in _children)
                child.UpdateOverrides();
        }

    }
}
