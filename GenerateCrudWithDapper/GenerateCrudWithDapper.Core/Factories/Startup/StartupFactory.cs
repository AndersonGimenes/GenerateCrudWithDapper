using GenerateCrudWithDapper.Core.Factories.Interface;
using GenerateCrudWithDapper.Core.Utils;

namespace GenerateCrudWithDapper.Core.Factories.Startup
{
    public static class StartupFactory
    {
        public static IFactory SetConfiguration()
        {
            FolderUtils.CreateRootFolder();

            var tableInstance = new TableFactory(null);
            var settingsOptionsInstance = new SettingsOptionsFactory(tableInstance);
            var queriesInstance = new QueriesDapperFactory(settingsOptionsInstance);
            var dapperInstance = new DapperContextFactory(queriesInstance);
            var mapperInstance = new MapperGenericFactory(dapperInstance);
            var iocInstance = new IoCFactory(mapperInstance);
            var interfaceRepositoryInstance = new RepositoryInterfaceFactory(iocInstance);
            var repositoryInstance = new RepositoryClassFactory(interfaceRepositoryInstance);
            var interfaceServiceInstance = new ServiceInterfaceFactory(repositoryInstance);            
            var serviceInstance = new ServiceClassFactory(interfaceServiceInstance);
            var controllerInstance = new ControllerClassFactory(serviceInstance);
            var modelInstance = new ModelClassFactory(controllerInstance);
            var entityInstance = new EntityClassFactory(modelInstance);

            return entityInstance;
        }
    }
}
