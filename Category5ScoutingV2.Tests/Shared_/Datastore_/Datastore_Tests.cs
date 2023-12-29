using Category5ScoutingV2.Shared.Datastore;

namespace Category5ScoutingV2.Tests.Shared_.Datastore_;

[TestClass]
public class Datastore_Tests
{
    [TestMethod]
    public void Serialization()
    {
        string json;
        {
            var datastore = Datastore.FromJson();
            datastore.Write(DatastoreKey.Untyped("a"), "Hello, World! 1");
            datastore.Write(DatastoreKey.Untyped("b"), "Hello, World! 2");
            datastore.Write(DatastoreKey.Untyped("c"), "Hello, World! 3");
            datastore.Write(DatastoreKey.Untyped("d"), "Hello, World! 4");
            json = datastore.ToJson();
        }

        {
            var datastore = Datastore.FromJson(json);

            Assert.IsTrue(datastore.TryRead(DatastoreKey.Untyped("a"), out string? value));
            Assert.AreEqual("Hello, World! 1", value!);

            Assert.IsTrue(datastore.TryRead(DatastoreKey.Untyped("b"), out value));
            Assert.AreEqual("Hello, World! 2", value!);

            Assert.IsTrue(datastore.TryRead(DatastoreKey.Untyped("c"), out value));
            Assert.AreEqual("Hello, World! 3", value!);

            Assert.IsTrue(datastore.TryRead(DatastoreKey.Untyped("d"), out value));
            Assert.AreEqual("Hello, World! 4", value!);
        }
    }

    [TestMethod]
    public void General()
    {
        var datastore = Datastore.FromJson();

        {
            bool success = datastore.TryRead(DatastoreKey.Typed<bool?>("null"), out bool? value);
            Assert.IsFalse(success);
            Assert.IsNull(value);
        }

        {
            datastore.Write(DatastoreKey.Typed<bool?>("null"), true);
        }

        {
            Assert.ThrowsException<DatastoreKeyTypeMismatchException>(() =>
            {
                bool success = datastore.TryRead(DatastoreKey.Typed<string?>("null"), out string? value);
                Assert.IsFalse(success);
                Assert.IsNull(value);
            });

            Assert.ThrowsException<DatastoreTypeMismatchException>(() =>
            {
                bool success = datastore.TryRead(DatastoreKey.Typed<bool?>("null"), out string? value);
                Assert.IsFalse(success);
                Assert.IsNull(value);
            });
        }

        {
            bool success = datastore.TryRead(DatastoreKey.Typed<bool?>("null"), out bool? value);
            Assert.IsTrue(success);
            Assert.IsNotNull(value);
            Assert.IsTrue(value);
        }

        {
            bool success = datastore.Delete(DatastoreKey.Typed<bool?>("null"), out var type, out var json);
            Assert.IsTrue(success);
            Assert.AreEqual(typeof(bool), type);
            Assert.AreEqual("true", json);
        }
    }

    [TestMethod]
    public void KeyEmpty_ArgumentException()
    {
        var datastore = Datastore.FromJson();

        Assert.ThrowsException<ArgumentException>(() =>
        {
            datastore.TryRead<string>(DatastoreKey.Untyped(""), out _);
        });

        Assert.ThrowsException<ArgumentException>(() =>
        {
            datastore.Write(DatastoreKey.Untyped(""), "");
        });
    }
}