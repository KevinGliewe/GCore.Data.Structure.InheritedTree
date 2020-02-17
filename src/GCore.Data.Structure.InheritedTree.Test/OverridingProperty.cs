using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace GCore.Data.Structure.InheritedTree.Test
{
    [TestFixture]
    public class OverridingPropertyTest
    {
        Tree<String, object> tree;

        [SetUp]
        public void Setup()
        {
            tree = new Tree<string, object>("Test");
            tree.Root.AddChildren(
                new[]
                {
                    tree.CreateNode("N1",
                        new Dictionary<string, object>(){
                            {"propN1_1", 11 },
                            {"propN1_2", 12 },
                            {"override", 1 },
                            {"changing", 0 },
                        },
                        tree.CreateNode("N11",
                            new Dictionary<string, object>(){
                                {"propN2_1", 21 },
                                {"propN2_2", 22 },
                                {"override", 2 },
                            }
                        )
                    )
                }
            );
        }
    }

    class OverridingProperty: IOverridingProperty<String, object>
    {
        int _overrides = 0;

        public int Overrides => _overrides;

        public void OnOverridesProperty(IProperty<String, object> property)
        {
            _overrides = (property.Value as OverridingProperty)?._overrides ?? 0 + 1;
        }
    }
}
