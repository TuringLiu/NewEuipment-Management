namespace Equipment_Management
{
    partial class 资料归档管理
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
            this.inDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usersnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rynameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flagDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataInBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.equipment_Management_Information_SystemDataSet2 = new Equipment_Management.Equipment_Management_Information_SystemDataSet2();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dataInTableAdapter = new Equipment_Management.Equipment_Management_Information_SystemDataSet2TableAdapters.DataInTableAdapter();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataInBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipment_Management_Information_SystemDataSet2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.inDateDataGridViewTextBoxColumn,
            this.dataNoDataGridViewTextBoxColumn,
            this.inCountDataGridViewTextBoxColumn,
            this.usersnameDataGridViewTextBoxColumn,
            this.rynameDataGridViewTextBoxColumn,
            this.flagDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.dataInBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(13, 13);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(973, 305);
            this.dataGridView1.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "归档号";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // inDateDataGridViewTextBoxColumn
            // 
            this.inDateDataGridViewTextBoxColumn.DataPropertyName = "InDate";
            this.inDateDataGridViewTextBoxColumn.HeaderText = "归档日期";
            this.inDateDataGridViewTextBoxColumn.Name = "inDateDataGridViewTextBoxColumn";
            // 
            // dataNoDataGridViewTextBoxColumn
            // 
            this.dataNoDataGridViewTextBoxColumn.DataPropertyName = "DataNo";
            this.dataNoDataGridViewTextBoxColumn.HeaderText = "资料编号";
            this.dataNoDataGridViewTextBoxColumn.Name = "dataNoDataGridViewTextBoxColumn";
            // 
            // inCountDataGridViewTextBoxColumn
            // 
            this.inCountDataGridViewTextBoxColumn.DataPropertyName = "InCount";
            this.inCountDataGridViewTextBoxColumn.HeaderText = "归档数量";
            this.inCountDataGridViewTextBoxColumn.Name = "inCountDataGridViewTextBoxColumn";
            // 
            // usersnameDataGridViewTextBoxColumn
            // 
            this.usersnameDataGridViewTextBoxColumn.DataPropertyName = "Usersname";
            this.usersnameDataGridViewTextBoxColumn.HeaderText = "经办人";
            this.usersnameDataGridViewTextBoxColumn.Name = "usersnameDataGridViewTextBoxColumn";
            // 
            // rynameDataGridViewTextBoxColumn
            // 
            this.rynameDataGridViewTextBoxColumn.DataPropertyName = "Ryname";
            this.rynameDataGridViewTextBoxColumn.HeaderText = "审批人";
            this.rynameDataGridViewTextBoxColumn.Name = "rynameDataGridViewTextBoxColumn";
            // 
            // flagDataGridViewTextBoxColumn
            // 
            this.flagDataGridViewTextBoxColumn.DataPropertyName = "Flag";
            this.flagDataGridViewTextBoxColumn.HeaderText = "审批标记";
            this.flagDataGridViewTextBoxColumn.Name = "flagDataGridViewTextBoxColumn";
            // 
            // dataInBindingSource
            // 
            this.dataInBindingSource.DataMember = "DataIn";
            this.dataInBindingSource.DataSource = this.equipment_Management_Information_SystemDataSet2;
            // 
            // equipment_Management_Information_SystemDataSet2
            // 
            this.equipment_Management_Information_SystemDataSet2.DataSetName = "Equipment_Management_Information_SystemDataSet2";
            this.equipment_Management_Information_SystemDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 352);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "增加";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(170, 351);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "删除";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(340, 352);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "修改";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(509, 352);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "审核";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dataInTableAdapter
            // 
            this.dataInTableAdapter.ClearBeforeFill = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(668, 351);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 5;
            this.button5.Text = "查看";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // 资料归档管理
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 460);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "资料归档管理";
            this.Text = "资料归档管理";
            this.Load += new System.EventHandler(this.资料归档管理_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataInBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipment_Management_Information_SystemDataSet2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private Equipment_Management_Information_SystemDataSet2 equipment_Management_Information_SystemDataSet2;
        private System.Windows.Forms.BindingSource dataInBindingSource;
        private Equipment_Management_Information_SystemDataSet2TableAdapters.DataInTableAdapter dataInTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn inDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn inCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usersnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rynameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn flagDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button5;
    }
}