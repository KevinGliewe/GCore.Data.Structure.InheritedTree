using System.Linq;
using NUnit.Framework;

namespace GCore.Data.Structure.InheritedTree.Test;

public class INotifyChildrenChangedTests
{
    Tree CreateTree()
    {
        var tree = new Tree();
        var c1 = tree.Root.CreateChild("C1");
        var c2 = c1.CreateChild("C2");
        var c3 = c2.CreateChild("C3");

        return tree;
    }

    [Test]
    public void Node_ChildrenChanged_RaisesEvent()
    {
        var tree = CreateTree();
        var node = tree.Root;
        var raised = false;
        node.ChildrenChanged += (sender, e) => raised = true;
        node.CreateChild("C4");
        Assert.IsTrue(raised);
    }

    [Test]
    public void Child_ChildrenChanged_RaisesEvent()
    {
        var tree = CreateTree();
        var node = tree.Root;
        var raised = false;
        node.ChildrenChanged += (sender, e) => raised = true;
        node.Children.First().CreateChild("C4");
        Assert.IsFalse(raised);
    }    
}
