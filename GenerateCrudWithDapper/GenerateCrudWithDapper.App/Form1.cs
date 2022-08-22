using GenerateCrudWithDapper.App.Extensions;
using GenerateCrudWithDapper.Core.Dto;
using GenerateCrudWithDapper.Core.Factories.Startup;
using System;
using System.Windows.Forms;

namespace GenerateCrudWithDapper.App
{
    public partial class GenerateCrud : Form
    {
        public GenerateCrud()
        {
            InitializeComponent();
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                var dto = new CrudGenerateDto
                {
                    ControllerClassName = InputControllerClassName.Text,
                    EntityClassName = InputEntityClassName.Text,
                    ModelClassName = InputModelClassName.Text,
                    ServiceClassName = InputServiceClassName.Text,
                    RepositoryClassName = InputRepositoryClassName.Text,
                    TableName = InputTableName.Text,
                    PrimaryKeyNameAndField = InputPrimaryKeyName.Text,
                    PropertiesTable = InputFieldsTable.ConvertRichTextBoxToStringArrayFromAnyChar(";", false),
                    PropertiesEntity = InputPropertiesEntity.ConvertRichTextBoxToStringArrayFromAnyChar(";", true),
                    PropertiesModel = InputPropertiesModel.ConvertRichTextBoxToStringArrayFromAnyChar(";", true),
                    GenerateUtils = CheckUtils.Checked
                };

                StartupFactory.SetConfiguration().Execute(dto);

                MessageBox.Show("Executed with success...");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}