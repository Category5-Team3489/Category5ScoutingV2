namespace Category5ScoutingV2.Shared.Datastore;

public static class DatastoreExtensions
{
    // TODO Redo

    //public static bool TryRead<T>(this Datastore datastore, DatastoreKey key, [MaybeNullWhen(false)] out T value)
    //{
    //    if (datastore.TryRead(key, out value, out var error))
    //    {
    //        return true;
    //    }

    //    if (error == Datastore.ReadError.TypeMismatch)
    //    {
    //        throw new Exception($"The provided type \"{nameof(T)}\" does not match the type of an existing value in the datastore.");
    //    }

    //    return false;
    //}
    //public static T? Read<T>(this Datastore datastore, DatastoreKey key)
    //{
    //    if (datastore.TryRead<T>(key, out var value, out var error))
    //    {
    //        return value;
    //    }

    //    if (error == Datastore.ReadError.TypeMismatch)
    //    {
    //        throw new Exception($"The provided type \"{nameof(T)}\" does not match the type of an existing value in the datastore.");
    //    }

    //    return default;
    //}

    //public static void Write<T>(this Datastore datastore, DatastoreKey key, T value)
    //{
    //    datastore.TryWrite(key, value);
    //}
}
