using System.Linq;

namespace PrintDiamond
{
    public static class Extension
    {
        public static int TextToNumber(this string text)
        {
            return text
                .Select(c => c - 'A')
                .Aggregate((sum, next) => sum * 26 + next);
        }

    }
}
