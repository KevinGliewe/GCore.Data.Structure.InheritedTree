using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace GCore.Data.Structure.InheritedTree.Test;

public class BasicTreeNodeTests
{
    [Test]
    public void CreateTree()
    {
        var tree = new Tree();
        Assert.IsNotNull(tree);
    }

    [Test]
    public void CreateNode()
    {
        var node = new Node();
        Assert.IsNotNull(node);
    }

    [Test]
    public void CreateTreeNode()
    {
        var tree = new Tree();
        var node = tree.Root.CreateChild("Child");

        Assert.IsNotNull(node);
        Assert.AreEqual(tree        , node.Tree);
        Assert.AreEqual(tree.Root   , node.Parent);
        Assert.AreEqual("Child"     , node.Name);
        Assert.AreEqual(0           , node.Children.Count());
        Assert.AreEqual(0           , node.Properties.Count());
        Assert.AreEqual("root:Child", node.Path);
        Assert.AreEqual(1           , node.Depth);
    }

    [Test]
    public void CreateTreeNodeWithProperties()
    {
        var tree = new Tree();
        var node = tree.Root.CreateChild("Child", new Dictionary<string, object> { { "Key", "Value" } });

        Assert.IsNotNull(node);
        Assert.AreEqual(tree        , node.Tree);
        Assert.AreEqual(tree.Root   , node.Parent);
        Assert.AreEqual("Child"     , node.Name);
        Assert.AreEqual(0           , node.Children.Count());
        Assert.AreEqual(1           , node.Properties.Count());
        Assert.AreEqual("Value"     , node["Key"]);
        Assert.AreEqual("root:Child", node.Path);
        Assert.AreEqual(1           , node.Depth);
    }

    [Test]
    public void CreateTreeNodeWithChilds()
    {
        var tree = new Tree();
        var node = tree.Root.CreateChild("Child1", null, tree.CreateNode("Child2"));

        Assert.IsNotNull(node);
        Assert.AreEqual(tree                , node.Tree);
        Assert.AreEqual(tree.Root           , node.Parent);
        Assert.AreEqual("Child1"            , node.Name);
        Assert.AreEqual(1                   , node.Children.Count());
        Assert.AreEqual(0                   , node.Properties.Count());
        Assert.AreEqual("root:Child1"       , node.Path);
        Assert.AreEqual(1                   , node.Depth);
        Assert.AreEqual("Child2"            , node.Children.First().Name);
        Assert.AreEqual("root:Child1:Child2", node.Children.First().Path);
    }
    
    [Test]
    public void CreateTreeNodeWithChildrenAndProperties()
    {
        var tree = new Tree();
        var node = tree.Root.CreateChild("Child1", new Dictionary<string, object> { { "Key", "Value1" } });
        var child = node.CreateChild("Child2", new Dictionary<string, object> { { "Key", "Value2" } });

        Assert.IsNotNull(node);
        Assert.AreEqual(tree                , node.Tree);
        Assert.AreEqual(tree.Root           , node.Parent);
        Assert.AreEqual("Child1"            , node.Name);
        Assert.AreEqual(1                   , node.Children.Count());
        Assert.AreEqual(1                   , node.Properties.Count());
        Assert.AreEqual("Value1"            , node["Key"]);
        Assert.AreEqual("root:Child1"       , node.Path);
        Assert.AreEqual(1                   , node.Depth);
        Assert.AreEqual("Child2"            , node.Children.First().Name);
        Assert.AreEqual("root:Child1:Child2", node.Children.First().Path);
        Assert.True(node.Defines("Key"));

        Assert.IsNotNull(child);
        Assert.AreEqual(tree                , child.Tree);
        Assert.AreEqual(node                , child.Parent);
        Assert.AreEqual("Child2"            , child.Name);
        Assert.AreEqual(0                   , child.Children.Count());
        Assert.AreEqual(1                   , child.Properties.Count());
        Assert.AreEqual("Value2"            , child["Key"]);
        Assert.AreEqual("root:Child1:Child2", child.Path);
        Assert.AreEqual(2                   , child.Depth);
        Assert.True(child.Defines("Key"));

        Assert.AreEqual(child, tree.FindNode("root:Child1:Child2"));
        
    }

    [Test]
    public void CreateTreeNodeWithChildrenAndInheritedProperties()
    {
        var tree = new Tree();
        var node = tree.Root.CreateChild("Child1", new Dictionary<string, object> { { "Key", "Value1" } });
        var child = node.CreateChild("Child2");

        Assert.IsNotNull(node);
        Assert.AreEqual(tree                , node.Tree);
        Assert.AreEqual(tree.Root           , node.Parent);
        Assert.AreEqual("Child1"            , node.Name);
        Assert.AreEqual(1                   , node.Children.Count());
        Assert.AreEqual(1                   , node.Properties.Count());
        Assert.AreEqual("Value1"            , node["Key"]);
        Assert.AreEqual("root:Child1"       , node.Path);
        Assert.AreEqual(1                   , node.Depth);
        Assert.AreEqual("Child2"            , node.Children.First().Name);
        Assert.AreEqual("root:Child1:Child2", node.Children.First().Path);
        Assert.True(node.Defines("Key"));

        Assert.IsNotNull(child);
        Assert.AreEqual(tree                , child.Tree);
        Assert.AreEqual(node                , child.Parent);
        Assert.AreEqual("Child2"            , child.Name);
        Assert.AreEqual(0                   , child.Children.Count());
        Assert.AreEqual(1                   , child.Properties.Count());
        Assert.AreEqual("Value1"            , child["Key"]);
        Assert.AreEqual("root:Child1:Child2", child.Path);
        Assert.AreEqual(2                   , child.Depth);
        Assert.False(child.Defines("Key"));
        
    }

    [Test]
    public void ResetDefinition()
    {
        var tree = new Tree();
        var node = tree.Root.CreateChild("Child1", new Dictionary<string, object> { { "Key", "Value1" } });
        var child = node.CreateChild("Child2", new Dictionary<string, object> { { "Key", "Value2" } });

        Assert.AreEqual(1       , node.Properties.Count());
        Assert.AreEqual("Value1", node["Key"]);
        Assert.True(node.Defines("Key"));

        Assert.AreEqual(1       , child.Properties.Count());
        Assert.AreEqual("Value2", child["Key"]);
        Assert.True(child.Defines("Key"));

        child.ResetDefinition("Key");

        Assert.AreEqual(1       , child.Properties.Count());
        Assert.AreEqual("Value1", child["Key"]);
        Assert.False(child.Defines("Key"));
    }
}
