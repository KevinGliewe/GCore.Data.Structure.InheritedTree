using System.Collections.Generic;
using NUnit.Framework;

namespace GCore.Data.Structure.InheritedTree.Test;

[TestFixture]
public class NonGenericTreeTests
{
    private Tree tree;

    [SetUp]
    public void Setup()
    {
        tree = new Tree();
        tree.Root.AddChildren(
            new[]
            {
                tree.CreateNode("N1",
                    new Dictionary<string, object>() { { "override", null }, },
                    tree.CreateNode("N11",
                        new Dictionary<string, object>() { { "override", 1 }, },
                        tree.CreateNode("N111",
                            new Dictionary<string, object>() { { "override", 2 }, }
                        ),
                        tree.CreateNode("N112")
                    )
                )
            }
        );
        tree.UpdateOverrides();
    }

    [Test]
    public void Overrides()
    {
        Assert.AreEqual(1, (tree.FindNode("root:N1:N11").Get("override")));
        Assert.AreEqual(2, (tree.FindNode("root:N1:N11:N111").Get("override")));
        Assert.AreEqual(1, (tree.FindNode("root:N1:N11:N112").Get("override")));
    }
}
