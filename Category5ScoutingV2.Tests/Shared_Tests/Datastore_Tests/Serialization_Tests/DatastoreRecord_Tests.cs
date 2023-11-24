using Category5ScoutingV2.Shared.Datastore.Serialization;

namespace Category5ScoutingV2.Tests.Shared_Tests.Datastore_Tests.Serialization_Tests;

[TestClass]
public class DatastoreRecord_Tests
{
    [TestMethod]
    public void FromAndToJson()
    {
        //var datastore = Datastore.FromJson();
        //datastore.Write(DatastoreKey.Untyped("abc"), "Hello, Jerry!");
        //datastore.Write(DatastoreKey.Untyped("def"), "Hello, Bobby!");
        //var json = datastore.ToJson();

        const string Json = "{\"SerializedKvps\":[{\"Key\":\"abc\",\"ValueTypeName\":\"System.String, System.Private.CoreLib\",\"ValueJson\":\"\\u0022Hello, Jerry!\\u0022\"},{\"Key\":\"def\",\"ValueTypeName\":\"System.String, System.Private.CoreLib\",\"ValueJson\":\"\\u0022Hello, Bobby!\\u0022\"}]}";
        var record = DatastoreRecord.FromJson(Json);
        Assert.AreEqual(2, record.SerializedKvps.Count);
        Assert.AreEqual(Json, record.ToJson());
    }
}