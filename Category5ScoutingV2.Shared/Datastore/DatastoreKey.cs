namespace Category5ScoutingV2.Shared.Datastore;

public readonly struct DatastoreKey
{
    private readonly Type? type;
    public Type? Type => type;
    public bool IsTyped => type is not null;

    private readonly string key;
    public string Key
    {
        get
        {
            if (key is null)
            {
                throw new NullReferenceException($"{nameof(DatastoreKey)} was never initialized.");
            }

            return key;
        }
    }

    public static DatastoreKey Typed<T>(params string[] args) => new(typeof(T), args);
    public static DatastoreKey Untyped(params string[] args) => new(null, args);

    public static DatastoreKey Unsafe(Type? type, string key) => new(type, key);

    public DatastoreKey AsTyped<T>() => new(typeof(T), Key);
    public DatastoreKey AsUntyped() => new(null, Key);

    /// <summary>
    /// Ensure the provided type has been stripped of any nullable value types!
    /// If this key is untyped, this will not throw.
    /// </summary>
    /// <exception cref="DatastoreKeyTypeMismatchException"></exception>
    internal void ThrowOnKeyTypeMismatch(Type type)
    {
        if (!IsTyped)
        {
            return;
        }

        if (type != this.type)
        {
            throw new DatastoreKeyTypeMismatchException(type, this);
        }
    }

    private DatastoreKey(Type? type, string key)
    {
        if (type is not null)
        {
            this.type = DatastoreTypeUtils.StripNullableValueType(type);
        }

        this.key = key;
    }

    private DatastoreKey(Type? type, params string[] args)
    {
        if (type is not null)
        {
            this.type = DatastoreTypeUtils.StripNullableValueType(type);
        }

        if (args.Length == 0)
        {
            throw new ArgumentException($"{nameof(DatastoreKey)} cannot have zero args.", nameof(args));
        }
        else if (args.Length == 1)
        {
            args = args[0].Split('/');
        }

        foreach (var arg in args)
        {
            if (string.IsNullOrWhiteSpace(arg))
            {
                throw new ArgumentException($"{nameof(DatastoreKey)} args cannot be null or whitespace. Ensure you have no leading, trailing, or contiguous slashes.");
            }

            if (!ContainsValidChars(arg))
            {
                throw new ArgumentException($"{nameof(DatastoreKey)} args must only contain ASCII alphanumeric, \'-\', or \'_\' characters.");
            }
        }

        key = string.Join('/', args);
    }

    private static bool ContainsValidChars(string value)
    {
        foreach (var c in value)
        {
            bool isAlphaUpper = c >= 'A' && c <= 'Z';
            bool isAlphaLower = c >= 'a' && c <= 'z';
            bool isNumber = c >= '0' && c <= '9';
            bool isValidSpecial = c == '-' || c == '_';

            if (isAlphaUpper || isAlphaLower || isNumber || isValidSpecial) { }
            else
            {
                return false;
            }
        }

        return true;
    }

    public static implicit operator string(DatastoreKey key) => key.Key;
}