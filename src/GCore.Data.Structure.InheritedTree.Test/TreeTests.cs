using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GCore.Data.Structure.InheritedTree;
using Newtonsoft.Json;

namespace GCore.Data.Structure.InheritedTree.Test
{

    class StringIntNode : Node<StringIntTree, StringIntNode, string, int> { }

    class StringIntTree : Tree<StringIntTree, StringIntNode, string, int>
    {
        public StringIntTree() : base() { }
        public StringIntTree(StringIntNode root, string rootName) : base(root, rootName) { }
        public StringIntTree(RawNode<StringIntNode, string, int> rawNode) : base(rawNode) {}
    }

    [TestFixture]
    public class TreeTests
    {
        StringIntTree tree;

        [SetUp]
        public void Setup()
        {
            tree = new StringIntTree(new StringIntNode(), "root");
            tree.Root.AddChildren(
                new[]
                {
                    tree.CreateNode<StringIntNode>("N1",
                        new Dictionary<string, int>(){
                            {"propN1_1", 11 },
                            {"propN1_2", 12 },
                            {"override", 1 },
                            {"changing", 0 },
                        },
                        tree.CreateNode<StringIntNode>("N11",
                            new Dictionary<string, int>(){
                                {"propN2_1", 21 },
                                {"propN2_2", 22 },
                                {"override", 2 },
                            }
                        )
                    )
                }
            );
        }

        [Test]
        public void DefinesFalse()
        {
            Assert.False(tree.FindNode("root:N1:N11").Defines("propN1_1"));
            Assert.False(tree.FindNode("root:N1:N11").Defines("propN1_2"));
            Assert.False(tree.FindNode("root:N1").Defines("propN2_1"));
            Assert.False(tree.FindNode("root:N1").Defines("propN2_2"));
            Assert.AreEqual(11, tree.FindNode("root:N1:N11").Get("propN1_1"));
        }

        [Test]
        public void DefinesTrue()
        {
            Assert.True(tree.FindNode("root:N1").Defines("propN1_1"));
            Assert.True(tree.FindNode("root:N1").Defines("propN1_2"));
            Assert.True(tree.FindNode("root:N1").Defines("override"));
            Assert.True(tree.FindNode("root:N1:N11").Defines("propN2_1"));
            Assert.True(tree.FindNode("root:N1:N11").Defines("propN2_2"));
            Assert.True(tree.FindNode("root:N1:N11").Defines("override"));
            Assert.AreEqual(11, tree.FindNode("root:N1").Get("propN1_1"));
        }

        [Test]
        public void Defines()
        {
            Assert.AreEqual(11, tree.FindNode("root:N1").Get("propN1_1"));
            Assert.AreEqual(12, tree.FindNode("root:N1").Get("propN1_2"));
        }

        [Test]
        public void Inherits()
        {
            Assert.AreEqual(11, tree.FindNode("root:N1:N11").Get("propN1_1"));
            Assert.AreEqual(12, tree.FindNode("root:N1:N11").Get("propN1_2"));
            Assert.True(tree.FindNode("root:N1:N11").IsInherted("propN1_1"));
            Assert.True(tree.FindNode("root:N1:N11").IsInherted("propN1_2"));
        }

        [Test]
        public void Depth()
        {
            Assert.AreEqual(1, tree.FindNode("root:N1").Depth);
            Assert.AreEqual(2, tree.FindNode("root:N1:N11").Depth);
        }

        [Test]
        public void Override()
        {
            Assert.AreEqual(1, tree.FindNode("root:N1").Get("override"));
            Assert.AreEqual(2, tree.FindNode("root:N1:N11").Get("override"));
        }

        [Test]
        public void Changing()
        {
            Assert.AreEqual(0, tree.FindNode("root:N1").Get("changing"));
            Assert.AreEqual(0, tree.FindNode("root:N1:N11").Get("changing"));

            tree.FindNode("root:N1")["changing"] = 1;

            Assert.AreEqual(1, tree.FindNode("root:N1").Get("changing"));
            Assert.AreEqual(1, tree.FindNode("root:N1:N11").Get("changing"));

        }

        [Test]
        public void PropertyChangedEvent()
        {
            PropertyChangedEventArgs<StringIntNode, String, int> e1 = null;
            PropertyChangedEventArgs<StringIntNode, String, int> e2 = null;

            tree.FindNode("root:N1")["changing"] = 1;

            tree.FindNode("root:N1").PropertyChanged += (s, e) => e1 = e;
            tree.FindNode("root:N1:N11").PropertyChanged += (s, e) => e2 = e;

            tree.FindNode("root:N1")["changing"] = 2;

            Assert.AreEqual(e1, e2);
            Assert.AreEqual(1, e1.OldValue);
            Assert.AreEqual(2, e2.Property.Value);
            Assert.AreEqual("changing", e2.Property.Key);
            Assert.AreEqual(tree.FindNode("root:N1"), e2.Property.DefinedNode);
        }

        [Test]
        public void ChildrenChangedEvent()
        {
            ChildrenChangedEventArgs<StringIntNode> e1 = null;

            int count = tree.Root.GetChildren(int.MaxValue).Count();

            tree.FindNode("root:N1:N11").ChildrenChanged += (s, e) => e1 = e;
            var node = tree.FindNode("root:N1:N11").CreateChild<StringIntNode>("N111");

            Assert.AreEqual("N111", e1.Child.Name);
            Assert.AreEqual("root:N1:N11:N111", e1.Child.Path);
            Assert.AreEqual(ChildrenChangeAction.Added, e1.Action);
            Assert.AreEqual(count + 1, tree.Root.GetChildren(int.MaxValue).Count());

            tree.FindNode("root:N1:N11").RemoveChild(node);

            Assert.AreEqual(ChildrenChangeAction.Removed, e1.Action);
            Assert.AreEqual(count, tree.Root.GetChildren(int.MaxValue).Count());
        }

        [Test]
        public void Serialization()
        {
            var raw = tree.ToRawNodes();

            var jsonSerializerSettings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(raw, jsonSerializerSettings);

            raw = Newtonsoft.Json.JsonConvert.DeserializeObject<RawNode<StringIntNode, String, int>>(json);

            tree = new StringIntTree(raw);

            this.Defines();
            this.DefinesFalse();
            this.DefinesTrue();
        }
    }
}
