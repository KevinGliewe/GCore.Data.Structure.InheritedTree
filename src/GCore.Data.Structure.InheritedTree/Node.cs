﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace GCore.Data.Structure.InheritedTree
{
    public class Node<TKey, TValue> : INode<TKey, TValue>
    {
        public const char SEPARATOR = ':';

        protected List<Property<TKey, TValue>> _props = new List<Property<TKey, TValue>>();
        protected List<INode<TKey, TValue>> _children = new List<INode<TKey, TValue>>();
        protected Tree<TKey, TValue> _tree;

        public event PropertyChangedEventHandler<TKey, TValue> PropertyChanged;
        public event ChildrenChangedEventHandler<TKey, TValue> ChildrenChanged;

        public TValue this[TKey key] { get => Get(key); set => Set(key, value); }

        public string Name { get; protected set; }

        public string Path => String.Join(SEPARATOR.ToString(), this.GetParents().Select(p => p.Name)) + SEPARATOR + Name;

        public uint Depth => (uint)this.GetParents().Count();

        public INode<TKey, TValue> Parent { get; protected set; }

        public IEnumerable<IProperty<TKey, TValue>> Propertys
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

        public ITree<TKey, TValue> Tree => _tree;

        public IEnumerable<IProperty<TKey, TValue>> SelfPropertys => _props;

        public IEnumerable<INode<TKey, TValue>> Children => _children;

        internal Node(String name, Tree<TKey, TValue> tree)
        {
            _tree = tree;
            Name = name;
        }

        internal Node(String name, Tree<TKey, TValue> tree, IDictionary<TKey, TValue> props = null, IEnumerable<INode<TKey, TValue>> children = null)
        {
            _tree = tree;
            Name = name;

            if (props != null)
                foreach (var kv in props)
                {
                    _props.Add(new Property<TKey, TValue>(this, kv.Key, kv.Value));
#pragma warning disable RECS0021
                    UpdateIOverridingProperty(kv.Key);
#pragma warning restore RECS0021
                }

            if (children != null)
                foreach (var child in children)
                    this.AddChild(child);
        }

        internal Node(RawNode<TKey, TValue> rawNode, Tree<TKey, TValue> tree)
        {
            _tree = tree;
            Name = rawNode.Name;

            foreach (var kv in rawNode.Propertys)
            {
                _props.Add(new Property<TKey, TValue>(this, kv.Key, kv.Value));
#pragma warning disable RECS0021
                UpdateIOverridingProperty(kv.Key);
#pragma warning restore RECS0021
            }

            foreach (var child in rawNode.Children)
                this.AddChild(new Node<TKey, TValue>(child, tree));
        }

        public void AddChild(INode<TKey, TValue> child)
        {
            if (_children.Contains(child))
                return;
            _children.Add(child);
            child.SetParent(this);

            RaiseChildrenChanged(new ChildrenChangedEventArgs<TKey, TValue>(child, ChildrenChangeAction.Added));
        }

        public void AddChildren(IEnumerable<INode<TKey, TValue>> child)
        {
            foreach (var node in child)
            {
                AddChild(node);
            }
        }

        public bool Defines(TKey key) => _props.FirstOrDefault(p => p.Key.Equals(key)) != null;

        public TValue Get(TKey key)
        {
            var val = _props.FirstOrDefault(p => p.Key.Equals(key));
            if (val != null)
                return val.Value;

            if (this.Parent != null)
                return this.Parent.Get(key);

            return default(TValue);
        }

        public bool ResetDefinition(TKey key)
        {
            var prop = _props.FirstOrDefault(p => p.Key.Equals(key));

            if (prop is null)
                return false;

            _props.Remove(prop);

            RaisePropertyChanged(
                new PropertyChangedEventArgs<TKey, TValue>(
                    new Property<TKey, TValue>(this, prop.Key, default(TValue)),
                    prop.Value,
                    PropertyChangedEventArgs<TKey, TValue>.PropertyChangedMode.Removed));

            return true;
        }

        public IEnumerable<IProperty<TKey, TValue>> CollectPropertys(TKey keys)
        {
            return GetAll().Where(p => p.Key.Equals(keys));
        }

        public IEnumerable<IProperty<TKey, TValue>> GetAll()
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

        public IEnumerable<INode<TKey, TValue>> GetChildren(uint maxDepth = 0)
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

        public IEnumerable<INode<TKey, TValue>> GetParents()
        {
            var parents = new List<INode<TKey, TValue>>();

            var parent = this.Parent;

            while(parent != null)
            {
                parents.Add(parent);
                parent = parent.Parent;
            }

            parents.Reverse();
            return parents;
        }

        public bool Has(TKey key)
        {
            if (_props.FirstOrDefault(p => p.Key.Equals(key)) != null)
                return true;

            return Parent?.Has(key) ?? false;
        }

        public bool IsInherted(TKey key)
        {
            return !Defines(key);
        }

        public void RemoveParent()
        {
            if (Parent != null)
            {
                Parent.PropertyChanged -= Parent_PropertyChanged;
                Parent.RemoveChild(this);
            }
            Parent = null;
        }

        public bool Set(TKey key, TValue value)
        {
            var old = Get(key);

            _props.RemoveAll(p => p.Key.Equals(key));

            var prop = new Property<TKey, TValue>(this, key, value);

            _props.Add(prop);

            RaisePropertyChanged(new PropertyChangedEventArgs<TKey, TValue>(prop, old));

            return !old.Equals(value);
        }

        public void SetParent(INode<TKey, TValue> parent)
        {
            if (_tree != parent.Tree)
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

        public INode<TKey, TValue> GetChild(string name)
        {
            return _children.FirstOrDefault(c => c.Name == name);
        }

        public INode<TKey, TValue> CreateChild(string name)
        {
            var node = _tree.CreateNode(name);

            AddChild(node);

            return node;
        }

        public bool RemoveChild(INode<TKey, TValue> child)
        {
            if (_children.Remove(child))
            {
                RaiseChildrenChanged(new ChildrenChangedEventArgs<TKey, TValue>(child, ChildrenChangeAction.Removed));
                return true;
            }
            return false;
        }

        public INode<TKey, TValue> FindNode(string path)
        {
            return FindNode(path.Split(SEPARATOR));
        }

        public INode<TKey, TValue> FindNode(IEnumerable<string> path)
        {
            if (path.Count() == 0)
                return this;

            return GetChild(path.ElementAt(0))?.FindNode(path.Skip(1)) ?? null;
        }

        protected void RaisePropertyChanged(PropertyChangedEventArgs<TKey, TValue> args)
        {
            if(args.Mode != PropertyChangedEventArgs<TKey, TValue>.PropertyChangedMode.Removed)
                UpdateIOverridingProperty(args.Property.Key, false);
            PropertyChanged?.Invoke(this, args);
        }

        protected void RaiseChildrenChanged(ChildrenChangedEventArgs<TKey, TValue> args)
        {
            args.Child.UpdateOverrides();
            ChildrenChanged?.Invoke(this, args);
        }

        protected virtual void UpdateIOverridingProperty(TKey key, bool raisePropertyChangedEvent = true)
        {
            var thisProp = _props.FirstOrDefault(p => p.Key.Equals(key));

            if (thisProp is null)
                return;

            if (!(thisProp.Value is IOverridingProperty<TKey, TValue>))
                return;

            IProperty<TKey, TValue> lastProp = null;

            try
            {
                lastProp = CollectPropertys(key).Reverse().Skip(1).First();
            }
            catch (Exception ex) { }

            //if (lastProp is null)
            //    return;

            (thisProp.Value as IOverridingProperty<TKey, TValue>).OnOverridesProperty(lastProp);

            if(raisePropertyChangedEvent)
                RaisePropertyChanged(new PropertyChangedEventArgs<TKey, TValue>(thisProp, thisProp.Value));
        }

        private void Parent_PropertyChanged(INode<TKey, TValue> sender, PropertyChangedEventArgs<TKey, TValue> e)
        {
            if (!this.Defines(e.Property.Key))
                RaisePropertyChanged(e);
            else
                UpdateIOverridingProperty(e.Property.Key);
        }

        internal RawNode<TKey, TValue> ToRawNode()
        {
            var props = new Dictionary<TKey, TValue>();
            foreach (var prop in this._props)
                props[prop.Key] = prop.Value;
            return new RawNode<TKey, TValue>()
            {
                Name = this.Name,
                Propertys = props,
                Children = _children.Select(c => (c as Node<TKey, TValue>).ToRawNode()).ToArray()
            };
        }

        public void Update<TArgs>(TKey key, TArgs args)
        {
            var updateQueue = new Queue<INode<TKey, TValue>>();
            updateQueue.Enqueue(this);

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

        public void UpdateOverrides()
        {
            foreach (var key in _props.Select(p => p.Key))
                UpdateIOverridingProperty(key, false);
            foreach (var child in _children)
                child.UpdateOverrides();
        }

    }
}
