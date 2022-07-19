using System;
using NUnit.Framework;

namespace GCore.Data.Structure.InheritedTree.Test;

public class IOverridingPropertyTests
{
    Tree CreateTree()
    {
        var tree = new Tree();
        var c1 = tree.Root.CreateChild("C1");
        var c2 = c1.CreateChild("C2");
        var c3 = c2.CreateChild("C3");

        c1["Key"] = new OverridingProperty();
        c2["Key"] = new OverridingProperty();
        c3["Key"] = new OverridingProperty();

        return tree;
    }

    [Test]
    public void IOverridingProperty_Homogen()
    {
        var tree = CreateTree();

        Assert.AreEqual(2, (tree.FindNode("root:C1:C2:C3")["Key"] as OverridingProperty).Overrides);
    }

    [Test]
    public void IOverridingProperty_Mix()
    {
        var tree = CreateTree();

        tree.FindNode("root:C1:C2")["Key"] = 42;

        Assert.AreEqual(43, (tree.FindNode("root:C1:C2:C3")["Key"] as OverridingProperty).Overrides);
    }

    [Test]
    public void IOverridingProperty_Remove()
    {
        var tree = CreateTree();

        tree.FindNode("root:C1:C2").ResetDefinition("Key");

        Assert.AreEqual(1, (tree.FindNode("root:C1:C2:C3")["Key"] as OverridingProperty).Overrides);
    }



    class OverridingProperty : IOverridingProperty<Node, String, object>
    {
        int _overrides = 0;

        public int Overrides => _overrides;

        public void OnOverridesProperty(IProperty<Node, String, object> property)
        {
            if (property is null)
            {
                _overrides = 0;
                return;
            }

            if (property.Value is OverridingProperty op)
            {
                _overrides = op.Overrides + 1;
            }
            else if (property.Value is int i)
            {
                _overrides = i + 1;
            }
            else
                _overrides = 0;

        }
    }
}
