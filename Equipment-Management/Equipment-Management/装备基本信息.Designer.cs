namespace Equipment_Management
{
    partial class 装备基本信息
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.zbidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zbnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zbspecDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zbkindDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zbunitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.armsInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.equipment_Management_Information_SystemDataSet = new Equipment_Management.Equipment_Management_Information_SystemDataSet();
            this.armsInfoTableAdapter = new Equipment_Management.Equipment_Management_Information_SystemDataSetTableAdapters.ArmsInfoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.armsInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipment_Management_Information_SystemDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(33, 298);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "添加";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(251, 298);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "修改";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(482, 298);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "删除";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(669, 298);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "返回";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.zbidDataGridViewTextBoxColumn,
            this.zbnameDataGridViewTextBoxColumn,
            this.zbspecDataGridViewTextBoxColumn,
            this.zbkindDataGridViewTextBoxColumn,
            this.zbunitDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.armsInfoBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(33, 47);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(711, 218);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // zbidDataGridViewTextBoxColumn
            // 
            this.zbidDataGridViewTextBoxColumn.DataPropertyName = "Zbid";
            this.zbidDataGridViewTextBoxColumn.HeaderText = "装备编号";
            this.zbidDataGridViewTextBoxColumn.Name = "zbidDataGridViewTextBoxColumn";
            // 
            // zbnameDataGridViewTextBoxColumn
            // 
            this.zbnameDataGridViewTextBoxColumn.DataPropertyName = "Zbname";
            this.zbnameDataGridViewTextBoxColumn.HeaderText = "装备名称";
            this.zbnameDataGridViewTextBoxColumn.Name = "zbnameDataGridViewTextBoxColumn";
            // 
            // zbspecDataGridViewTextBoxColumn
            // 
            this.zbspecDataGridViewTextBoxColumn.DataPropertyName = "Zbspec";
            this.zbspecDataGridViewTextBoxColumn.HeaderText = "装备型号";
            this.zbspecDataGridViewTextBoxColumn.Name = "zbspecDataGridViewTextBoxColumn";
            // 
            // zbkindDataGridViewTextBoxColumn
            // 
            this.zbkindDataGridViewTextBoxColumn.DataPropertyName = "Zbkind";
            this.zbkindDataGridViewTextBoxColumn.HeaderText = "装备类别";
            this.zbkindDataGridViewTextBoxColumn.Name = "zbkindDataGridViewTextBoxColumn";
            // 
            // zbunitDataGridViewTextBoxColumn
            // 
            this.zbunitDataGridViewTextBoxColumn.DataPropertyName = "Zbunit";
            this.zbunitDataGridViewTextBoxColumn.HeaderText = "计量单位";
            this.zbunitDataGridViewTextBoxColumn.Name = "zbunitDataGridViewTextBoxColumn";
            // 
            // armsInfoBindingSource
            // 
            this.armsInfoBindingSource.DataMember = "ArmsInfo";
            this.armsInfoBindingSource.DataSource = this.equipment_Management_Information_SystemDataSet;
            // 
            // equipment_Management_Information_SystemDataSet
            // 
            this.equipment_Management_Information_SystemDataSet.DataSetName = "Equipment_Management_Information_SystemDataSet";
            this.equipment_Management_Information_SystemDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // armsInfoTableAdapter
            // 
            this.armsInfoTableAdapter.ClearBeforeFill = true;
            // 
            // 装备基本信息
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 389);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "装备基本信息";
            this.Text = "装备基本信息";
            this.Load += new System.EventHandler(this.装备基本信息_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.armsInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipment_Management_Information_SystemDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private Equipment_Management_Information_SystemDataSet equipment_Management_Information_SystemDataSet;
        private System.Windows.Forms.BindingSource armsInfoBindingSource;
        private Equipment_Management_Information_SystemDataSetTableAdapters.ArmsInfoTableAdapter armsInfoTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn zbidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn zbnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn zbspecDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn zbkindDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn zbunitDataGridViewTextBoxColumn;
        public System.Windows.Forms.DataGridView dataGridView1;
    }
}