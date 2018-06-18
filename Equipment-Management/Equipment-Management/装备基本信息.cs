using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static Equipment_Management.Program;

namespace Equipment_Management
{
    public partial class 装备基本信息 : Form
    {
        static public int i = 0;
        public 装备基本信息()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            i = 1;
            mystr.data = dataGridView1;
            编辑装备信息 do_zbxx = new 编辑装备信息();
            do_zbxx.Show();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            i = 2;
            mystr.str = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            mystr.data = dataGridView1;
            编辑装备信息 do_zbxx = new 编辑装备信息();
            do_zbxx.Show();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        

        }

        private void 装备基本信息_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“equipment_Management_Information_SystemDataSet.ArmsInfo”中。您可以根据需要移动或删除它。
            this.armsInfoTableAdapter.Fill(this.equipment_Management_Information_SystemDataSet.ArmsInfo);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
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
                cmd.CommandText = "delete from ArmsInfo where[Zbid]='" + mystr.str + "'";
                cmd.ExecuteNonQuery();

                DataSet dsMyDataBase = new DataSet();
                SqlDataAdapter daBaseInform = new SqlDataAdapter("Select*From ArmsInfo", DBClass_xu.conn);
                daBaseInform.Fill(dsMyDataBase, "ArmsInfo");
                dataGridView1.DataSource = dsMyDataBase.Tables["ArmsInfo"];
                MessageBox.Show("成功删除数据");
                DBClass_xu.conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "打开数据库失败");
            }
        }
    }
}
