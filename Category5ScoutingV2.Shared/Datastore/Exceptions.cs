﻿namespace Category5ScoutingV2.Shared.Datastore;

public class DatastoreKeyTypeMismatchException : Exception
{
    internal DatastoreKeyTypeMismatchException(Type existing, DatastoreKey key) : base($"Existing type \"{existing.AssemblyQualifiedName}\" does not match given key \"{key.Key}\" of type \"{key.Type}\".") { }
}

public class DatastoreTypeMismatchException : Exception
{
    internal DatastoreTypeMismatchException(Type existing, Type given, DatastoreKey key) : base($"Existing type \"{existing.AssemblyQualifiedName}\" does not match given type \"{given.AssemblyQualifiedName}\" for key \"{key.Key}\" of type \"{key.Type}\".") { }
}
