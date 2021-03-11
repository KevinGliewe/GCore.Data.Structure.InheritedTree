using System;
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

        public event PropertyChangedEventHandler<TNode, TKey, TValue> PropertyChanged;
        public event ChildrenChangedEventHandler<TNode, TKey, TValue> ChildrenChanged;

        public TValue this[TKey key] { get => Get(key); set => Set(key, value); }

        public string Name { get; protected set; }

        public string Path => String.Join(Tree.Separator, this.GetParents().Select(p => p.Name)) + Tree.Separator + Name;

        public uint Depth => (uint)this.GetParents().Count();

        public TNode Parent { get; protected set; }

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

        public TTree Tree => _tree;

        public IEnumerable<IProperty<TNode, TKey, TValue>> SelfPropertys => _props;

        public IEnumerable<TNode> Children => _children;

        public Node()
        {
        }

        public void AddChild(TNode child)
        {
            if (_children.Contains(child))
                return;
            _children.Add(child);
            child.SetParent((TNode)this);

            RaiseChildrenChanged(new ChildrenChangedEventArgs<TNode, TKey, TValue>(child, ChildrenChangeAction.Added));
        }

        public void AddChildren(IEnumerable<TNode> child)
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
                new PropertyChangedEventArgs<TNode, TKey, TValue>(
                    new Property<TNode, TKey, TValue>((TNode)this, prop.Key, default(TValue)),
                    prop.Value,
                    PropertyChangedEventArgs<TNode, TKey, TValue>.PropertyChangedMode.Removed));

            return true;
        }

        public IEnumerable<IProperty<TNode, TKey, TValue>> CollectPropertys(TKey keys)
        {
            return GetAll().Where(p => p.Key.Equals(keys));
        }

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

        public bool Has(TKey key)
        {
            if (_props.FirstOrDefault(p => p.Key.Equals(key)) != null)
                return true;

            return Parent?.Has(key) ?? false;
        }

        public void InitNode(string nodeName, TTree tree)
        {
            _tree = tree;
            Name = nodeName;
        }

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
                var node = Activator.CreateInstance<TNode>();
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
                Parent.RemoveChild((TNode)this);
            }
            Parent = null;
        }

        public bool Set(TKey key, TValue value)
        {
            var old = Get(key);

            _props.RemoveAll(p => p.Key.Equals(key));

            var prop = new Property<TNode, TKey, TValue>((TNode)this, key, value);

            _props.Add(prop);

            RaisePropertyChanged(new PropertyChangedEventArgs<TNode, TKey, TValue>(prop, old));

            return !old.Equals(value);
        }

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

        public TNode GetChild(string name)
        {
            return _children.FirstOrDefault(c => c.Name == name);
        }

        public TNode CreateChild(string name)
        {
            var node = _tree.CreateNode(name);

            AddChild(node);

            return node;
        }

        public bool RemoveChild(TNode child)
        {
            if (_children.Remove(child))
            {
                RaiseChildrenChanged(new ChildrenChangedEventArgs<TNode, TKey, TValue>(child, ChildrenChangeAction.Removed));
                return true;
            }
            return false;
        }

        public TNode FindNode(string path)
        {
            
            return FindNode(path.Split(new []{ Tree.Separator }, StringSplitOptions.None));
        }

        public TNode FindNode(IEnumerable<string> path)
        {
            if (path.Count() == 0)
                return (TNode)this;

            return GetChild(path.ElementAt(0))?.FindNode(path.Skip(1)) ?? null;
        }

        protected void RaisePropertyChanged(PropertyChangedEventArgs<TNode, TKey, TValue> args)
        {
            if(args.Mode != PropertyChangedEventArgs<TNode, TKey, TValue>.PropertyChangedMode.Removed)
                UpdateIOverridingProperty(args.Property.Key, false);
            PropertyChanged?.Invoke((TNode)this, args);
        }

        protected void RaiseChildrenChanged(ChildrenChangedEventArgs<TNode, TKey, TValue> args)
        {
            args.Child.UpdateOverrides();
            ChildrenChanged?.Invoke((TNode)this, args);
        }

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

        public RawNode<TNode, TKey, TValue> ToRawNode()
        {
            var props = new Dictionary<TKey, TValue>();
            foreach (var prop in this._props)
                props[prop.Key] = prop.Value;
            return new RawNode<TNode, TKey, TValue>()
            {
                Name = this.Name,
                Propertys = props,
                Children = _children.Select(c => (c as TNode).ToRawNode()).ToArray()
            };
        }

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

        public void UpdateOverrides()
        {
            foreach (var key in _props.Select(p => p.Key))
                UpdateIOverridingProperty(key, false);
            foreach (var child in _children)
                child.UpdateOverrides();
        }

    }
}
