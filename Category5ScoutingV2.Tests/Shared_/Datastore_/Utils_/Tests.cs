using System.Text;
using Category5ScoutingV2.Shared.Datastore;
using Category5ScoutingV2.Shared.Datastore.Utils;

namespace Category5ScoutingV2.Tests.Shared_.Datastore_.Utils_;

[TestClass]
public class Tests
{
    [TestMethod]
    public void TypeAndNameConversion()
    {
        {
            string name = TypeToName.Convert(typeof(StringBuilder));
            Assert.IsTrue(typeof(StringBuilder).AssemblyQualifiedName!.Contains(name));

            Type type = NameToType.Convert(name);
            Assert.AreEqual(typeof(StringBuilder), type);
        }

        {
            string name = TypeToName.Convert(typeof(StringBuilder));
            Assert.IsTrue(typeof(StringBuilder).AssemblyQualifiedName!.Contains(name));

            Type type = NameToType.Convert(name);
            Assert.AreEqual(typeof(StringBuilder), type);
        }

        {
            string name = TypeToName.Convert(typeof(Datastore));
            Assert.IsTrue(typeof(Datastore).AssemblyQualifiedName!.Contains(name));

            Type type = NameToType.Convert(name);
            Assert.AreEqual(typeof(Datastore), type);
        }

        {
            string name = TypeToName.Convert(typeof(Datastore));
            Assert.IsTrue(typeof(Datastore).AssemblyQualifiedName!.Contains(name));

            Type type = NameToType.Convert(name);
            Assert.AreEqual(typeof(Datastore), type);
        }
    }

    [TestMethod]
    public void NullableValueTypeUnderlyingTypeStripping()
    {
        {
            Type type = NullableValueType.Strip(typeof(int?));
            Assert.AreEqual(typeof(int), type);
        }

        {
            Type type = NullableValueType.Strip(typeof(int?));
            Assert.AreEqual(typeof(int), type);
        }
    }
}