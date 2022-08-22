using GenerateCrudWithDapper.Core.Constants;
using GenerateCrudWithDapper.Core.Dto;
using GenerateCrudWithDapper.Core.Factories.Interface;
using GenerateCrudWithDapper.Core.Utils;
using System.IO;

namespace GenerateCrudWithDapper.Core.Factories
{
    internal class DapperContextFactory : IFactory
    {
        private readonly IFactory _next;

        public DapperContextFactory(IFactory next)
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

            var className = StringConstant.DapperContext;
            var fullPath = FileUtils.CreateFile(folderName, className, "cs");

            using var sw = new StreamWriter(fullPath);

            sw.WriteLine($"//Add package System.Data.SqlClient -> Delete this line");
            sw.WriteLine($"public class {className}");
            sw.WriteLine("{");

            sw.WriteLine($"{StringConstant.Indentation}private readonly IOptions<{StringConstant.SettingsOptions}> _options;");
            sw.WriteLine();            
            sw.WriteLine($"{StringConstant.Indentation}public {className}(IOptions<{StringConstant.SettingsOptions}> options)");
            sw.WriteLine($"{StringConstant.Indentation}{{");

            sw.WriteLine($"{StringConstant.Indentation}{StringConstant.Indentation}_options = options;");

            sw.WriteLine($"{StringConstant.Indentation}}}");

            sw.WriteLine();
            sw.WriteLine($"{StringConstant.Indentation}public IDbConnection CreateConnection() =>");
            sw.WriteLine($"{StringConstant.Indentation}{StringConstant.Indentation}new SqlConnection(_options.Value.DefaultConnectionStrings);");

            sw.WriteLine("}");

            sw.Close();

            if (_next is null)
                return;

            _next.Execute(value);
        }
    }
}
