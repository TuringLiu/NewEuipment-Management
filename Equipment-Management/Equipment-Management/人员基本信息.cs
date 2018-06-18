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
    public partial class 人员基本信息 : Form
    {
        public 人员基本信息()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mystr.i = 1;
            mystr.str = treeView1.SelectedNode.Text;
            mystr.str2 = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            mystr.data = dataGridView1;
            编辑人员信息 do_ryxx = new 编辑人员信息();
            do_ryxx.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mystr.i = 2;
            mystr.str = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            mystr.str2 = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            mystr.data = dataGridView1;
            编辑人员信息 do_ryxx = new 编辑人员信息();
            do_ryxx.Show();
        }

        private void 人员基本信息_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“equipment_Management_Information_SystemDataSet1.ArmsPerson”中。您可以根据需要移动或删除它。
            this.armsPersonTableAdapter.Fill(this.equipment_Management_Information_SystemDataSet1.ArmsPerson);
            try
            {
                if (DBClass_xu.conn.State != ConnectionState.Open)//检查连接状态是否为已连接
                {
                    DBClass_xu.conn.Open();
                }
                string strda = "select [DepId], [DepName], [UpperId] from Departments";
                SqlDataAdapter da = new SqlDataAdapter(strda, DBClass_xu.conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "Dep");
                for (int i = 0; i < ds.Tables["Dep"].Rows.Count; i++)
                {
                    TreeViewList.id.Add(new List<string>());
                    TreeViewList.name.Add(new List<string>());
                    WriteList(ds.Tables["Dep"].Rows[i]["DepId"].ToString(),
                        ds.Tables["Dep"].Rows[i]["DepName"].ToString(),
                        ds.Tables["Dep"].Rows[i]["UpperId"].ToString(), i);
                    TreeViewList.id[i].Add(ds.Tables["Dep"].Rows[i]["DepId"].ToString());
                    TreeViewList.name[i].Add(ds.Tables["Dep"].Rows[i]["DepName"].ToString());
                }
                for (int i = 0; i < TreeViewList.id.Count; i++)
                {
                    treeView1.SelectedNode = treeView1.TopNode;
                    for (int j = 0; j < TreeViewList.id[i].Count; j++)
                    {
                        if (TreeViewList.id[i][j] == "1" && treeView1.SelectedNode == null)
                        {
                            treeView1.Nodes.Add(TreeViewList.id[i][j], TreeViewList.name[i][j]);
                            treeView1.SelectedNode = treeView1.TopNode;
                        }
                        if (treeView1.Nodes.Find(TreeViewList.id[i][j], true).Length == 0)
                        {
                            treeView1.SelectedNode.Nodes.Add(TreeViewList.id[i][j], TreeViewList.name[i][j]);
                        }
                        treeView1.SelectedNode = treeView1.Nodes.Find(TreeViewList.id[i][j], true)[0];
                    }
                }

                
                DBClass_xu.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + "\n打开数据库失败");
            }
        }
        private void WriteList(string id, string name, string upperid, int count)
        {
            string id1 = "";
            string name1 = "";
            string upperid1 = "";
            if (upperid == "" || upperid == id)
            {
                return;
            }
            string strcmd = "select [UpperId] from Departments where [DepId] = '" + upperid + "'";
            SqlCommand cmd = new SqlCommand(strcmd, DBClass_xu.conn);
            if (cmd.ExecuteScalar() != null)
            {
                upperid1 = cmd.ExecuteScalar().ToString();
                string strda = "select [DepId], [DepName] from Departments " +
                    "where [DepId] = '" + upperid + "'";
                SqlDataAdapter da = new SqlDataAdapter(strda, DBClass_xu.conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "Dep");
                id1 = ds.Tables["Dep"].Rows[0]["DepId"].ToString();
                name1 = ds.Tables["Dep"].Rows[0]["DepName"].ToString();
            }
            WriteList(id1, name1, upperid1, count);
            TreeViewList.id[count].Add(id1);
            TreeViewList.name[count].Add(name1);
            return;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mystr.str = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            mystr.data = dataGridView1;
            编辑部门调转 to_bmdz = new 编辑部门调转();
            to_bmdz.Show();
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
                cmd.CommandText = "delete from ArmsPerson where[RyId]='" + mystr.str + "'";
                cmd.ExecuteNonQuery();
                DataSet dsMyDataBase = new DataSet();
                SqlDataAdapter daBaseInform = new SqlDataAdapter("Select*From ArmsPerson", DBClass_xu.conn);
                daBaseInform.Fill(dsMyDataBase, "ArmsPerson");
                dataGridView1.DataSource = dsMyDataBase.Tables["ArmsPerson"];
                MessageBox.Show("成功删除数据");
                DBClass_xu.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "打开数据库失败");
            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (DBClass_xu.conn.State != ConnectionState.Open)//检查连接状态是否为已连接
                {
                    DBClass_xu.conn.Open();
                }
               
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBClass_xu.conn;

                string strcmd2 = "select DepId from Departments where DepName='" +treeView1.SelectedNode.Text + "'";
                cmd.CommandText = strcmd2;
                int save = int.Parse(cmd.ExecuteScalar().ToString());

                string strcmd = "select Ryid,Ryname,Sex,Birth,Title,Dep_Id from ArmsPerson where Dep_Id='" + save + "'";

                DataSet ds = new DataSet();
                SqlDataAdapter dataAdpt = new SqlDataAdapter(strcmd, DBClass_xu.conn);
                dataAdpt.Fill(ds);

                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();

                for (int i=0;i<ds.Tables[0].Rows.Count;i++)
                {
                    dataGridView1.Rows.Add(ds.Tables[0].Rows[i][0], ds.Tables[0].Rows[i][1], ds.Tables[0].Rows[i][2], ds.Tables[0].Rows[i][3], ds.Tables[0].Rows[i][4], ds.Tables[0].Rows[i][5]);
                }
            

                DBClass_xu.conn.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + " 打开数据库失败");
            }
        }
    }
}
