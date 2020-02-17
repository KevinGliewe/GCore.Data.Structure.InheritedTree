﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GCore.Data.Structure.InheritedTree.Test
{
    [TestFixture]
    public class UpdatablePropertyTest
    {
        Tree<String, UpdatableProperty> tree;

        public static int LastUpdate = -1;

        [SetUp]
        public void Setup()
        {
            tree = new Tree<string, UpdatableProperty>("Test");
            tree.Root.AddChildren(
                new[]
                {
                    tree.CreateNode("N1",
                        new Dictionary<string, UpdatableProperty>(){
                            {"propN1_1", 11 },
                            {"propN1_2", 12 },
                            {"override", 1 },
                            {"changing", 0 },
                        },
                        tree.CreateNode("N11",
                            new Dictionary<string, UpdatableProperty>(){
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
        public void Update()
        {
            LastUpdate = 0;

            tree.Update("override", 1000);


            Assert.AreEqual(1001, tree.FindNode("Test:N1").Get("override").Value);
            Assert.AreEqual(1002, tree.FindNode("Test:N1:N11").Get("override").Value);
            Assert.AreEqual(1002, LastUpdate);

        }
    }

    public class UpdatableProperty : IUpdatableProperty<int>
    {
        public int Value = 0;

        public void Update(int args)
        {
            Value += args;
            UpdatablePropertyTest.LastUpdate = Value;
        }

        public static implicit operator UpdatableProperty(int v) => new UpdatableProperty() { Value = v};
    }
}
