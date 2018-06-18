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
    public partial class 资料信息管理 : Form
    {
        public 资料信息管理()
        {
            InitializeComponent();
        }

        private void 资料信息管理_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“equipment_Management_Information_SystemDataSet4.ArmsData”中。您可以根据需要移动或删除它。
            this.armsDataTableAdapter.Fill(this.equipment_Management_Information_SystemDataSet4.ArmsData);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            mystr.i = 1;
            mystr.data = dataGridView1;
            编辑资料信息 do_zlxx = new 编辑资料信息();
            do_zlxx.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
             mystr.i = 2;
            mystr.data = dataGridView1;
            编辑资料信息 do_zlxx = new 编辑资料信息();
            do_zlxx.Show();
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
                cmd.CommandText = "delete from ArmsData where[DataNo]='" + mystr.str + "'";
                cmd.ExecuteNonQuery();
                DataSet dsMyDataBase = new DataSet();
                SqlDataAdapter daBaseInform = new SqlDataAdapter("Select*From ArmsData", DBClass_xu.conn);
                daBaseInform.Fill(dsMyDataBase, "ArmsData");
                dataGridView1.DataSource = dsMyDataBase.Tables["ArmsData"];
                MessageBox.Show("成功删除数据");
                DBClass_xu.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "打开数据库失败");
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            mystr.str = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            展示资料信息 show_zlxx = new 展示资料信息();
            show_zlxx.Show();
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (DBClass_xu.conn.State != ConnectionState.Open)//检查连接状态是否为已连接
                {
                    DBClass_xu.conn.Open();
                }
                
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBClass_xu.conn;
                cmd.CommandText = "Insert DataLend(Id,DataNo,LendDate,Ryid,LendCount,Ryname,Flag)values('" + 001 + "','" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "','" + System.DateTime.Now.ToString() + "','" + 2016081090 + "','" + 1 + "','" + "无" + "','" + 0 + "')";
                cmd.ExecuteNonQuery();
/*
                DataSet dsMyDataBase = new DataSet();
                SqlDataAdapter daBaseInform = new SqlDataAdapter("Select*From DataLend", DBClass_xu.conn);
                daBaseInform.Fill(dsMyDataBase, "DataLend");

                mystr.data.DataSource = dsMyDataBase.Tables["DataLend"];  */
                MessageBox.Show("借阅成功");
                DBClass_xu.conn.Close();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + " 打开数据库失败");
            }
        }
    }
}
