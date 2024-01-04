using System.Text;

public class Identifiers
{
    // XR RIG Parts
    public const string LEFT_HAND = "LEFT_HAND";
    public const string RIGHT_HAND = "RIGHT_HAND";
    public const string HMD = "HMD";

    // BDSM Elements
    public const string BLINDFOLD = "BLINDFOLD";
    public const string LOCK = "LOCK";

    // Properties
    public const string POSITION = "POSITION";
    public const string ROTATION = "ROTATION"; // Euler Angles
    public const string TARGET = "TARGET";
    public const string DISTANCE = "DISTANCE";
    public const string IS_OK = "IS_OK";
    public const string ACTIVE = "ACTIVE";
    public const string COLOR = "COLOR";

    public static string NewId(params string[] args)
    {
        var sb = new StringBuilder();
        for (int i = 0; i < args.Length; i++)
        {
            // Add command dot ;)
            if (i > 0) sb.Append(".");

            string arg = args[i];
            sb.Append(arg);
        }

        return sb.ToString();
    }

}