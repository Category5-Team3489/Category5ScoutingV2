using Category5ScoutingV2.Shared.Datastore;

namespace Category5ScoutingV2.Tests.Shared_Tests.Datastore_Tests;

[TestClass]
public class TypedJsonCell_Tests
{
    [TestMethod]
    public void WriteNullableNull_ReadNormalNull()
    {
        uint? value = null;
        TypedJsonCell cell = TypedJsonCell.FromValue(value);
        (Type type, string json) = cell;
        Assert.AreEqual(typeof(uint), type);
        Assert.AreEqual("null", json);

        {
            var v = cell.Read<uint?>(DatastoreKey.Untyped("dsadsdsa"));
            Assert.IsNull(v);
        }
    }

    [TestMethod]
    public void WriteNormalNull_ReadNormalNull()
    {
        Random? value = null;
        TypedJsonCell cell = TypedJsonCell.FromValue(value);
        (Type type, string json) = cell;
        Assert.AreEqual(typeof(Random), type);
        Assert.AreEqual("null", json);

        {
            var v = cell.Read<Random?>(DatastoreKey.Untyped("dsadsdsa"));
            Assert.IsNull(v);
        }
    }
}
