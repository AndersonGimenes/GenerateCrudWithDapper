using GenerateCrudWithDapper.Core.Constants;
using GenerateCrudWithDapper.Core.Dto;
using GenerateCrudWithDapper.Core.Factories.Interface;
using GenerateCrudWithDapper.Core.Utils;
using System.IO;

namespace GenerateCrudWithDapper.Core.Factories
{
    internal class MapperGenericFactory : IFactory
    {
        private readonly IFactory _next;

        public MapperGenericFactory(IFactory next)
        {
            _next = next;
        }

        public void Execute(CrudGenerateDto value)
        {
            FlagExecuteUtils.Execute(value, () =>
            {
                var folderName = StringConstant.Utils;
                FolderUtils.CreateChildFolder(folderName);

                var className = StringConstant.Mapper;
                var fullPath = FileUtils.CreateFile(folderName, className, "cs");

                using var sw = new StreamWriter(fullPath);

                sw.WriteLine($"public class {className}");
                sw.WriteLine("{");

                sw.WriteLine($"{StringConstant.Indentation}// Add Package Newtonsoft.Json -> Delete this line");
                sw.WriteLine($"{StringConstant.Indentation}public TOutput CreateMap<TInput, TOutput>(TInput input)");
                sw.WriteLine($"{StringConstant.Indentation}{{");

                sw.WriteLine($"{StringConstant.Indentation}{StringConstant.Indentation}var output = JsonConvert.SerializeObject(input);");
                sw.WriteLine($"{StringConstant.Indentation}{StringConstant.Indentation}return JsonConvert.DeserializeObject<TOutput>(output);");

                sw.WriteLine($"{StringConstant.Indentation}}}");

                sw.WriteLine("}");

                sw.Close();
            });

            if (_next is null)
                return;

            _next.Execute(value);
        }
    }
}
