namespace Equipment_Management
{
    partial class 资料借阅管理
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lendDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ryidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lendCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rynameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Flag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataLendBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.equipment_Management_Information_SystemDataSet6 = new Equipment_Management.Equipment_Management_Information_SystemDataSet6();
            this.dataLendBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.equipment_Management_Information_SystemDataSet3 = new Equipment_Management.Equipment_Management_Information_SystemDataSet3();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.dataLendTableAdapter = new Equipment_Management.Equipment_Management_Information_SystemDataSet3TableAdapters.DataLendTableAdapter();
            this.dataLendTableAdapter1 = new Equipment_Management.Equipment_Management_Information_SystemDataSet6TableAdapters.DataLendTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLendBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipment_Management_Information_SystemDataSet6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLendBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipment_Management_Information_SystemDataSet3)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.dataNoDataGridViewTextBoxColumn,
            this.lendDateDataGridViewTextBoxColumn,
            this.ryidDataGridViewTextBoxColumn,
            this.lendCountDataGridViewTextBoxColumn,
            this.rynameDataGridViewTextBoxColumn,
            this.Flag});
            this.dataGridView1.DataSource = this.dataLendBindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(12, 21);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(926, 314);
            this.dataGridView1.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "借阅号";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // dataNoDataGridViewTextBoxColumn
            // 
            this.dataNoDataGridViewTextBoxColumn.DataPropertyName = "DataNo";
            this.dataNoDataGridViewTextBoxColumn.HeaderText = "资料编号";
            this.dataNoDataGridViewTextBoxColumn.Name = "dataNoDataGridViewTextBoxColumn";
            // 
            // lendDateDataGridViewTextBoxColumn
            // 
            this.lendDateDataGridViewTextBoxColumn.DataPropertyName = "LendDate";
            this.lendDateDataGridViewTextBoxColumn.HeaderText = "借阅日期";
            this.lendDateDataGridViewTextBoxColumn.Name = "lendDateDataGridViewTextBoxColumn";
            // 
            // ryidDataGridViewTextBoxColumn
            // 
            this.ryidDataGridViewTextBoxColumn.DataPropertyName = "Ryid";
            this.ryidDataGridViewTextBoxColumn.HeaderText = "借阅人编号";
            this.ryidDataGridViewTextBoxColumn.Name = "ryidDataGridViewTextBoxColumn";
            // 
            // lendCountDataGridViewTextBoxColumn
            // 
            this.lendCountDataGridViewTextBoxColumn.DataPropertyName = "LendCount";
            this.lendCountDataGridViewTextBoxColumn.HeaderText = "借阅数量";
            this.lendCountDataGridViewTextBoxColumn.Name = "lendCountDataGridViewTextBoxColumn";
            // 
            // rynameDataGridViewTextBoxColumn
            // 
            this.rynameDataGridViewTextBoxColumn.DataPropertyName = "Ryname";
            this.rynameDataGridViewTextBoxColumn.HeaderText = "批准人";
            this.rynameDataGridViewTextBoxColumn.Name = "rynameDataGridViewTextBoxColumn";
            // 
            // Flag
            // 
            this.Flag.DataPropertyName = "Flag";
            this.Flag.HeaderText = "标记";
            this.Flag.Name = "Flag";
            // 
            // dataLendBindingSource1
            // 
            this.dataLendBindingSource1.DataMember = "DataLend";
            this.dataLendBindingSource1.DataSource = this.equipment_Management_Information_SystemDataSet6;
            // 
            // equipment_Management_Information_SystemDataSet6
            // 
            this.equipment_Management_Information_SystemDataSet6.DataSetName = "Equipment_Management_Information_SystemDataSet6";
            this.equipment_Management_Information_SystemDataSet6.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataLendBindingSource
            // 
            this.dataLendBindingSource.DataMember = "DataLend";
            this.dataLendBindingSource.DataSource = this.equipment_Management_Information_SystemDataSet3;
            // 
            // equipment_Management_Information_SystemDataSet3
            // 
            this.equipment_Management_Information_SystemDataSet3.DataSetName = "Equipment_Management_Information_SystemDataSet3";
            this.equipment_Management_Information_SystemDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 357);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "添加";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(190, 357);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "删除";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(358, 356);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "借阅确认";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(517, 357);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "归还";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(654, 356);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 5;
            this.button5.Text = "归还确认";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // dataLendTableAdapter
            // 
            this.dataLendTableAdapter.ClearBeforeFill = true;
            // 
            // dataLendTableAdapter1
            // 
            this.dataLendTableAdapter1.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(965, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "0-借阅";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(965, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "1-借阅确认";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(968, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "2-归还";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(968, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "3-归还确认";
            // 
            // 资料借阅管理
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 445);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "资料借阅管理";
            this.Text = "资料借阅管理";
            this.Load += new System.EventHandler(this.资料借阅管理_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLendBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipment_Management_Information_SystemDataSet6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLendBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipment_Management_Information_SystemDataSet3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private Equipment_Management_Information_SystemDataSet3 equipment_Management_Information_SystemDataSet3;
        private System.Windows.Forms.BindingSource dataLendBindingSource;
        private Equipment_Management_Information_SystemDataSet3TableAdapters.DataLendTableAdapter dataLendTableAdapter;
        private Equipment_Management_Information_SystemDataSet6 equipment_Management_Information_SystemDataSet6;
        private System.Windows.Forms.BindingSource dataLendBindingSource1;
        private Equipment_Management_Information_SystemDataSet6TableAdapters.DataLendTableAdapter dataLendTableAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lendDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ryidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lendCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rynameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Flag;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}