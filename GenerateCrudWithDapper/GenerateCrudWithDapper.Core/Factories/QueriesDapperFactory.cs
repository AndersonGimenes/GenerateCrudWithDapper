using GenerateCrudWithDapper.Core.Constants;
using GenerateCrudWithDapper.Core.Dto;
using GenerateCrudWithDapper.Core.Extensions;
using GenerateCrudWithDapper.Core.Factories.Interface;
using GenerateCrudWithDapper.Core.Utils;
using System.IO;
using System.Linq;

namespace GenerateCrudWithDapper.Core.Factories
{
    internal class QueriesDapperFactory : IFactory
    {
        private readonly IFactory _next;

        public QueriesDapperFactory(IFactory next)
        {
            _next = next;
        }

        public void Execute(CrudGenerateDto value)
        {
            var folderName = $"{StringConstant.Queries}";
            FolderUtils.CreateChildFolder(folderName);

            var className = $"{value.RepositoryClassName}{StringConstant.Queries}";
            var tableClassName = value.TableName;
            var pkField = value.PrimaryKeyNameAndField.Split("-").LastOrDefault()?.Trim();

            var fullPath = FileUtils.CreateFile(folderName, className, "cs");

            var contents = value.PropertiesTable.ConvertStringArrayToListKeyValuePair();

            using var sw = new StreamWriter(fullPath);
            var fields = string.Empty;

            #region [CLASS]                               
            sw.WriteLine($"public static class {className}");
            sw.WriteLine("{");

            #region [GETALL]
            fields = contents.ConvertListKeyValuePairArrayToStringWithComma("{0}", false, pkField);

            sw.WriteLine($"{StringConstant.Indentation}//Change \"TOP 100\" to Pagination or another way -> Delete this line");
            sw.WriteLine($"{StringConstant.Indentation}public static string GetAll() =>");
            sw.WriteLine($"{StringConstant.Indentation}{StringConstant.Indentation}\"SELECT TOP 100 {fields} FROM {tableClassName}\";");
            #endregion

            #region [GETBYID]
            sw.WriteLine();
            sw.WriteLine($"{StringConstant.Indentation}public static string GetById() =>");
            sw.WriteLine($"{StringConstant.Indentation}{StringConstant.Indentation}\"SELECT {fields} FROM {tableClassName} WHERE {pkField} = @{pkField}\";");
            #endregion

            #region [CREATE]
            fields = contents.ConvertListKeyValuePairArrayToStringWithComma("@{0}", true, pkField);

            sw.WriteLine();
            sw.WriteLine($"{StringConstant.Indentation}public static string Create() =>");
            sw.WriteLine($"{StringConstant.Indentation}{StringConstant.Indentation}\"INSERT INTO {tableClassName} VALUES({fields})\";");
            #endregion

            #region [UPDATE]
            fields = contents.ConvertListKeyValuePairArrayToStringWithComma("{0} = @{0}", true, pkField);

            sw.WriteLine();
            sw.WriteLine($"{StringConstant.Indentation}public static string Update() =>");
            sw.WriteLine($"{StringConstant.Indentation}{StringConstant.Indentation}\"UPDATE {tableClassName} SET {fields} WHERE {pkField} = @{pkField}\";");
            #endregion

            #region [DELETE]
            sw.WriteLine();
            sw.WriteLine($"{StringConstant.Indentation}public static string Delete() =>");
            sw.WriteLine($"{StringConstant.Indentation}{StringConstant.Indentation}\"DELETE FROM {tableClassName} WHERE {pkField} = @{pkField}\";");
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
