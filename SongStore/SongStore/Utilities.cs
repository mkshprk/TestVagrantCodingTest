using System;

namespace SongStore
{
    class Utilities
    {
        internal static int ToInt(string convertToInt)
        {
            try
            {
                return Convert.ToInt32(convertToInt.Trim());
            }
            catch
            {
                Console.WriteLine($"Unable to convert {convertToInt} to an integer, default value of 0 will be used");
                return 0;
            }
        }
    }
}
