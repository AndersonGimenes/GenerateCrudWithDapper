using GenerateCrudWithDapper.Core.Dto;

namespace GenerateCrudWithDapper.Core.Factories.Interface
{
    public interface IFactory
    {
        void Execute(CrudGenerateDto value);
    }
}
