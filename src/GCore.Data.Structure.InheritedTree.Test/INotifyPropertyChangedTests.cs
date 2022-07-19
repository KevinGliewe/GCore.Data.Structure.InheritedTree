using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using NUnit.Framework;

namespace GCore.Data.Structure.InheritedTree.Test;

public class INotifyPropertyChangedTests
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
    public void Node_PropertyChanged_RaisesEvent()
    {
        var tree = CreateTree();
        var node = tree.Root;
        var raised = false;
        node.PropertyChanged += (sender, e) => raised = true;
        node["Key"] = 1;
        Assert.IsTrue(raised);
    }

    [Test]
    public void Parent_PropertyChanged_RaisesEvent()
    {
        var tree = CreateTree();
        var node = tree.Root;
        var raised = false;
        node.Children.First().PropertyChanged += (sender, e) => raised = true;
        node["Key"] = 1;
        Assert.IsTrue(raised);
    }

}
