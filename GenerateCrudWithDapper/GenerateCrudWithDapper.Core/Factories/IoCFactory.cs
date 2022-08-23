using GenerateCrudWithDapper.Core.Constants;
using GenerateCrudWithDapper.Core.Dto;
using GenerateCrudWithDapper.Core.Factories.Interface;
using GenerateCrudWithDapper.Core.Utils;
using System.IO;

namespace GenerateCrudWithDapper.Core.Factories
{
    internal class IoCFactory : IFactory
    {
        private readonly IFactory _next;

        public IoCFactory(IFactory next)
        {
            _next = next;
        }

        public void Execute(CrudGenerateDto value)
        {
            var folderName = StringConstant.IoC;
            FolderUtils.CreateChildFolder(folderName);

            var fullPath = FileUtils.CreateFile(folderName, folderName, "txt");

            var classServiceName = $"{value.ServiceClassName}{StringConstant.Service}";
            var classRepositoryName = $"{value.RepositoryClassName}{StringConstant.Repository}";

            using var sw = new StreamWriter(fullPath);

            sw.WriteLine($"{StringConstant.Indentation}services.AddScoped<I{classServiceName}, {classServiceName}>();");
            sw.WriteLine($"{StringConstant.Indentation}services.AddScoped<I{classRepositoryName}, {classRepositoryName}>();");

            FlagExecuteUtils.Execute(value, () =>
            {
                sw.WriteLine($"{StringConstant.Indentation}services.AddScoped<{StringConstant.DapperContext}>();");
                sw.WriteLine($"{StringConstant.Indentation}services.AddSingleton(new {StringConstant.Mapper}());");
                sw.WriteLine($"{StringConstant.Indentation}services.Configure<{StringConstant.SettingsOptions}>(Configuration.GetSection(\"ConnectionStrings\"));");
            });

            sw.Close();

            if (_next is null)
                return;

            _next.Execute(value);
        }
    }
}
