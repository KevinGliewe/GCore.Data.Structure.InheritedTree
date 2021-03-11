using System;
using System.Collections.Generic;
using System.Text;

namespace GCore.Data.Structure.InheritedTree
{
    public class RawNode<TNode, TKey, TValue>
    {
        public String Name { get; set; }
        public RawNode<TNode, TKey, TValue>[] Children { get; set; }
        public Dictionary<TKey, TValue> Propertys { get; set; }
    }
}
