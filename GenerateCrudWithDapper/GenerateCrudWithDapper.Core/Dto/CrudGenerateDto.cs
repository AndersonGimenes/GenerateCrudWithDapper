namespace GenerateCrudWithDapper.Core.Dto
{
    public struct CrudGenerateDto
    {
        public string EntityClassName;
        public string ModelClassName;
        public string ControllerClassName;
        public string ServiceClassName;
        public string RepositoryClassName;
        public string TableName;
        public string PrimaryKeyNameAndField;
      
        public string[] PropertiesEntity;
        public string[] PropertiesModel;
        public string[] PropertiesTable;

        public bool GenerateUtils;
    }
}
