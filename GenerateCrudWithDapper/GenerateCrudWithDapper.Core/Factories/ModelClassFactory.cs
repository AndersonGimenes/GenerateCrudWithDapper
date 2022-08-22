using GenerateCrudWithDapper.Core.Constants;
using GenerateCrudWithDapper.Core.Dto;
using GenerateCrudWithDapper.Core.Extensions;
using GenerateCrudWithDapper.Core.Factories.Interface;
using GenerateCrudWithDapper.Core.Utils;
using System.IO;

namespace GenerateCrudWithDapper.Core.Factories
{
    internal class ModelClassFactory : IFactory
    {
        private readonly IFactory _next;

        public ModelClassFactory(IFactory next)
        {
            _next = next;
        }

        public void Execute(CrudGenerateDto value)
        {
            var folderName = StringConstant.Model;
            FolderUtils.CreateChildFolder(folderName);

            var className = $"{value.ModelClassName}{StringConstant.Model}";
            var fullPath = FileUtils.CreateFile(folderName, className, "cs");

            var contents = value.PropertiesModel.ConvertStringArrayToListKeyValuePair();

            using var sw = new StreamWriter(fullPath);

            sw.WriteLine($"public class {className}");
            sw.WriteLine("{");

            foreach (var content in contents)
                sw.WriteLine($"{StringConstant.Indentation}public {content.Key} {content.Value} {{ get; set; }}");

            sw.WriteLine("}");

            sw.Close();

            if (_next is null)
                return;

            _next.Execute(value);
        }
    }
}
