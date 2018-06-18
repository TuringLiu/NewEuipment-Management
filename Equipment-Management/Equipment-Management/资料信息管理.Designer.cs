namespace Equipment_Management
{
    partial class 资料信息管理
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
            this.dataNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.armsDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.equipment_Management_Information_SystemDataSet4 = new Equipment_Management.Equipment_Management_Information_SystemDataSet4();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.armsDataTableAdapter = new Equipment_Management.Equipment_Management_Information_SystemDataSet4TableAdapters.ArmsDataTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.armsDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipment_Management_Information_SystemDataSet4)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataNoDataGridViewTextBoxColumn,
            this.dataNameDataGridViewTextBoxColumn,
            this.typeIdDataGridViewTextBoxColumn,
            this.iCountDataGridViewTextBoxColumn,
            this.iPriceDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.armsDataBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(13, 13);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(753, 277);
            this.dataGridView1.TabIndex = 0;
            // 
            // dataNoDataGridViewTextBoxColumn
            // 
            this.dataNoDataGridViewTextBoxColumn.DataPropertyName = "DataNo";
            this.dataNoDataGridViewTextBoxColumn.HeaderText = "资料编号";
            this.dataNoDataGridViewTextBoxColumn.Name = "dataNoDataGridViewTextBoxColumn";
            // 
            // dataNameDataGridViewTextBoxColumn
            // 
            this.dataNameDataGridViewTextBoxColumn.DataPropertyName = "DataName";
            this.dataNameDataGridViewTextBoxColumn.HeaderText = "资料名称";
            this.dataNameDataGridViewTextBoxColumn.Name = "dataNameDataGridViewTextBoxColumn";
            // 
            // typeIdDataGridViewTextBoxColumn
            // 
            this.typeIdDataGridViewTextBoxColumn.DataPropertyName = "TypeId";
            this.typeIdDataGridViewTextBoxColumn.HeaderText = "资料分类编号";
            this.typeIdDataGridViewTextBoxColumn.Name = "typeIdDataGridViewTextBoxColumn";
            // 
            // iCountDataGridViewTextBoxColumn
            // 
            this.iCountDataGridViewTextBoxColumn.DataPropertyName = "ICount";
            this.iCountDataGridViewTextBoxColumn.HeaderText = "数量";
            this.iCountDataGridViewTextBoxColumn.Name = "iCountDataGridViewTextBoxColumn";
            // 
            // iPriceDataGridViewTextBoxColumn
            // 
            this.iPriceDataGridViewTextBoxColumn.DataPropertyName = "IPrice";
            this.iPriceDataGridViewTextBoxColumn.HeaderText = "价格";
            this.iPriceDataGridViewTextBoxColumn.Name = "iPriceDataGridViewTextBoxColumn";
            // 
            // armsDataBindingSource
            // 
            this.armsDataBindingSource.DataMember = "ArmsData";
            this.armsDataBindingSource.DataSource = this.equipment_Management_Information_SystemDataSet4;
            // 
            // equipment_Management_Information_SystemDataSet4
            // 
            this.equipment_Management_Information_SystemDataSet4.DataSetName = "Equipment_Management_Information_SystemDataSet4";
            this.equipment_Management_Information_SystemDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 343);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "添加";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(189, 343);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "删除";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(355, 343);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "修改";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(535, 343);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "查看";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(691, 343);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 5;
            this.button5.Text = "借阅";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // armsDataTableAdapter
            // 
            this.armsDataTableAdapter.ClearBeforeFill = true;
            // 
            // 资料信息管理
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 406);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "资料信息管理";
            this.Text = "资料信息管理";
            this.Load += new System.EventHandler(this.资料信息管理_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.armsDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipment_Management_Information_SystemDataSet4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private Equipment_Management_Information_SystemDataSet4 equipment_Management_Information_SystemDataSet4;
        private System.Windows.Forms.BindingSource armsDataBindingSource;
        private Equipment_Management_Information_SystemDataSet4TableAdapters.ArmsDataTableAdapter armsDataTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iPriceDataGridViewTextBoxColumn;
    }
}