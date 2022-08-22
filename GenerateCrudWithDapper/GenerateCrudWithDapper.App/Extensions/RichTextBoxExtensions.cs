using System.Windows.Forms;

namespace GenerateCrudWithDapper.App.Extensions
{
    internal static class RichTextBoxExtensions
    {
        public static string[] ConvertRichTextBoxToStringArrayFromAnyChar(this RichTextBox richText, string character, bool removeSpace)
        {
            var stringFormat = richText.Text.Replace("\n", "");

            if (removeSpace)
                stringFormat = stringFormat.Replace(" ", "");

            return stringFormat.Split(character);
        }
            
    }
}
