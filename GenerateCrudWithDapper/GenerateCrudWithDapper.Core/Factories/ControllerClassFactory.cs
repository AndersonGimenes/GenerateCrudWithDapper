using GenerateCrudWithDapper.Core.Constants;
using GenerateCrudWithDapper.Core.Dto;
using GenerateCrudWithDapper.Core.Factories.Interface;
using GenerateCrudWithDapper.Core.Utils;
using System.IO;

namespace GenerateCrudWithDapper.Core.Factories
{
    internal class ControllerClassFactory : IFactory
    {
        private readonly IFactory _next;

        public ControllerClassFactory(IFactory next)
        {
            _next = next;
        }

        public void Execute(CrudGenerateDto value)
        {
            var folderName = StringConstant.Controller;
            FolderUtils.CreateChildFolder(folderName);

            var className = $"{value.ControllerClassName}{StringConstant.Controller}";
            var serviceInterfaceName = $"I{value.ServiceClassName}{StringConstant.Service}";
            var modelClassName = $"{value.ModelClassName}{StringConstant.Model}";
            var entityClassName = value.EntityClassName;

            var fullPath = FileUtils.CreateFile(folderName, className, "cs");

            using var sw = new StreamWriter(fullPath);

            #region [CLASS]       
            sw.WriteLine($"[ApiController]");
            sw.WriteLine($"[Route(\"api/v1/[controller]\")]");
            sw.WriteLine($"public class {className} : ControllerBase");
            sw.WriteLine("{");

            sw.WriteLine($"{StringConstant.Indentation}private readonly {serviceInterfaceName} _service;");
            sw.WriteLine($"{StringConstant.Indentation}private readonly {StringConstant.Mapper} _mapper;");

            #region [CONSTRUCTOR]
            sw.WriteLine();
            sw.WriteLine($"{StringConstant.Indentation}public {className}({serviceInterfaceName} service, {StringConstant.Mapper} mapper)");
            sw.WriteLine($"{StringConstant.Indentation}{{");

            sw.WriteLine($"{StringConstant.Indentation}{StringConstant.Indentation}_service = service;");
            sw.WriteLine($"{StringConstant.Indentation}{StringConstant.Indentation}_mapper = mapper;");

            sw.WriteLine($"{StringConstant.Indentation}}}");
            #endregion

            #region [GETALL]
            sw.WriteLine();
            sw.WriteLine($"{StringConstant.Indentation}[HttpGet]");
            sw.WriteLine($"{StringConstant.Indentation}public IActionResult GetAll()");
            sw.WriteLine($"{StringConstant.Indentation}{{");

            sw.WriteLine($"{StringConstant.Indentation}{StringConstant.Indentation}var entities = _service.GetAll();");
            sw.WriteLine($"{StringConstant.Indentation}{StringConstant.Indentation}var result = _mapper.CreateMap<IEnumerable<{entityClassName}>, IEnumerable<{modelClassName}>>(entities);");
            sw.WriteLine();
            sw.WriteLine($"{StringConstant.Indentation}{StringConstant.Indentation}return Ok(result);");

            sw.WriteLine($"{StringConstant.Indentation}}}");
            #endregion

            #region [GETBYID]
            sw.WriteLine();
            sw.WriteLine($"{StringConstant.Indentation}[HttpGet(\"{{id:int}}\")]");
            sw.WriteLine($"{StringConstant.Indentation}public IActionResult GetById(int id)");
            sw.WriteLine($"{StringConstant.Indentation}{{");

            sw.WriteLine($"{StringConstant.Indentation}{StringConstant.Indentation}var entity = _service.GetById(id);");
            sw.WriteLine($"{StringConstant.Indentation}{StringConstant.Indentation}var result = _mapper.CreateMap<{entityClassName}, {modelClassName}>(entity);");
            sw.WriteLine();
            sw.WriteLine($"{StringConstant.Indentation}{StringConstant.Indentation}return Ok(result);");

            sw.WriteLine($"{StringConstant.Indentation}}}");
            #endregion

            #region [CREATE]
            sw.WriteLine();
            sw.WriteLine($"{StringConstant.Indentation}[HttpPost]");
            sw.WriteLine($"{StringConstant.Indentation}public IActionResult Create({modelClassName} model)");
            sw.WriteLine($"{StringConstant.Indentation}{{");

            sw.WriteLine($"{StringConstant.Indentation}{StringConstant.Indentation}var entity = _mapper.CreateMap<{modelClassName}, {entityClassName}>(model);");
            sw.WriteLine($"{StringConstant.Indentation}{StringConstant.Indentation}var result = _mapper.CreateMap<{entityClassName}, {modelClassName}>(_service.Create(entity));");
            sw.WriteLine();
            sw.WriteLine($"{StringConstant.Indentation}{StringConstant.Indentation}return Ok(result);");

            sw.WriteLine($"{StringConstant.Indentation}}}");
            #endregion

            #region [UPDATE]
            sw.WriteLine();
            sw.WriteLine($"{StringConstant.Indentation}[HttpPut]");
            sw.WriteLine($"{StringConstant.Indentation}public IActionResult Update({modelClassName} model)");
            sw.WriteLine($"{StringConstant.Indentation}{{");

            sw.WriteLine($"{StringConstant.Indentation}{StringConstant.Indentation}var entity = _mapper.CreateMap<{modelClassName}, {entityClassName}>(model);");
            sw.WriteLine($"{StringConstant.Indentation}{StringConstant.Indentation}var result = _mapper.CreateMap<{entityClassName}, {modelClassName}>(_service.Update(entity));");
            sw.WriteLine();
            sw.WriteLine($"{StringConstant.Indentation}{StringConstant.Indentation}return Ok(result);");

            sw.WriteLine($"{StringConstant.Indentation}}}");
            #endregion

            #region [DELETE]
            sw.WriteLine();
            sw.WriteLine($"{StringConstant.Indentation}[HttpDelete(\"{{id:int}}\")]");
            sw.WriteLine($"{StringConstant.Indentation}public IActionResult Delete(int id)");
            sw.WriteLine($"{StringConstant.Indentation}{{");

            sw.WriteLine($"{StringConstant.Indentation}{StringConstant.Indentation}_service.Delete(id);");
            sw.WriteLine();
            sw.WriteLine($"{StringConstant.Indentation}{StringConstant.Indentation}return NoContent();");

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
