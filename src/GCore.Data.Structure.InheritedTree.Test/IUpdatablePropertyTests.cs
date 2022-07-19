using NUnit.Framework;

namespace GCore.Data.Structure.InheritedTree.Test;

public class IUpdatablePropertyTests
{
    [Test]
    public void Property_Update_Test()
    {
        var tree = new Tree();
        var c1 = tree.CreateNode("C1");
        var c11 = c1.CreateChild("C2");
        var c12 = c1.CreateChild("C2");

        var p11 = new UpdatableProperty();
        c11["Key"] = p11;
        c11["OtherKey"] = p11;
        var p12 = new UpdatableProperty();
        c12["Key"] = p12;
        

        c1.Update("Key",40);
        c11.Update("Key",2);

        Assert.AreEqual(42, p11.Value);
        Assert.AreEqual(40, p12.Value);
    }

    public class UpdateableProperty : IUpdatableProperty<int>
    {
        public int Value { get; set; } = 0;
        public void Update(int args)
        {
            Value += args;
        }
    }
}
