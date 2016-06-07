namespace Cathedra
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.распределитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поВладельцамКурсовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.лабараторныеРаботыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вКРИРуководствоМагистрантовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вКРИРуководствоМагистрантовToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поАудиторнымЗанятиямToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поПреподователямToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.дляВыбранногоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.дляВсехToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.fioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.postIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nonActiveDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.phoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.postDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shortNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rateInHoursDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workLoadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.underloadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.overloadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rateFormDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isOverloadDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isUnderloadDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.maskDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.summHorseOnLabDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.распределитьToolStripMenuItem,
            this.отчетыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(788, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // распределитьToolStripMenuItem
            // 
            this.распределитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.поВладельцамКурсовToolStripMenuItem,
            this.лабараторныеРаботыToolStripMenuItem,
            this.вКРИРуководствоМагистрантовToolStripMenuItem,
            this.вКРИРуководствоМагистрантовToolStripMenuItem1});
            this.распределитьToolStripMenuItem.Name = "распределитьToolStripMenuItem";
            this.распределитьToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.распределитьToolStripMenuItem.Text = "Распределить";
            // 
            // поВладельцамКурсовToolStripMenuItem
            // 
            this.поВладельцамКурсовToolStripMenuItem.Name = "поВладельцамКурсовToolStripMenuItem";
            this.поВладельцамКурсовToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.поВладельцамКурсовToolStripMenuItem.Text = "По владельцам курсов";
            this.поВладельцамКурсовToolStripMenuItem.Click += new System.EventHandler(this.поВладельцамКурсовToolStripMenuItem_Click);
            // 
            // лабараторныеРаботыToolStripMenuItem
            // 
            this.лабараторныеРаботыToolStripMenuItem.Name = "лабараторныеРаботыToolStripMenuItem";
            this.лабараторныеРаботыToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.лабараторныеРаботыToolStripMenuItem.Text = "Лабараторные работы";
            this.лабараторныеРаботыToolStripMenuItem.Click += new System.EventHandler(this.лабараторныеРаботыToolStripMenuItem_Click);
            // 
            // вКРИРуководствоМагистрантовToolStripMenuItem
            // 
            this.вКРИРуководствоМагистрантовToolStripMenuItem.Name = "вКРИРуководствоМагистрантовToolStripMenuItem";
            this.вКРИРуководствоМагистрантовToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.вКРИРуководствоМагистрантовToolStripMenuItem.Text = "Курсовые работы и проекты";
            this.вКРИРуководствоМагистрантовToolStripMenuItem.Click += new System.EventHandler(this.вКРИРуководствоМагистрантовToolStripMenuItem_Click);
            // 
            // вКРИРуководствоМагистрантовToolStripMenuItem1
            // 
            this.вКРИРуководствоМагистрантовToolStripMenuItem1.Name = "вКРИРуководствоМагистрантовToolStripMenuItem1";
            this.вКРИРуководствоМагистрантовToolStripMenuItem1.Size = new System.Drawing.Size(256, 22);
            this.вКРИРуководствоМагистрантовToolStripMenuItem1.Text = "ВКР и руководство магистрантов";
            this.вКРИРуководствоМагистрантовToolStripMenuItem1.Click += new System.EventHandler(this.вКРИРуководствоМагистрантовToolStripMenuItem1_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.поАудиторнымЗанятиямToolStripMenuItem,
            this.поПреподователямToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // поАудиторнымЗанятиямToolStripMenuItem
            // 
            this.поАудиторнымЗанятиямToolStripMenuItem.Name = "поАудиторнымЗанятиямToolStripMenuItem";
            this.поАудиторнымЗанятиямToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.поАудиторнымЗанятиямToolStripMenuItem.Text = "По аудиторным занятиям";
            this.поАудиторнымЗанятиямToolStripMenuItem.Click += new System.EventHandler(this.поАудиторнымЗанятиямToolStripMenuItem_Click);
            // 
            // поПреподователямToolStripMenuItem
            // 
            this.поПреподователямToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.дляВыбранногоToolStripMenuItem,
            this.дляВсехToolStripMenuItem});
            this.поПреподователямToolStripMenuItem.Name = "поПреподователямToolStripMenuItem";
            this.поПреподователямToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.поПреподователямToolStripMenuItem.Text = "По преподователям";
            // 
            // дляВыбранногоToolStripMenuItem
            // 
            this.дляВыбранногоToolStripMenuItem.Name = "дляВыбранногоToolStripMenuItem";
            this.дляВыбранногоToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.дляВыбранногоToolStripMenuItem.Text = "Для выбранного";
            this.дляВыбранногоToolStripMenuItem.Click += new System.EventHandler(this.дляВыбранногоToolStripMenuItem_Click);
            // 
            // дляВсехToolStripMenuItem
            // 
            this.дляВсехToolStripMenuItem.Name = "дляВсехToolStripMenuItem";
            this.дляВсехToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.дляВсехToolStripMenuItem.Text = "Для всех";
            this.дляВсехToolStripMenuItem.Click += new System.EventHandler(this.поПреподователямToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fioDataGridViewTextBoxColumn,
            this.idDataGridViewTextBoxColumn,
            this.commentDataGridViewTextBoxColumn,
            this.postIDDataGridViewTextBoxColumn,
            this.nonActiveDataGridViewCheckBoxColumn,
            this.phoneDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn,
            this.postDataGridViewTextBoxColumn,
            this.shortNameDataGridViewTextBoxColumn,
            this.rateInHoursDataGridViewTextBoxColumn,
            this.workLoadDataGridViewTextBoxColumn,
            this.underloadDataGridViewTextBoxColumn,
            this.overloadDataGridViewTextBoxColumn,
            this.rateFormDataGridViewTextBoxColumn,
            this.isOverloadDataGridViewCheckBoxColumn,
            this.isUnderloadDataGridViewCheckBoxColumn,
            this.maskDataGridViewTextBoxColumn,
            this.summHorseOnLabDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.employeeBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(764, 371);
            this.dataGridView1.TabIndex = 1;
            // 
            // fioDataGridViewTextBoxColumn
            // 
            this.fioDataGridViewTextBoxColumn.DataPropertyName = "Fio";
            this.fioDataGridViewTextBoxColumn.HeaderText = "Fio";
            this.fioDataGridViewTextBoxColumn.Name = "fioDataGridViewTextBoxColumn";
            this.fioDataGridViewTextBoxColumn.ReadOnly = true;
            this.fioDataGridViewTextBoxColumn.Width = 300;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // commentDataGridViewTextBoxColumn
            // 
            this.commentDataGridViewTextBoxColumn.DataPropertyName = "Comment";
            this.commentDataGridViewTextBoxColumn.HeaderText = "Comment";
            this.commentDataGridViewTextBoxColumn.Name = "commentDataGridViewTextBoxColumn";
            this.commentDataGridViewTextBoxColumn.ReadOnly = true;
            this.commentDataGridViewTextBoxColumn.Visible = false;
            // 
            // postIDDataGridViewTextBoxColumn
            // 
            this.postIDDataGridViewTextBoxColumn.DataPropertyName = "PostID";
            this.postIDDataGridViewTextBoxColumn.HeaderText = "PostID";
            this.postIDDataGridViewTextBoxColumn.Name = "postIDDataGridViewTextBoxColumn";
            this.postIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.postIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // nonActiveDataGridViewCheckBoxColumn
            // 
            this.nonActiveDataGridViewCheckBoxColumn.DataPropertyName = "NonActive";
            this.nonActiveDataGridViewCheckBoxColumn.HeaderText = "NonActive";
            this.nonActiveDataGridViewCheckBoxColumn.Name = "nonActiveDataGridViewCheckBoxColumn";
            this.nonActiveDataGridViewCheckBoxColumn.ReadOnly = true;
            this.nonActiveDataGridViewCheckBoxColumn.Visible = false;
            // 
            // phoneDataGridViewTextBoxColumn
            // 
            this.phoneDataGridViewTextBoxColumn.DataPropertyName = "Phone";
            this.phoneDataGridViewTextBoxColumn.HeaderText = "Phone";
            this.phoneDataGridViewTextBoxColumn.Name = "phoneDataGridViewTextBoxColumn";
            this.phoneDataGridViewTextBoxColumn.ReadOnly = true;
            this.phoneDataGridViewTextBoxColumn.Visible = false;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "E_mail";
            this.emailDataGridViewTextBoxColumn.HeaderText = "E_mail";
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            this.emailDataGridViewTextBoxColumn.ReadOnly = true;
            this.emailDataGridViewTextBoxColumn.Visible = false;
            // 
            // postDataGridViewTextBoxColumn
            // 
            this.postDataGridViewTextBoxColumn.DataPropertyName = "Post";
            this.postDataGridViewTextBoxColumn.HeaderText = "Post";
            this.postDataGridViewTextBoxColumn.Name = "postDataGridViewTextBoxColumn";
            this.postDataGridViewTextBoxColumn.ReadOnly = true;
            this.postDataGridViewTextBoxColumn.Visible = false;
            // 
            // shortNameDataGridViewTextBoxColumn
            // 
            this.shortNameDataGridViewTextBoxColumn.DataPropertyName = "ShortName";
            this.shortNameDataGridViewTextBoxColumn.HeaderText = "ShortName";
            this.shortNameDataGridViewTextBoxColumn.Name = "shortNameDataGridViewTextBoxColumn";
            this.shortNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.shortNameDataGridViewTextBoxColumn.Visible = false;
            // 
            // rateInHoursDataGridViewTextBoxColumn
            // 
            this.rateInHoursDataGridViewTextBoxColumn.DataPropertyName = "RateInHours";
            this.rateInHoursDataGridViewTextBoxColumn.HeaderText = "Всего часов";
            this.rateInHoursDataGridViewTextBoxColumn.Name = "rateInHoursDataGridViewTextBoxColumn";
            this.rateInHoursDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // workLoadDataGridViewTextBoxColumn
            // 
            this.workLoadDataGridViewTextBoxColumn.DataPropertyName = "WorkLoad";
            this.workLoadDataGridViewTextBoxColumn.HeaderText = "Загружен";
            this.workLoadDataGridViewTextBoxColumn.Name = "workLoadDataGridViewTextBoxColumn";
            this.workLoadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // underloadDataGridViewTextBoxColumn
            // 
            this.underloadDataGridViewTextBoxColumn.DataPropertyName = "Underload";
            this.underloadDataGridViewTextBoxColumn.HeaderText = "Недогружен";
            this.underloadDataGridViewTextBoxColumn.Name = "underloadDataGridViewTextBoxColumn";
            this.underloadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // overloadDataGridViewTextBoxColumn
            // 
            this.overloadDataGridViewTextBoxColumn.DataPropertyName = "Overload";
            this.overloadDataGridViewTextBoxColumn.HeaderText = "Перегружен";
            this.overloadDataGridViewTextBoxColumn.Name = "overloadDataGridViewTextBoxColumn";
            this.overloadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rateFormDataGridViewTextBoxColumn
            // 
            this.rateFormDataGridViewTextBoxColumn.DataPropertyName = "RateForm";
            this.rateFormDataGridViewTextBoxColumn.HeaderText = "RateForm";
            this.rateFormDataGridViewTextBoxColumn.Name = "rateFormDataGridViewTextBoxColumn";
            this.rateFormDataGridViewTextBoxColumn.ReadOnly = true;
            this.rateFormDataGridViewTextBoxColumn.Visible = false;
            // 
            // isOverloadDataGridViewCheckBoxColumn
            // 
            this.isOverloadDataGridViewCheckBoxColumn.DataPropertyName = "IsOverload";
            this.isOverloadDataGridViewCheckBoxColumn.HeaderText = "IsOverload";
            this.isOverloadDataGridViewCheckBoxColumn.Name = "isOverloadDataGridViewCheckBoxColumn";
            this.isOverloadDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isOverloadDataGridViewCheckBoxColumn.Visible = false;
            // 
            // isUnderloadDataGridViewCheckBoxColumn
            // 
            this.isUnderloadDataGridViewCheckBoxColumn.DataPropertyName = "IsUnderload";
            this.isUnderloadDataGridViewCheckBoxColumn.HeaderText = "IsUnderload";
            this.isUnderloadDataGridViewCheckBoxColumn.Name = "isUnderloadDataGridViewCheckBoxColumn";
            this.isUnderloadDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isUnderloadDataGridViewCheckBoxColumn.Visible = false;
            // 
            // maskDataGridViewTextBoxColumn
            // 
            this.maskDataGridViewTextBoxColumn.DataPropertyName = "Mask";
            this.maskDataGridViewTextBoxColumn.HeaderText = "Mask";
            this.maskDataGridViewTextBoxColumn.Name = "maskDataGridViewTextBoxColumn";
            this.maskDataGridViewTextBoxColumn.ReadOnly = true;
            this.maskDataGridViewTextBoxColumn.Visible = false;
            // 
            // summHorseOnLabDataGridViewTextBoxColumn
            // 
            this.summHorseOnLabDataGridViewTextBoxColumn.DataPropertyName = "SummHorseOnLab";
            this.summHorseOnLabDataGridViewTextBoxColumn.HeaderText = "SummHorseOnLab";
            this.summHorseOnLabDataGridViewTextBoxColumn.Name = "summHorseOnLabDataGridViewTextBoxColumn";
            this.summHorseOnLabDataGridViewTextBoxColumn.ReadOnly = true;
            this.summHorseOnLabDataGridViewTextBoxColumn.Visible = false;
            // 
            // employeeBindingSource
            // 
            this.employeeBindingSource.DataSource = typeof(Cathedra.Data.Employee);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 410);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem распределитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поВладельцамКурсовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem лабараторныеРаботыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вКРИРуководствоМагистрантовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вКРИРуководствоМагистрантовToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поАудиторнымЗанятиямToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поПреподователямToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem дляВыбранногоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem дляВсехToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource employeeBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn fioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn commentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn postIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn nonActiveDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn postDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shortNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rateInHoursDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn workLoadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn underloadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn overloadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rateFormDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isOverloadDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isUnderloadDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maskDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn summHorseOnLabDataGridViewTextBoxColumn;
    }
}

