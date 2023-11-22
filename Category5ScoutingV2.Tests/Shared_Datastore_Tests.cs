using Category5ScoutingV2.Shared;

namespace Category5ScoutingV2.Tests;

[TestClass]
public class Shared_Datastore_Tests
{
    [TestMethod]
    public void A()
    {
        Datastore datastore = new();

        {
            bool success = datastore.TryRead("abc", out bool? value, out var error);
            Assert.IsFalse(success);
            Assert.IsNull(value);
            Assert.AreEqual(Datastore.ReadError.DNE, error);
        }
    }

    [TestMethod]
    public void KeyEmpty_ArgumentException()
    {
        Datastore datastore = new();

        Assert.ThrowsException<ArgumentException>(() =>
        {
            datastore.TryRead<string>("", out _, out _);
        });

        //Assert.ThrowsException<ArgumentException>(() =>
        //{
        //    datastore.TryWrite<string>("", out _, out _);
        //});
    }
}