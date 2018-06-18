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
    public partial class 资料归档管理 : Form
    {
        public 资料归档管理()
        {
            InitializeComponent();
        }

        private void 资料归档管理_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“equipment_Management_Information_SystemDataSet2.DataIn”中。您可以根据需要移动或删除它。
            this.dataInTableAdapter.Fill(this.equipment_Management_Information_SystemDataSet2.DataIn);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            mystr.i = 1;
            mystr.data = dataGridView1;
            编辑资料归档 do_zlgd = new 编辑资料归档();
            do_zlgd.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int j = int.Parse(dataGridView1.CurrentRow.Cells[6].Value.ToString());
            if (j != 1)
            {
                mystr.i = 2;
                mystr.num = (int)dataGridView1.CurrentRow.Cells[0].Value;
                mystr.str = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                编辑资料归档 do_zlgd = new 编辑资料归档();
                do_zlgd.Show();
            }
            else
                MessageBox.Show("该资料已审核无法修改", "wrong", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mystr.num = (int)dataGridView1.CurrentRow.Cells[0].Value;
            try
            {
                if (DBClass_xu.conn.State != ConnectionState.Open)//检查连接状态是否为已连接
                {
                    DBClass_xu.conn.Open();
                }
                
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBClass_xu.conn;
                cmd.CommandText = "delete from DataIn where[Id]='" + mystr.num + "'";
                cmd.ExecuteNonQuery();
                DataSet dsMyDataBase = new DataSet();
                SqlDataAdapter daBaseInform = new SqlDataAdapter("Select*From Datain", DBClass_xu.conn);
                daBaseInform.Fill(dsMyDataBase, "DataIn");
                dataGridView1.DataSource = dsMyDataBase.Tables["DataIn"];
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
            try
            {
                if ((int)dataGridView1.CurrentRow.Cells[6].Value == 0)
                {
                    if (DBClass_xu.conn.State != ConnectionState.Open)//检查连接状态是否为已连接
                    {
                        DBClass_xu.conn.Open();
                    }
                    int i = 1;
                   
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = DBClass_xu.conn;
                    cmd.CommandText = "Update DataIn set[Id]='" + dataGridView1.CurrentRow.Cells[0].Value + "'" +
                        ",[InDate]='" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "'" +
                        ",[DataNo]='" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "'" +
                        ",[InCount]='" + dataGridView1.CurrentRow.Cells[3].Value + "'" +
                        ",[Usersname]='" + dataGridView1.CurrentRow.Cells[4].Value + "'" +
                        //               审批人的名字
                        ",[Ryname]='" + "徐嘉豪" + "'" +
                        ",[Detail]='" + dataGridView1.CurrentRow.Cells[5].Value.ToString() + "'" +
                        ",[Flag]='" + i + "'" +
                        "where[Id]='" + dataGridView1.CurrentRow.Cells[0].Value + "'";
                    cmd.ExecuteNonQuery();

                    DataSet dsMyDataBase = new DataSet();
                    SqlDataAdapter daBaseInform = new SqlDataAdapter("Select*From DataIn", DBClass_xu.conn);
                    daBaseInform.Fill(dsMyDataBase, "DataIn");

                    dataGridView1.DataSource = dsMyDataBase.Tables["DataIn"];
                    MessageBox.Show("借阅确认成功");
                    DBClass_xu.conn.Close();
                }
                else
                    MessageBox.Show("该书未借阅!", "失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + " 打开数据库失败");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            mystr.num = (int)dataGridView1.CurrentRow.Cells[0].Value;
            展示归档信息 show_gdxx = new 展示归档信息();
            show_gdxx.Show();
        }
    }
}
