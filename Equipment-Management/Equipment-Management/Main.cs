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

        //----------------------------李朗---------------------------------------
        //窗口加载时运行的代码
        private void Main_Load(object sender, EventArgs e)
        {
            LoadCombobox();
            //将欢迎panel加入lastpanels中（欢迎panel默认第一个显示，其余均隐藏）
            MyPanel.lastpanels.Add(WelcomePicture);
            //判断登录的用户的权限，若权限不够则禁用功能
            if (LogInUser.userType != "管理员")
            {
                添加账户ToolStripMenuItem.Enabled = false;
                重置密码ToolStripMenuItem.Enabled = false;
                删除账户ToolStripMenuItem.Enabled = false;
                日志管理ToolStripMenuItem.Enabled = false;
                //添加维修记录ToolStripMenuItem.Enabled = false;
                //添加调拨记录ToolStripMenuItem.Enabled = false;
               // 删除维修记录ToolStripMenuItem.Enabled = false;
                //删除调拨记录ToolStripMenuItem.Enabled = false;
                //修改维修记录ToolStripMenuItem.Enabled = false;
                //修改调拨记录ToolStripMenuItem.Enabled = false;
                //维修完成ToolStripMenuItem.Enabled = false;
            }
        }
        private void LoadCombobox()
        {
            String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608"; ;
            SqlConnection conn = new SqlConnection(strConn);


            /*conn.Open();
            SqlCommand cmd = new SqlCommand("Select Sid * From  Storehouse", conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            /*conn.Open();           
            DataSet dsMyDataBase = new DataSet();
            SqlDataAdapter daBaseInform = new SqlDataAdapter("Select  * From Storeln", conn);
            daBaseInform.Fill(dsMyDataBase, "Storeln");





            conn.Close();
            入库信息管理修改时间选择年.DataSource = dt;
            入库信息管理修改时间选择年.DisplayMember = "Sid";*/

            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            string s_cmd = "select distinct OptDate from Storeln";
            string c_cmd = "select distinct OptDate from Takeout";

            cmd.CommandText = s_cmd;                                    //入库
            SqlDataReader reader = cmd.ExecuteReader();
            int i = -1;
            string temp1 = null;

            入库信息管理添加时间选择年.Items.Clear();
            入库信息管理修改时间选择年.Items.Clear();
            入库信息管理删除时间选择年.Items.Clear();

            出库信息管理添加时间选择年.Items.Clear();
            出库信息管理修改时间选择年.Items.Clear();
            出库信息管理删除时间选择年.Items.Clear();


            while (reader.Read())   //combobox中加入年并筛选出相同项
            {
                i += 1;

                if (i >= 1)
                {
                    if (string.Compare(reader[0].ToString().Substring(0, 4), temp1) != 0)
                    {
                        入库信息管理添加时间选择年.Items.Add(reader[0].ToString().Substring(0, 4));
                        入库信息管理修改时间选择年.Items.Add(reader[0].ToString().Substring(0, 4));
                        入库信息管理删除时间选择年.Items.Add(reader[0].ToString().Substring(0, 4));
                        temp1 = reader[0].ToString().Substring(0, 4);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (i < 1)
                {
                    入库信息管理添加时间选择年.Items.Add(reader[0].ToString().Substring(0, 4));
                    入库信息管理修改时间选择年.Items.Add(reader[0].ToString().Substring(0, 4));
                    入库信息管理删除时间选择年.Items.Add(reader[0].ToString().Substring(0, 4));
                    temp1 = reader[0].ToString().Substring(0, 4);
                }

            }
            reader.Close();

            cmd.CommandText = c_cmd;                                //出库
            SqlDataReader reader2 = cmd.ExecuteReader();
            int c = -1;
            while (reader2.Read())   //combobox中加入年并筛选出相同项
            {
                c += 1;

                if (c >= 1)
                {
                    if (string.Compare(reader2[0].ToString().Substring(0, 4), temp1) != 0)
                    {
                        出库信息管理添加时间选择年.Items.Add(reader2[0].ToString().Substring(0, 4));
                        出库信息管理修改时间选择年.Items.Add(reader2[0].ToString().Substring(0, 4));
                        出库信息管理删除时间选择年.Items.Add(reader2[0].ToString().Substring(0, 4));
                        temp1 = reader2[0].ToString().Substring(0, 4);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (c < 1)
                {
                    出库信息管理添加时间选择年.Items.Add(reader2[0].ToString().Substring(0, 4));
                    出库信息管理修改时间选择年.Items.Add(reader2[0].ToString().Substring(0, 4));
                    出库信息管理删除时间选择年.Items.Add(reader2[0].ToString().Substring(0, 4));
                    temp1 = reader2[0].ToString().Substring(0, 4);
                }

            }
            reader2.Close();
            conn.Close();
        }
        private void pandianLoad()
        {
            String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608"; ;
            SqlConnection conn = new SqlConnection(strConn);

            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            string s_cmd = "select distinct Sname from Storehouse";
            cmd.CommandText = s_cmd;                                    //入库
            SqlDataReader reader = cmd.ExecuteReader();
            int i = -1;
            string temp1 = null;

            盘点仓库名称.Items.Clear();
            盘点装备名称.Items.Clear();
            盘点单价.Items.Clear();
            盘点生产日期.Text = "";

            while (reader.Read())   //combobox中加入年并筛选出相同项
            {
                i += 1;

                if (i >= 1)
                {
                    if (string.Compare(reader[0].ToString(), temp1) != 0)
                    {
                        盘点仓库名称.Items.Add(reader[0].ToString());

                        temp1 = reader[0].ToString();
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (i < 1)
                {
                    盘点仓库名称.Items.Add(reader[0].ToString());

                    temp1 = reader[0].ToString();
                }

            }
            reader.Close();
        }

        private void 装备信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        /* private void Main_Load(object sender, EventArgs e)
         {
             LoadCombobox();
             /*String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608"; ;
             SqlConnection conn = new SqlConnection(strConn);

             conn.Open();
             SqlCommand cmd = new SqlCommand("Select Sid * From  Storehouse", conn);
             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             sda.Fill(dt);

             /*conn.Open();           
             DataSet dsMyDataBase = new DataSet();
             SqlDataAdapter daBaseInform = new SqlDataAdapter("Select  * From Storeln", conn);
             daBaseInform.Fill(dsMyDataBase, "Storeln");


             conn.Close();
             入库信息管理修改时间选择年.DataSource = dt;
             入库信息管理修改时间选择年.DisplayMember = "Sid";*

             conn.Open();
             SqlCommand cmd = new SqlCommand();
             cmd.Connection = conn;
             string s_cmd = "select distinct OptDate from Storeln";
             string c_cmd = "select distinct OptDate from Takeout";

             cmd.CommandText = s_cmd;                                    //入库
             SqlDataReader reader = cmd.ExecuteReader();
             int i = -1;
             string temp1 = null;
             while (reader.Read())   //combobox中加入年并筛选出相同项
             {
                 i += 1;

                 if (i >= 1)
                 {
                     if (string.Compare(reader[0].ToString().Substring(0, 4), temp1) != 0)
                     {
                         入库信息管理添加时间选择年.Items.Add(reader[0].ToString().Substring(0, 4));
                         入库信息管理修改时间选择年.Items.Add(reader[0].ToString().Substring(0, 4));
                         入库信息管理删除时间选择年.Items.Add(reader[0].ToString().Substring(0, 4));
                         temp1 = reader[0].ToString().Substring(0, 4);
                     }
                     else
                     {
                         continue;
                     }
                 }
                 else if (i < 1)
                 {
                     入库信息管理添加时间选择年.Items.Add(reader[0].ToString().Substring(0, 4));
                     入库信息管理修改时间选择年.Items.Add(reader[0].ToString().Substring(0, 4));
                     入库信息管理删除时间选择年.Items.Add(reader[0].ToString().Substring(0, 4));
                     temp1 = reader[0].ToString().Substring(0, 4);
                 }

             }
             reader.Close();

             cmd.CommandText = c_cmd;                                //出库
             SqlDataReader reader2 = cmd.ExecuteReader();
             int c = -1;
             while (reader2.Read())   //combobox中加入年并筛选出相同项
             {
                 c += 1;

                 if (c >= 1)
                 {
                     if (string.Compare(reader2[0].ToString().Substring(0, 4), temp1) != 0)
                     {
                         出库信息管理添加时间选择年.Items.Add(reader2[0].ToString().Substring(0, 4));
                         出库信息管理修改时间选择年.Items.Add(reader2[0].ToString().Substring(0, 4));
                         出库信息管理删除时间选择年.Items.Add(reader2[0].ToString().Substring(0, 4));
                         temp1 = reader2[0].ToString().Substring(0, 4);
                     }
                     else
                     {
                         continue;
                     }
                 }
                 else if (c < 1)
                 {
                     出库信息管理添加时间选择年.Items.Add(reader2[0].ToString().Substring(0, 4));
                     出库信息管理修改时间选择年.Items.Add(reader2[0].ToString().Substring(0, 4));
                     出库信息管理删除时间选择年.Items.Add(reader2[0].ToString().Substring(0, 4));
                     temp1 = reader2[0].ToString().Substring(0, 4);
                 }

             }
             reader2.Close();
             conn.Close();
         }*/

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void 用户管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void 统计查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 入库信息管理添加_Click(object sender, EventArgs e)
        {
            new 装备库存管理框.入库信息管理添加().Show();
        }

        private void 入库信息管理删除_Click(object sender, EventArgs e)
        {
            //new 装备库存管理框.入库信息管理删除().Show();
            if (dataGridView入库信息管理删除.SelectedRows.Count > 0)
            {

                DialogResult dialogresult = MessageBox.Show("是否删除？", "提示",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogresult == DialogResult.Yes)
                {
                    int r = this.dataGridView入库信息管理删除.CurrentRow.Index; //获取点击的行号
                    string SiId = this.dataGridView入库信息管理删除.Rows[r].Cells[0].Value.ToString(); //获取Sid的值


                    String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608";
                    SqlConnection conn = new SqlConnection(strConn);

                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    /*SqlDataAdapter sda = new SqlDataAdapter("select Zbnum from Storeln where SiId = '" + SiId + "'", conn);
                    cmd.CommandText = string.Format("select Zbnum from Storeln  where SiId = {0}", SiId);
                    SqlDataReader reader3 = cmd.ExecuteReader();
                    string Zbnumyuan = null;

                    while (reader3.Read())
                    {
                        Zbnumyuan = reader3[0].ToString();
                    }
                    reader3.Close();*/


                    try
                    {

                        string ckbianhao = this.dataGridView入库信息管理删除.Rows[r].Cells[6].Value.ToString();
                        string zbbianhao = this.dataGridView入库信息管理删除.Rows[r].Cells[2].Value.ToString();
                        string zbprice = this.dataGridView入库信息管理删除.Rows[r].Cells[4].Value.ToString();
                        string CKshuliang = this.dataGridView入库信息管理删除.Rows[r].Cells[5].Value.ToString();
                        //string newone = (int.Parse(CKshuliang) - int.Parse(Zbnumyuan)).ToString();
                        cmd.CommandText = string.Format("update ArmsSurplus set Zbnum=Zbnum-{0} where Sid={1} and Zbid={2} and Zbprice={3}", CKshuliang, ckbianhao, zbbianhao, zbprice);
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = string.Format("delete from Storeln where SiId = '" + SiId + "'", conn);
                        this.dataGridView入库信息管理删除.Rows.Remove(this.dataGridView入库信息管理删除.Rows[r]);//删除选中行
                        cmd.ExecuteNonQuery();

                        LoadCombobox();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString() + "执行失败");
                    }
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("中止删除操作，删除失败！");
                }
            }
            else
            {
                MessageBox.Show("未选择删除目标项");
            }
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            仓库信息管理.Visible = true;
            出库信息管理.Visible = false;
            入库信息管理.Visible = false;
            装备库存盘点.Visible = false;
            仓库信息添加.Visible = true;
            仓库信息修改.Visible = false;
            仓库信息删除.Visible = false;
            装备经费管理.Visible = false;
            统计与查询.Visible = false;
            WelcomePicture.Visible = false;
            //menuStrip1.Visible = false;
            String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608"; ;
            SqlConnection conn = new SqlConnection(strConn);
            try
            {
                conn.Open();
                DataSet dsMyDataBase = new DataSet();


                SqlDataAdapter daBaseInform = new SqlDataAdapter("Select * From Storehouse", conn);
                daBaseInform.Fill(dsMyDataBase, "Storehouse");

                dataGridView仓库信息管理添加.DataSource = dsMyDataBase.Tables["Storehouse"];
                dataGridView仓库信息管理添加.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "打开数据库失败");
            }
        }

        private void 仓库信息管理添加_Click(object sender, EventArgs e)
        {
            new 装备库存管理框.仓库信息管理添加().Show();
        }

        private void 仓库信息修改修改_Click(object sender, EventArgs e)
        {
            //new 装备库存管理框.仓库信息管理修改().Show();
            if (dataGridView仓库信息管理修改.SelectedRows.Count > 0)
            {

                /* String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608";
                 SqlConnection conn = new SqlConnection(strConn);
                 DataSet ds = new DataSet();
                 DataTable dt = new DataTable();

                 SqlDataAdapter sda = new SqlDataAdapter();
                 SqlCommandBuilder sb = new SqlCommandBuilder(sda);
                 sda.Update(ds.Tables[0]);
                 ds.Tables[0].AcceptChanges();
                 SqlParameter param = new SqlParameter();


                 DataGridView obj = (DataGridView)dataGridView仓库信息管理修改.SelectedRows[0].DataBoundItem;
                 int r = this.dataGridView仓库信息管理修改.CurrentRow.Index;//获取点击的行号
                 string Sid = this.dataGridView仓库信息管理修改.Rows[r].Cells[0].Value.ToString();
                 string Sname = this.dataGridView仓库信息管理修改.Rows[r].Cells[1].Value.ToString();
                 string Memo = this.dataGridView仓库信息管理修改.Rows[r].Cells[2].Value.ToString();

                 string strSql = "update Storehouse set Sid=@Sid,Sname=@Sname where 1=1 and Memo=@Memo";
                 sda.UpdateCommand = new SqlCommand(strSql, conn);
                 param = sda.UpdateCommand.Parameters.Add("@Sid",SqlDbType.VarChar,50,"Sid");
                 param.SourceVersion = DataRowVersion.Current;

                 param = sda.UpdateCommand.Parameters.Add("@Sname", SqlDbType.VarChar, 50, "Sname");
                 param.SourceVersion = DataRowVersion.Current;

                 param = sda.UpdateCommand.Parameters.Add("@Memo", SqlDbType.VarChar, 50, "Memo");
                 param.SourceVersion = DataRowVersion.Original;

                 sda.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;

                 sda.UpdateBatchSize = 10;
                 sda.Update(ds.Tables[0]);
                 ds.Tables[0].AcceptChanges();*/


                DialogResult dialogresult = MessageBox.Show("是否修改？", "提示",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogresult == DialogResult.Yes)//判断是否修改
                {
                    //DataGridView obj = (DataGridView)dataGridView仓库信息管理修改.SelectedRows[0].DataBoundItem;
                    int r = this.dataGridView仓库信息管理修改.CurrentRow.Index;//获取点击的行号
                    string Sid = this.dataGridView仓库信息管理修改.Rows[r].Cells[0].Value.ToString();
                    string Sname = this.dataGridView仓库信息管理修改.Rows[r].Cells[1].Value.ToString();
                    string Memo = this.dataGridView仓库信息管理修改.Rows[r].Cells[2].Value.ToString();

                    String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608";
                    SqlConnection conn = new SqlConnection(strConn);

                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    try
                    {
                        //int i = r + 1;
                        //string strUpdata = "update Storehouse set Sid = '" + Sid + "'" + ",Sname = '" + Sname + "'" + ",Memo = '" + Memo + "'";
                        cmd.CommandText = "update  Storehouse set  Sid='" + Sid + "'" + ",Sname='" + Sname + "'" + ",Memo='" + Memo + "'" + "where Sid = '" + Sid + "'";
                        //SqlCommand cmd = new SqlCommand(strUpdata, conn);
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

        private void 仓库信息管理删除_Click(object sender, EventArgs e)
        {

            if (dataGridView仓库信息管理删除.SelectedRows.Count > 0)
            {
                /*DataRowView obj = (DataRowView)dataGridView仓库信息管理删除.SelectedRows[0].DataBoundItem;
                装备库存管理框.仓库信息管理删除 frm = new 装备库存管理框.仓库信息管理删除(obj);
                frm.Show();*/
                DialogResult dialogresult = MessageBox.Show("是否删除？", "提示",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogresult == DialogResult.Yes)
                {
                    int r = this.dataGridView仓库信息管理删除.CurrentRow.Index; //获取点击的行号
                    string Sid = this.dataGridView仓库信息管理删除.Rows[r].Cells[0].Value.ToString(); //获取Sid的值
                    this.dataGridView仓库信息管理删除.Rows.Remove(this.dataGridView仓库信息管理删除.Rows[r]);//删除选中行

                    String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608";
                    SqlConnection conn = new SqlConnection(strConn);

                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    try
                    {
                        cmd.CommandText = string.Format("delete from Storehouse where Sid = '" + Sid + "'", conn);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("执行失败");
                    }
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("中止删除操作，删除失败！");
                }
            }
            else
            {
                MessageBox.Show("未选择删除目标项");
            }
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            仓库信息管理.Visible = true;
            出库信息管理.Visible = false;
            入库信息管理.Visible = false;
            装备库存盘点.Visible = false;
            仓库信息添加.Visible = false;
            仓库信息修改.Visible = true;
            仓库信息删除.Visible = false;
            装备经费管理.Visible = false;
            统计与查询.Visible = false;
            WelcomePicture.Visible = false;
            String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608"; ;
            SqlConnection conn = new SqlConnection(strConn);
            try
            {
                conn.Open();
                DataSet dsMyDataBase = new DataSet();


                SqlDataAdapter daBaseInform = new SqlDataAdapter("Select * From Storehouse", conn);
                daBaseInform.Fill(dsMyDataBase, "Storehouse");

                dataGridView仓库信息管理修改.DataSource = dsMyDataBase.Tables["Storehouse"];
                dataGridView仓库信息管理修改.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "打开数据库失败");
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            仓库信息管理.Visible = true;
            出库信息管理.Visible = false;
            入库信息管理.Visible = false;
            装备库存盘点.Visible = false;
            仓库信息添加.Visible = false;
            仓库信息修改.Visible = false;
            仓库信息删除.Visible = true;
            装备经费管理.Visible = false;
            统计与查询.Visible = false;
            WelcomePicture.Visible = false;
            String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608"; ;
            SqlConnection conn = new SqlConnection(strConn);
            try
            {
                conn.Open();
                DataSet dsMyDataBase = new DataSet();


                SqlDataAdapter daBaseInform = new SqlDataAdapter("Select * From Storehouse", conn);
                daBaseInform.Fill(dsMyDataBase, "Storehouse");

                dataGridView仓库信息管理删除.DataSource = dsMyDataBase.Tables["Storehouse"];
                dataGridView仓库信息管理删除.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "打开数据库失败");
            }
        }



        private void 添加ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            入库信息管理.Visible = true;
            出库信息管理.Visible = false;
            仓库信息管理.Visible = false;
            装备库存盘点.Visible = false;
            入库信息添加.Visible = true;
            入库信息删除.Visible = false;
            入库信息修改.Visible = false;
            装备经费管理.Visible = false;
            统计与查询.Visible = false;
            WelcomePicture.Visible = false;

            String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608"; ;
            SqlConnection conn = new SqlConnection(strConn);
            try
            {
                conn.Open();
                DataSet dsMyDataBase = new DataSet();


                SqlDataAdapter daBaseInform = new SqlDataAdapter("Select * From Storeln", conn);
                daBaseInform.Fill(dsMyDataBase, "Storeln");

                dataGridView入库信息管理添加.DataSource = dsMyDataBase.Tables["Storeln"];

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "打开数据库失败");
            }
        }

        private void 修改ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            入库信息管理.Visible = true;
            出库信息管理.Visible = false;
            仓库信息管理.Visible = false;
            装备库存盘点.Visible = false;
            入库信息添加.Visible = false;
            入库信息删除.Visible = false;
            入库信息修改.Visible = true;
            装备经费管理.Visible = false;
            统计与查询.Visible = false;
            WelcomePicture.Visible = false;
            String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608"; ;
            SqlConnection conn = new SqlConnection(strConn);
            try
            {
                conn.Open();
                DataSet dsMyDataBase = new DataSet();


                SqlDataAdapter daBaseInform = new SqlDataAdapter("Select * From Storeln", conn);
                daBaseInform.Fill(dsMyDataBase, "Storeln");

                dataGridView入库信息管理修改.DataSource = dsMyDataBase.Tables["Storeln"];

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "打开数据库失败");
            }
        }

        private void 删除ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            入库信息管理.Visible = true;
            出库信息管理.Visible = false;
            仓库信息管理.Visible = false;
            装备库存盘点.Visible = false;
            入库信息添加.Visible = false;
            入库信息删除.Visible = true;
            入库信息修改.Visible = false;
            装备经费管理.Visible = false;
            统计与查询.Visible = false;
            WelcomePicture.Visible = false;
            String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608"; ;
            SqlConnection conn = new SqlConnection(strConn);
            try
            {
                conn.Open();
                DataSet dsMyDataBase = new DataSet();


                SqlDataAdapter daBaseInform = new SqlDataAdapter("Select * From Storeln", conn);
                daBaseInform.Fill(dsMyDataBase, "Storeln");

                dataGridView入库信息管理删除.DataSource = dsMyDataBase.Tables["Storeln"];

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "打开数据库失败");
            }
        }

        private void 添加ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            出库信息管理.Visible = true;
            仓库信息管理.Visible = false;
            装备库存盘点.Visible = false;
            入库信息管理.Visible = false;
            出库信息添加.Visible = true;
            出库信息删除.Visible = false;
            出库信息修改.Visible = false;
            装备经费管理.Visible = false;
            统计与查询.Visible = false;
            WelcomePicture.Visible = false;
            //连接数据库到DataGridView
            String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608"; ;
            SqlConnection conn = new SqlConnection(strConn);
            try
            {
                conn.Open();
                DataSet dsMyDataBase = new DataSet();


                SqlDataAdapter daBaseInform = new SqlDataAdapter("Select * From Takeout", conn);
                daBaseInform.Fill(dsMyDataBase, "Takeout");

                dataGridView出库信息管理添加.DataSource = dsMyDataBase.Tables["Takeout"];

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "打开数据库失败");
            }
        }

        private void 修改ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            出库信息管理.Visible = true;
            仓库信息管理.Visible = false;
            装备库存盘点.Visible = false;
            入库信息管理.Visible = false;
            出库信息添加.Visible = false;
            出库信息删除.Visible = false;
            出库信息修改.Visible = true;
            装备经费管理.Visible = false;
            统计与查询.Visible = false;
            WelcomePicture.Visible = false;
            //连接数据库到DataGridView
            String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608"; ;
            SqlConnection conn = new SqlConnection(strConn);
            try
            {
                conn.Open();
                DataSet dsMyDataBase = new DataSet();


                SqlDataAdapter daBaseInform = new SqlDataAdapter("Select * From Takeout", conn);
                daBaseInform.Fill(dsMyDataBase, "Takeout");

                dataGridView出库信息管理修改.DataSource = dsMyDataBase.Tables["Takeout"];

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "打开数据库失败");
            }
        }

        private void 删除ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            出库信息管理.Visible = true;
            仓库信息管理.Visible = false;
            装备库存盘点.Visible = false;
            入库信息管理.Visible = false;
            出库信息添加.Visible = false;
            出库信息删除.Visible = true;
            出库信息修改.Visible = false;
            装备经费管理.Visible = false;
            统计与查询.Visible = false;
            WelcomePicture.Visible = false;
            //连接数据库到DataGridView
            String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608"; ;
            SqlConnection conn = new SqlConnection(strConn);
            try
            {
                conn.Open();
                DataSet dsMyDataBase = new DataSet();


                SqlDataAdapter daBaseInform = new SqlDataAdapter("Select * From Takeout", conn);
                daBaseInform.Fill(dsMyDataBase, "Takeout");

                dataGridView出库信息管理删除.DataSource = dsMyDataBase.Tables["Takeout"];

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "打开数据库失败");
            }
        }

        private void 出库信息管理修改_Click(object sender, EventArgs e)
        {
            //new 装备库存管理框.出库信息管理修改().Show();
            if (dataGridView出库信息管理修改.SelectedRows.Count > 0)
            {

                /* String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608";
                 SqlConnection conn = new SqlConnection(strConn);
                 DataSet ds = new DataSet();
                 DataTable dt = new DataTable();

                 SqlDataAdapter sda = new SqlDataAdapter();
                 SqlCommandBuilder sb = new SqlCommandBuilder(sda);
                 sda.Update(ds.Tables[0]);
                 ds.Tables[0].AcceptChanges();
                 SqlParameter param = new SqlParameter();


                 DataGridView obj = (DataGridView)dataGridView仓库信息管理修改.SelectedRows[0].DataBoundItem;
                 int r = this.dataGridView仓库信息管理修改.CurrentRow.Index;//获取点击的行号
                 string Sid = this.dataGridView仓库信息管理修改.Rows[r].Cells[0].Value.ToString();
                 string Sname = this.dataGridView仓库信息管理修改.Rows[r].Cells[1].Value.ToString();
                 string Memo = this.dataGridView仓库信息管理修改.Rows[r].Cells[2].Value.ToString();

                 string strSql = "update Storehouse set Sid=@Sid,Sname=@Sname where 1=1 and Memo=@Memo";
                 sda.UpdateCommand = new SqlCommand(strSql, conn);
                 param = sda.UpdateCommand.Parameters.Add("@Sid",SqlDbType.VarChar,50,"Sid");
                 param.SourceVersion = DataRowVersion.Current;

                 param = sda.UpdateCommand.Parameters.Add("@Sname", SqlDbType.VarChar, 50, "Sname");
                 param.SourceVersion = DataRowVersion.Current;

                 param = sda.UpdateCommand.Parameters.Add("@Memo", SqlDbType.VarChar, 50, "Memo");
                 param.SourceVersion = DataRowVersion.Original;

                 sda.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;

                 sda.UpdateBatchSize = 10;
                 sda.Update(ds.Tables[0]);
                 ds.Tables[0].AcceptChanges();*/





                DialogResult dialogresult = MessageBox.Show("是否修改？", "提示",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogresult == DialogResult.Yes)//判断是否修改
                {
                    //DataGridView obj = (DataGridView)dataGridView仓库信息管理修改.SelectedRows[0].DataBoundItem;
                    int r = this.dataGridView出库信息管理修改.CurrentRow.Index;//获取点击的行号
                    string ToId = this.dataGridView出库信息管理修改.Rows[r].Cells[0].Value.ToString();
                    string Ttype = this.dataGridView出库信息管理修改.Rows[r].Cells[1].Value.ToString();
                    string Zbid = this.dataGridView出库信息管理修改.Rows[r].Cells[2].Value.ToString();
                    string Zbprice = this.dataGridView出库信息管理修改.Rows[r].Cells[3].Value.ToString();
                    string Zbnum = this.dataGridView出库信息管理修改.Rows[r].Cells[4].Value.ToString();
                    string Sid = this.dataGridView出库信息管理修改.Rows[r].Cells[5].Value.ToString();
                    string Ryname1 = this.dataGridView出库信息管理修改.Rows[r].Cells[6].Value.ToString();
                    string Ryname = this.dataGridView出库信息管理修改.Rows[r].Cells[7].Value.ToString();
                    string OptDate = this.dataGridView出库信息管理修改.Rows[r].Cells[8].Value.ToString();
                    string Memo = this.dataGridView出库信息管理修改.Rows[r].Cells[9].Value.ToString();
                    String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608";
                    SqlConnection conn = new SqlConnection(strConn);

                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    SqlDataAdapter sda = new SqlDataAdapter("select Zbnum from Takeout where ToId = '" + ToId + "'", conn);
                    cmd.CommandText = string.Format("select Zbnum from Takeout  where ToId = {0}", ToId);
                    SqlDataReader reader3 = cmd.ExecuteReader();
                    string Zbnumyuan = null;

                    while (reader3.Read())
                    {
                        Zbnumyuan = reader3[0].ToString();
                    }
                    reader3.Close();


                    try
                    {
                        //int i = r + 1;
                        //string strUpdata = "update Storehouse set Sid = '" + Sid + "'" + ",Sname = '" + Sname + "'" + ",Memo = '" + Memo + "'";
                        cmd.CommandText = "update  Takeout set  ToId='" + ToId + "'"
                            + ",Ttype='" + Ttype + "'"
                            + ",Zbid='" + Zbid + "'"
                            + ",Zbprice='" + Zbprice + "'"
                            + ",Zbnum='" + Zbnum + "'"
                            + ",Sid='" + Sid + "'"
                            + ",Ryname1='" + Ryname1 + "'"
                            + ",Ryname='" + Ryname + "'"
                            + ",OptDate='" + OptDate + "'"
                            + ",Memo='" + Memo + "'"
                            + "where ToId = '" + ToId + "'";
                        //SqlCommand cmd = new SqlCommand(strUpdata, conn);
                        cmd.ExecuteNonQuery();
                        string ckbianhao = this.dataGridView出库信息管理修改.Rows[r].Cells[5].Value.ToString();
                        string zbbianhao = this.dataGridView出库信息管理修改.Rows[r].Cells[2].Value.ToString();
                        string zbprice = this.dataGridView出库信息管理修改.Rows[r].Cells[3].Value.ToString();
                        string CKshuliang = this.dataGridView出库信息管理修改.Rows[r].Cells[4].Value.ToString();
                        string newone = (int.Parse(Zbnumyuan) - int.Parse(CKshuliang)).ToString();
                        cmd.CommandText = string.Format("update ArmsSurplus set Zbnum=Zbnum+{0} where Sid={1} and Zbid={2} and Zbprice={3}", newone, ckbianhao, zbbianhao, zbprice);
                        cmd.ExecuteNonQuery();


                        LoadCombobox();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                    conn.Close();
                }
            }
        }

        private void 出库信息管理删除_Click(object sender, EventArgs e)
        {
            // new 装备库存管理框.出库信息管理删除().Show();
            if (dataGridView出库信息管理删除.SelectedRows.Count > 0)
            {

                DialogResult dialogresult = MessageBox.Show("是否删除？", "提示",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogresult == DialogResult.Yes)
                {
                    int r = this.dataGridView出库信息管理删除.CurrentRow.Index; //获取点击的行号
                    string ToId = this.dataGridView出库信息管理删除.Rows[r].Cells[0].Value.ToString(); //获取Sid的值


                    String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608";
                    SqlConnection conn = new SqlConnection(strConn);

                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;


                    // string XGshuliang = this.dataGridView出库信息管理删除.Rows[r].Cells[5].Value.ToString();
                    try
                    {


                        string ckbianhao = this.dataGridView出库信息管理删除.Rows[r].Cells[5].Value.ToString();
                        string zbbianhao = this.dataGridView出库信息管理删除.Rows[r].Cells[2].Value.ToString();
                        string zbprice = this.dataGridView出库信息管理删除.Rows[r].Cells[3].Value.ToString();
                        string CKshuliang = this.dataGridView出库信息管理删除.Rows[r].Cells[4].Value.ToString();
                        cmd.CommandText = string.Format("update ArmsSurplus set Zbnum=Zbnum+{0} where Sid={1} and Zbid={2} and Zbprice={3}", CKshuliang, ckbianhao, zbbianhao, zbprice);
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = string.Format("delete from Takeout where ToId = '" + ToId + "'", conn);
                        //cmd.CommandText = string.Format("update ArmsSurplus set Zbnum=Zbnum+{0} where SpId={1}",XGshuliang);
                        cmd.ExecuteNonQuery();
                        this.dataGridView出库信息管理删除.Rows.Remove(this.dataGridView出库信息管理删除.Rows[r]);//删除选中行
                        LoadCombobox();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString() + "执行失败");
                    }
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("中止删除操作，删除失败！");
                }
            }
            else
            {
                MessageBox.Show("未选择删除目标项");
            }
        }

        private void 出库信息管理添加_Click(object sender, EventArgs e)
        {

            new 装备库存管理框.出库信息管理添加().Show();

        }

        private void dataGridView仓库信息管理删除_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /* String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608"; ;
             SqlConnection conn = new SqlConnection(strConn);
             try
             {
                 conn.Open();
                 DataSet dsMyDataBase = new DataSet();


                 SqlDataAdapter daBaseInform = new SqlDataAdapter("Select * From BaseInform", conn);
                 daBaseInform.Fill(dsMyDataBase, "BaseInform");

                 dataGridView仓库信息管理删除.DataSource = dsMyDataBase.Tables["BaseInform"];

                 conn.Close();
             }
             catch(Exception ex)
             {
                 MessageBox.Show(ex.Message.ToString() + "打开数据库失败");
             }*/
        }

        private void dataGridView仓库信息管理删除_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView仓库信息管理删除_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataRowView obj = (DataRowView)dataGridView仓库信息管理删除.Rows[e.RowIndex].DataBoundItem;
            //装备库存管理框.仓库信息管理删除 frm = new 装备库存管理框.仓库信息管理删除(obj);            
        }

        private void dataGridView仓库信息管理添加_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /* int rowIndex = e.RowIndex;
             DataRowView obj = (DataRowView)dataGridView仓库信息管理删除.Rows[e.RowIndex].DataBoundItem;
             装备库存管理框.仓库信息管理添加 frm = new 装备库存管理框.仓库信息管理添加(obj);*/

        }

        private void 仓库信息管理添加刷新_Click(object sender, EventArgs e)
        {
            String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608"; ;
            SqlConnection conn = new SqlConnection(strConn);
            try
            {
                conn.Open();
                DataSet dsMyDataBase = new DataSet();


                SqlDataAdapter daBaseInform = new SqlDataAdapter("Select * From Storehouse", conn);
                daBaseInform.Fill(dsMyDataBase, "Storehouse");

                dataGridView仓库信息管理添加.DataSource = dsMyDataBase.Tables["Storehouse"];
                dataGridView仓库信息管理添加.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "打开数据库失败");
            }
        }

        private void 入库信息添加_Paint(object sender, PaintEventArgs e)
        {
            /*String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608"; ;
            SqlConnection conn = new SqlConnection(strConn);

            conn.Open();
            SqlCommand cmd = new SqlCommand("Select Sid * From  Storehouse", conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            /*conn.Open();           
            DataSet dsMyDataBase = new DataSet();
            SqlDataAdapter daBaseInform = new SqlDataAdapter("Select  * From Storeln", conn);
            daBaseInform.Fill(dsMyDataBase, "Storeln");


            conn.Close();
            入库信息管理修改时间选择年.DataSource = dt;
            入库信息管理修改时间选择年.DisplayMember = "Sid";

            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            string s_cmd = "select Zbid from Storeln";

            cmd.CommandText = s_cmd;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                入库信息管理修改时间选择年.Items.Add(reader[0].ToString());
            }
            reader.Close();
            conn.Close();*/
        }

        private void 入库信息管理添加时间选择年_SelectedIndexChanged(object sender, EventArgs e)
        {
            入库信息管理添加时间选择月.Items.Clear();

            string s = 入库信息管理添加时间选择年.SelectedItem.ToString().Substring(0, 4);

            String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608"; ;
            SqlConnection conn = new SqlConnection(strConn);

            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            string s_cmd = string.Format("select OptDate from Storeln where OptDate like '{0}%'", s);

            cmd.CommandText = s_cmd;
            SqlDataReader reader = cmd.ExecuteReader();

            int i = -1;
            string temp1 = null;
            while (reader.Read())   //combobox中加入年并筛选出相同项
            {
                i += 1;

                if (i >= 1)
                {
                    if (string.Compare(reader[0].ToString().Substring(4, 2), temp1) != 0)
                    {

                        入库信息管理添加时间选择月.Items.Add(reader[0].ToString().Substring(4, 2));
                        temp1 = reader[0].ToString().Substring(4, 2);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (i < 1)
                {

                    入库信息管理添加时间选择月.Items.Add(reader[0].ToString().Substring(4, 2));
                    temp1 = reader[0].ToString().Substring(4, 2);
                }

            }

            reader.Close();
            conn.Close();
        }

        private void Main_Layout(object sender, LayoutEventArgs e)
        {

        }

        private void 入库信息管理添加时间选择年_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string s = 入库信息管理添加时间选择年.SelectedItem.ToString().Substring(0, 4);
            String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608"; ;
            SqlConnection conn = new SqlConnection(strConn);

            try
            {
                conn.Open();
                DataSet dsMyDataBase = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                string s_cmd = string.Format("select * from Storeln where OptDate like '%{0}%'", s);

                cmd = new SqlCommand(s_cmd, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView入库信息管理添加.DataSource = ds.Tables[0];
                /*SqlDataAdapter daBaseInform = new SqlDataAdapter("Select MakeDate From Storeln where MakeDate= '"+ s_cmd +"'",conn);
                daBaseInform.Fill(dsMyDataBase, "Storeln");

                dataGridView入库信息管理添加.DataSource = dsMyDataBase.Tables["Storeln"];
                dataGridView入库信息管理添加.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;*/

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "打开数据库失败");
            }
        }

        private void 入库信息管理修改修改_Click(object sender, EventArgs e)
        {
            if (dataGridView入库信息管理修改.SelectedRows.Count > 0)
            {

                /* String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608";
                 SqlConnection conn = new SqlConnection(strConn);
                 DataSet ds = new DataSet();
                 DataTable dt = new DataTable();

                 SqlDataAdapter sda = new SqlDataAdapter();
                 SqlCommandBuilder sb = new SqlCommandBuilder(sda);
                 sda.Update(ds.Tables[0]);
                 ds.Tables[0].AcceptChanges();
                 SqlParameter param = new SqlParameter();


                 DataGridView obj = (DataGridView)dataGridView仓库信息管理修改.SelectedRows[0].DataBoundItem;
                 int r = this.dataGridView仓库信息管理修改.CurrentRow.Index;//获取点击的行号
                 string Sid = this.dataGridView仓库信息管理修改.Rows[r].Cells[0].Value.ToString();
                 string Sname = this.dataGridView仓库信息管理修改.Rows[r].Cells[1].Value.ToString();
                 string Memo = this.dataGridView仓库信息管理修改.Rows[r].Cells[2].Value.ToString();

                 string strSql = "update Storehouse set Sid=@Sid,Sname=@Sname where 1=1 and Memo=@Memo";
                 sda.UpdateCommand = new SqlCommand(strSql, conn);
                 param = sda.UpdateCommand.Parameters.Add("@Sid",SqlDbType.VarChar,50,"Sid");
                 param.SourceVersion = DataRowVersion.Current;

                 param = sda.UpdateCommand.Parameters.Add("@Sname", SqlDbType.VarChar, 50, "Sname");
                 param.SourceVersion = DataRowVersion.Current;

                 param = sda.UpdateCommand.Parameters.Add("@Memo", SqlDbType.VarChar, 50, "Memo");
                 param.SourceVersion = DataRowVersion.Original;

                 sda.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;

                 sda.UpdateBatchSize = 10;
                 sda.Update(ds.Tables[0]);
                 ds.Tables[0].AcceptChanges();*/





                DialogResult dialogresult = MessageBox.Show("是否修改？", "提示",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogresult == DialogResult.Yes)//判断是否修改
                {
                    //DataGridView obj = (DataGridView)dataGridView仓库信息管理修改.SelectedRows[0].DataBoundItem;
                    int r = this.dataGridView入库信息管理修改.CurrentRow.Index;//获取点击的行号
                    string SiId = this.dataGridView入库信息管理修改.Rows[r].Cells[0].Value.ToString();
                    string SiType = this.dataGridView入库信息管理修改.Rows[r].Cells[1].Value.ToString();
                    string Zbid = this.dataGridView入库信息管理修改.Rows[r].Cells[2].Value.ToString();
                    string MakeDate = this.dataGridView入库信息管理修改.Rows[r].Cells[3].Value.ToString();
                    string Zbprice = this.dataGridView入库信息管理修改.Rows[r].Cells[4].Value.ToString();
                    string Zbnum = this.dataGridView入库信息管理修改.Rows[r].Cells[5].Value.ToString();
                    string Sid = this.dataGridView入库信息管理修改.Rows[r].Cells[6].Value.ToString();
                    string Ryname1 = this.dataGridView入库信息管理修改.Rows[r].Cells[7].Value.ToString();
                    string Ryname = this.dataGridView入库信息管理修改.Rows[r].Cells[8].Value.ToString();
                    string OptDate = this.dataGridView入库信息管理修改.Rows[r].Cells[9].Value.ToString();
                    string Memo = this.dataGridView入库信息管理修改.Rows[r].Cells[10].Value.ToString();
                    String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608";
                    SqlConnection conn = new SqlConnection(strConn);

                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    SqlDataAdapter sda = new SqlDataAdapter("select Zbnum from Storeln where SiId = '" + SiId + "'", conn);
                    cmd.CommandText = string.Format("select Zbnum from Storeln  where SiId = {0}", SiId);
                    SqlDataReader reader3 = cmd.ExecuteReader();
                    string Zbnumyuan = null;

                    while (reader3.Read())
                    {
                        Zbnumyuan = reader3[0].ToString();
                    }
                    reader3.Close();

                    try
                    {
                        //int i = r + 1;
                        //string strUpdata = "update Storehouse set Sid = '" + Sid + "'" + ",Sname = '" + Sname + "'" + ",Memo = '" + Memo + "'";
                        cmd.CommandText = "update  Storeln set  SiId='" + SiId + "'"
                            + ",SiType='" + SiType + "'"
                            + ",Zbid='" + Zbid + "'"
                            + ",MakeDate='" + MakeDate + "'"
                            + ",Zbprice='" + Zbprice + "'"
                            + ",Zbnum='" + Zbnum + "'"
                            + ",Sid='" + Sid + "'"
                            + ",Ryname1='" + Ryname1 + "'"
                            + ",Ryname='" + Ryname + "'"
                            + ",OptDate='" + OptDate + "'"
                            + ",Memo='" + Memo + "'"
                            + "where SiId = '" + SiId + "'";
                        //SqlCommand cmd = new SqlCommand(strUpdata, conn);
                        cmd.ExecuteNonQuery();

                        string ckbianhao = this.dataGridView入库信息管理修改.Rows[r].Cells[6].Value.ToString();
                        string zbbianhao = this.dataGridView入库信息管理修改.Rows[r].Cells[2].Value.ToString();
                        string zbprice = this.dataGridView入库信息管理修改.Rows[r].Cells[4].Value.ToString();
                        string CKshuliang = this.dataGridView入库信息管理修改.Rows[r].Cells[5].Value.ToString();
                        string newone = (int.Parse(CKshuliang) - int.Parse(Zbnumyuan)).ToString();
                        cmd.CommandText = string.Format("update ArmsSurplus set Zbnum=Zbnum+{0} where Sid={1} and Zbid={2} and Zbprice={3}", newone, ckbianhao, zbbianhao, zbprice);
                        cmd.ExecuteNonQuery();

                        LoadCombobox();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                    conn.Close();
                }
            }
        }

        private void 入库信息管理修改时间选择年_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string s = 入库信息管理修改时间选择年.SelectedItem.ToString().Substring(0, 4);
            String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608"; ;
            SqlConnection conn = new SqlConnection(strConn);

            try
            {
                conn.Open();
                DataSet dsMyDataBase = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                string s_cmd = string.Format("select * from Storeln where OptDate like '%{0}%'", s);

                cmd = new SqlCommand(s_cmd, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView入库信息管理修改.DataSource = ds.Tables[0];
                /*SqlDataAdapter daBaseInform = new SqlDataAdapter("Select MakeDate From Storeln where MakeDate= '"+ s_cmd +"'",conn);
                daBaseInform.Fill(dsMyDataBase, "Storeln");

                dataGridView入库信息管理添加.DataSource = dsMyDataBase.Tables["Storeln"];
                dataGridView入库信息管理添加.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;*/

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "打开数据库失败");
            }
        }

        private void 入库信息管理删除时间选择年_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string s = 入库信息管理删除时间选择年.SelectedItem.ToString().Substring(0, 4);
            String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608"; ;
            SqlConnection conn = new SqlConnection(strConn);

            try
            {
                conn.Open();
                DataSet dsMyDataBase = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                string s_cmd = string.Format("select * from Storeln where OptDate like '%{0}%'", s);

                cmd = new SqlCommand(s_cmd, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView入库信息管理删除.DataSource = ds.Tables[0];
                /*SqlDataAdapter daBaseInform = new SqlDataAdapter("Select MakeDate From Storeln where MakeDate= '"+ s_cmd +"'",conn);
                daBaseInform.Fill(dsMyDataBase, "Storeln");

                dataGridView入库信息管理添加.DataSource = dsMyDataBase.Tables["Storeln"];
                dataGridView入库信息管理添加.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;*/

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "打开数据库失败");
            }
        }


        private void 入库信息管理删除时间选择年_SelectedIndexChanged(object sender, EventArgs e)
        {
            入库信息管理删除时间选择月.Items.Clear();
        }

        //查看维修记录隐藏时
        private void 查看维修记录_VisibleChanged(object sender, EventArgs e)
        {
            StrList.timeFlag = false;
        }
        private void 入库信息管理删除实践选择年_SelectedChangeCommited(object sender, EventArgs e)
        {

            string s = 入库信息管理删除时间选择年.SelectedItem.ToString().Substring(0, 4);

            String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608"; ;
            SqlConnection conn = new SqlConnection(strConn);

            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            string s_cmd = string.Format("select OptDate from Storeln where OptDate like '{0}%'", s);

            cmd.CommandText = s_cmd;
            SqlDataReader reader = cmd.ExecuteReader();

            int i = -1;
            string temp1 = null;
            while (reader.Read())   //combobox中加入年并筛选出相同项
            {
                i += 1;

                if (i >= 1)
                {
                    if (string.Compare(reader[0].ToString().Substring(4, 2), temp1) != 0)
                    {

                        入库信息管理删除时间选择月.Items.Add(reader[0].ToString().Substring(4, 2));
                        temp1 = reader[0].ToString().Substring(4, 2);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (i < 1)
                {

                    入库信息管理删除时间选择月.Items.Add(reader[0].ToString().Substring(4, 2));
                    temp1 = reader[0].ToString().Substring(4, 2);
                }

            }

            reader.Close();
            conn.Close();
        }


        private void 入库信息管理修改时间选择年_SelectedIndexChanged(object sender, EventArgs e)
        {
            入库信息管理修改时间选择月.Items.Clear();

            string s = 入库信息管理修改时间选择年.SelectedItem.ToString().Substring(0, 4);

            String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608"; ;
            SqlConnection conn = new SqlConnection(strConn);

            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            string s_cmd = string.Format("select OptDate from Storeln where OptDate like '{0}%'", s);

            cmd.CommandText = s_cmd;
            SqlDataReader reader = cmd.ExecuteReader();

            int i = -1;
            string temp1 = null;
            while (reader.Read())   //combobox中加入年并筛选出相同项
            {
                i += 1;

                if (i >= 1)
                {
                    if (string.Compare(reader[0].ToString().Substring(4, 2), temp1) != 0)
                    {

                        入库信息管理修改时间选择月.Items.Add(reader[0].ToString().Substring(4, 2));
                        temp1 = reader[0].ToString().Substring(4, 2);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (i < 1)
                {

                    入库信息管理修改时间选择月.Items.Add(reader[0].ToString().Substring(4, 2));
                    temp1 = reader[0].ToString().Substring(4, 2);
                }

            }

            reader.Close();
            conn.Close();
        }

        private void 入库信息管理添加时间选择月_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string s = 入库信息管理添加时间选择年.SelectedItem.ToString().Substring(0, 4);

            string b2 = 入库信息管理添加时间选择月.SelectedItem.ToString();
            String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608"; ;
            SqlConnection conn = new SqlConnection(strConn);

            try
            {
                conn.Open();
                DataSet dsMyDataBase = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                string x_cmd = string.Format("select * from Storeln where OptDate like '%{0}{1}%'", s, b2);

                cmd = new SqlCommand(x_cmd, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView入库信息管理添加.DataSource = ds.Tables[0];


                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "打开数据库失败");
            }
        }

        private void 入库信息管理修改时间选择月_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string s = 入库信息管理修改时间选择年.SelectedItem.ToString().Substring(0, 4);

            string b2 = 入库信息管理修改时间选择月.SelectedItem.ToString();
            String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608"; ;
            SqlConnection conn = new SqlConnection(strConn);

            try
            {
                conn.Open();
                DataSet dsMyDataBase = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                string x_cmd = string.Format("select * from Storeln where OptDate like '%{0}{1}%'", s, b2);

                cmd = new SqlCommand(x_cmd, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView入库信息管理修改.DataSource = ds.Tables[0];


                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "打开数据库失败");
            }
        }

        private void 入库信息管理删除时间选择月_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string s = 入库信息管理删除时间选择年.SelectedItem.ToString().Substring(0, 4);

            string b2 = 入库信息管理删除时间选择月.SelectedItem.ToString();
            String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608"; ;
            SqlConnection conn = new SqlConnection(strConn);

            try
            {
                conn.Open();
                DataSet dsMyDataBase = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                string x_cmd = string.Format("select * from Storeln where OptDate like '%{0}{1}%'", s, b2);

                cmd = new SqlCommand(x_cmd, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView入库信息管理删除.DataSource = ds.Tables[0];
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "打开数据库失败");
            }
        }

        private void 出库信息管理添加时间选择年_SelectedIndexChanged(object sender, EventArgs e)
        {
            出库信息管理添加时间选择月.Items.Clear();

            string s = 出库信息管理添加时间选择年.SelectedItem.ToString().Substring(0, 4);

            String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608"; ;
            SqlConnection conn = new SqlConnection(strConn);

            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            string s_cmd = string.Format("select OptDate from Takeout where OptDate like '{0}%'", s);

            cmd.CommandText = s_cmd;
            SqlDataReader reader = cmd.ExecuteReader();

            int i = -1;
            string temp1 = null;
            while (reader.Read())   //combobox中加入年并筛选出相同项
            {
                i += 1;

                if (i >= 1)
                {
                    if (string.Compare(reader[0].ToString().Substring(4, 2), temp1) != 0)
                    {

                        出库信息管理添加时间选择月.Items.Add(reader[0].ToString().Substring(4, 2));
                        temp1 = reader[0].ToString().Substring(4, 2);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (i < 1)
                {

                    出库信息管理添加时间选择月.Items.Add(reader[0].ToString().Substring(4, 2));
                    temp1 = reader[0].ToString().Substring(4, 2);
                }

            }

            reader.Close();
            conn.Close();
        }

        private void 出库信息管理添加时间选择年_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string s = 出库信息管理添加时间选择年.SelectedItem.ToString().Substring(0, 4);
            String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608"; ;
            SqlConnection conn = new SqlConnection(strConn);

            try
            {
                conn.Open();
                DataSet dsMyDataBase = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                string s_cmd = string.Format("select * from Takeout where OptDate like '%{0}%'", s);

                cmd = new SqlCommand(s_cmd, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView出库信息管理添加.DataSource = ds.Tables[0];
                /*SqlDataAdapter daBaseInform = new SqlDataAdapter("Select MakeDate From Storeln where MakeDate= '"+ s_cmd +"'",conn);
                daBaseInform.Fill(dsMyDataBase, "Storeln");

                dataGridView入库信息管理添加.DataSource = dsMyDataBase.Tables["Storeln"];
                dataGridView入库信息管理添加.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;*/

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "打开数据库失败");
            }
        }

        private void 出库信息管理添加时间选择月_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string s = 出库信息管理添加时间选择年.SelectedItem.ToString().Substring(0, 4);

            string b2 = 出库信息管理添加时间选择月.SelectedItem.ToString();
            String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608"; ;
            SqlConnection conn = new SqlConnection(strConn);

            try
            {
                conn.Open();
                DataSet dsMyDataBase = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                string x_cmd = string.Format("select * from Takeout where OptDate like '%{0}{1}%'", s, b2);

                cmd = new SqlCommand(x_cmd, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView出库信息管理添加.DataSource = ds.Tables[0];
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "打开数据库失败");
            }
        }

        private void 出库信息管理删除时间选择年_SelectedIndexChanged(object sender, EventArgs e)
        {
            出库信息管理删除时间选择月.Items.Clear();

            string s = 出库信息管理删除时间选择年.SelectedItem.ToString().Substring(0, 4);

            String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608"; ;
            SqlConnection conn = new SqlConnection(strConn);

            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            string s_cmd = string.Format("select OptDate from Takeout where OptDate like '{0}%'", s);

            cmd.CommandText = s_cmd;
            SqlDataReader reader = cmd.ExecuteReader();

            int i = -1;
            string temp1 = null;
            while (reader.Read())   //combobox中加入年并筛选出相同项
            {
                i += 1;

                if (i >= 1)
                {
                    if (string.Compare(reader[0].ToString().Substring(4, 2), temp1) != 0)
                    {

                        出库信息管理删除时间选择月.Items.Add(reader[0].ToString().Substring(4, 2));
                        temp1 = reader[0].ToString().Substring(4, 2);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (i < 1)
                {

                    出库信息管理删除时间选择月.Items.Add(reader[0].ToString().Substring(4, 2));
                    temp1 = reader[0].ToString().Substring(4, 2);
                }

            }

            reader.Close();
            conn.Close();
        }

        private void 出库信息管理删除时间选择年_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string s = 出库信息管理删除时间选择年.SelectedItem.ToString().Substring(0, 4);
            String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608"; ;
            SqlConnection conn = new SqlConnection(strConn);

            try
            {
                conn.Open();
                DataSet dsMyDataBase = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                string s_cmd = string.Format("select * from Takeout where OptDate like '%{0}%'", s);

                cmd = new SqlCommand(s_cmd, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView出库信息管理删除.DataSource = ds.Tables[0];
                /*SqlDataAdapter daBaseInform = new SqlDataAdapter("Select MakeDate From Storeln where MakeDate= '"+ s_cmd +"'",conn);
                daBaseInform.Fill(dsMyDataBase, "Storeln");

                dataGridView入库信息管理添加.DataSource = dsMyDataBase.Tables["Storeln"];
                dataGridView入库信息管理添加.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;*/

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "打开数据库失败");
            }
        }

        private void 出库信息管理修改时间选择年_SelectedIndexChanged(object sender, EventArgs e)
        {
            出库信息管理修改时间选择月.Items.Clear();

            string s = 出库信息管理修改时间选择年.SelectedItem.ToString().Substring(0, 4);

            String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608"; ;
            SqlConnection conn = new SqlConnection(strConn);

            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            string s_cmd = string.Format("select OptDate from Takeout where OptDate like '{0}%'", s);

            cmd.CommandText = s_cmd;
            SqlDataReader reader = cmd.ExecuteReader();

            int i = -1;
            string temp1 = null;
            while (reader.Read())   //combobox中加入年并筛选出相同项
            {
                i += 1;

                if (i >= 1)
                {
                    if (string.Compare(reader[0].ToString().Substring(4, 2), temp1) != 0)
                    {

                        出库信息管理修改时间选择月.Items.Add(reader[0].ToString().Substring(4, 2));
                        temp1 = reader[0].ToString().Substring(4, 2);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (i < 1)
                {

                    出库信息管理修改时间选择月.Items.Add(reader[0].ToString().Substring(4, 2));
                    temp1 = reader[0].ToString().Substring(4, 2);
                }

            }

            reader.Close();
            conn.Close();
        }

        private void 出库信息管理修改时间选择月_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string s = 出库信息管理修改时间选择年.SelectedItem.ToString().Substring(0, 4);
            String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608"; ;
            SqlConnection conn = new SqlConnection(strConn);

            try
            {
                conn.Open();
                DataSet dsMyDataBase = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                string s_cmd = string.Format("select * from Takeout where OptDate like '%{0}%'", s);

                cmd = new SqlCommand(s_cmd, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView出库信息管理修改.DataSource = ds.Tables[0];
                /*SqlDataAdapter daBaseInform = new SqlDataAdapter("Select MakeDate From Storeln where MakeDate= '"+ s_cmd +"'",conn);
                daBaseInform.Fill(dsMyDataBase, "Storeln");

                dataGridView入库信息管理添加.DataSource = dsMyDataBase.Tables["Storeln"];
                dataGridView入库信息管理添加.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;*/

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "打开数据库失败");
            }
        }

        private void 出库信息管理删除时间选择月_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string s = 出库信息管理删除时间选择年.SelectedItem.ToString().Substring(0, 4);

            string b2 = 出库信息管理删除时间选择月.SelectedItem.ToString();
            String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608"; ;
            SqlConnection conn = new SqlConnection(strConn);

            try
            {
                conn.Open();
                DataSet dsMyDataBase = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                string x_cmd = string.Format("select * from Takeout where OptDate like '%{0}{1}%'", s, b2);

                cmd = new SqlCommand(x_cmd, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView出库信息管理删除.DataSource = ds.Tables[0];
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "打开数据库失败");
            }
        }

        private void 出库信息管理修改时间选择年_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string s = 出库信息管理修改时间选择年.SelectedItem.ToString().Substring(0, 4);
            String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608"; ;
            SqlConnection conn = new SqlConnection(strConn);

            try
            {
                conn.Open();
                DataSet dsMyDataBase = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                string s_cmd = string.Format("select * from Takeout where OptDate like '%{0}%'", s);

                cmd = new SqlCommand(s_cmd, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView出库信息管理修改.DataSource = ds.Tables[0];
                /*SqlDataAdapter daBaseInform = new SqlDataAdapter("Select MakeDate From Storeln where MakeDate= '"+ s_cmd +"'",conn);
                daBaseInform.Fill(dsMyDataBase, "Storeln");

                dataGridView入库信息管理添加.DataSource = dsMyDataBase.Tables["Storeln"];
                dataGridView入库信息管理添加.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;*/

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "打开数据库失败");
            }
        }

        private void 装备库存盘点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            出库信息管理.Visible = false;
            仓库信息管理.Visible = false;
            装备库存盘点.Visible = true;
            入库信息管理.Visible = false;
            出库信息添加.Visible = false;
            出库信息删除.Visible = true;
            出库信息修改.Visible = false;
            装备经费管理.Visible = false;
            统计与查询.Visible = false;
            WelcomePicture.Visible = false;

            pandianLoad();
        }

        private void 盘点仓库名称_SelectedIndexChanged(object sender, EventArgs e)
        {
            盘点装备名称.Items.Clear();

            string s = 盘点仓库名称.SelectedItem.ToString();

            String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608"; ;
            SqlConnection conn = new SqlConnection(strConn);

            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            string s_cmd = string.Format("select Sid from Storehouse where Sname='{0}'", s);
            cmd.CommandText = s_cmd;
            SqlDataReader reader = cmd.ExecuteReader();
            string sid = null;
            while (reader.Read())
            {
                sid = reader[0].ToString();
            }
            reader.Close();

            string s_cmd2 = string.Format("select Zbid from ArmsSurplus where Sid={0}", sid);
            cmd.CommandText = s_cmd2;
            reader = cmd.ExecuteReader();
            string zbid = null;
            while (reader.Read())
            {
                zbid = reader[0].ToString();
            }
            reader.Close();

            string s_cmd3 = string.Format("select Zbname from ArmsInfo where Zbid={0}", zbid);
            cmd.CommandText = s_cmd3;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                盘点装备名称.Items.Add(reader[0].ToString());
            }
            reader.Close();

            /* int i = -1;
             string temp1 = null;
             while (reader.Read())   //combobox中加入年并筛选出相同项
             {
                 i += 1;

                 if (i >= 1)
                 {
                     if (string.Compare(reader[0].ToString().Substring(4, 2), temp1) != 0)
                     {

                         出库信息管理删除时间选择月.Items.Add(reader[0].ToString().Substring(4, 2));
                         temp1 = reader[0].ToString().Substring(4, 2);
                     }
                     else
                     {
                         continue;
                     }
                 }
                 else if (i < 1)
                 {

                     出库信息管理删除时间选择月.Items.Add(reader[0].ToString().Substring(4, 2));
                     temp1 = reader[0].ToString().Substring(4, 2);
                 }

             }*/

            //reader.Close();
            conn.Close();
        }

        private void 盘点装备名称_SelectedIndexChanged(object sender, EventArgs e)
        {
            盘点单价.Items.Clear();

            string s = 盘点装备名称.SelectedItem.ToString();

            String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608"; ;
            SqlConnection conn = new SqlConnection(strConn);

            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            string s_cmd = string.Format("select Zbid from ArmsInfo where Zbname='{0}'", s);
            cmd.CommandText = s_cmd;
            SqlDataReader reader = cmd.ExecuteReader();
            string zbid = null;
            while (reader.Read())
            {
                zbid = reader[0].ToString();
            }
            reader.Close();

            string s_cmd2 = string.Format("select Zbprice from ArmsSurplus where Zbid='{0}'", zbid);
            cmd.CommandText = s_cmd2;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                盘点单价.Items.Add(reader[0].ToString());
            }
            reader.Close();
            conn.Close();
        }

        private void 盘点单价_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string s = 盘点单价.SelectedItem.ToString();
            String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608"; ;
            SqlConnection conn = new SqlConnection(strConn);

            try
            {
                conn.Open();
                //DataSet dsMyDataBase = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                string s_cmd = string.Format("select [MakeDate] from ArmsSurplus where Zbprice='{0}'", s);
                string makedate = null;
                cmd.CommandText = s_cmd;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    makedate = reader[0].ToString();
                }
                盘点生产日期.Text = makedate;
                reader.Close();

                string s_cmd2 = string.Format("select [Zbnum] from ArmsSurplus where Zbprice='{0}'", s);
                string zbnum = null;
                cmd.CommandText = s_cmd2;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    zbnum = reader[0].ToString();
                }
                盘点当前数量.Text = zbnum;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "打开数据库失败");
            }
        }

        private void 盘点盘点_Click(object sender, EventArgs e)
        {
            String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608"; ;
            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            conn.Open();
            try
            {
                string s_cmd = string.Format("select Sid from Storehouse where Sname='{0}'", 盘点仓库名称.SelectedItem.ToString());
                string s_cmd4 = string.Format("select Zbid from ArmsInfo where Zbname='{0}'", 盘点装备名称.SelectedItem.ToString());

                cmd.CommandText = s_cmd;
                SqlDataReader reader = cmd.ExecuteReader();
                string sid = null;
                while (reader.Read())
                {
                    sid = reader[0].ToString();
                }
                reader.Close();
                cmd.CommandText = s_cmd4;
                reader = cmd.ExecuteReader();
                string zbid = null;
                while (reader.Read())
                {
                    zbid = reader[0].ToString();
                }
                reader.Close();
                string zbname = 盘点装备名称.SelectedItem.ToString();
                string zbprice = 盘点单价.SelectedItem.ToString();
                //string shuliang1 = 出库管理添加出库数量.Text;
                string s_cmd2 = string.Format("select Zbnum from Storeln where Sid={0} and Zbid={1} and Zbprice={2}", sid, zbid, zbprice);
                string s_cmd3 = string.Format("select Zbnum from Takeout where Sid={0} and Zbid={1} and Zbprice={2}", sid, zbid, zbprice);
                int cknum = 0;
                int rknum = 0;
                int i = 0, n = 0;
                int pandiannum = 0;
                cmd.CommandText = s_cmd2;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rknum += int.Parse(reader[0].ToString());
                    i++;
                }
                reader.Close();

                cmd.CommandText = s_cmd3;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cknum += int.Parse(reader[0].ToString());
                    n++;
                }
                reader.Close();

                if (i > 0)
                {
                    if (n > 0)
                    {
                        pandiannum = rknum - cknum;
                    }
                    else
                    {
                        pandiannum = rknum;
                    }
                }
                else
                {
                    pandiannum = 0;
                }

                盘点数量.Text = pandiannum.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }

        private void 盘点仓库名称_SelectionChangeCommitted(object sender, EventArgs e)
        {
            盘点装备名称.Text = "";
            盘点单价.SelectedIndex = -1;
            盘点当前数量.Text = "";
            盘点生产日期.Text = "";
            盘点数量.Text = "";
        }

        //------------------------------赵康强---------------------------------------------

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

                cmd.CommandText = "delete from Outlayln where [Id]='" + 经费入账删除dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";

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
    }
}
		
//------------------------------赵康强---------------------------------------------

  

