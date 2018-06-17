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
using System.Collections;

namespace Equipment_Management
{

    public partial class Main : Form
    {
        ArrayList update_row = new ArrayList();
        public Main()
        {
            InitializeComponent();
        }

        private void 注销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Load load = new Load();
            load.Show();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void 添加ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            // 装备经费管理.Visible = true;
            经费使用管理.Visible = true;
            经费入账管理.Visible = false;
            系统管理.Visible = false;
            装备库存管理.Visible = false;
            统计与查询.Visible = false;
            WelcomePicture.Visible = false;
            经费使用添加.Visible = true;
            经费使用删除.Visible = false;
            经费使用修改.Visible = false;
            try
            {
                String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhaokangqiang;pwd=201608";
                SqlConnection conn = new SqlConnection(strConn);

                conn.Open();
                DataSet dsMyDataBase = new DataSet();


                SqlDataAdapter daBaseInform = new SqlDataAdapter("Select * From OutlayCost", conn);
                daBaseInform.Fill(dsMyDataBase, "OutlayCost");

                经费使用添加dataGridView6.DataSource = dsMyDataBase.Tables["OutlayCost"];
                经费使用添加dataGridView6.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                conn.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "打开数据库失败!");
            }

        }

        private void 修改ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            装备经费管理.Visible = true;
            经费使用管理.Visible = true;
            经费入账管理.Visible = false;
            系统管理.Visible = false;
            装备库存管理.Visible = false;
            统计与查询.Visible = false;
            WelcomePicture.Visible = false;
            经费使用添加.Visible = false;
            经费使用删除.Visible = false;
            经费使用修改.Visible = true;
            try
            {
                String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhaokangqiang;pwd=201608";
                SqlConnection conn = new SqlConnection(strConn);

                conn.Open();
                DataSet dsMyDataBase = new DataSet();


                SqlDataAdapter daBaseInform = new SqlDataAdapter("Select * From OutlayCost", conn);
                daBaseInform.Fill(dsMyDataBase, "OutlayCost");

                经费使用修改dataGridView1.DataSource = dsMyDataBase.Tables["OutlayCost"];
                经费使用修改dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "打开数据库失败!");
            }
        }

        private void 删除ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            装备经费管理.Visible = true;
            经费使用管理.Visible = true;
            经费入账管理.Visible = false;
            系统管理.Visible = false;
            装备库存管理.Visible = false;
            统计与查询.Visible = false;
            WelcomePicture.Visible = false;
            经费使用添加.Visible = false;
            经费使用删除.Visible = true;
            经费使用修改.Visible = false;
            try
            {
                String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhaokangqiang;pwd=201608";
                SqlConnection conn = new SqlConnection(strConn);

                conn.Open();
                DataSet dsMyDataBase = new DataSet();


                SqlDataAdapter daBaseInform = new SqlDataAdapter("Select * From OutlayCost", conn);
                daBaseInform.Fill(dsMyDataBase, "OutlayCost");

                经费使用删除dataGridView1.DataSource = dsMyDataBase.Tables["OutlayCost"];
                经费使用删除dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "打开数据库失败!");
            }
        }

        private void 添加ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            装备经费管理.Visible = true;
            经费使用管理.Visible = false;
            经费入账管理.Visible = true;
            系统管理.Visible = false;
            装备库存管理.Visible = false;
            统计与查询.Visible = false;
            WelcomePicture.Visible = false;
            经费入账添加.Visible = true;
            经费入账删除.Visible = false;
            经费入账修改.Visible = false;
            try
            {
                String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhaokangqiang;pwd=201608";
                SqlConnection conn = new SqlConnection(strConn);

                conn.Open();
                DataSet dsMyDataBase = new DataSet();


                SqlDataAdapter daBaseInform = new SqlDataAdapter("Select * From Outlayln", conn);
                daBaseInform.Fill(dsMyDataBase, "Outlayln");

                经费入账添加dataGridView1.DataSource = dsMyDataBase.Tables["Outlayln"];
                经费入账添加dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "打开数据库失败!");
            }
        }

        private void 修改ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            装备经费管理.Visible = true;
            经费使用管理.Visible = false;
            经费入账管理.Visible = true;
            系统管理.Visible = false;
            装备库存管理.Visible = false;
            统计与查询.Visible = false;
            WelcomePicture.Visible = false;
            经费入账添加.Visible = false;
            经费入账删除.Visible = false;
            经费入账修改.Visible = true;
            try
            {
                String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhaokangqiang;pwd=201608";
                SqlConnection conn = new SqlConnection(strConn);

                conn.Open();
                DataSet dsMyDataBase = new DataSet();


                SqlDataAdapter daBaseInform = new SqlDataAdapter("Select * From Outlayln", conn);
                daBaseInform.Fill(dsMyDataBase, "Outlayln");

                经费入账修改dataGridView1.DataSource = dsMyDataBase.Tables["Outlayln"];
                经费入账修改dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "打开数据库失败!");
            }
        }

        private void 删除ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            装备经费管理.Visible = true;
            经费使用管理.Visible = false;
            经费入账管理.Visible = true;
            系统管理.Visible = false;
            装备库存管理.Visible = false;
            统计与查询.Visible = false;
            WelcomePicture.Visible = false;
            经费入账添加.Visible = false;
            经费入账删除.Visible = true;
            经费入账修改.Visible = false;
            try
            {
                String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhaokangqiang;pwd=201608";
                SqlConnection conn = new SqlConnection(strConn);

                conn.Open();
                DataSet dsMyDataBase = new DataSet();


                SqlDataAdapter daBaseInform = new SqlDataAdapter("Select * From Outlayln", conn);
                daBaseInform.Fill(dsMyDataBase, "Outlayln");

                经费入账删除dataGridView1.DataSource = dsMyDataBase.Tables["Outlayln"];
                经费入账删除dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "打开数据库失败!");
            }
        }


     

      

        private void 经费添加确定_Click(object sender, EventArgs e)
        {
            try
            {
                String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhaokangqiang;pwd=201608";
                SqlConnection conn = new SqlConnection(strConn);

                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "Insert OutlayCost(Id,CDate,ItemId,CSum,Ryname,Ryname1,CDescribe,Memo)Values('" +
                    经费使用添加textBox27.Text + "','" + System.DateTime.Now.ToString() + "','" +
                    经费使用添加textBox33.Text + "','" + 经费使用添加textBox30.Text + "','" +
                    经费使用添加textBox31.Text + "','" + 经费使用添加textBox32.Text + "','" +
                    经费使用添加textBox28.Text + "','" + 经费使用添加textBox29.Text + "')";

                cmd.ExecuteNonQuery();
                DataSet dsMyDataBase = new DataSet();

                //将数据库中的
                SqlDataAdapter daBaseInform = new SqlDataAdapter("Select * From OutlayCost", conn);
                daBaseInform.Fill(dsMyDataBase, "OutlayCost");
                经费使用添加dataGridView6.DataSource = dsMyDataBase.Tables["OutlayCost"];
                MessageBox.Show("恭喜您，已经成功添加记录!");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "打开数据库失败!");
            }
        }

        private void 经费使用删除button7_Click(object sender, EventArgs e)
        {
            try
            {
                String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhaokangqiang;pwd=201608";
                SqlConnection conn = new SqlConnection(strConn);

                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "delete from OutlayCost where [Id]='" + 经费使用删除dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";

                cmd.ExecuteNonQuery();
                DataSet dsMyDataBase = new DataSet();

                SqlDataAdapter daBaseInform = new SqlDataAdapter("Select * From OutlayCost", conn);
                daBaseInform.Fill(dsMyDataBase, "OutlayCost");
                经费使用修改dataGridView1.DataSource = dsMyDataBase.Tables["OutlayCost"];
                MessageBox.Show("恭喜您，已经成功删除记录!");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "打开数据库失败!");
            }
        }

        private void 经费使用修改button9_Click(object sender, EventArgs e)
        {
            if (经费使用修改dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult dialogresult = MessageBox.Show("是否修改？", "提示",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogresult == DialogResult.Yes)//判断是否修改
                {
                    int r = this.经费使用修改dataGridView1.CurrentRow.Index;//获取点击的行号
                    string Id = this.经费使用修改dataGridView1.Rows[r].Cells[0].Value.ToString();
                    string CDate = this.经费使用修改dataGridView1.Rows[r].Cells[1].Value.ToString();
                    string ItemId = this.经费使用修改dataGridView1.Rows[r].Cells[2].Value.ToString();
                    string CSum = this.经费使用修改dataGridView1.Rows[r].Cells[3].Value.ToString();
                    string Ryname = this.经费使用修改dataGridView1.Rows[r].Cells[4].Value.ToString();
                    string Ryname1 = this.经费使用修改dataGridView1.Rows[r].Cells[5].Value.ToString();
                    string CDescribe = this.经费使用修改dataGridView1.Rows[r].Cells[6].Value.ToString();
                    string Memo = this.经费使用修改dataGridView1.Rows[r].Cells[7].Value.ToString();
                   
                    String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhaokangqiang;pwd=201608";
                    SqlConnection conn = new SqlConnection(strConn);

                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    try
                    {
                        cmd.CommandText = "update OutlayCost set Id='" + Id + "'"
                            + ",CDate='" + CDate + "'"
                            + ",ItemId='" + ItemId + "'"
                            + ",CSum='" + CSum + "'"
                            + ",Ryname='" + Ryname + "'"
                            + ",Ryname1='" + Ryname1 + "'"
                            + ",CDescribe='" + CDescribe + "'"
                            + ",Memo='" + Memo + "'"
                            + "where Id = '" + Id + "'";
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                    conn.Close();
                }
            }
        }

        private void 经费入账添加button3_Click(object sender, EventArgs e)
        {
            try
            {
                String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhaokangqiang;pwd=201608";
                SqlConnection conn = new SqlConnection(strConn);

                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "Insert Outlayln(Id,Source,ItemId,InSum,Ryname,InDate,Memo)Values('" +
                    经费入账添加项目编号textBox.Text + "','" + 经费入账添加textBox10.Text + "','" + 经费入账添加textBox1.Text + "','" + 经费入账添加textBox9.Text + "','" + 经费入账添加textBox11.Text + "','" + System.DateTime.Now.ToString() + "','" + 经费入账添加textBox12.Text + "')";

                cmd.ExecuteNonQuery();
                DataSet dsMyDataBase = new DataSet();

   
                SqlDataAdapter daBaseInform = new SqlDataAdapter("Select * From Outlayln", conn);
                daBaseInform.Fill(dsMyDataBase, "Outlayln");
                经费入账添加dataGridView1.DataSource = dsMyDataBase.Tables["Outlayln"];
                MessageBox.Show("恭喜您，已经成功添加记录!");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "打开数据库失败!");
            }
        }

        private void 经费入账修改button5_Click(object sender, EventArgs e)
        {

            if (经费入账修改dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult dialogresult = MessageBox.Show("是否修改？", "提示",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogresult == DialogResult.Yes)//判断是否修改
                {
                    int r = this.经费入账修改dataGridView1.CurrentRow.Index;//获取点击的行号
                    string Id = this.经费入账修改dataGridView1.Rows[r].Cells[0].Value.ToString();
                    string Source = this.经费入账修改dataGridView1.Rows[r].Cells[1].Value.ToString();
                    string ItemId = this.经费入账修改dataGridView1.Rows[r].Cells[2].Value.ToString();
                    string InSum = this.经费入账修改dataGridView1.Rows[r].Cells[3].Value.ToString();
                    string Ryname = this.经费入账修改dataGridView1.Rows[r].Cells[4].Value.ToString();
                    string InDate = this.经费入账修改dataGridView1.Rows[r].Cells[5].Value.ToString();
                    string Memo = this.经费入账修改dataGridView1.Rows[r].Cells[6].Value.ToString();

                    String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhaokangqiang;pwd=201608";
                    SqlConnection conn = new SqlConnection(strConn);

                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    try
                    {
                        cmd.CommandText = "update Outlayln set Id='" + Id + "'"
                            + ",Source='" + Source + "'"
                            + ",ItemId='" + ItemId + "'"
                            + ",InSum='" + InSum + "'"
                            + ",Ryname='" + Ryname + "'"
                            + ",InDate='" + InDate + "'"
                            + ",Memo='" + Memo + "'"
                            + "where Id = '" + Id + "'";
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                    conn.Close();
                }
            }
        }

        private void 经费入账删除button2_Click(object sender, EventArgs e)
        {
            try
            {

                String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhaokangqiang;pwd=201608";
                SqlConnection conn = new SqlConnection(strConn);

                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "delete from Outlayln where [Id]='" + 经费入账删除dataGridView1.CurrentRow.Cells[0].Value.ToString()  + "'";

                cmd.ExecuteNonQuery();
                DataSet dsMyDataBase = new DataSet();

                SqlDataAdapter daBaseInform = new SqlDataAdapter("Select * From Outlayln", conn);
                daBaseInform.Fill(dsMyDataBase, "Outlayln");
                经费入账删除dataGridView1.DataSource = dsMyDataBase.Tables["Outlayln"];
                MessageBox.Show("恭喜您，已经成功删除记录!");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "打开数据库失败!");
            }
        }



        private void 经费使用修改button10_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void 经费入账修改dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!update_row.Contains(e.RowIndex))
            {
                update_row.Add(e.RowIndex);
            }
        }

        //加载主窗口事件
        private void Main_Load(object sender, EventArgs e)
        {
            this.Owner.Hide();                 //隐藏登录界面
        }

        //主窗口关闭事件
        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Load load = new Load();
            load = (Load)this.Owner;
            load.Dispose();
            load.Close();
        }


  
       
    }
}
