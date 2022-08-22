using GenerateCrudWithDapper.Core.Constants;
using GenerateCrudWithDapper.Core.Dto;
using GenerateCrudWithDapper.Core.Factories.Interface;
using GenerateCrudWithDapper.Core.Utils;
using System.IO;

namespace GenerateCrudWithDapper.Core.Factories
{
    internal class ServiceInterfaceFactory : IFactory
    {
        private readonly IFactory _next;

        public ServiceInterfaceFactory(IFactory next)
        {
            _next = next;
        }

        public void Execute(CrudGenerateDto value)
        {
            var folderName = $"{StringConstant.Interfaces}";
            FolderUtils.CreateChildFolder(folderName);

            var interfaceName = $"I{value.ServiceClassName}{StringConstant.Service}";
            var entityClassName = value.EntityClassName;

            var fullPath = FileUtils.CreateFile(folderName, interfaceName, "cs");

            using var sw = new StreamWriter(fullPath);

            #region [CLASS]                               
            sw.WriteLine($"public interface {interfaceName}");
            sw.WriteLine("{");

            #region [GETALL]
            sw.WriteLine($"{StringConstant.Indentation}IEnumerable<{entityClassName}> GetAll();");
            #endregion

            #region [GETBYID]
            sw.WriteLine();
            sw.WriteLine($"{StringConstant.Indentation}{entityClassName} GetById(int id);");
            #endregion

            #region [CREATE]
            sw.WriteLine();
            sw.WriteLine($"{StringConstant.Indentation}{entityClassName} Create({entityClassName} entity);");
            #endregion

            #region [UPDATE]
            sw.WriteLine();
            sw.WriteLine($"{StringConstant.Indentation}{entityClassName} Update({entityClassName} entity);");
            #endregion

            #region [DELETE]
            sw.WriteLine();
            sw.WriteLine($"{StringConstant.Indentation}void Delete(int id);");
            #endregion

            sw.WriteLine("}");
            #endregion

            sw.Close();

            if (_next is null)
                return;

            _next.Execute(value);
        }
    }
}
