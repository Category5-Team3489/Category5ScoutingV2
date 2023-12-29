using Category5ScoutingV2.Shared.Datastore;

namespace Category5ScoutingV2.Tests.Shared_.Datastore_;

[TestClass]
public class DatastoreKey_Tests
{
    [TestMethod]
    public void ThrowsWasNeverInit()
    {
        Assert.ThrowsException<NullReferenceException>(() =>
        {
            DatastoreKey key = default;
            _ = key.Key;
        });
    }

    [TestMethod]
    public void ThrowsZeroArgs()
    {
        Assert.ThrowsException<ArgumentException>(() =>
        {
            _ = DatastoreKey.Untyped([]);
        });
    }

    [TestMethod]
    [DataRow("llll lllll")]
    [DataRow("-----=-----")]
    [DataRow(" -=3210d-as-0dsa=")]
    public void ThrowsBadCharsSingle(string key)
    {
        Assert.ThrowsException<ArgumentException>(() =>
        {
            _ = DatastoreKey.Untyped(key);
        });
    }

    [TestMethod]
    [DataRow("llll lllll", "llll lllll", "llll lllll")]
    [DataRow("-----=-----", "-----=-----", "-----=-----")]
    [DataRow(" -=3210d-as-0dsa=", " -=3210d-as-0dsa=", " -=3210d-as-0dsa=")]
    public void ThrowsBadCharsMultiple(params string[] args)
    {
        Assert.ThrowsException<ArgumentException>(() =>
        {
            _ = DatastoreKey.Untyped(args);
        });
    }

    [TestMethod]
    public void ThrowsContiguousSlashesSingle()
    {
        Assert.ThrowsException<ArgumentException>(() =>
        {
            _ = DatastoreKey.Untyped("231321//321//213123");
        });
    }

    [TestMethod]
    public void ThrowsContiguousSlashesMultiple()
    {
        Assert.ThrowsException<ArgumentException>(() =>
        {
            _ = DatastoreKey.Untyped("231321/", "312321321");
        });
    }

    [TestMethod]
    public void EmptySingle()
    {
        Assert.ThrowsException<ArgumentException>(() =>
        {
            _ = DatastoreKey.Untyped("");
        });
    }

    [TestMethod]
    public void EmptyMultiple()
    {
        Assert.ThrowsException<ArgumentException>(() =>
        {
            _ = DatastoreKey.Untyped("dasdassadsa", "dsadsadas", "dsadsadas", "");
        });
    }

    [TestMethod]
    public void ValidSingle()
    {
        Assert.AreEqual("312321-3_21", DatastoreKey.Untyped("312321-3_21").Key);
    }

    [TestMethod]
    public void ValidMultiple()
    {
        Assert.AreEqual("312321321/dasdasda_ss-a", DatastoreKey.Untyped("312321321", "dasdasda_ss-a").Key);
    }
}