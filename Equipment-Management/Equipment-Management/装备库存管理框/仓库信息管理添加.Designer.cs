namespace Equipment_Management.装备库存管理框
{
    partial class 仓库信息管理添加
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
            this.仓库信息管理添加添加 = new System.Windows.Forms.Button();
            this.仓库信息管理添加取消 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.仓库信息管理添加仓库编号 = new System.Windows.Forms.TextBox();
            this.仓库信息管理添加仓库名称 = new System.Windows.Forms.TextBox();
            this.仓库信息管理添加仓库备注 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // 仓库信息管理添加添加
            // 
            this.仓库信息管理添加添加.Location = new System.Drawing.Point(72, 301);
            this.仓库信息管理添加添加.Name = "仓库信息管理添加添加";
            this.仓库信息管理添加添加.Size = new System.Drawing.Size(75, 23);
            this.仓库信息管理添加添加.TabIndex = 0;
            this.仓库信息管理添加添加.Text = "添加";
            this.仓库信息管理添加添加.UseVisualStyleBackColor = true;
            this.仓库信息管理添加添加.Click += new System.EventHandler(this.仓库信息管理添加添加_Click);
            // 
            // 仓库信息管理添加取消
            // 
            this.仓库信息管理添加取消.Location = new System.Drawing.Point(210, 301);
            this.仓库信息管理添加取消.Name = "仓库信息管理添加取消";
            this.仓库信息管理添加取消.Size = new System.Drawing.Size(75, 23);
            this.仓库信息管理添加取消.TabIndex = 1;
            this.仓库信息管理添加取消.Text = "取消";
            this.仓库信息管理添加取消.UseVisualStyleBackColor = true;
            this.仓库信息管理添加取消.Click += new System.EventHandler(this.仓库信息管理添加取消_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "仓库编号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "仓库名称";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "仓库备注";
            // 
            // 仓库信息管理添加仓库编号
            // 
            this.仓库信息管理添加仓库编号.Location = new System.Drawing.Point(140, 34);
            this.仓库信息管理添加仓库编号.Name = "仓库信息管理添加仓库编号";
            this.仓库信息管理添加仓库编号.Size = new System.Drawing.Size(100, 21);
            this.仓库信息管理添加仓库编号.TabIndex = 5;
            this.仓库信息管理添加仓库编号.TextChanged += new System.EventHandler(this.仓库信息管理添加仓库编号_TextChanged);
            // 
            // 仓库信息管理添加仓库名称
            // 
            this.仓库信息管理添加仓库名称.Location = new System.Drawing.Point(140, 96);
            this.仓库信息管理添加仓库名称.Name = "仓库信息管理添加仓库名称";
            this.仓库信息管理添加仓库名称.Size = new System.Drawing.Size(100, 21);
            this.仓库信息管理添加仓库名称.TabIndex = 6;
            // 
            // 仓库信息管理添加仓库备注
            // 
            this.仓库信息管理添加仓库备注.Location = new System.Drawing.Point(140, 173);
            this.仓库信息管理添加仓库备注.Multiline = true;
            this.仓库信息管理添加仓库备注.Name = "仓库信息管理添加仓库备注";
            this.仓库信息管理添加仓库备注.Size = new System.Drawing.Size(145, 100);
            this.仓库信息管理添加仓库备注.TabIndex = 7;
            // 
            // 仓库信息管理添加
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.仓库信息管理添加仓库备注);
            this.Controls.Add(this.仓库信息管理添加仓库名称);
            this.Controls.Add(this.仓库信息管理添加仓库编号);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.仓库信息管理添加取消);
            this.Controls.Add(this.仓库信息管理添加添加);
            this.Name = "仓库信息管理添加";
            this.Text = "仓库信息管理添加";
            this.Load += new System.EventHandler(this.仓库信息管理添加_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button 仓库信息管理添加添加;
        private System.Windows.Forms.Button 仓库信息管理添加取消;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox 仓库信息管理添加仓库编号;
        private System.Windows.Forms.TextBox 仓库信息管理添加仓库名称;
        private System.Windows.Forms.TextBox 仓库信息管理添加仓库备注;
    }
}