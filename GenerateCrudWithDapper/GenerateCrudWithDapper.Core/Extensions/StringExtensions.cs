using System.Collections.Generic;

namespace GenerateCrudWithDapper.Core.Extensions
{
    internal static class StringExtensions
    {
        public static IEnumerable<KeyValuePair<string, string>> ConvertStringArrayToListKeyValuePair(this string[] values)
        {
            var result = new List<KeyValuePair<string, string>>();

            foreach(var value in values)
            {
                var keyValue = value.Split("-");

                if (keyValue.Length < 2)
                    continue;

                result.Add(new KeyValuePair<string, string>(keyValue[0], keyValue[1]));
            }

            return result;
        }
    }
}
