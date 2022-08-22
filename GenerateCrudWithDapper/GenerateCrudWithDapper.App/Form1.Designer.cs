using System.Windows.Forms;

namespace GenerateCrudWithDapper.App
{
    partial class GenerateCrud
    {
        #region [Properties]
        private Label LabelEntityClassName;
        private Label LabelPropertiesEntitty;
        private Label LabelPropertiesModel;
        private Label LabelModelClassName;
        private Label ControllerClassName;
        private Label ServiceClassName;
        private Label RepositoryClassName;
        private Label LabelWarmController;
        private Label LabelWarmService;
        private Label LabelWarmRepository;
        private Label LabelWarmModel;
        private Label LabelTableName;
        private Label LableTableNameExemplo;
        private Label LabelFieldsTable;
        private Label LabelPrimaryKeyExemplo;
        private Label LabelPrimaryKeyName;

        private TextBox InputEntityClassName;
        private TextBox InputModelClassName;
        private TextBox InputControllerClassName;
        private TextBox InputServiceClassName;
        private TextBox InputRepositoryClassName;
        private TextBox InputTableName;
        private TextBox InputPrimaryKeyName;

        private RichTextBox InputFieldsTable;
        private RichTextBox InputPropertiesEntity;
        private RichTextBox InputPropertiesModel;

        private Button BtnGenerate;

        private CheckBox CheckUtils;

        private System.ComponentModel.IContainer components = null;

        #endregion

        private void InitializeComponent()
        {
            this.LabelEntityClassName = new System.Windows.Forms.Label();
            this.InputEntityClassName = new System.Windows.Forms.TextBox();
            this.InputModelClassName = new System.Windows.Forms.TextBox();
            this.LabelModelClassName = new System.Windows.Forms.Label();
            this.LabelPropertiesEntitty = new System.Windows.Forms.Label();
            this.LabelPropertiesModel = new System.Windows.Forms.Label();
            this.InputPropertiesEntity = new System.Windows.Forms.RichTextBox();
            this.InputPropertiesModel = new System.Windows.Forms.RichTextBox();
            this.InputControllerClassName = new System.Windows.Forms.TextBox();
            this.ControllerClassName = new System.Windows.Forms.Label();
            this.InputServiceClassName = new System.Windows.Forms.TextBox();
            this.ServiceClassName = new System.Windows.Forms.Label();
            this.InputRepositoryClassName = new System.Windows.Forms.TextBox();
            this.RepositoryClassName = new System.Windows.Forms.Label();
            this.BtnGenerate = new System.Windows.Forms.Button();
            this.LabelWarmController = new System.Windows.Forms.Label();
            this.LabelWarmService = new System.Windows.Forms.Label();
            this.LabelWarmRepository = new System.Windows.Forms.Label();
            this.LabelWarmModel = new System.Windows.Forms.Label();
            this.InputTableName = new System.Windows.Forms.TextBox();
            this.LabelTableName = new System.Windows.Forms.Label();
            this.LableTableNameExemplo = new System.Windows.Forms.Label();
            this.InputFieldsTable = new System.Windows.Forms.RichTextBox();
            this.LabelFieldsTable = new System.Windows.Forms.Label();
            this.LabelPrimaryKeyExemplo = new System.Windows.Forms.Label();
            this.LabelPrimaryKeyName = new System.Windows.Forms.Label();
            this.InputPrimaryKeyName = new System.Windows.Forms.TextBox();
            this.CheckUtils = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // LabelEntityClassName
            // 
            this.LabelEntityClassName.AutoSize = true;
            this.LabelEntityClassName.Location = new System.Drawing.Point(13, 13);
            this.LabelEntityClassName.Name = "LabelEntityClassName";
            this.LabelEntityClassName.Size = new System.Drawing.Size(102, 15);
            this.LabelEntityClassName.TabIndex = 0;
            this.LabelEntityClassName.Text = "Entity Class Name";
            // 
            // InputEntityClassName
            // 
            this.InputEntityClassName.Location = new System.Drawing.Point(121, 10);
            this.InputEntityClassName.Name = "InputEntityClassName";
            this.InputEntityClassName.Size = new System.Drawing.Size(209, 23);
            this.InputEntityClassName.TabIndex = 1;
            // 
            // InputModelClassName
            // 
            this.InputModelClassName.Location = new System.Drawing.Point(121, 222);
            this.InputModelClassName.Name = "InputModelClassName";
            this.InputModelClassName.Size = new System.Drawing.Size(209, 23);
            this.InputModelClassName.TabIndex = 3;
            // 
            // LabelModelClassName
            // 
            this.LabelModelClassName.AutoSize = true;
            this.LabelModelClassName.Location = new System.Drawing.Point(12, 228);
            this.LabelModelClassName.Name = "LabelModelClassName";
            this.LabelModelClassName.Size = new System.Drawing.Size(106, 15);
            this.LabelModelClassName.TabIndex = 2;
            this.LabelModelClassName.Text = "Model Class Name";
            // 
            // LabelPropertiesEntitty
            // 
            this.LabelPropertiesEntitty.AutoSize = true;
            this.LabelPropertiesEntitty.Location = new System.Drawing.Point(12, 42);
            this.LabelPropertiesEntitty.Name = "LabelPropertiesEntitty";
            this.LabelPropertiesEntitty.Size = new System.Drawing.Size(389, 15);
            this.LabelPropertiesEntitty.TabIndex = 4;
            this.LabelPropertiesEntitty.Text = "Enter class properties - Type and Name \"ex: string - FirstName; int - Age\"";
            // 
            // LabelPropertiesModel
            // 
            this.LabelPropertiesModel.AutoSize = true;
            this.LabelPropertiesModel.Location = new System.Drawing.Point(12, 280);
            this.LabelPropertiesModel.Name = "LabelPropertiesModel";
            this.LabelPropertiesModel.Size = new System.Drawing.Size(389, 15);
            this.LabelPropertiesModel.TabIndex = 5;
            this.LabelPropertiesModel.Text = "Enter class properties - Type and Name \"ex: string - FirstName; int - Age\"";
            // 
            // InputPropertiesEntity
            // 
            this.InputPropertiesEntity.Location = new System.Drawing.Point(13, 60);
            this.InputPropertiesEntity.Name = "InputPropertiesEntity";
            this.InputPropertiesEntity.Size = new System.Drawing.Size(559, 145);
            this.InputPropertiesEntity.TabIndex = 6;
            this.InputPropertiesEntity.Text = "";
            // 
            // InputPropertiesModel
            // 
            this.InputPropertiesModel.Location = new System.Drawing.Point(12, 299);
            this.InputPropertiesModel.Name = "InputPropertiesModel";
            this.InputPropertiesModel.Size = new System.Drawing.Size(560, 154);
            this.InputPropertiesModel.TabIndex = 7;
            this.InputPropertiesModel.Text = "";
            // 
            // InputControllerClassName
            // 
            this.InputControllerClassName.Location = new System.Drawing.Point(763, 12);
            this.InputControllerClassName.Name = "InputControllerClassName";
            this.InputControllerClassName.Size = new System.Drawing.Size(218, 23);
            this.InputControllerClassName.TabIndex = 9;
            // 
            // ControllerClassName
            // 
            this.ControllerClassName.AutoSize = true;
            this.ControllerClassName.Location = new System.Drawing.Point(632, 15);
            this.ControllerClassName.Name = "ControllerClassName";
            this.ControllerClassName.Size = new System.Drawing.Size(125, 15);
            this.ControllerClassName.TabIndex = 8;
            this.ControllerClassName.Text = "Controller Class Name";
            // 
            // InputServiceClassName
            // 
            this.InputServiceClassName.Location = new System.Drawing.Point(763, 76);
            this.InputServiceClassName.Name = "InputServiceClassName";
            this.InputServiceClassName.Size = new System.Drawing.Size(218, 23);
            this.InputServiceClassName.TabIndex = 11;
            // 
            // ServiceClassName
            // 
            this.ServiceClassName.AutoSize = true;
            this.ServiceClassName.Location = new System.Drawing.Point(631, 79);
            this.ServiceClassName.Name = "ServiceClassName";
            this.ServiceClassName.Size = new System.Drawing.Size(109, 15);
            this.ServiceClassName.TabIndex = 10;
            this.ServiceClassName.Text = "Service Class Name";
            // 
            // InputRepositoryClassName
            // 
            this.InputRepositoryClassName.Location = new System.Drawing.Point(763, 145);
            this.InputRepositoryClassName.Name = "InputRepositoryClassName";
            this.InputRepositoryClassName.Size = new System.Drawing.Size(218, 23);
            this.InputRepositoryClassName.TabIndex = 13;
            // 
            // RepositoryClassName
            // 
            this.RepositoryClassName.AutoSize = true;
            this.RepositoryClassName.Location = new System.Drawing.Point(631, 148);
            this.RepositoryClassName.Name = "RepositoryClassName";
            this.RepositoryClassName.Size = new System.Drawing.Size(128, 15);
            this.RepositoryClassName.TabIndex = 12;
            this.RepositoryClassName.Text = "Repository Class Name";
            // 
            // BtnGenerate
            // 
            this.BtnGenerate.Location = new System.Drawing.Point(1013, 560);
            this.BtnGenerate.Name = "BtnGenerate";
            this.BtnGenerate.Size = new System.Drawing.Size(209, 71);
            this.BtnGenerate.TabIndex = 14;
            this.BtnGenerate.Text = "Generate";
            this.BtnGenerate.UseVisualStyleBackColor = true;
            this.BtnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // LabelWarmController
            // 
            this.LabelWarmController.AutoSize = true;
            this.LabelWarmController.ForeColor = System.Drawing.Color.Red;
            this.LabelWarmController.Location = new System.Drawing.Point(633, 39);
            this.LabelWarmController.Name = "LabelWarmController";
            this.LabelWarmController.Size = new System.Drawing.Size(608, 15);
            this.LabelWarmController.TabIndex = 15;
            this.LabelWarmController.Text = "Enter only the first name and the system will complete the full name of the class" +
    " ex: \"Student = StudentController\"";
            // 
            // LabelWarmService
            // 
            this.LabelWarmService.AutoSize = true;
            this.LabelWarmService.ForeColor = System.Drawing.Color.Red;
            this.LabelWarmService.Location = new System.Drawing.Point(632, 102);
            this.LabelWarmService.Name = "LabelWarmService";
            this.LabelWarmService.Size = new System.Drawing.Size(592, 15);
            this.LabelWarmService.TabIndex = 16;
            this.LabelWarmService.Text = "Enter only the first name and the system will complete the full name of the class" +
    " ex: \"Student = StudentService\"";
            // 
            // LabelWarmRepository
            // 
            this.LabelWarmRepository.AutoSize = true;
            this.LabelWarmRepository.ForeColor = System.Drawing.Color.Red;
            this.LabelWarmRepository.Location = new System.Drawing.Point(632, 172);
            this.LabelWarmRepository.Name = "LabelWarmRepository";
            this.LabelWarmRepository.Size = new System.Drawing.Size(611, 15);
            this.LabelWarmRepository.TabIndex = 17;
            this.LabelWarmRepository.Text = "Enter only the first name and the system will complete the full name of the class" +
    " ex: \"Student = StudentRepository\"";
            // 
            // LabelWarmModel
            // 
            this.LabelWarmModel.AutoSize = true;
            this.LabelWarmModel.ForeColor = System.Drawing.Color.Red;
            this.LabelWarmModel.Location = new System.Drawing.Point(11, 257);
            this.LabelWarmModel.Name = "LabelWarmModel";
            this.LabelWarmModel.Size = new System.Drawing.Size(589, 15);
            this.LabelWarmModel.TabIndex = 18;
            this.LabelWarmModel.Text = "Enter only the first name and the system will complete the full name of the class" +
    " ex: \"Student = StudentModel\"";
            // 
            // InputTableName
            // 
            this.InputTableName.Location = new System.Drawing.Point(772, 219);
            this.InputTableName.Name = "InputTableName";
            this.InputTableName.Size = new System.Drawing.Size(209, 23);
            this.InputTableName.TabIndex = 19;
            // 
            // LabelTableName
            // 
            this.LabelTableName.AutoSize = true;
            this.LabelTableName.Location = new System.Drawing.Point(629, 224);
            this.LabelTableName.Name = "LabelTableName";
            this.LabelTableName.Size = new System.Drawing.Size(140, 15);
            this.LabelTableName.TabIndex = 20;
            this.LabelTableName.Text = "Table Name with Schema";
            // 
            // LableTableNameExemplo
            // 
            this.LableTableNameExemplo.AutoSize = true;
            this.LableTableNameExemplo.Location = new System.Drawing.Point(630, 248);
            this.LableTableNameExemplo.Name = "LableTableNameExemplo";
            this.LableTableNameExemplo.Size = new System.Drawing.Size(297, 15);
            this.LableTableNameExemplo.TabIndex = 21;
            this.LableTableNameExemplo.Text = "Enter Table Name with Schema Ex: \"[dbo].[tb_student]\"";
            // 
            // InputFieldsTable
            // 
            this.InputFieldsTable.Location = new System.Drawing.Point(630, 299);
            this.InputFieldsTable.Name = "InputFieldsTable";
            this.InputFieldsTable.Size = new System.Drawing.Size(592, 154);
            this.InputFieldsTable.TabIndex = 23;
            this.InputFieldsTable.Text = "";
            // 
            // LabelFieldsTable
            // 
            this.LabelFieldsTable.AutoSize = true;
            this.LabelFieldsTable.Location = new System.Drawing.Point(629, 281);
            this.LabelFieldsTable.Name = "LabelFieldsTable";
            this.LabelFieldsTable.Size = new System.Drawing.Size(530, 15);
            this.LabelFieldsTable.TabIndex = 22;
            this.LabelFieldsTable.Text = "Enter the table fields - key and value \"ex: INT IDENTITY(1,1) - Id; VARCHAR(200) " +
    "NOT NULL - Name;\"";
            // 
            // LabelPrimaryKeyExemplo
            // 
            this.LabelPrimaryKeyExemplo.AutoSize = true;
            this.LabelPrimaryKeyExemplo.Location = new System.Drawing.Point(631, 502);
            this.LabelPrimaryKeyExemplo.Name = "LabelPrimaryKeyExemplo";
            this.LabelPrimaryKeyExemplo.Size = new System.Drawing.Size(318, 15);
            this.LabelPrimaryKeyExemplo.TabIndex = 26;
            this.LabelPrimaryKeyExemplo.Text = "Enter the Primary Key Name and Field Ex: \"PK_Student - Id\"";
            // 
            // LabelPrimaryKeyName
            // 
            this.LabelPrimaryKeyName.AutoSize = true;
            this.LabelPrimaryKeyName.Location = new System.Drawing.Point(630, 477);
            this.LabelPrimaryKeyName.Name = "LabelPrimaryKeyName";
            this.LabelPrimaryKeyName.Size = new System.Drawing.Size(105, 15);
            this.LabelPrimaryKeyName.TabIndex = 25;
            this.LabelPrimaryKeyName.Text = "Primary Key Name";
            // 
            // InputPrimaryKeyName
            // 
            this.InputPrimaryKeyName.Location = new System.Drawing.Point(742, 472);
            this.InputPrimaryKeyName.Name = "InputPrimaryKeyName";
            this.InputPrimaryKeyName.Size = new System.Drawing.Size(240, 23);
            this.InputPrimaryKeyName.TabIndex = 24;
            // 
            // CheckUtils
            // 
            this.CheckUtils.AutoSize = true;
            this.CheckUtils.Location = new System.Drawing.Point(859, 612);
            this.CheckUtils.Name = "CheckUtils";
            this.CheckUtils.Size = new System.Drawing.Size(104, 19);
            this.CheckUtils.TabIndex = 27;
            this.CheckUtils.Text = "Generate Utils?";
            this.CheckUtils.UseVisualStyleBackColor = true;
            // 
            // GenerateCrud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1288, 662);
            this.Controls.Add(this.CheckUtils);
            this.Controls.Add(this.LabelPrimaryKeyExemplo);
            this.Controls.Add(this.LabelPrimaryKeyName);
            this.Controls.Add(this.InputPrimaryKeyName);
            this.Controls.Add(this.InputFieldsTable);
            this.Controls.Add(this.LabelFieldsTable);
            this.Controls.Add(this.LableTableNameExemplo);
            this.Controls.Add(this.LabelTableName);
            this.Controls.Add(this.InputTableName);
            this.Controls.Add(this.LabelWarmModel);
            this.Controls.Add(this.LabelWarmRepository);
            this.Controls.Add(this.LabelWarmService);
            this.Controls.Add(this.LabelWarmController);
            this.Controls.Add(this.BtnGenerate);
            this.Controls.Add(this.InputRepositoryClassName);
            this.Controls.Add(this.RepositoryClassName);
            this.Controls.Add(this.InputServiceClassName);
            this.Controls.Add(this.ServiceClassName);
            this.Controls.Add(this.InputControllerClassName);
            this.Controls.Add(this.ControllerClassName);
            this.Controls.Add(this.InputPropertiesModel);
            this.Controls.Add(this.InputPropertiesEntity);
            this.Controls.Add(this.LabelPropertiesModel);
            this.Controls.Add(this.LabelPropertiesEntitty);
            this.Controls.Add(this.InputModelClassName);
            this.Controls.Add(this.LabelModelClassName);
            this.Controls.Add(this.InputEntityClassName);
            this.Controls.Add(this.LabelEntityClassName);
            this.Name = "GenerateCrud";
            this.Text = "Generate Crud";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

