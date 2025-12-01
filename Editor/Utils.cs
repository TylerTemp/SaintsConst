using System.Text.RegularExpressions;

namespace SaintsConst.Editor
{
    public static class Utils
    {
        private const string Numbers = "0123456789";
        private static readonly Regex InvalidRegex = new Regex("[^a-zA-Z0-9_]+");

        public static string ProperVarName(string tagValue)
        {
            char firstLetter = tagValue[0];
            string prepend = "";
            if (Numbers.Contains(firstLetter))
            {
                prepend = "_";
            }
            string result = InvalidRegex.Replace(tagValue, "_");

            return $"{prepend}{result}";
        }
    }
}
