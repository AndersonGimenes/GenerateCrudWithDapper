using GenerateCrudWithDapper.Core.Constants;
using GenerateCrudWithDapper.Core.Dto;
using GenerateCrudWithDapper.Core.Extensions;
using GenerateCrudWithDapper.Core.Factories.Interface;
using GenerateCrudWithDapper.Core.Utils;
using System.IO;
using System.Linq;

namespace GenerateCrudWithDapper.Core.Factories
{
    internal class TableFactory : IFactory
    {
        private readonly IFactory _next;

        public TableFactory(IFactory next)
        {
            _next = next;
        }

        public void Execute(CrudGenerateDto value)
        {
            var folderName = StringConstant.Table;
            FolderUtils.CreateChildFolder(folderName);

            var tableName = $"{value.TableName}";
            var fullPath = FileUtils.CreateFile(folderName, tableName, "sql");
            var pkProperties = value.PrimaryKeyNameAndField.Split("-");

            var contents = value.PropertiesTable.ConvertStringArrayToListKeyValuePair();

            using var sw = new StreamWriter(fullPath);

            sw.WriteLine($"CREATE TABLE {tableName}");
            sw.WriteLine("(");

            foreach (var content in contents)
                sw.WriteLine($"{StringConstant.Indentation}[{content.Value.Trim()}] {content.Key},");

            sw.WriteLine($"{StringConstant.Indentation}CONSTRAINT [{pkProperties.FirstOrDefault()?.Trim()}] PRIMARY KEY ([{pkProperties.LastOrDefault()?.Trim()}])");

            sw.WriteLine(")");

            sw.Close();

            if (_next is null)
                return;

            _next.Execute(value);
        }
    }
}
