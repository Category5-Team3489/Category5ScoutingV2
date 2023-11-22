namespace Category5ScoutingV2.Shared;

public readonly struct DatastoreKey
{
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

    public DatastoreKey(params string[] args)
    {
        if (args.Length == 0)
        {
            throw new ArgumentException($"{nameof(DatastoreKey)} cannot have zero args.", nameof(args));
        }
        else if (args.Length == 1)
        {
            if (!ContainsValidChars(args[0], true))
            {
                throw new ArgumentException($"{nameof(DatastoreKey)} arg can only contain ASCII alphanumeric, \'-\', \'_\', or \'/\' characters.");
            }

            key = args[0];
            return;
        }

        foreach (var arg in args)
        {
            if (!ContainsValidChars(arg, false))
            {
                throw new ArgumentException($"{nameof(DatastoreKey)} args can only contain ASCII alphanumeric, \'-\', or \'_\' characters.");
            }
        }

        key = string.Join('/', args);
    }

    private static bool ContainsValidChars(string value, bool canContainSlashes)
    {
        foreach (var c in value)
        {
            bool isAlphaUpper = c >= 'A' && c <= 'Z';
            bool isAlphaLower = c >= 'a' && c <= 'z';
            bool isNumber = c >= '1' && c <= '9';
            bool isValidSpecial = c == '-' || c == '_';

            if (isAlphaUpper || isAlphaLower || isNumber || isValidSpecial) { }
            else
            {
                if (canContainSlashes && c == '/') { }
                else
                {
                    return false;
                }
            }
        }

        return true;
    }
}