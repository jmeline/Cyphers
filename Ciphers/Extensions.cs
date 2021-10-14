namespace Ciphers
{
    public static class Extensions
    {
        // C#'s modulo is a remainder
        public static int Mod(int x, int m)
        {
            var remainder = x % m;
            return remainder < 0 
                ? remainder + m 
                : remainder;
        }
    }
}