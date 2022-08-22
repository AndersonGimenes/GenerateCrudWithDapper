using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerateCrudWithDapper.Core.Extensions
{
    internal static class EnumerableExtesnsions
    {
        public static string ConvertListKeyValuePairArrayToStringWithComma(this IEnumerable<KeyValuePair<string, string>> contents, string format, bool removePk, string pkField)
        {
            var sb = new StringBuilder();
            var index = 0;

            foreach (var content in contents)
            {
                index++;

                if (removePk && pkField.Trim() == content.Value.Trim())
                    continue;

                if (index == contents.Count())
                {
                    sb.Append(string.Format(format, content.Value.Trim()));
                    break;
                }

                sb.Append(string.Format($"{format},", content.Value.Trim()));
            }

            return sb.ToString();
        }
    }
}
