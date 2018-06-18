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

                int save = int.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString());
                if (save == 0)
                { MessageBox.Show("没有该资料，当前无法借阅"); DBClass_xu.conn.Close(); }
                else
                {
                    //                                                                                                                                                                                                                               借阅人编号 RyId       应该是一回只能借阅一本吧         
                string a = "Select Max(Id) from DataLend ";
                cmd.CommandText = a;
                increase.dataLend_id= int.Parse(cmd.ExecuteScalar().ToString())+1;

                cmd.CommandText = "Insert DataLend(Id,DataNo,LendDate,Ryid,LendCount,Ryname,Flag)values('" + increase.dataLend_id + "','" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "','" + System.DateTime.Now.ToString() + "','" + 2016081090 + "','" + 1 + "','" + "待确认" + "','" + 0 + "')";
                cmd.ExecuteNonQuery();

                MessageBox.Show("借阅成功");
                    save = save - 1;
                    cmd.CommandText = "update ArmsData set[ICount]='" + save + "'" +
                          "where[DataNo]='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";

                    cmd.ExecuteNonQuery();
                    DataSet dsMydataBase = new DataSet();
                    SqlDataAdapter daBaseInform = new SqlDataAdapter("Select*From ArmsData", DBClass_xu.conn);
                    daBaseInform.Fill(dsMydataBase, "ArmsData");

                    dataGridView1.DataSource = dsMydataBase.Tables["ArmsData"];
                    DBClass_xu.conn.Close();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + " 打开数据库失败");
            }
        }
    }
}
