using System;
using System.IO;
using System.Linq;

namespace GenerateCrudWithDapper.Core.Utils
{
    internal class FolderUtils
    {
        public static void CreateChildFolder(string pathName)
        {
            var path = Directory.GetCurrentDirectory() + $"\\CrudGenerator\\{pathName}";

            try
            {
                Directory.CreateDirectory(path);
            }
            catch (Exception e)
            {
                throw new Exception($"The process create child folder {pathName} fail: {e.Message}");
            }
        }

        public static void CreateRootFolder()
        {
            var path = Directory.GetCurrentDirectory() + $"\\CrudGenerator";

            try
            {
                if (Directory.Exists(path))
                {
                    var files = Directory.GetFiles(path);

                    if (files.Any())
                    {
                        foreach (var file in files)
                            File.Delete(file);
                    }

                    Directory.Delete(path, true);
                }

                Directory.CreateDirectory(path);
            }
            catch (Exception e)
            {
                throw new Exception($"The process create root folder fail: {e.Message}");
            }
        }
    }
}
