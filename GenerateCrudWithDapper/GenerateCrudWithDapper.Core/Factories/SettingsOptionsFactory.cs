using GenerateCrudWithDapper.Core.Constants;
using GenerateCrudWithDapper.Core.Dto;
using GenerateCrudWithDapper.Core.Factories.Interface;
using GenerateCrudWithDapper.Core.Utils;
using System.IO;

namespace GenerateCrudWithDapper.Core.Factories
{
    internal class SettingsOptionsFactory : IFactory
    {
        private readonly IFactory _next;

        public SettingsOptionsFactory(IFactory next)
        {
            _next = next;
        }

        public void Execute(CrudGenerateDto value)
        {
            if (!value.GenerateUtils)
            {
                _next.Execute(value);
                return;
            }

            var folderName = StringConstant.Utils;
            FolderUtils.CreateChildFolder(folderName);

            var className = StringConstant.SettingsOptions;

            var fullPath = FileUtils.CreateFile(folderName, className, "cs");

            using var sw = new StreamWriter(fullPath);

            sw.WriteLine($"public class {className}");
            sw.WriteLine("{");

            sw.WriteLine($"{StringConstant.Indentation}public string DefaultConnectionStrings {{ get; set; }}");

            sw.WriteLine("}");

            sw.Close();

            if (_next is null)
                return;

            _next.Execute(value);
        }
    }
}
