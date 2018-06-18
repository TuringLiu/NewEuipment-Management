using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Equipment_Management.Program;

namespace Equipment_Management
{
    
    public partial class 资料类型管理 : Form
    {
        public 资料类型管理()
        {
            
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mystr.i = 1;
            编辑资料类型 do_zllx = new 编辑资料类型();
            do_zllx.Show();
            mystr.data = dataGridView1;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            mystr.i = 2;
            编辑资料类型 do_zllx = new 编辑资料类型();
            do_zllx.Show();
            mystr.data = dataGridView1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void 资料类型管理_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“equipment_Management_Information_SystemDataSet10.DataTypes”中。您可以根据需要移动或删除它。
            this.dataTypesTableAdapter2.Fill(this.equipment_Management_Information_SystemDataSet10.DataTypes);


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            mystr.str = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            try
            {
                if (DBClass_xu.conn.State != ConnectionState.Open)//检查连接状态是否为已连接
                {
                    DBClass_xu.conn.Open();
                }
                
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBClass_xu.conn;
                cmd.CommandText = "delete from DataTypes where[TypeId]='" + mystr.str + "'";
                cmd.ExecuteNonQuery();
                DataSet dsMyDataBase = new DataSet();
                SqlDataAdapter daBaseInform = new SqlDataAdapter("Select*From DataTypes", DBClass_xu.conn);
                daBaseInform.Fill(dsMyDataBase, "DataTypes");
                dataGridView1.DataSource = dsMyDataBase.Tables["DataTypes"];
                MessageBox.Show("成功删除数据");
                DBClass_xu.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "打开数据库失败");
            }
        }
    }
}
