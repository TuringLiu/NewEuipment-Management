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
    public partial class 资料借阅管理 : Form
    {
        public 资料借阅管理()
        {
            InitializeComponent();
        }

        private void 资料借阅管理_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“equipment_Management_Information_SystemDataSet6.DataLend”中。您可以根据需要移动或删除它。
            this.dataLendTableAdapter1.Fill(this.equipment_Management_Information_SystemDataSet6.DataLend);
            // TODO: 这行代码将数据加载到表“equipment_Management_Information_SystemDataSet3.DataLend”中。您可以根据需要移动或删除它。
            this.dataLendTableAdapter.Fill(this.equipment_Management_Information_SystemDataSet3.DataLend);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            mystr.i = 1;
            mystr.data = dataGridView1;
            编辑借阅 do_zljy = new 编辑借阅();
            do_zljy.Show();
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
                cmd.CommandText = "delete from DataLend where[Id]='" + mystr.str + "'";
                cmd.ExecuteNonQuery();
                DataSet dsMyDataBase = new DataSet();
                SqlDataAdapter daBaseInform = new SqlDataAdapter("Select*From DataLend", DBClass_xu.conn);
                daBaseInform.Fill(dsMyDataBase, "DataLend");
                dataGridView1.DataSource = dsMyDataBase.Tables["DataLend"];
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
                if ((int)dataGridView1.CurrentRow.Cells[6].Value == 1)
                {
                    if (DBClass_xu.conn.State != ConnectionState.Open)//检查连接状态是否为已连接
                    {
                        DBClass_xu.conn.Open();
                    }
                    int i = 2;
                   
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = DBClass_xu.conn;
                    cmd.CommandText = "Update DataLend set[Id]='" + dataGridView1.CurrentRow.Cells[0].Value + "'" +
                        ",[DataNo]='" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "'" +
                        ",[LendDate]='" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "'" +
                        ",[Ryid]='" + dataGridView1.CurrentRow.Cells[3].Value + "'" +
                        ",[LendCount]='" + dataGridView1.CurrentRow.Cells[4].Value + "'" +
                        ",[Ryname]='" + dataGridView1.CurrentRow.Cells[5].Value.ToString() + "'" +
                        ",[Flag]='" + i + "'" +
                        "where[Id]='" + dataGridView1.CurrentRow.Cells[0].Value + "'";
                    cmd.ExecuteNonQuery();

                    DataSet dsMyDataBase = new DataSet();
                    SqlDataAdapter daBaseInform = new SqlDataAdapter("Select*From DataLend", DBClass_xu.conn);
                    daBaseInform.Fill(dsMyDataBase, "DataLend");

                    dataGridView1.DataSource = dsMyDataBase.Tables["DataLend"];
                    MessageBox.Show("归还成功");
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

        private void button3_Click(object sender, EventArgs e)
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
                    cmd.CommandText = "Update DataLend set[Id]='" + dataGridView1.CurrentRow.Cells[0].Value + "'" +
                        ",[DataNo]='" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "'" +
                        ",[LendDate]='" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "'" +
                        ",[Ryid]='" + dataGridView1.CurrentRow.Cells[3].Value + "'" +
                        ",[LendCount]='" + dataGridView1.CurrentRow.Cells[4].Value + "'" +
                        //               当前管理人员RyName
                        ",[Ryname]='" + "徐嘉豪" + "'" +
                        ",[Flag]='" + i + "'" +
                        "where[Id]='" + dataGridView1.CurrentRow.Cells[0].Value + "'";
                    cmd.ExecuteNonQuery();

                    DataSet dsMyDataBase = new DataSet();
                    SqlDataAdapter daBaseInform = new SqlDataAdapter("Select*From DataLend", DBClass_xu.conn);
                    daBaseInform.Fill(dsMyDataBase, "DataLend");

                    dataGridView1.DataSource = dsMyDataBase.Tables["DataLend"];
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
            try
            {
                if ((int)dataGridView1.CurrentRow.Cells[6].Value == 2)
                {
                    if (DBClass_xu.conn.State != ConnectionState.Open)//检查连接状态是否为已连接
                    {
                        DBClass_xu.conn.Open();
                    }
                    int i = 3;
                    
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = DBClass_xu.conn;
                    cmd.CommandText = "Update DataLend set[Id]='" + dataGridView1.CurrentRow.Cells[0].Value + "'" +
                        ",[DataNo]='" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "'" +
                        ",[LendDate]='" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "'" +
                        ",[Ryid]='" + dataGridView1.CurrentRow.Cells[3].Value + "'" +
                        ",[LendCount]='" + dataGridView1.CurrentRow.Cells[4].Value + "'" +
                        ",[Ryname]='" + dataGridView1.CurrentRow.Cells[5].Value.ToString() + "'" +
                        ",[Flag]='" + i + "'" +
                        "where[Id]='" + dataGridView1.CurrentRow.Cells[0].Value + "'";
                    cmd.ExecuteNonQuery();

                    DataSet dsMyDataBase = new DataSet();
                    SqlDataAdapter daBaseInform = new SqlDataAdapter("Select*From DataLend", DBClass_xu.conn);
                    daBaseInform.Fill(dsMyDataBase, "DataLend");

                    dataGridView1.DataSource = dsMyDataBase.Tables["DataLend"];
                    MessageBox.Show("归还确认成功");
                    DBClass_xu.conn.Close();
                }
                else
                    MessageBox.Show("该书未归还!", "失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + " 打开数据库失败");
            }
        }
    }
    
}
