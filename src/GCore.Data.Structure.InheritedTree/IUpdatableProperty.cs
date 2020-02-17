using System;
using System.Collections.Generic;
using System.Text;

namespace GCore.Data.Structure.InheritedTree
{
    public interface IUpdatableProperty<TArgs>
    {
        void Update(TArgs args);
    }
}
