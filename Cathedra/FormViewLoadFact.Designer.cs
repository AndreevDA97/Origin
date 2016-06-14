namespace Cathedra
{
    partial class FormViewLoadFact
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxDocument = new System.Windows.Forms.ComboBox();
            this.comboBoxYear = new System.Windows.Forms.ComboBox();
            this.lblSemestr = new System.Windows.Forms.Label();
            this.cbSemestr = new System.Windows.Forms.ComboBox();
            this.lblFormStudy = new System.Windows.Forms.Label();
            this.cbFormStudy = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 47);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(958, 504);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // comboBoxType
            // 
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(513, 20);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(162, 21);
            this.comboBoxType.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(510, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Тип нагрузки";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(352, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Документ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Учебный год";
            // 
            // comboBoxDocument
            // 
            this.comboBoxDocument.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDocument.FormattingEnabled = true;
            this.comboBoxDocument.Location = new System.Drawing.Point(355, 20);
            this.comboBoxDocument.Name = "comboBoxDocument";
            this.comboBoxDocument.Size = new System.Drawing.Size(147, 21);
            this.comboBoxDocument.TabIndex = 33;
            this.comboBoxDocument.SelectedIndexChanged += new System.EventHandler(this.comboBoxDocument_SelectedValueChanged);
            this.comboBoxDocument.SelectedValueChanged += new System.EventHandler(this.comboBoxDocument_SelectedValueChanged);
            // 
            // comboBoxYear
            // 
            this.comboBoxYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxYear.FormattingEnabled = true;
            this.comboBoxYear.Location = new System.Drawing.Point(12, 20);
            this.comboBoxYear.Name = "comboBoxYear";
            this.comboBoxYear.Size = new System.Drawing.Size(121, 21);
            this.comboBoxYear.TabIndex = 31;
            this.comboBoxYear.SelectedValueChanged += new System.EventHandler(this.comboBoxYear_SelectedValueChanged);
            // 
            // lblSemestr
            // 
            this.lblSemestr.AutoSize = true;
            this.lblSemestr.Location = new System.Drawing.Point(136, 4);
            this.lblSemestr.Name = "lblSemestr";
            this.lblSemestr.Size = new System.Drawing.Size(51, 13);
            this.lblSemestr.TabIndex = 34;
            this.lblSemestr.Text = "Семестр";
            // 
            // cbSemestr
            // 
            this.cbSemestr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSemestr.FormattingEnabled = true;
            this.cbSemestr.Location = new System.Drawing.Point(139, 20);
            this.cbSemestr.Name = "cbSemestr";
            this.cbSemestr.Size = new System.Drawing.Size(104, 21);
            this.cbSemestr.TabIndex = 36;
            // 
            // lblFormStudy
            // 
            this.lblFormStudy.AutoSize = true;
            this.lblFormStudy.Location = new System.Drawing.Point(246, 4);
            this.lblFormStudy.Name = "lblFormStudy";
            this.lblFormStudy.Size = new System.Drawing.Size(93, 13);
            this.lblFormStudy.TabIndex = 35;
            this.lblFormStudy.Text = "Форма обучения";
            // 
            // cbFormStudy
            // 
            this.cbFormStudy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFormStudy.FormattingEnabled = true;
            this.cbFormStudy.Location = new System.Drawing.Point(249, 20);
            this.cbFormStudy.Name = "cbFormStudy";
            this.cbFormStudy.Size = new System.Drawing.Size(100, 21);
            this.cbFormStudy.TabIndex = 37;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(681, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 23);
            this.button1.TabIndex = 38;
            this.button1.Text = "Приминить фильтр";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.udateGridView_SelectedValueChanged);
            // 
            // FormViewLoadFact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 563);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblSemestr);
            this.Controls.Add(this.cbSemestr);
            this.Controls.Add(this.lblFormStudy);
            this.Controls.Add(this.cbFormStudy);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxDocument);
            this.Controls.Add(this.comboBoxYear);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormViewLoadFact";
            this.Text = "FormViewLoadFact";
            this.Load += new System.EventHandler(this.FormViewLoadFact_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxDocument;
        private System.Windows.Forms.ComboBox comboBoxYear;
        private System.Windows.Forms.Label lblSemestr;
        private System.Windows.Forms.ComboBox cbSemestr;
        private System.Windows.Forms.Label lblFormStudy;
        private System.Windows.Forms.ComboBox cbFormStudy;
        private System.Windows.Forms.Button button1;
    }
}