namespace Cathedra
{
    partial class FormReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBoxWorkloadType = new System.Windows.Forms.GroupBox();
            this.radioButtonZaochniki = new System.Windows.Forms.RadioButton();
            this.radioButtonOchniki = new System.Windows.Forms.RadioButton();
            this.labelSemestr = new System.Windows.Forms.Label();
            this.comboBoxSemestr = new System.Windows.Forms.ComboBox();
            this.semestrBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBoxSchoolYear = new System.Windows.Forms.ComboBox();
            this.schoolYearBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelSchoolYear = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.documentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBoxWorkloadType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.semestrBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schoolYearBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxWorkloadType
            // 
            this.groupBoxWorkloadType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxWorkloadType.Controls.Add(this.radioButtonZaochniki);
            this.groupBoxWorkloadType.Controls.Add(this.radioButtonOchniki);
            this.groupBoxWorkloadType.Location = new System.Drawing.Point(18, 105);
            this.groupBoxWorkloadType.Name = "groupBoxWorkloadType";
            this.groupBoxWorkloadType.Size = new System.Drawing.Size(343, 37);
            this.groupBoxWorkloadType.TabIndex = 23;
            this.groupBoxWorkloadType.TabStop = false;
            this.groupBoxWorkloadType.Text = "Тип нагрузки";
            // 
            // radioButtonZaochniki
            // 
            this.radioButtonZaochniki.AutoSize = true;
            this.radioButtonZaochniki.Location = new System.Drawing.Point(170, 14);
            this.radioButtonZaochniki.Name = "radioButtonZaochniki";
            this.radioButtonZaochniki.Size = new System.Drawing.Size(73, 17);
            this.radioButtonZaochniki.TabIndex = 0;
            this.radioButtonZaochniki.Text = "Заочники";
            this.radioButtonZaochniki.UseVisualStyleBackColor = true;
            // 
            // radioButtonOchniki
            // 
            this.radioButtonOchniki.AutoSize = true;
            this.radioButtonOchniki.Checked = true;
            this.radioButtonOchniki.Location = new System.Drawing.Point(17, 14);
            this.radioButtonOchniki.Name = "radioButtonOchniki";
            this.radioButtonOchniki.Size = new System.Drawing.Size(62, 17);
            this.radioButtonOchniki.TabIndex = 0;
            this.radioButtonOchniki.TabStop = true;
            this.radioButtonOchniki.Text = "Очники";
            this.radioButtonOchniki.UseVisualStyleBackColor = true;
            // 
            // labelSemestr
            // 
            this.labelSemestr.AutoSize = true;
            this.labelSemestr.Location = new System.Drawing.Point(18, 50);
            this.labelSemestr.Name = "labelSemestr";
            this.labelSemestr.Size = new System.Drawing.Size(54, 13);
            this.labelSemestr.TabIndex = 20;
            this.labelSemestr.Text = "Семестр:";
            // 
            // comboBoxSemestr
            // 
            this.comboBoxSemestr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSemestr.DataSource = this.semestrBindingSource;
            this.comboBoxSemestr.FormattingEnabled = true;
            this.comboBoxSemestr.Location = new System.Drawing.Point(188, 50);
            this.comboBoxSemestr.Name = "comboBoxSemestr";
            this.comboBoxSemestr.Size = new System.Drawing.Size(173, 21);
            this.comboBoxSemestr.TabIndex = 18;
            // 
            // semestrBindingSource
            // 
            this.semestrBindingSource.DataSource = typeof(Cathedra.Data.Semestr);
            // 
            // comboBoxSchoolYear
            // 
            this.comboBoxSchoolYear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSchoolYear.DataSource = this.schoolYearBindingSource;
            this.comboBoxSchoolYear.FormattingEnabled = true;
            this.comboBoxSchoolYear.Location = new System.Drawing.Point(188, 23);
            this.comboBoxSchoolYear.Name = "comboBoxSchoolYear";
            this.comboBoxSchoolYear.Size = new System.Drawing.Size(173, 21);
            this.comboBoxSchoolYear.TabIndex = 19;
            // 
            // schoolYearBindingSource
            // 
            this.schoolYearBindingSource.DataSource = typeof(Cathedra.Data.SchoolYear);
            // 
            // labelSchoolYear
            // 
            this.labelSchoolYear.AutoSize = true;
            this.labelSchoolYear.Location = new System.Drawing.Point(18, 26);
            this.labelSchoolYear.Name = "labelSchoolYear";
            this.labelSchoolYear.Size = new System.Drawing.Size(75, 13);
            this.labelSchoolYear.TabIndex = 17;
            this.labelSchoolYear.Text = "Учебный год:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(286, 148);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 22;
            this.buttonCancel.Text = "Выход";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonCreate
            // 
            this.buttonCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCreate.Location = new System.Drawing.Point(174, 148);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(106, 23);
            this.buttonCreate.TabIndex = 21;
            this.buttonCreate.Text = "Сформировать";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Документ:";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DataSource = this.documentsBindingSource;
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(188, 77);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(173, 21);
            this.comboBox1.TabIndex = 24;
            this.comboBox1.ValueMember = "DocumentId";
            // 
            // documentsBindingSource
            // 
            this.documentsBindingSource.DataSource = typeof(Cathedra.Data.Documents);
            // 
            // FormReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 183);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.groupBoxWorkloadType);
            this.Controls.Add(this.labelSemestr);
            this.Controls.Add(this.comboBoxSemestr);
            this.Controls.Add(this.comboBoxSchoolYear);
            this.Controls.Add(this.labelSchoolYear);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonCreate);
            this.Name = "FormReport";
            this.Text = "FormReport";
            this.groupBoxWorkloadType.ResumeLayout(false);
            this.groupBoxWorkloadType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.semestrBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schoolYearBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxWorkloadType;
        private System.Windows.Forms.RadioButton radioButtonZaochniki;
        private System.Windows.Forms.RadioButton radioButtonOchniki;
        private System.Windows.Forms.Label labelSemestr;
        private System.Windows.Forms.ComboBox comboBoxSemestr;
        private System.Windows.Forms.ComboBox comboBoxSchoolYear;
        private System.Windows.Forms.Label labelSchoolYear;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.BindingSource semestrBindingSource;
        private System.Windows.Forms.BindingSource schoolYearBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.BindingSource documentsBindingSource;
    }
}