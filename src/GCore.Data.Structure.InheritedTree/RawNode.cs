using System;
using System.Collections.Generic;
using System.Text;

namespace GCore.Data.Structure.InheritedTree
{
    public class RawNode<TKey,TValue>
    {
        public String Name { get; set; }
        public RawNode<TKey, TValue>[] Children { get; set; }
        public Dictionary<TKey, TValue> Propertys { get; set; }
    }
}
