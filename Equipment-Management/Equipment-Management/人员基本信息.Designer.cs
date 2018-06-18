namespace Equipment_Management
{
    partial class 人员基本信息
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
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.armsPersonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.equipment_Management_Information_SystemDataSet1 = new Equipment_Management.Equipment_Management_Information_SystemDataSet1();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.armsPersonTableAdapter = new Equipment_Management.Equipment_Management_Information_SystemDataSet1TableAdapters.ArmsPersonTableAdapter();
            this.button6 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.人员编号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.姓名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.性别 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.出生日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.职务 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.部门编号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.armsPersonBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipment_Management_Information_SystemDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(180, 358);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // armsPersonBindingSource
            // 
            this.armsPersonBindingSource.DataMember = "ArmsPerson";
            this.armsPersonBindingSource.DataSource = this.equipment_Management_Information_SystemDataSet1;
            // 
            // equipment_Management_Information_SystemDataSet1
            // 
            this.equipment_Management_Information_SystemDataSet1.DataSetName = "Equipment_Management_Information_SystemDataSet1";
            this.equipment_Management_Information_SystemDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(205, 399);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "添加";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(349, 399);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "修改";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(479, 399);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "删除";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(615, 399);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(95, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "部门调转";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(752, 399);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 6;
            this.button5.Text = "返回";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // armsPersonTableAdapter
            // 
            this.armsPersonTableAdapter.ClearBeforeFill = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(56, 399);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 7;
            this.button6.Text = "查询";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.人员编号,
            this.姓名,
            this.性别,
            this.出生日期,
            this.职务,
            this.部门编号});
            this.dataGridView1.Location = new System.Drawing.Point(205, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(866, 358);
            this.dataGridView1.TabIndex = 8;
            // 
            // 人员编号
            // 
            this.人员编号.HeaderText = "人员编号";
            this.人员编号.Name = "人员编号";
            // 
            // 姓名
            // 
            this.姓名.HeaderText = "姓名";
            this.姓名.Name = "姓名";
            // 
            // 性别
            // 
            this.性别.HeaderText = "性别";
            this.性别.Name = "性别";
            // 
            // 出生日期
            // 
            this.出生日期.HeaderText = "出生日期";
            this.出生日期.Name = "出生日期";
            // 
            // 职务
            // 
            this.职务.HeaderText = "职务";
            this.职务.Name = "职务";
            // 
            // 部门编号
            // 
            this.部门编号.HeaderText = "部门编号";
            this.部门编号.Name = "部门编号";
            // 
            // 人员基本信息
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 443);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.treeView1);
            this.Name = "人员基本信息";
            this.Text = "人员基本信息";
            this.Load += new System.EventHandler(this.人员基本信息_Load);
            ((System.ComponentModel.ISupportInitialize)(this.armsPersonBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipment_Management_Information_SystemDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private Equipment_Management_Information_SystemDataSet1 equipment_Management_Information_SystemDataSet1;
        private System.Windows.Forms.BindingSource armsPersonBindingSource;
        private Equipment_Management_Information_SystemDataSet1TableAdapters.ArmsPersonTableAdapter armsPersonTableAdapter;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 人员编号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 姓名;
        private System.Windows.Forms.DataGridViewTextBoxColumn 性别;
        private System.Windows.Forms.DataGridViewTextBoxColumn 出生日期;
        private System.Windows.Forms.DataGridViewTextBoxColumn 职务;
        private System.Windows.Forms.DataGridViewTextBoxColumn 部门编号;
    }
}