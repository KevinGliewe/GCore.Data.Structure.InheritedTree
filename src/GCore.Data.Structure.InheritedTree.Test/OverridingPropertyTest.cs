using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace GCore.Data.Structure.InheritedTree.Test
{
    class StringObjectNode : Node<StringObjectTree, StringObjectNode, String, object> { }
    class StringObjectTree : Tree<StringObjectTree, StringObjectNode, String, object> { }

    [TestFixture]
    public class OverridingPropertyTest
    {
        StringObjectTree tree;

        [SetUp]
        public void Setup()
        {
            tree = new StringObjectTree();
            tree.Root.AddChildren(
                new[]
                {
                    tree.CreateNode<StringObjectNode>("N1",
                        new Dictionary<string, object>(){
                            {"override", null },
                        },
                        tree.CreateNode<StringObjectNode>("N11",
                            new Dictionary<string, object>(){
                                {"override", new OverridingProperty() },
                            },
                            tree.CreateNode<StringObjectNode>("N111",
                                new Dictionary<string, object>(){
                                    {"override", new OverridingProperty() },
                                }
                            )
                        )
                    )
                }
            );
        }

        [Test]
        public void RemovedOverride()
        {
            tree.UpdateOverrides();
            tree.FindNode("root:N1:N11").ResetDefinition("override");
            Assert.AreEqual(0, (tree.FindNode("root:N1:N11:N111").Get("override") as OverridingProperty)?.Overrides);
        }
    }

    class OverridingProperty: IOverridingProperty<StringObjectNode, String, object>
    {
        int _overrides = 0;

        public int Overrides => _overrides;

        public void OnOverridesProperty(IProperty<StringObjectNode, String, object> property)
        {
            if (property is null)
            {
                _overrides = 0;
                return;
            }
            _overrides = ((property.Value as OverridingProperty)?._overrides ?? 0) + 1;
        }
    }
}
