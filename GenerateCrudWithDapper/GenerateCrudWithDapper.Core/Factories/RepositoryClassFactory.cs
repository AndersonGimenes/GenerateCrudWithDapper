using GenerateCrudWithDapper.Core.Constants;
using GenerateCrudWithDapper.Core.Dto;
using GenerateCrudWithDapper.Core.Factories.Interface;
using GenerateCrudWithDapper.Core.Utils;
using System.IO;

namespace GenerateCrudWithDapper.Core.Factories
{
    internal class RepositoryClassFactory : IFactory
    {
        private readonly IFactory _next;

        public RepositoryClassFactory(IFactory next)
        {
            _next = next;
        }

        public void Execute(CrudGenerateDto value)
        {
            var folderName = StringConstant.Repository;
            FolderUtils.CreateChildFolder(folderName);

            var className = $"{value.RepositoryClassName}{StringConstant.Repository}";
            var queryClassName = $"{value.RepositoryClassName}{StringConstant.Queries}";
            var dapperContext = $"{StringConstant.DapperContext}";
            var entityClassName = value.EntityClassName;

            var fullPath = FileUtils.CreateFile(folderName, className, "cs");

            using var sw = new StreamWriter(fullPath);

            #region [CLASS]    
            sw.WriteLine($"//Add Dapper and System.Data.SqlClient Packages -> Delete this line");
            sw.WriteLine($"public class {className} : I{className}");
            sw.WriteLine("{");

            sw.WriteLine($"{StringConstant.Indentation}private readonly {dapperContext} _context;");

            #region [CONSTRUCTOR]
            sw.WriteLine();
            sw.WriteLine($"{StringConstant.Indentation}public {className}({dapperContext} context)");
            sw.WriteLine($"{StringConstant.Indentation}{{");

            sw.WriteLine($"{StringConstant.Indentation}{StringConstant.Indentation}_context = context;");

            sw.WriteLine($"{StringConstant.Indentation}}}");
            #endregion

            #region [GETALL]
            sw.WriteLine();
            sw.WriteLine($"{StringConstant.Indentation}public IEnumerable<{entityClassName}> GetAll()");
            sw.WriteLine($"{StringConstant.Indentation}{{");

            sw.WriteLine($"{StringConstant.Indentation}{StringConstant.Indentation}using var connection = _context.CreateConnection();");
            sw.WriteLine();
            sw.WriteLine($"{StringConstant.Indentation}{StringConstant.Indentation}return connection.Query<{entityClassName}>({queryClassName}.GetAll());");

            sw.WriteLine($"{StringConstant.Indentation}}}");
            #endregion

            #region [GETBYID]
            sw.WriteLine();
            sw.WriteLine($"{StringConstant.Indentation}public {entityClassName} GetById(int id)");
            sw.WriteLine($"{StringConstant.Indentation}{{");

            sw.WriteLine($"{StringConstant.Indentation}{StringConstant.Indentation}using var connection = _context.CreateConnection();");
            sw.WriteLine();
            sw.WriteLine($"{StringConstant.Indentation}{StringConstant.Indentation}return connection.QueryFirst<{entityClassName}>({queryClassName}.GetById(), new {{ Id = id }});");

            sw.WriteLine($"{StringConstant.Indentation}}}");
            #endregion

            #region [CREATE]
            sw.WriteLine();
            sw.WriteLine($"{StringConstant.Indentation}public {entityClassName} Create({entityClassName} entity)");
            sw.WriteLine($"{StringConstant.Indentation}{{");

            sw.WriteLine($"{StringConstant.Indentation}{StringConstant.Indentation}using var connection = _context.CreateConnection();");
            sw.WriteLine();
            sw.WriteLine($"{StringConstant.Indentation}{StringConstant.Indentation}connection.Execute({queryClassName}.Create(), entity);");
            sw.WriteLine();
            sw.WriteLine($"{StringConstant.Indentation}{StringConstant.Indentation}return entity;");

            sw.WriteLine($"{StringConstant.Indentation}}}");
            #endregion

            #region [UPDATE]
            sw.WriteLine();
            sw.WriteLine($"{StringConstant.Indentation}public {entityClassName} Update({entityClassName} entity)");
            sw.WriteLine($"{StringConstant.Indentation}{{");

            sw.WriteLine($"{StringConstant.Indentation}{StringConstant.Indentation}using var connection = _context.CreateConnection();");
            sw.WriteLine();
            sw.WriteLine($"{StringConstant.Indentation}{StringConstant.Indentation}connection.Execute({queryClassName}.Update(), entity);");
            sw.WriteLine();
            sw.WriteLine($"{StringConstant.Indentation}{StringConstant.Indentation}return entity;");

            sw.WriteLine($"{StringConstant.Indentation}}}");
            #endregion

            #region [DELETE]
            sw.WriteLine();
            sw.WriteLine($"{StringConstant.Indentation}public void Delete(int id)");
            sw.WriteLine($"{StringConstant.Indentation}{{");

            sw.WriteLine($"{StringConstant.Indentation}{StringConstant.Indentation}using var connection = _context.CreateConnection();");
            sw.WriteLine();
            sw.WriteLine($"{StringConstant.Indentation}{StringConstant.Indentation}connection.Execute({queryClassName}.Delete(), new {{ Id = id }});");

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
