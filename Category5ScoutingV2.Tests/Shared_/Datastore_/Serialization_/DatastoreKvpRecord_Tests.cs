﻿using Category5ScoutingV2.Shared.Datastore.Serialization;
using Category5ScoutingV2.Shared.Datastore.Utils;

namespace Category5ScoutingV2.Tests.Shared_.Datastore_.Serialization_;

[TestClass]
public class DatastoreKvpRecord_
{
    [TestMethod]
    public void FromAndToKvp()
    {
        var record = DatastoreKvpRecord.FromKvp(new("abc", new(typeof(string), "\"hello\"")));
        Assert.AreEqual("abc", record.Key);
        Assert.AreEqual(TypeToName.Convert(typeof(string)), record.ValueTypeName);
        Assert.AreEqual("\"hello\"", record.ValueJson);

        var kvp = record.ToKvp();
        Assert.AreEqual("abc", kvp.Key);
        (Type type, string json) = kvp.Value;
        Assert.AreEqual(typeof(string), type);
        Assert.AreEqual("\"hello\"", json);
    }
}