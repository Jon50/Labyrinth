namespace Labyrinth
{
    public static class BoolExtension
    {
        public static bool AnyIsTrue(this bool instance, params bool[] args)
        {
            for (int i = 0; i < args.Length; i++)
                if (args[i] == true)
                    return true;

            return false;
        }

        public static bool AllAreTrue(this bool instance, params bool[] args)
        {
            for (int i = 0; i < args.Length; i++)
                if (args[i] == false)
                    return false;

            return true;
        }

        public static bool IsNull(this object instance)
        {
            if (instance == null)
                return true;
            return false;
        }

        public static bool IsNotNull(this object instance)
        {
            if (instance != null)
                return true;
            return false;
        }
    }
}