using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace GCore.Data.Structure.InheritedTree
{
    public class Node<TImpl, TKey, TValue> :
        INode<TImpl, TKey, TValue>
        where TImpl : Node<TImpl, TKey, TValue>
    {

        protected List<Property<TImpl, TKey, TValue>> _props = new List<Property<TImpl, TKey, TValue>>();
        protected List<TImpl> _children = new List<TImpl>();
        protected ITree<TImpl, TKey, TValue> _tree;

        public event PropertyChangedEventHandler<TImpl, TKey, TValue> PropertyChanged;
        public event ChildrenChangedEventHandler<TImpl, TKey, TValue> ChildrenChanged;

        public TValue this[TKey key] { get => Get(key); set => Set(key, value); }

        public string Name { get; protected set; }

        public string Path => String.Join(Tree.Separator, this.GetParents().Select(p => p.Name)) + Tree.Separator + Name;

        public uint Depth => (uint)this.GetParents().Count();

        public TImpl Parent { get; protected set; }

        public IEnumerable<IProperty<TImpl, TKey, TValue>> Propertys
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

        public ITree<TImpl, TKey, TValue> Tree => _tree;

        public IEnumerable<IProperty<TImpl, TKey, TValue>> SelfPropertys => _props;

        public IEnumerable<TImpl> Children => _children;

        public Node()
        {
        }

        public void AddChild(TImpl child)
        {
            if (_children.Contains(child))
                return;
            _children.Add(child);
            child.SetParent((TImpl)this);

            RaiseChildrenChanged(new ChildrenChangedEventArgs<TImpl, TKey, TValue>(child, ChildrenChangeAction.Added));
        }

        public void AddChildren(IEnumerable<TImpl> child)
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
                new PropertyChangedEventArgs<TImpl, TKey, TValue>(
                    new Property<TImpl, TKey, TValue>((TImpl)this, prop.Key, default(TValue)),
                    prop.Value,
                    PropertyChangedEventArgs<TImpl, TKey, TValue>.PropertyChangedMode.Removed));

            return true;
        }

        public IEnumerable<IProperty<TImpl, TKey, TValue>> CollectPropertys(TKey keys)
        {
            return GetAll().Where(p => p.Key.Equals(keys));
        }

        public IEnumerable<IProperty<TImpl, TKey, TValue>> GetAll()
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

        public IEnumerable<TImpl> GetChildren(uint maxDepth = 0)
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

        public IEnumerable<TImpl> GetParents()
        {
            var parents = new List<TImpl>();

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

        public void InitNode(string nodeName, ITree<TImpl, TKey, TValue> tree)
        {
            _tree = tree;
            Name = nodeName;
        }

        public void InitNode(String name, Tree<TImpl, TKey, TValue> tree, IDictionary<TKey, TValue> props = null, IEnumerable<TImpl> children = null)
        {
            _tree = tree;
            Name = name;

            if (props != null)
                foreach (var kv in props)
                {
                    _props.Add(new Property<TImpl, TKey, TValue>((TImpl)this, kv.Key, kv.Value));
#pragma warning disable RECS0021
                    UpdateIOverridingProperty(kv.Key);
#pragma warning restore RECS0021
                }

            if (children != null)
                foreach (var child in children)
                    this.AddChild(child);
        }

        public void InitNode(RawNode<TImpl, TKey, TValue> rawNode, Tree<TImpl, TKey, TValue> tree)
        {
            _tree = tree;
            Name = rawNode.Name;

            foreach (var kv in rawNode.Propertys)
            {
                _props.Add(new Property<TImpl, TKey, TValue>((TImpl)this, kv.Key, kv.Value));
#pragma warning disable RECS0021
                UpdateIOverridingProperty(kv.Key);
#pragma warning restore RECS0021
            }

            foreach (var child in rawNode.Children)
            {
                var node = Activator.CreateInstance<TImpl>();
                node.InitNode(child, tree);
                this.AddChild(node);
            }
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
                Parent.RemoveChild((TImpl)this);
            }
            Parent = null;
        }

        public bool Set(TKey key, TValue value)
        {
            var old = Get(key);

            _props.RemoveAll(p => p.Key.Equals(key));

            var prop = new Property<TImpl, TKey, TValue>((TImpl)this, key, value);

            _props.Add(prop);

            RaisePropertyChanged(new PropertyChangedEventArgs<TImpl, TKey, TValue>(prop, old));

            return !old.Equals(value);
        }

        public void SetParent(TImpl parent)
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

        public TImpl GetChild(string name)
        {
            return _children.FirstOrDefault(c => c.Name == name);
        }

        public TImpl CreateChild(string name)
        {
            var node = _tree.CreateNode(name);

            AddChild(node);

            return node;
        }

        public bool RemoveChild(TImpl child)
        {
            if (_children.Remove(child))
            {
                RaiseChildrenChanged(new ChildrenChangedEventArgs<TImpl, TKey, TValue>(child, ChildrenChangeAction.Removed));
                return true;
            }
            return false;
        }

        public TImpl FindNode(string path)
        {
            
            return FindNode(path.Split(new []{ Tree.Separator }, StringSplitOptions.None));
        }

        public TImpl FindNode(IEnumerable<string> path)
        {
            if (path.Count() == 0)
                return (TImpl)this;

            return GetChild(path.ElementAt(0))?.FindNode(path.Skip(1)) ?? null;
        }

        protected void RaisePropertyChanged(PropertyChangedEventArgs<TImpl, TKey, TValue> args)
        {
            if(args.Mode != PropertyChangedEventArgs<TImpl, TKey, TValue>.PropertyChangedMode.Removed)
                UpdateIOverridingProperty(args.Property.Key, false);
            PropertyChanged?.Invoke((TImpl)this, args);
        }

        protected void RaiseChildrenChanged(ChildrenChangedEventArgs<TImpl, TKey, TValue> args)
        {
            args.Child.UpdateOverrides();
            ChildrenChanged?.Invoke((TImpl)this, args);
        }

        protected virtual void UpdateIOverridingProperty(TKey key, bool raisePropertyChangedEvent = true)
        {
            var thisProp = _props.FirstOrDefault(p => p.Key.Equals(key));

            if (thisProp is null)
                return;

            if (!(thisProp.Value is IOverridingProperty<TImpl, TKey, TValue>))
                return;

            IProperty<TImpl, TKey, TValue> lastProp = null;

            try
            {
                lastProp = CollectPropertys(key).Reverse().Skip(1).First();
            }
            catch (Exception ex) { }

            //if (lastProp is null)
            //    return;

            (thisProp.Value as IOverridingProperty<TImpl, TKey, TValue>).OnOverridesProperty(lastProp);

            if(raisePropertyChangedEvent)
                RaisePropertyChanged(new PropertyChangedEventArgs<TImpl, TKey, TValue>(thisProp, thisProp.Value));
        }

        private void Parent_PropertyChanged(TImpl sender, PropertyChangedEventArgs<TImpl, TKey, TValue> e)
        {
            if (!this.Defines(e.Property.Key))
                RaisePropertyChanged(e);
            else
                UpdateIOverridingProperty(e.Property.Key);
        }

        public RawNode<TImpl, TKey, TValue> ToRawNode()
        {
            var props = new Dictionary<TKey, TValue>();
            foreach (var prop in this._props)
                props[prop.Key] = prop.Value;
            return new RawNode<TImpl, TKey, TValue>()
            {
                Name = this.Name,
                Propertys = props,
                Children = _children.Select(c => (c as TImpl).ToRawNode()).ToArray()
            };
        }

        public void Update<TArgs>(TKey key, TArgs args)
        {
            var updateQueue = new Queue<TImpl>();
            updateQueue.Enqueue((TImpl)this);

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
