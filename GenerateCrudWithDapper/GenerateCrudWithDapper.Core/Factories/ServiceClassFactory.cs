using GenerateCrudWithDapper.Core.Constants;
using GenerateCrudWithDapper.Core.Dto;
using GenerateCrudWithDapper.Core.Factories.Interface;
using GenerateCrudWithDapper.Core.Utils;
using System.IO;

namespace GenerateCrudWithDapper.Core.Factories
{
    internal class ServiceClassFactory : IFactory
    {
        private readonly IFactory _next;

        public ServiceClassFactory(IFactory next)
        {
            _next = next;
        }

        public void Execute(CrudGenerateDto value)
        {
            var folderName = StringConstant.Service;
            FolderUtils.CreateChildFolder(folderName);

            var className = $"{value.ServiceClassName}{StringConstant.Service}";
            var repositoryInterfaceName = $"I{value.RepositoryClassName}{StringConstant.Repository}";
            var entityClassName = value.EntityClassName;

            var fullPath = FileUtils.CreateFile(folderName, className, "cs");

            using var sw = new StreamWriter(fullPath);

            #region [CLASS]                               
            sw.WriteLine($"public class {className} : I{className}");
            sw.WriteLine("{");

            sw.WriteLine($"{StringConstant.Indentation}private readonly {repositoryInterfaceName} _repository;");

            #region [CONSTRUCTOR]
            sw.WriteLine();
            sw.WriteLine($"{StringConstant.Indentation}public {className}({repositoryInterfaceName} repository)");
            sw.WriteLine($"{StringConstant.Indentation}{{");

            sw.WriteLine($"{StringConstant.Indentation}{StringConstant.Indentation}_repository = repository;");

            sw.WriteLine($"{StringConstant.Indentation}}}");
            #endregion

            #region [GETALL]
            sw.WriteLine();
            sw.WriteLine($"{StringConstant.Indentation}public IEnumerable<{entityClassName}> GetAll()");
            sw.WriteLine($"{StringConstant.Indentation}{{");

            sw.WriteLine($"{StringConstant.Indentation}{StringConstant.Indentation}return _repository.GetAll();");

            sw.WriteLine($"{StringConstant.Indentation}}}");
            #endregion

            #region [GETBYID]
            sw.WriteLine();
            sw.WriteLine($"{StringConstant.Indentation}public {entityClassName} GetById(int id)");
            sw.WriteLine($"{StringConstant.Indentation}{{");

            sw.WriteLine($"{StringConstant.Indentation}{StringConstant.Indentation}return _repository.GetById(id);");

            sw.WriteLine($"{StringConstant.Indentation}}}");
            #endregion

            #region [CREATE]
            sw.WriteLine();
            sw.WriteLine($"{StringConstant.Indentation}public {entityClassName} Create({entityClassName} entity)");
            sw.WriteLine($"{StringConstant.Indentation}{{");

            sw.WriteLine($"{StringConstant.Indentation}{StringConstant.Indentation}return _repository.Create(entity);");

            sw.WriteLine($"{StringConstant.Indentation}}}");
            #endregion

            #region [UPDATE]
            sw.WriteLine();
            sw.WriteLine($"{StringConstant.Indentation}public {entityClassName} Update({entityClassName} entity)");
            sw.WriteLine($"{StringConstant.Indentation}{{");

            sw.WriteLine($"{StringConstant.Indentation}{StringConstant.Indentation}return _repository.Update(entity);");

            sw.WriteLine($"{StringConstant.Indentation}}}");
            #endregion

            #region [DELETE]
            sw.WriteLine();
            sw.WriteLine($"{StringConstant.Indentation}public void Delete(int id)");
            sw.WriteLine($"{StringConstant.Indentation}{{");

            sw.WriteLine($"{StringConstant.Indentation}{StringConstant.Indentation}_repository.Delete(id);");

            sw.WriteLine($"{StringConstant.Indentation}}}");
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
