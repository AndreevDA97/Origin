namespace Cathedra
{
    partial class FormEditLoad
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxGroups = new System.Windows.Forms.GroupBox();
            this.panelGroups = new System.Windows.Forms.Panel();
            this.cbGroup1 = new System.Windows.Forms.ComboBox();
            this.btnGroupAdd = new System.Windows.Forms.Button();
            this.btnGroupDelete = new System.Windows.Forms.Button();
            this.groupBoxGeneralnfo = new System.Windows.Forms.GroupBox();
            this.lblCourseName = new System.Windows.Forms.Label();
            this.cbCourseName = new System.Windows.Forms.ComboBox();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.cbEmployee = new System.Windows.Forms.ComboBox();
            this.lblSemestr = new System.Windows.Forms.Label();
            this.cbSemestr = new System.Windows.Forms.ComboBox();
            this.lblFormStudy = new System.Windows.Forms.Label();
            this.cbFormStudy = new System.Windows.Forms.ComboBox();
            this.groupBoxStudyLoads = new System.Windows.Forms.GroupBox();
            this.ctlSortLoads = new System.Windows.Forms.DataGridView();
            this.idColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sortLoadColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countHoursColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBoxYear = new System.Windows.Forms.ComboBox();
            this.comboBoxDocument = new System.Windows.Forms.ComboBox();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBoxGroups.SuspendLayout();
            this.panelGroups.SuspendLayout();
            this.groupBoxGeneralnfo.SuspendLayout();
            this.groupBoxStudyLoads.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctlSortLoads)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxGroups
            // 
            this.groupBoxGroups.Controls.Add(this.panelGroups);
            this.groupBoxGroups.Controls.Add(this.btnGroupAdd);
            this.groupBoxGroups.Controls.Add(this.btnGroupDelete);
            this.groupBoxGroups.Location = new System.Drawing.Point(6, 307);
            this.groupBoxGroups.Name = "groupBoxGroups";
            this.groupBoxGroups.Size = new System.Drawing.Size(272, 160);
            this.groupBoxGroups.TabIndex = 24;
            this.groupBoxGroups.TabStop = false;
            this.groupBoxGroups.Text = "Группы";
            // 
            // panelGroups
            // 
            this.panelGroups.Controls.Add(this.cbGroup1);
            this.panelGroups.Location = new System.Drawing.Point(4, 20);
            this.panelGroups.Name = "panelGroups";
            this.panelGroups.Size = new System.Drawing.Size(124, 128);
            this.panelGroups.TabIndex = 12;
            // 
            // cbGroup1
            // 
            this.cbGroup1.FormattingEnabled = true;
            this.cbGroup1.ItemHeight = 13;
            this.cbGroup1.Location = new System.Drawing.Point(0, 0);
            this.cbGroup1.Name = "cbGroup1";
            this.cbGroup1.Size = new System.Drawing.Size(121, 21);
            this.cbGroup1.TabIndex = 0;
            // 
            // btnGroupAdd
            // 
            this.btnGroupAdd.Location = new System.Drawing.Point(132, 20);
            this.btnGroupAdd.Name = "btnGroupAdd";
            this.btnGroupAdd.Size = new System.Drawing.Size(68, 23);
            this.btnGroupAdd.TabIndex = 1;
            this.btnGroupAdd.Text = "Добавить";
            this.btnGroupAdd.UseVisualStyleBackColor = true;
            this.btnGroupAdd.Click += new System.EventHandler(this.btnGroupAdd_Click);
            // 
            // btnGroupDelete
            // 
            this.btnGroupDelete.Location = new System.Drawing.Point(200, 20);
            this.btnGroupDelete.Name = "btnGroupDelete";
            this.btnGroupDelete.Size = new System.Drawing.Size(64, 23);
            this.btnGroupDelete.TabIndex = 13;
            this.btnGroupDelete.Text = "Удалить";
            this.btnGroupDelete.UseVisualStyleBackColor = true;
            this.btnGroupDelete.Click += new System.EventHandler(this.btnGroupDelete_Click);
            // 
            // groupBoxGeneralnfo
            // 
            this.groupBoxGeneralnfo.Controls.Add(this.lblCourseName);
            this.groupBoxGeneralnfo.Controls.Add(this.cbCourseName);
            this.groupBoxGeneralnfo.Controls.Add(this.lblEmployee);
            this.groupBoxGeneralnfo.Controls.Add(this.cbEmployee);
            this.groupBoxGeneralnfo.Controls.Add(this.lblSemestr);
            this.groupBoxGeneralnfo.Controls.Add(this.cbSemestr);
            this.groupBoxGeneralnfo.Controls.Add(this.lblFormStudy);
            this.groupBoxGeneralnfo.Controls.Add(this.cbFormStudy);
            this.groupBoxGeneralnfo.Location = new System.Drawing.Point(2, 75);
            this.groupBoxGeneralnfo.Name = "groupBoxGeneralnfo";
            this.groupBoxGeneralnfo.Size = new System.Drawing.Size(496, 216);
            this.groupBoxGeneralnfo.TabIndex = 23;
            this.groupBoxGeneralnfo.TabStop = false;
            this.groupBoxGeneralnfo.Text = "Общая информация";
            // 
            // lblCourseName
            // 
            this.lblCourseName.AutoSize = true;
            this.lblCourseName.Location = new System.Drawing.Point(8, 24);
            this.lblCourseName.Name = "lblCourseName";
            this.lblCourseName.Size = new System.Drawing.Size(89, 13);
            this.lblCourseName.TabIndex = 2;
            this.lblCourseName.Text = "Название курса";
            // 
            // cbCourseName
            // 
            this.cbCourseName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbCourseName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbCourseName.FormattingEnabled = true;
            this.cbCourseName.Location = new System.Drawing.Point(8, 40);
            this.cbCourseName.Name = "cbCourseName";
            this.cbCourseName.Size = new System.Drawing.Size(396, 21);
            this.cbCourseName.TabIndex = 3;
            this.cbCourseName.SelectedIndexChanged += new System.EventHandler(this.cbCourseName_SelectedIndexChanged);
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Location = new System.Drawing.Point(8, 72);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(88, 13);
            this.lblEmployee.TabIndex = 4;
            this.lblEmployee.Text = "Владелец курса";
            // 
            // cbEmployee
            // 
            this.cbEmployee.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbEmployee.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbEmployee.FormattingEnabled = true;
            this.cbEmployee.Location = new System.Drawing.Point(8, 88);
            this.cbEmployee.Name = "cbEmployee";
            this.cbEmployee.Size = new System.Drawing.Size(308, 21);
            this.cbEmployee.TabIndex = 5;
            // 
            // lblSemestr
            // 
            this.lblSemestr.AutoSize = true;
            this.lblSemestr.Location = new System.Drawing.Point(8, 120);
            this.lblSemestr.Name = "lblSemestr";
            this.lblSemestr.Size = new System.Drawing.Size(51, 13);
            this.lblSemestr.TabIndex = 6;
            this.lblSemestr.Text = "Семестр";
            // 
            // cbSemestr
            // 
            this.cbSemestr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSemestr.FormattingEnabled = true;
            this.cbSemestr.Location = new System.Drawing.Point(11, 136);
            this.cbSemestr.Name = "cbSemestr";
            this.cbSemestr.Size = new System.Drawing.Size(104, 21);
            this.cbSemestr.TabIndex = 8;
            this.cbSemestr.SelectedValueChanged += new System.EventHandler(this.cbSemestr_SelectedValueChanged);
            // 
            // lblFormStudy
            // 
            this.lblFormStudy.AutoSize = true;
            this.lblFormStudy.Location = new System.Drawing.Point(8, 168);
            this.lblFormStudy.Name = "lblFormStudy";
            this.lblFormStudy.Size = new System.Drawing.Size(93, 13);
            this.lblFormStudy.TabIndex = 7;
            this.lblFormStudy.Text = "Форма обучения";
            // 
            // cbFormStudy
            // 
            this.cbFormStudy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFormStudy.FormattingEnabled = true;
            this.cbFormStudy.Location = new System.Drawing.Point(11, 184);
            this.cbFormStudy.Name = "cbFormStudy";
            this.cbFormStudy.Size = new System.Drawing.Size(100, 21);
            this.cbFormStudy.TabIndex = 9;
            this.cbFormStudy.SelectedValueChanged += new System.EventHandler(this.cbFormStudy_SelectedValueChanged);
            // 
            // groupBoxStudyLoads
            // 
            this.groupBoxStudyLoads.Controls.Add(this.ctlSortLoads);
            this.groupBoxStudyLoads.Location = new System.Drawing.Point(504, 75);
            this.groupBoxStudyLoads.Name = "groupBoxStudyLoads";
            this.groupBoxStudyLoads.Size = new System.Drawing.Size(309, 358);
            this.groupBoxStudyLoads.TabIndex = 22;
            this.groupBoxStudyLoads.TabStop = false;
            this.groupBoxStudyLoads.Text = "Учебная нагрузка";
            // 
            // ctlSortLoads
            // 
            this.ctlSortLoads.AllowUserToAddRows = false;
            this.ctlSortLoads.AllowUserToDeleteRows = false;
            this.ctlSortLoads.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ctlSortLoads.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ctlSortLoads.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctlSortLoads.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idColumn,
            this.sortLoadColumn,
            this.countHoursColumn});
            this.ctlSortLoads.Location = new System.Drawing.Point(6, 11);
            this.ctlSortLoads.MultiSelect = false;
            this.ctlSortLoads.Name = "ctlSortLoads";
            this.ctlSortLoads.Size = new System.Drawing.Size(297, 343);
            this.ctlSortLoads.TabIndex = 10;
            this.ctlSortLoads.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.ctlSortLoads_CellEndEdit);
            // 
            // idColumn
            // 
            this.idColumn.HeaderText = "Ид";
            this.idColumn.Name = "idColumn";
            this.idColumn.Visible = false;
            this.idColumn.Width = 46;
            // 
            // sortLoadColumn
            // 
            this.sortLoadColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sortLoadColumn.HeaderText = "Вид нагрузки";
            this.sortLoadColumn.Name = "sortLoadColumn";
            this.sortLoadColumn.ReadOnly = true;
            // 
            // countHoursColumn
            // 
            this.countHoursColumn.HeaderText = "Количество часов";
            this.countHoursColumn.Name = "countHoursColumn";
            this.countHoursColumn.Width = 80;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(639, 443);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(84, 24);
            this.btnOK.TabIndex = 20;
            this.btnOK.Text = "Сохранить";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(729, 443);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 24);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 473);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(807, 191);
            this.dataGridView1.TabIndex = 25;
            // 
            // comboBoxYear
            // 
            this.comboBoxYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxYear.FormattingEnabled = true;
            this.comboBoxYear.Location = new System.Drawing.Point(6, 28);
            this.comboBoxYear.Name = "comboBoxYear";
            this.comboBoxYear.Size = new System.Drawing.Size(121, 21);
            this.comboBoxYear.TabIndex = 26;
            this.comboBoxYear.SelectedValueChanged += new System.EventHandler(this.comboBoxYear_SelectedValueChanged);
            // 
            // comboBoxDocument
            // 
            this.comboBoxDocument.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDocument.FormattingEnabled = true;
            this.comboBoxDocument.Location = new System.Drawing.Point(138, 28);
            this.comboBoxDocument.Name = "comboBoxDocument";
            this.comboBoxDocument.Size = new System.Drawing.Size(147, 21);
            this.comboBoxDocument.TabIndex = 27;
            this.comboBoxDocument.SelectedValueChanged += new System.EventHandler(this.comboBoxDocument_SelectedValueChanged);
            // 
            // comboBoxType
            // 
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(296, 28);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(162, 21);
            this.comboBoxType.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Учебный год";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(135, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Документ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(293, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Тип нагрузки";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(464, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 28;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.comboBoxType_SelectedValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 674);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxDocument);
            this.Controls.Add(this.comboBoxYear);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBoxGroups);
            this.Controls.Add(this.groupBoxGeneralnfo);
            this.Controls.Add(this.groupBoxStudyLoads);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxGroups.ResumeLayout(false);
            this.panelGroups.ResumeLayout(false);
            this.groupBoxGeneralnfo.ResumeLayout(false);
            this.groupBoxGeneralnfo.PerformLayout();
            this.groupBoxStudyLoads.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ctlSortLoads)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxGroups;
        private System.Windows.Forms.Panel panelGroups;
        private System.Windows.Forms.ComboBox cbGroup1;
        private System.Windows.Forms.Button btnGroupAdd;
        private System.Windows.Forms.Button btnGroupDelete;
        private System.Windows.Forms.GroupBox groupBoxGeneralnfo;
        private System.Windows.Forms.Label lblCourseName;
        private System.Windows.Forms.ComboBox cbCourseName;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.ComboBox cbEmployee;
        private System.Windows.Forms.Label lblSemestr;
        private System.Windows.Forms.ComboBox cbSemestr;
        private System.Windows.Forms.Label lblFormStudy;
        private System.Windows.Forms.ComboBox cbFormStudy;
        private System.Windows.Forms.GroupBox groupBoxStudyLoads;
        private System.Windows.Forms.DataGridView ctlSortLoads;
        private System.Windows.Forms.DataGridViewTextBoxColumn idColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sortLoadColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countHoursColumn;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBoxYear;
        private System.Windows.Forms.ComboBox comboBoxDocument;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}

