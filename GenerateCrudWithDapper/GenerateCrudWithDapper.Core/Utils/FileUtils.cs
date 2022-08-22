using System;
using System.IO;

namespace GenerateCrudWithDapper.Core.Utils
{
    internal static class FileUtils
    {
        public static string CreateFile(string folderName, string className, string extension)
        {
            var path = Directory.GetCurrentDirectory() + $"\\CrudGenerator\\{folderName}";

            try
            {
                var fullPath = $"{path}\\{className}.{extension}";

                using var _= File.Create(fullPath);

                return fullPath;
            }
            catch (Exception e)
            {
                throw new Exception($"The process create folder fail: {e.Message}");
            }
        }
    }
}
